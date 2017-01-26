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
using TowerDefend.Objects.Monsters;

namespace Common.Objects.Monsters
{
	/// <summary>
	/// Interaction logic for MonsterControl.xaml
	/// </summary>
	public partial class MonsterControl : UserControl
	{
		public MonsterControl()
		{
			InitializeComponent();
		}

		public void SetImage(BitmapSource bs)
		{
			this.imgMain.Source = bs;
		}

		public void ApplyMonster(BaseMonster bm)
		{
			if (bm.Hp <= 0)
				lblHp.Width = 0;
			else
				lblHp.Width = this.Width * bm.Hp / bm.MaxHp;

			if (lblHp.Width < this.Width / 5)
				lblHp.Background = new SolidColorBrush(Colors.Red);
			else if (lblHp.Width < this.Width / 2)
				lblHp.Background = new SolidColorBrush(Colors.Orange);
		}
	}
}
