using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Common.Objects.Others
{
	public class HPDamage : ActiveObject
	{
		private double damage;

		public double Damage
		{
			get { return damage; }
			set { damage = value; }
		}

		private ActiveObject target;

		public ActiveObject Target
		{
			get { return target; }
			set { target = value; }
		}

		public override System.Windows.UIElement CreateUiControl()
		{
			Label l = new Label();
			l.Foreground = new SolidColorBrush(Colors.Red);
			l.Content = string.Format("-{0}", damage);
			return l;
		}

		public override void PlayMovingAnime(double x, double y)
		{
			DoubleAnimation moveX = new DoubleAnimation();
			DoubleAnimation moveY = new DoubleAnimation();
			moveX.Duration = TimeSpan.FromMilliseconds(400);
			moveY.Duration = TimeSpan.FromMilliseconds(400);
			moveX.Completed += moveX_Completed;

			double xAlter = Utility.RandomNum(0, 40);

			moveX.From = x + xAlter;
			moveX.To = x + xAlter;
			moveY.From = y;
			moveY.To = y - 20;
			uiControl.BeginAnimation(Canvas.LeftProperty, moveX);
			uiControl.BeginAnimation(Canvas.TopProperty, moveY);
		}

		private void moveX_Completed(object sender, EventArgs e)
		{
			blockMovingAnime_Completed(this, e);
		}
	}
}
