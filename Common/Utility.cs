using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Common
{
	public class Utility
	{
		public static double IndexToPosition(double index)
		{
			return 2 + index * (48 + 2);
		}

		public System.Windows.Point GetCenter(UIElement e)
		{
			double left = Canvas.GetLeft(e);
			double top = Canvas.GetTop(e);

			return new Point(left + 24, top + 24);
		}

		public static int RandomNum(int min, int max)
		{
			Random r = new Random(DateTime.Now.GetHashCode());
			return r.Next(min, max);
		}

		public static double RadianToDegree(double angle)
		{
			return angle * (180.0 / Math.PI);
		}

		public static double GetRotateDegree(double x1, double y1, double x2, double y2)
		{
			double angle = 0;
			double degree = 0;
			if (x1 < x2 && y1 < y2)
			{
				angle = Math.Tanh(Math.Abs(x1 - x2) / Math.Abs(y1 - y2));
				degree = 360 - Utility.RadianToDegree(angle);
			}
			else if (x1 > x2 && y1 < y2)
			{
				angle = Math.Tanh(Math.Abs(x1 - x2) / Math.Abs(y1 - y2));
				degree = Utility.RadianToDegree(angle);
			}
			else if (x1 < x2 && y1 > y2)
			{
				angle = Math.Tanh(Math.Abs(x1 - x2) / Math.Abs(y1 - y2));
				degree = 180 + Utility.RadianToDegree(angle);
			}
			else if (x1 > x2 && y1 > y2)
			{
				angle = Math.Tanh(Math.Abs(x1 - x2) / Math.Abs(y1 - y2));
				degree = 180 - Utility.RadianToDegree(angle);
			}

			//double x = Math.Abs(x1 - x2);
			//double y = Math.Abs(y1 - y2);
			//double z = Math.Sqrt(x * x + y * y);
			//double degree = Math.Asin(y / z) / Math.PI * 180;


			return degree;
		}
	}
}
