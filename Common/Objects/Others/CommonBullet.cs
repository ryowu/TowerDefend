using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Common.Objects.Others
{
	public class CommonBullet : ActiveObject
	{
		protected ActiveObject target;
		protected double currentDamage;

		public CommonBullet()
		{
			InitBullet();
		}

		public virtual void InitBullet()
		{	
			this.img.BeginInit();
			this.img.UriSource = new Uri("pack://application:,,,/Common;component/Resources/commonbullet.gif");
			this.img.EndInit();

			Image i = (Image)this.UiControl;
			i.Source = this.img;
			i.Width = 10;
			i.Height = 10;
		}

		public override void PlayAttackAnime(double x, double y, double damage, ActiveObject target)
		{
			this.target = target;
			this.currentDamage = damage;

			//Move bullet
			double left = Canvas.GetLeft(uiControl);
			double top = Canvas.GetTop(uiControl);

			DoubleAnimation moveX = new DoubleAnimation();
			DoubleAnimation moveY = new DoubleAnimation();
			moveX.Duration = TimeSpan.FromMilliseconds(200);
			moveY.Duration = TimeSpan.FromMilliseconds(200);
			moveX.Completed += moveX_Completed;
			moveX.From = left + 24;
			moveX.To = x + 24;
			moveY.From = top + 24;
			moveY.To = y + 24;
			uiControl.BeginAnimation(Canvas.LeftProperty, moveX);
			uiControl.BeginAnimation(Canvas.TopProperty, moveY);
		}

		protected void moveX_Completed(object sender, EventArgs e)
		{
			AttackAnime_Completed(this, this.currentDamage, this.target);
		}
	}
}
