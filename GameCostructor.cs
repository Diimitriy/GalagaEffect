using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace GalagaEffect
{
    class GameCostructor
    {
        public string gameState = "Intro";
        readonly Player player;
        Wave currentWave;
        bool leftDown = false;
        bool rightDown = false;
        bool downDown = false;
        bool upDown = false;
        int iteration = 0;
        MainForm mainForm;

        public GameCostructor(MainForm form)
        {
            currentWave = new Wave(this);
            mainForm = form;
            player = new Player(currentWave, this);
        }

        public void Next()
        {
            if (gameState == "Intro")
            {
                if (iteration == 0)
                {
                    
                    currentWave.visible = false;
                    mainForm.Start.Invoke(new Action(() => mainForm.Start.Location = new Point(-100, -100)));
                    mainForm.mainPanel.Invoke(new Action(() => mainForm.mainPanel.Image = Properties.Resources.backgroundlogo));
                }
                iteration += 1;

            }
            else if (gameState == "Ready")
            {
                if (iteration < 5)
                {
                    currentWave.visible = true;
                    mainForm.mainPanel.Invoke(new Action(() => mainForm.mainPanel.Image = Properties.Resources.background));
                    iteration += 1;
                }
                else if (iteration < 180)
                {
                    if (iteration == 30)
                        player.img = Properties.Resources.pplayer;
                    iteration += 10;
                }
                else
                {
                    iteration = 0;
                    gameState = "Gameplay";
                }
            }
            else if (gameState == "Gameplay")
            {
                currentWave.Update();
                currentWave.Next();
                player.Update(leftDown, rightDown, downDown, upDown);
            }

            else if (gameState == "WaveTransition")
            {
                gameState = "Gameplay";
                currentWave = new Wave(this);
                player.currentWave = currentWave;
                iteration = 0;
            }
            else if (gameState == "GameOver")
            {
                if (iteration < 100)
                {
                    iteration += 1;
                }
                else
                {
                    iteration = 0;
                    gameState = "Intro";
                }
            }
        }
        public void Draw(Graphics g)
        {
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            currentWave.Draw(g);
            player.Draw(g);
        }

        public void UserInput(Keys input, bool down)
        {
            if (down)
            {
                if (input == Keys.Left)
                {
                    leftDown = true;
                }
                if (input == Keys.Right)
                {
                    rightDown = true;
                }
                if (input == Keys.Down)
                {
                    downDown = true;
                }
                if (input == Keys.Up)
                {
                    upDown = true;
                }

                if ((input == Keys.Space) && gameState == "Gameplay")
                {
                    player.Shoot();
                }

                if(gameState == "Intro")
                {
                    iteration = 0;
                    currentWave = new Wave(this);
                    player.currentWave = currentWave;
                    gameState = "Ready";                
                }
            }
            else
            {
                if (input == Keys.Left) 
                {
                    leftDown = false;
                }
                if (input == Keys.Right) 
                {
                    rightDown = false;
                }

                if (input == Keys.Up)
                {
                    upDown = false;
                }
                if (input == Keys.Down)
                {
                    downDown = false;
                }
            }
        }
    }
}
