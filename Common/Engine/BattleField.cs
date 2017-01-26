using Common.Engine;
using Common.Objects.Monsters;
using Common.Objects.Others;
using Common.Objects.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using TowerDefend.Objects.Monsters;

namespace Common.Objects
{
	public class BattleField
	{
		private int money = 0;

		public int Money
		{
			get { return money; }
			set { money = value; }
		}

		private int zindex = 10000;

		private Canvas innerCanvas;

		private DispatcherTimer timerMain = new DispatcherTimer();

		Queue<ActiveObject> activeQueue = new Queue<ActiveObject>();

		List<ActiveObject> activeList = new List<ActiveObject>();

		private List<Point> pathList = new List<Point>();

		public List<Point> PathList
		{
			get { return pathList; }
			set
			{
				pathList = value;
				pathList.ForEach((a) => { invalidLocations.Add(new Point(a.X, a.Y)); });
			}
		}

		private List<Point> invalidLocations = new List<Point>();

		public event OnUIUpdatedHandler OnUIUpdated;

		public void SetCanvas(Canvas c)
		{
			this.innerCanvas = c;
		}

		public BattleField()
		{
			money = 0;

			timerMain.Interval = TimeSpan.FromMilliseconds(10);
			timerMain.Tick += timerMain_Tick;
			timerMain.Start();
		}

		private void timerMain_Tick(object sender, EventArgs e)
		{
			while (activeQueue.Count > 0)
			{
				ActiveObject obj = activeQueue.Dequeue();

				if (obj is BaseMonster)
				{
					#region Monster
					//Play move anime
					BaseMonster m = (BaseMonster)obj;
					if (m.CurrentPathIndex + 1 < pathList.Count)
					{
						m.CurrentPathIndex++;
						Point nextPathNode = pathList[m.CurrentPathIndex];
						m.PlayMovingAnime(Utility.IndexToPosition(nextPathNode.X), Utility.IndexToPosition(nextPathNode.Y));
					}
					else
					{
						//the end of current active object, remove from UI
						innerCanvas.Children.Remove(m.UiControl);
						activeList.Remove(m);
					}
					#endregion
				}
				else if (obj is BaseTower)
				{
					#region Tower
					BaseTower bt = (BaseTower)obj;

					//Try to attack multi enemy if available
					int atkCount = bt.AttackTargetCount;

					//Check if match enemy
					for (int ci = 0; ci < activeList.Count; ci++)
					{
						if (activeList[ci] is BaseMonster)
						{
							BaseMonster a = (BaseMonster)(activeList[ci]);
							double left = Canvas.GetLeft(a.UiControl);
							double top = Canvas.GetTop(a.UiControl);

							double selfLeft = Canvas.GetLeft(bt.UiControl);
							double selfTop = Canvas.GetTop(bt.UiControl);

							double distance = Math.Sqrt(Math.Pow(left - selfLeft, 2) + Math.Pow(top - selfTop, 2));
							//if can attack
							if (distance <= bt.Range)
							{
								//Rotate tower
								double degree = Utility.GetRotateDegree(left, top, selfLeft, selfTop);
								RotateTransform rotateTransform = new RotateTransform(degree);
								rotateTransform.CenterX = 24;
								rotateTransform.CenterY = 24;
								bt.UiControl.RenderTransform = rotateTransform;

								//Create bullet
								CommonBullet bullet = bt.GetBullet();
								Canvas.SetLeft(bullet.UiControl, selfLeft);
								Canvas.SetTop(bullet.UiControl, selfTop);
								innerCanvas.Children.Add(bullet.UiControl);
								Canvas.SetZIndex(bullet.UiControl, 10000);
								bullet.AnimeCompleted += bullet_AnimeCompleted;

								//Damage
								double damage = bt.Atk;

								//Play anime
								bullet.PlayAttackAnime(left, top, damage, a);

								//Attack all
								if (atkCount == -1)
									continue;
								//If still can attack, then attack next enemy
								atkCount--;
								if (atkCount <= 0)
									break;
							}
						}
					}

					//Play idol anime, wait next attack
					bt.PlayIdleAnime();
					#endregion
				}
				else if (obj is HPDamage)
				{
					innerCanvas.Children.Remove(obj.UiControl);
				}
			}
		}

		public void PutMonstersIn(BaseMonster m)
		{
			//Set position to the first path node
			Canvas.SetLeft(m.UiControl, Utility.IndexToPosition(pathList[0].X));
			Canvas.SetTop(m.UiControl, Utility.IndexToPosition(pathList[0].Y));
			innerCanvas.Children.Add(m.UiControl);
			Canvas.SetZIndex(m.UiControl, zindex--);
			if (zindex < 1000) zindex = 10000;
			m.AnimeCompleted += item_AnimeCompleted;
			activeQueue.Enqueue(m);

			activeList.Add(m);
		}

		public void PutTowserIn(BaseTower t)
		{
			innerCanvas.Children.Add(t.UiControl);
			Canvas.SetZIndex(t.UiControl, zindex++);
			t.AnimeCompleted += item_AnimeCompleted;
			activeQueue.Enqueue(t);

			activeList.Add(t);

			double ix = Math.Floor(Canvas.GetLeft(t.UiControl) / 50);
			double iy = Math.Floor(Canvas.GetTop(t.UiControl) / 50);

			invalidLocations.Add(new Point(ix, iy));
		}

		private void item_AnimeCompleted(ActiveObject sender, AnimeCompletedEventArgs e)
		{
			activeQueue.Enqueue(sender);
		}

		private void bullet_AnimeCompleted(ActiveObject sender, AnimeCompletedEventArgs e)
		{
			//Remove bullet
			innerCanvas.Children.Remove(sender.UiControl);

			//Apply damage to target
			e.Target.Hp -= e.Damage;

			//apply hp label
			((MonsterControl)(e.Target.UiControl)).ApplyMonster((BaseMonster)(e.Target));

			//Play damage hp anime
			PlayDamageHpAnime(e.Target, e.Damage);

			if (e.Target.Hp <= 0)
			{
				innerCanvas.Children.Remove(e.Target.UiControl);
				//to do, see if can remove from queue
				activeList.Remove(e.Target);

				//earn money
				money += ((BaseMonster)(e.Target)).CarryMoney;

				if (OnUIUpdated != null)
					OnUIUpdated();
			}
		}

		private void PlayDamageHpAnime(ActiveObject target, double damage)
		{
			HPDamage hd = new HPDamage() { Damage = damage, Target = target };
			hd.AnimeCompleted += item_AnimeCompleted;
			innerCanvas.Children.Add(hd.UiControl);
			Canvas.SetZIndex(hd.UiControl, 100 + zindex++);
			hd.PlayMovingAnime(Canvas.GetLeft(target.UiControl), Canvas.GetTop(target.UiControl));
		}

		public bool IsValidLocation(Point p)
		{
			return !invalidLocations.Exists((i) => { return i.X == p.X && i.Y == p.Y; });
		}
	}
}
