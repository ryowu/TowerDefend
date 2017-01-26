using Common.Objects.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Common.Objects.Monsters
{
	public class BaseMonster : ActiveObject
	{
		protected int speed;

		public int Speed
		{
			get { return speed; }
			set { speed = value; }
		}

		private int currentPathIndex;

		public int CurrentPathIndex
		{
			get { return currentPathIndex; }
			set { currentPathIndex = value; }
		}

		protected int carryMoney = 0;

		public int CarryMoney
		{
			get { return carryMoney; }
			set { carryMoney = value; }
		}

		public override UIElement CreateUiControl()
		{
			return new MonsterControl();
		}

		public override void PlayMovingAnime(double x, double y)
		{
			//Move
			double left = Canvas.GetLeft(uiControl);
			double top = Canvas.GetTop(uiControl);

			DoubleAnimation moveX = new DoubleAnimation();
			DoubleAnimation moveY = new DoubleAnimation();
			moveX.Duration = TimeSpan.FromMilliseconds(1000);
			moveY.Duration = TimeSpan.FromMilliseconds(1000);
			moveX.Completed += moveX_Completed;
			moveX.From = left;
			moveX.To = x;
			moveY.From = top;
			moveY.To = y;
			uiControl.BeginAnimation(Canvas.LeftProperty, moveX);
			uiControl.BeginAnimation(Canvas.TopProperty, moveY);
		}

		private void moveX_Completed(object sender, EventArgs e)
		{
			blockMovingAnime_Completed(this, e);
		}
	}
}
