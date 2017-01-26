using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TowerDefend.FunctionManagers;

namespace Common
{
	/// <summary>
	/// Interaction logic for ImageTextControl.xaml
	/// </summary>
	public partial class ImageTextControl : UserControl
	{
		private List<Image> currentImages = new List<Image>();

		private string text;

		public string Text
		{
			get { return text; }
			set
			{
				text = value;
				RenderText();
			}
		}

		private bool redraw = true;

		public bool Redraw
		{
			get { return redraw; }
			set { redraw = value; }
		}

		public ImageTextControl()
		{
			InitializeComponent();
		}

		public void InitializeTextLength(int len)
		{
			redraw = true;
			text = new string('{', len);
			RenderText();
		}

		private void RenderText()
		{
			if (redraw)
			{
				canvasMain.Children.Clear();
				currentImages.Clear();
			}
			for (int i = 0; i < text.Length; i++)
			{
				if (redraw)
				{
					Image ic = new Image();
					ic.Width = 31;
					ic.Height = 43;
					ic.Stretch = Stretch.Fill;
					ic.StretchDirection = StretchDirection.DownOnly;
					Canvas.SetLeft(ic, 31 * i);
					Canvas.SetTop(ic, 0);
					ic.Source = ImageManager.Instance.GetTextImage(text[i]);
					canvasMain.Children.Add(ic);
					currentImages.Add(ic);
				}
				else
				{
 					currentImages[i].Source = ImageManager.Instance.GetTextImage(text[i]);
				}
			}
		}
	}
}
