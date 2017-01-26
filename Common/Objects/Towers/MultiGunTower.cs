using Common.Engine;
using Common.Objects.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TowerDefend.FunctionManagers;

namespace Common.Objects.Towers
{
	public class MultiGunTower : BaseTower
	{
		public MultiGunTower()
		{
			this.atk = 3;
			this.attackSpeed = 600;
			this.attackTargetCount = 3;
			this.range = 141;

			Image i = (Image)this.UiControl;
			i.Source = ImageManager.Instance.GetTowerImage(TowerNodeType.MultiGun);
			i.Width = 48;
			i.Height = 48;
		}

		public override Others.CommonBullet GetBullet()
		{
			return new StarBullet();
		}
	}
}
