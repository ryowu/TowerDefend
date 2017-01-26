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
	public class SunshineTower : BaseTower
	{
		public SunshineTower()
		{
			this.atk = 2;
			this.attackSpeed = 800;
			this.attackTargetCount = -1; //Attack all enemy
			this.range = 141;

			Image i = (Image)this.UiControl;
			i.Source = ImageManager.Instance.GetTowerImage(TowerNodeType.Sunshine);
			i.Width = 48;
			i.Height = 48;
		}

		public override Others.CommonBullet GetBullet()
		{
			return new SunshineBullet();
		}
	}
}
