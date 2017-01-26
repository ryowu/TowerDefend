using Common.Objects.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TowerDefend.FunctionManagers;

namespace Common.Objects
{
	public class MachineGunTower : BaseTower
	{
		public MachineGunTower()
		{
			this.atk = 2;
			this.attackSpeed = 300;
			this.range = 70;

			Image i = (Image)this.UiControl;
			i.Source = ImageManager.Instance.GetTowerImage(Engine.TowerNodeType.MachineGun);
			i.Width = 48;
			i.Height = 48;
		}
	}
}
