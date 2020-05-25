using System.Drawing;

namespace GalagaEffect
{
    class Bullet
    {   
        readonly Image image = Properties.Resources.bullets;
        readonly Player parentPlayer;
        public int locX = -100;
        public int locY = -100;
        public bool fired = false;

        public Bullet(Player p)
        {
            parentPlayer = p;
        }

        public void Update()
        {
            if(!fired)
            {
                locX = -200;
                locY = -100;
            }
            else
            {
                locY -= 20;
                if(locY < 10)
                {
                    fired = false;
                }
            }
            parentPlayer.HitTest(locX, locY, this);
            
        }

        public void Draw(Graphics g)
        {
            g.ResetTransform();
            g.DrawImage(image, locX, locY, 50, 150);
        }

        public void Shoot(int x, int y)
        {
            locX = x + 35;
            locY = y - 40;
            fired = true;
        }

        public void Reset()
        {
            fired = false;
            locX = -200;
            locY = -100;
        }

    }
}
