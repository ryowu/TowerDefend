using Common.Engine;
using Common.Objects.Monsters;
using TowerDefend.FunctionManagers;

namespace TowerDefend.Objects.Monsters
{
	public class Slime : BaseMonster
	{
		public Slime()
		{
			this.hp = 15;
			this.maxHp = 15;
			this.speed = 2;
			this.carryMoney = 3;

			MonsterControl i = (MonsterControl)this.UiControl;
			i.SetImage(ImageManager.Instance.GetMonsterNode(MonsterNodeType.Scop));
			i.Width = 48;
			i.Height = 48;
		}

	}
}
