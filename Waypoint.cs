using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GalagaEffect
{
    class Waypoint
    {
        public string Type;
        public Point Start; 
        public Point End;
        private double LinearDistance; 
        public double Steps; 

        public Waypoint(int x1, int y1, int x2, int y2)
        {
            Type = "Line";
            Start = new Point(x1, y1);
            End = new Point(x2, y2);

            LinearDistance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Steps = LinearDistance / 3;
        }

        public Waypoint(Waypoint lastPoint, int x2, int y2) 
        {
            Type = "Line";
            Start = new Point(lastPoint.End.X, lastPoint.End.Y);
            End = new Point(x2, y2);

            LinearDistance = Math.Sqrt(Math.Pow(x2 - Start.X, 2) + Math.Pow(y2 - Start.Y, 2));
            Steps = LinearDistance / 3; 
        }
    }
}
