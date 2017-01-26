using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefend.Engine
{
	public class Map
	{
		private List<MapNode> nodes = new List<MapNode>();

		public List<MapNode> Nodes
		{
			get { return nodes; }
			set { nodes = value; }
		}
	}
}
