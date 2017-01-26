using Common.Objects.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using TowerDefend.Objects;

namespace Common.Objects.Towers
{
	public class BaseTower : ActiveObject
	{
		protected double atk;

		public double Atk
		{
			get { return atk; }
			set { atk = value; }
		}

		protected double attackSpeed;

		public double AttackSpeed
		{
			get { return attackSpeed; }
			set { attackSpeed = value; }
		}

		protected int attackTargetCount = 1;

		public int AttackTargetCount
		{
			get { return attackTargetCount; }
			set { attackTargetCount = value; }
		}

		protected double range;

		public double Range
		{
			get { return range; }
			set { range = value; }
		}

		public void PlayIdleAnime()
		{
			DoubleAnimation d = new DoubleAnimation();
			d.Duration = TimeSpan.FromMilliseconds(this.attackSpeed);
			d.From = Canvas.GetLeft(this.uiControl);
			d.To = Canvas.GetLeft(this.uiControl);
			d.Completed += d_Completed;
			uiControl.BeginAnimation(Canvas.LeftProperty, d);
		}

		public virtual CommonBullet GetBullet()
		{
			return new CommonBullet();
		}

		private void d_Completed(object sender, EventArgs e)
		{
			blockMovingAnime_Completed(this, e);
		}
	}
}
