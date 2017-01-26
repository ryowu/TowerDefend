using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Engine
{
	public enum MapNodeType
	{

		BracketLeftTop = 1,
		BracketTop = 2,
		BracketRightTop = 3,
		Sign = 4,
		Flower = 16,
		BracketLeft = 62,
		BracketRight = 64,
		BracketLeftBottom = 123,
		BracketBottom = 124,
		BracketRightBottom = 125,
		Grass = 186,
		LadderFromHole = 385,
		Mud = 510
	}

	public enum MonsterNodeType
	{
		Scop = 1,
		Flame = 4,
		Zombi = 7
	}

	public enum TowerNodeType
	{
 		MachineGun = 1,
		MultiGun = 3,
		Missle = 10,
		Sunshine = 12
	}

	public enum ImageNames
	{
 		StarBullet,
		SunshineBullet,
		Coin,
		RedX
	}
}
