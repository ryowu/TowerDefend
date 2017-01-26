using Common.Engine;
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
using TowerDefend.Engine;
using TowerDefend.FunctionManagers;

namespace MapViewer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		int col = 0;
		int row = 0;

		public MainWindow()
		{
			InitializeComponent();
			imgNode.Source = ImageManager.Instance.GetMapNode((MapNodeType)(0));
		}

		private void mainForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Up)
			{
				if (row - 1 >= 0)
					row--;

			}
			else if (e.Key == Key.Down)
			{
				if (row + 1 < 28)
					row++;
			}
			else if (e.Key == Key.Left)
			{
				if (col - 1 >= 0)
					col--;
			}
			if (e.Key == Key.Right)
			{
				if (col + 1 < 61)
					col++;

			}

			imgNode.Source = ImageManager.Instance.GetMapNode((MapNodeType)(row * 61 + col));

			txtCol.Text = col.ToString();
			txtRow.Text = row.ToString();

			mainForm.Title = (row * 61 + col).ToString();
		}


		double degree = 0;
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			//double angle = Math.Tanh(Math.Abs(left - selfLeft) / Math.Abs(top - selfTop));
			//double degree = ((left > selfLeft) ? 1 : -1) * Utility.RadianToDegree(angle);
			degree++;
			RotateTransform rotateTransform = new RotateTransform(degree);
			rotateTransform.CenterX = imgNode.Width / 2;
			rotateTransform.CenterY = imgNode.Height / 2;
			imgNode.RenderTransform = rotateTransform;
		}
	}
}
