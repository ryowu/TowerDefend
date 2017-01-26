using Common.Objects.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TowerDefend.FunctionManagers;

namespace Common.Objects.Towers
{
	public class MissleTower : BaseTower
	{
		public MissleTower()
		{
			this.atk = 5;
			this.attackSpeed = 700;
			this.range = 200;

			Image i = (Image)this.UiControl;
			i.Source = ImageManager.Instance.GetTowerImage(Engine.TowerNodeType.Missle);
			i.Width = 48;
			i.Height = 48;
		}
	}
}
