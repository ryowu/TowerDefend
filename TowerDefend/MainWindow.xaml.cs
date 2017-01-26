using Common.Engine;
using Common.Objects;
using Common.Objects.Monsters;
using Common.Objects.Towers;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TowerDefend.Engine;
using TowerDefend.FunctionManagers;
using TowerDefend.Objects.Monsters;

namespace TowerDefend
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		BattleField bf = new BattleField();

		BaseTower newTower = null;
		ImageSource newImageSource = null;

		public MainWindow()
		{
			InitializeComponent();
			bf.SetCanvas(this.canvasMain);
			bf.OnUIUpdated += bf_OnUIUpdated;

			imgMouse.Visibility = System.Windows.Visibility.Hidden;
			imgCoin.Source = ImageManager.Instance.GetImageByName(ImageNames.Coin);

			Canvas.SetZIndex(lblScoreLabel, 10000);
			Canvas.SetZIndex(lblScoreNumber, 10001);

			lblMoney.InitializeTextLength(5);
			lblMoney.Redraw = false;
		}

		private void bf_OnUIUpdated()
		{
			//Update money text
			lblMoney.Text = bf.Money.ToString();
		}

		private void InitMap()
		{
			//bf_OnUIUpdated()
			bf_OnUIUpdated();

			//Add Path list
			List<Point> pathList = new List<Point>();
			pathList.Clear();
			pathList.Add(new Point(0, 2));
			pathList.Add(new Point(1, 2));
			pathList.Add(new Point(2, 2));
			pathList.Add(new Point(2, 3));
			pathList.Add(new Point(2, 4));
			pathList.Add(new Point(2, 5));
			pathList.Add(new Point(3, 5));
			pathList.Add(new Point(4, 5));
			pathList.Add(new Point(5, 5));
			pathList.Add(new Point(6, 5));
			pathList.Add(new Point(6, 4));
			pathList.Add(new Point(6, 3));
			pathList.Add(new Point(6, 2));

			pathList.Add(new Point(7, 2));
			pathList.Add(new Point(8, 2));
			pathList.Add(new Point(9, 2));
			pathList.Add(new Point(10, 2));
			pathList.Add(new Point(10, 3));
			pathList.Add(new Point(10, 4));
			pathList.Add(new Point(10, 5));
			pathList.Add(new Point(10, 6));
			pathList.Add(new Point(10, 7));
			pathList.Add(new Point(10, 8));
			//pathList.Add(new Point(10, 9));
			//pathList.Add(new Point(11, 10));
			bf.PathList = pathList;

			//Create test Map
			Map m = new Map();


			//m.Nodes.Add(new MapNode() { NodeType = MapNodeType.BracketLeftTop, Pos = new Point(0, 0) });
			//m.Nodes.Add(new MapNode() { NodeType = MapNodeType.BracketRightTop, Pos = new Point(15, 0) });
			//m.Nodes.Add(new MapNode() { NodeType = MapNodeType.BracketLeftBottom, Pos = new Point(0, 9) });
			//m.Nodes.Add(new MapNode() { NodeType = MapNodeType.BracketRightBottom, Pos = new Point(15, 9) });

			//for (int i = 1; i < 15; i++)
			//{
			//	m.Nodes.Add(new MapNode() { NodeType = MapNodeType.BracketTop, Pos = new Point(i, 0) });
			//	m.Nodes.Add(new MapNode() { NodeType = MapNodeType.BracketBottom, Pos = new Point(i, 9) });
			//}

			//for (int j = 1; j < 9; j++)
			//{
			//	m.Nodes.Add(new MapNode() { NodeType = MapNodeType.BracketLeft, Pos = new Point(0, j) });
			//	m.Nodes.Add(new MapNode() { NodeType = MapNodeType.BracketRight, Pos = new Point(15, j) });
			//}

			m.Nodes.Add(new MapNode() { NodeType = MapNodeType.Grass, Pos = new Point(0, 0) });
			m.Nodes.Add(new MapNode() { NodeType = MapNodeType.Grass, Pos = new Point(15, 0) });
			m.Nodes.Add(new MapNode() { NodeType = MapNodeType.Grass, Pos = new Point(0, 9) });
			m.Nodes.Add(new MapNode() { NodeType = MapNodeType.Grass, Pos = new Point(15, 9) });

			for (int i = 1; i < 15; i++)
			{
				m.Nodes.Add(new MapNode() { NodeType = MapNodeType.Grass, Pos = new Point(i, 0) });
				m.Nodes.Add(new MapNode() { NodeType = MapNodeType.Grass, Pos = new Point(i, 9) });
			}

			for (int j = 1; j < 9; j++)
			{
				m.Nodes.Add(new MapNode() { NodeType = MapNodeType.Grass, Pos = new Point(0, j) });
				m.Nodes.Add(new MapNode() { NodeType = MapNodeType.Grass, Pos = new Point(15, j) });
			}


			for (int j = 1; j < 9; j++)
			{
				for (int i = 1; i < 15; i++)
				{
					m.Nodes.Add(new MapNode() { NodeType = MapNodeType.Grass, Pos = new Point(i, j) });
				}
			}

			m.Nodes[34].NodeType = MapNodeType.Mud;
			m.Nodes[62].NodeType = MapNodeType.Mud;
			m.Nodes[63].NodeType = MapNodeType.Mud;
			m.Nodes[77].NodeType = MapNodeType.Mud;
			m.Nodes[91].NodeType = MapNodeType.Mud;
			m.Nodes[105].NodeType = MapNodeType.Mud;
			m.Nodes[106].NodeType = MapNodeType.Mud;
			m.Nodes[107].NodeType = MapNodeType.Mud;
			m.Nodes[108].NodeType = MapNodeType.Mud;
			m.Nodes[109].NodeType = MapNodeType.Mud;
			m.Nodes[95].NodeType = MapNodeType.Mud;
			m.Nodes[81].NodeType = MapNodeType.Mud;
			m.Nodes[67].NodeType = MapNodeType.Mud;
			m.Nodes[68].NodeType = MapNodeType.Mud;
			m.Nodes[69].NodeType = MapNodeType.Mud;
			m.Nodes[70].NodeType = MapNodeType.Mud;
			m.Nodes[71].NodeType = MapNodeType.Mud;
			m.Nodes[85].NodeType = MapNodeType.Mud;
			m.Nodes[99].NodeType = MapNodeType.Mud;
			m.Nodes[113].NodeType = MapNodeType.Mud;
			m.Nodes[127].NodeType = MapNodeType.Mud;
			m.Nodes[141].NodeType = MapNodeType.Mud;
			m.Nodes[155].NodeType = MapNodeType.Sign;


			m.Nodes[2].NodeType = MapNodeType.Flower;
			m.Nodes[123].NodeType = MapNodeType.Flower;

			//Save test map to local
			//string test = SerializationManager.Serialize(m);
			//StreamWriter sw = new StreamWriter(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "map1.xml"));
			//sw.Write(test);
			//sw.Close();

			//Draw map
			int zi = 1;
			m.Nodes.ForEach((n) =>
			{
				Image im = new Image();
				im.Width = 50;
				im.Height = 50;
				im.Source = ImageManager.Instance.GetMapNode(n.NodeType);
				Canvas.SetLeft(im, (double)(n.Pos.X * 50));
				Canvas.SetTop(im, (double)(n.Pos.Y * 50));
				canvasMain.Children.Add(im);
				Canvas.SetZIndex(im, zi++);
			});
		}

		private void InitTowerBox()
		{
			imgSmallGunTower.Source = ImageManager.Instance.GetTowerImage(TowerNodeType.MachineGun);
			imgMissleTower.Source = ImageManager.Instance.GetTowerImage(TowerNodeType.Missle);
			imgMultiGunTower.Source = ImageManager.Instance.GetTowerImage(TowerNodeType.MultiGun);
			imgSunshineTower.Source = ImageManager.Instance.GetTowerImage(TowerNodeType.Sunshine);
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Slime s = new Slime();
			bf.PutMonstersIn(s);
		}

		private void ButtonAddFlame_Click(object sender, RoutedEventArgs e)
		{
			Flame s = new Flame();
			bf.PutMonstersIn(s);
		}

		private void canvasMain_MouseMove(object sender, MouseEventArgs e)
		{
			if (imgMouse.Visibility == System.Windows.Visibility.Visible)
			{
				Canvas.SetZIndex(imgMouse, 9999);
				System.Windows.Point p = e.GetPosition(this);

				double ix = Math.Floor(p.X / 50);
				double iy = Math.Floor(p.Y / 50);

				Canvas.SetLeft(imgMouse, ix * 50);
				Canvas.SetTop(imgMouse, iy * 50);

				if (bf.IsValidLocation(new Point(ix, iy)))
				{
					imgMouse.Source = newImageSource;
					imgMouse.Tag = "ValidLocation";
				}
				else
				{
					imgMouse.Source = ImageManager.Instance.GetImageByName(ImageNames.RedX);
					imgMouse.Tag = "NotValid";
				}
			}
		}

		private void canvasMain_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.RightButton == MouseButtonState.Pressed)
			{
				CancelTowerSelect();
			}
			else if (e.LeftButton == MouseButtonState.Pressed)
			{
				if (imgMouse.Visibility == System.Windows.Visibility.Visible &&
					imgMouse.Tag.ToString() == "ValidLocation")
				{
					//Set tower
					Canvas.SetLeft(newTower.UiControl, Canvas.GetLeft(imgMouse));
					Canvas.SetTop(newTower.UiControl, Canvas.GetTop(imgMouse));
					bf.PutTowserIn(newTower);

					CancelTowerSelect();
				}
			}
		}

		private void CancelTowerSelect()
		{
			imgMouse.Visibility = System.Windows.Visibility.Hidden;
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			InitMap();
			InitTowerBox();
		}

		#region Select Tower Buttons
		private void imgSmallGunTower_MouseDown(object sender, MouseButtonEventArgs e)
		{
			newTower = new MachineGunTower();
			newImageSource = imgSmallGunTower.Source;
			imgMouse.Visibility = System.Windows.Visibility.Visible;
		}

		private void imgMissleTower_MouseDown(object sender, MouseButtonEventArgs e)
		{
			newTower = new MissleTower();
			newImageSource = imgMissleTower.Source;
			imgMouse.Visibility = System.Windows.Visibility.Visible;
		}

		private void imgMultiGunTower_MouseDown(object sender, MouseButtonEventArgs e)
		{
			newTower = new MultiGunTower();
			newImageSource = imgMultiGunTower.Source;
			imgMouse.Visibility = System.Windows.Visibility.Visible;
		}

		private void imgSunshineTower_MouseDown(object sender, MouseButtonEventArgs e)
		{
			newTower = new SunshineTower();
			newImageSource = imgSunshineTower.Source;
			imgMouse.Visibility = System.Windows.Visibility.Visible;
		}
		#endregion
	}
}
