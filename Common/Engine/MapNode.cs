using Common.Engine;
using System.Windows;

namespace TowerDefend.Engine
{
	public class MapNode
	{
		private Point pos;

		public Point Pos
		{
			get { return pos; }
			set { pos = value; }
		}

		private MapNodeType nodeType;

		public MapNodeType NodeType
		{
			get { return nodeType; }
			set { nodeType = value; }
		}
	}
}
