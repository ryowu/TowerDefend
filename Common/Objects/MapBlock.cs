using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TowerDefend.Objects
{
	public class MapBlock
	{
		private Point pos;

		public Point Pos
		{
			get { return pos; }
			set { pos = value; }
		}
	}
}
