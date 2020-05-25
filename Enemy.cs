using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace GalagaEffect
{
    class Enemy
    {
        public int EnX; 
        public int EnY;
        public bool alive = true;
        public bool moving = false;
        public Path defaultPath;
        public bool attack = false;
        public bool halfHP = false;
        public bool death = false;
        int exp = 0;
        int d = 0;
        public string type;
        public Image image;

        public Enemy(Path path)
        {
            var r = new Random();
            defaultPath = path;
            EnX = r.Next(40,350);
            EnY = -160;
        }

        public void Next()
        {
            if (defaultPath.currentStep <= defaultPath.totalSteps)
            {
                Point testPoint = defaultPath.Next();
                EnX = testPoint.X;
                EnY = testPoint.Y;
            }
            
        }
        public void Draw(Graphics g)
        {

            if (death)
            {
                if(exp < 4)
                {
                    image = Properties.Resources.exp;
                    g.DrawImage(image, EnX+30, EnY+30, 60, 60);
                    exp++;
                }
                g.ResetTransform();
            }
            else if (halfHP)
            {
                if (type == "Cerberus")
                {
                    image = Properties.Resources.e3;
                    g.DrawImage(image, EnX, EnY, 120, 120);
                }
                if (type == "ReaperSmall")
                {
                    image = Properties.Resources.e2d;
                    g.DrawImage(image, EnX, EnY, 120, 120);
                }
                if (type == "ReaperBig")
                {
                    image = Properties.Resources.e3d;
                    g.DrawImage(image, EnX, EnY, 160, 150);
                }
                else g.DrawImage(image, EnX, EnY, 120, 120);
            }
            else
            {
                if (type == "ReaperBig")
                {
                    g.DrawImage(image, EnX, EnY, 160, 150);
                }
                else
                    g.DrawImage(image, EnX, EnY, 120, 120);
            }
        }
        public bool HitTest(int x, int y)
        {

            if (Math.Abs(x - EnX) < 120)
            {
                Point[] temp = { new Point(x, y) };
                if (temp[0].X > EnX && temp[0].X < EnX + 120)
                {
                    if (temp[0].Y > EnY && temp[0].Y < EnY + 130)
                    {
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
    }
}
