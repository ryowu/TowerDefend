using Common.Engine;
using TowerDefend.FunctionManagers;

namespace Common.Objects.Monsters
{
	public class Flame : BaseMonster
	{
		public Flame()
		{
			this.hp = 20;
			this.maxHp = 20;
			this.speed = 2;
			this.carryMoney = 8;

			MonsterControl i = (MonsterControl)this.UiControl;
			i.SetImage(ImageManager.Instance.GetMonsterNode(MonsterNodeType.Flame));
			i.Width = 48;
			i.Height = 48;
		}
	}
}
