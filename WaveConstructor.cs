using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalagaEffect
{
    class WaveConstructor : Path 
    {
        public WaveConstructor(int ObjectID)
        {
            if (ObjectID < 10)
            {
                Waypoint line1, line2;
                line1 = new Waypoint(300,-40 ,15 + (ObjectID * 80), 150);
                line2 = new Waypoint(275, -40, (ObjectID * 70) - 310, 50);

                if (ObjectID < 6)
                {
                    AddWaypoint(line1);
                }
                else
                {
                    AddWaypoint(line2);
                }
            }
            if (ObjectID >= 10 && ObjectID < 27)
            {
                Waypoint line1, line2;
                line1 = new Waypoint(275, -40, (ObjectID * 45) - 310, 50);
                
                int x1, y1, x2, y2;
                if (ObjectID % 2 == 0)
                {
                    x2 = (int)(50 * Math.Floor((double)ObjectID / -2) + 705);
                    y1 = 180;
                    y2 = 180;
                    x1 = -10;
                }
                else
                { 
                    x2 = (int)(50 * Math.Floor((double)ObjectID / 2) - 240);
                    y1 = 270;
                    y2 = 270;
                    x1 = 570;
                }              
                line2 = new Waypoint(x1, y1, x2, y2);

                if (ObjectID < 13)
                {
                    AddWaypoint(line1);
                }
                else
                {
                    AddWaypoint(line2);
                }
            }
            if (ObjectID >= 27 && ObjectID < 43)
            {
                Waypoint line1;
                int x1, y1, x2, y2;
                if (ObjectID < 34)
                {
                    x2 = (int)(Math.Floor((double)ObjectID * 45)-1150);
                    y1 = -140;
                    y2 = 40;
                    x1 = 195;
                }
                else
                {
                    x2 = (int)(Math.Floor((double)ObjectID * 45) - 1400);
                    y1 = 200;
                    y2 = 200;
                    x1 = 570;
                }
                line1 = new Waypoint(x1, y1, x2, y2);
                AddWaypoint(line1);
            }
        }
        Random r = new Random();
        public WaveConstructor(int initX, int initY)
        {
            Waypoint temp;
            temp = new Waypoint(initX, initY, 200, 1100);
            AddWaypoint(temp);
        }
    }
}
