using Common.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using TowerDefend.FunctionManagers;

namespace Common.Objects.Others
{
	public class SunshineBullet : CommonBullet
	{
		public override void InitBullet()
		{
			Image i = (Image)this.UiControl;
			i.Source = ImageManager.Instance.GetImageByName(ImageNames.SunshineBullet);
			i.Width = 20;
			i.Height = 20;
		}

		public override void PlayAttackAnime(double x, double y, double damage, ActiveObject target)
		{
			this.target = target;
			this.currentDamage = damage;

			//Move bullet
			double left = Canvas.GetLeft(uiControl);
			double top = Canvas.GetTop(uiControl);

			Canvas.SetLeft(uiControl, left + 14);
			Canvas.SetTop(uiControl, top + 14);

			ScaleTransform st = new ScaleTransform();
			st.CenterX = 10;
			st.CenterY = 10;
			uiControl.RenderTransform = st;

			var scale_x = new DoubleAnimation()
			{
				From = 1,
				To = 10,
				Duration = TimeSpan.FromMilliseconds(500),
			};

			var scale_y = new DoubleAnimation()
			{
				From = 1,
				To = 10,
				Duration = TimeSpan.FromMilliseconds(500),
			};
			
			scale_x.Completed += moveX_Completed;
			
			st.BeginAnimation(ScaleTransform.ScaleXProperty, scale_x);
			st.BeginAnimation(ScaleTransform.ScaleYProperty, scale_y);
		}
	}
}
