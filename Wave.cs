using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GalagaEffect
{
    class Wave
    {
        int tick = 0;
        int wave = 1;       
        int movecount = 0;
        int killCount = 0;
        Random r = new Random();
        GameCostructor gameManager;
        public Enemy[] enemiesArray = new Enemy[0];
        public bool visible = true;       

        public Wave(GameCostructor GM)
        {
            gameManager = GM;

            for (int i = 0; i < 40; i++)
            {
                Array.Resize(ref enemiesArray, enemiesArray.Length + 1);
                Enemy temp;
                if (i < 6)
                {
                    temp = new Cerberus(new WaveConstructor(i));
                }
                else if (i < 10)
                {
                    temp = new ReaperSmall(new WaveConstructor(i));
                }
                else if (i < 13)
                {
                    temp = new ReaperBig(new WaveConstructor(i));
                }
                else if (i < 27)
                {
                    temp = new Cerberus(new WaveConstructor(i));
                }
                else if(i < 34)
                {
                    temp = new ReaperBig(new WaveConstructor(i));
                }
                else
                {
                    temp = new ReaperSmall(new WaveConstructor(i));
                }
                temp.alive = true;
                enemiesArray[enemiesArray.Length - 1] = temp;
                enemiesArray[enemiesArray.Length - 1].defaultPath.parentEnemy = enemiesArray[enemiesArray.Length - 1];
            }
        }
        public void Update()
        {
            if (wave == 1)
            {
                tick += 1;
                if (tick % 10 == 1 && movecount < 10)
                {
                    enemiesArray[movecount].moving = true;
                    movecount += 1;
                }
                else if (tick % 20 == 1 && tick > 250 && gameManager.gameState == "Gameplay")
                {
                    Attack();
                }
                if (killCount >= 10)
                {
                    wave = 2;
                }
            }
            if (wave == 2)
            {
                 tick += 1;
                if (tick % 10 == 1 && tick > 0 && movecount < 27)
                {
                    enemiesArray[movecount].moving = true;
                    movecount += 1;
                }
                else if (tick % 20 == 1 && tick > 500 && gameManager.gameState == "Gameplay")
                {
                    Attack();
                }
                if (killCount >= 27)
                {
                    wave = 3;
                }
            }
            if (wave == 3)
            {
                tick += 1;
                if (tick % 10 == 1 && tick > 0 && movecount < 39)
                {
                    enemiesArray[movecount].moving = true;
                    movecount += 1;
                }
                else if (tick % 30 == 1 && tick > 150 && gameManager.gameState == "Gameplay")
                {
                    Attack();
                }
            }
        }
        public void Draw(Graphics g)
        {
            if (visible)
            {
                for (int i = 0; i < enemiesArray.Length; i++)
                {
                    if (enemiesArray[i].alive || enemiesArray[i].death == true)
                    {
                        enemiesArray[i].Draw(g);
                    }
                }
            }

        }

        public void Next()
        {
            for (int i = 0; i < enemiesArray.Length; i++)
            {
                if (enemiesArray[i].moving && enemiesArray[i].alive)
                {
                    enemiesArray[i].Next();
                }
            }
        }

        public bool CheckCollision(int x, int y)
        {

            for (int i = 0; i < enemiesArray.Length; i++)
            {
                if (enemiesArray[i].alive)
                {
                    if (enemiesArray[i].HitTest(x, y))
                    {
                        if (enemiesArray[i].type == "Cerberus")
                        {
                            enemiesArray[i].death = true;
                            enemiesArray[i].alive = false;
                            killCount++;
                        }
                        else if (enemiesArray[i].type == "ReaperBig")
                        {
                            if (enemiesArray[i].halfHP == true)
                            {
                                enemiesArray[i].death = true;
                                enemiesArray[i].alive = false;
                                killCount++;
                            }
                            enemiesArray[i].halfHP = true;
                        }
                        else if (enemiesArray[i].type == "ReaperSmall")
                        {
                            if (enemiesArray[i].halfHP == true)
                            {
                                enemiesArray[i].death = true;
                                enemiesArray[i].alive = false;
                                killCount++;
                            }
                            enemiesArray[i].halfHP = true;
                        }
                        if (killCount >= 39)
                        {
                            killCount = 0;
                            gameManager.gameState = "WaveTransition";
                        }
                        return true;
                    }
                    if (enemiesArray[i].EnY >= 900)
                    {
                        killCount++;
                        gameManager.gameState = "GameOver";
                    }
                }
            }
            return false;
        }
        public void Attack()
        {
            int enemyID = r.Next(0, enemiesArray.Length - 1);
            Enemy temp = enemiesArray[enemyID];
            temp.defaultPath = new WaveConstructor(temp.EnX, temp.EnY);
            temp.defaultPath.parentEnemy = temp;
            temp.attack = true;
        }
    }
}
