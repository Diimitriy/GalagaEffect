using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GalagaEffect
{
    class Path
    {
        public Enemy parentEnemy;
        private Waypoint[] Waypoints = new Waypoint[0];
        private int[] StepArray = new int[0];
        private int currentIndex = 0;
        public int currentStep = 0;
        private int localStep = 0;
        public bool finished = false;
        public int totalSteps = 0;

        public void AddWaypoint(Waypoint waypoint)
        {
            Array.Resize(ref Waypoints, Waypoints.Length + 1);
            Array.Resize(ref StepArray, StepArray.Length + 1);

            totalSteps += Convert.ToInt32(Math.Floor(waypoint.Steps));
            Waypoints[Waypoints.Length - 1] = waypoint;
            StepArray[StepArray.Length - 1] = totalSteps;
        }

        public Point Next()
        {
            if (currentStep == StepArray[currentIndex])
            {

                if (currentIndex != StepArray.Length - 1)
                {
                    currentIndex += 1;
                    localStep = 0;
                }
            }

            if (currentStep + 1 == totalSteps)
            {
                parentEnemy.attack = false;
            }

            Waypoint temp = Waypoints[currentIndex];

            currentStep += 1;
            localStep += 1;

            if (currentStep == totalSteps + 1)
            {
                finished = true;
                return temp.End;
            }

            if (temp.Type == "Line")
            {
                int tempX = Convert.ToInt32(temp.Start.X + (temp.End.X - temp.Start.X) * localStep / temp.Steps);
                int tempY = Convert.ToInt32(temp.Start.Y + (temp.End.Y - temp.Start.Y) * localStep / temp.Steps);

                return new Point(tempX, tempY);
            }
            else
            {
                return new Point(0, 0);
            }

        }
    }
}
