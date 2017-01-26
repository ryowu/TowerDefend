using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Common.Objects
{
	public class ActiveObject
	{
		protected double hp;

		public double Hp
		{
			get { return hp; }
			set { hp = value; }
		}

		protected double maxHp;

		public double MaxHp
		{
			get { return maxHp; }
			set { maxHp = value; }
		}

		protected BitmapImage img = new BitmapImage();

		public BitmapImage Img
		{
			get { return img; }
			set { img = value; }
		}

		protected UIElement uiControl;

		public UIElement UiControl
		{
			get
			{
				if (uiControl == null)
				{
					uiControl = CreateUiControl();
				}
				return uiControl;
			}
			set { uiControl = value; }
		}

		public delegate void AnimeCompletedHandler(ActiveObject sender, AnimeCompletedEventArgs e);
		public event AnimeCompletedHandler AnimeCompleted;

		public ActiveObject()
		{

		}

		public virtual UIElement CreateUiControl()
		{
			return new System.Windows.Controls.Image();
		}

		public virtual void PlayMovingAnime(double x, double y)
		{
		}

		public virtual void PlayAttackAnime(double x, double y, double damage, ActiveObject target)
		{
		}

		protected void blockMovingAnime_Completed(object sender, EventArgs e)
		{
			if (AnimeCompleted != null)
				AnimeCompleted((ActiveObject)sender, null);
		}

		protected void AttackAnime_Completed(object sender, double damage, ActiveObject target)
		{
			if (AnimeCompleted != null)
				AnimeCompleted((ActiveObject)sender, new AnimeCompletedEventArgs() { Damage = damage, Target = target });
		}
	}

	public class AnimeCompletedEventArgs
	{
		public double Damage { get; set; }
		public ActiveObject Target { get; set; }
	}
}
