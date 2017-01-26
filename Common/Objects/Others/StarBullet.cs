using Common.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TowerDefend.FunctionManagers;

namespace Common.Objects.Others
{
	public class StarBullet : CommonBullet
	{
		public override void InitBullet()
		{
			Image i = (Image)this.UiControl;
			i.Source = ImageManager.Instance.GetImageByName(ImageNames.StarBullet);
			i.Width = 10;
			i.Height = 10;
		}
	}
}
