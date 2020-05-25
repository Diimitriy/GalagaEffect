using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GalagaEffect
{
    class Player
    {
        public Image img = Properties.Resources.pplayer;
        public Wave currentWave;
        public int Y = 900;
        public int X = 215;
        public Bullet bullet1;
        public GameCostructor gameManager;
        bool playerDeath = false;
        int exp = 0;

        public Player(Wave wave,GameCostructor GM)
        {
            currentWave = wave;
            bullet1 = new Bullet(this);
            gameManager = GM;
        }

        public void Draw(Graphics g)
        {
            if (playerDeath)
            {
                if (exp < 4)
                {
                    img = Properties.Resources.exp;
                    g.DrawImage(img, X + 30, Y + 30, 60, 60);
                    exp++;
                }
                else if (exp == 4)
                {
                    exp = 0;
                    img = Properties.Resources.pplayer;
                    playerDeath = false;
                    X = 215;
                    Y = 900;
                    gameManager.gameState = "GameOver";
                }
                g.ResetTransform();
            }
            else
            {
                g.ResetTransform();
                bullet1.Draw(g);
                g.DrawImage(img, X, Y, 120, 120);
                if (Y >= 670)
                    g.DrawImage(img, X, Y -= 3, 120, 120);
            }
        }
         
        public void Update(bool left, bool right, bool up, bool down)
        {
            if(left && !right && X >= -25)
            {
                GC.GetTotalMemory(true);
                X -= 3;
            }
            else if(!left && right && X <= 440)
            {
                X += 3;
            }
            else if (!down && up && Y <= 670)
            {
                Y += 3;
            }
            else if (down && !up && Y >= 550)
            {
                Y -= 3;
            }

            bullet1.Update();       
            
            if(playerHitTest(X, Y))
            {
                playerDeath = true;
            }
        }

        public void Shoot()
        {
            if(!bullet1.fired)
            {
                bullet1.Shoot(X, Y);
            }
        }
        public void HitTest(int x, int y, Bullet bullet)
        {
            if (currentWave.CheckCollision(x, y))
            {
                bullet.Reset();
            }
        }
        public bool playerHitTest(int x, int y)
        {
            if (currentWave.CheckCollision(x+8, y) || currentWave.CheckCollision(x+8, y))
            {
                return true;
            }
            if (currentWave.CheckCollision(x, y + 16) || currentWave.CheckCollision(x, y + 16))
            {
                return true;
            }
            return false;
        }
    }
}
