using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Pacman
{
    public partial class Form1 : Form
    {
        // Constants
        private const int FORMHEIGHT = 800;
        private const int FORMWIDTH = 600;

        // declare the Maze object.
        private  Maze maze;
        private Graphics graphics;
        private GameEngine gameEngine;
        private Random random;
        private SoundPlayer intro;

        // This is the form constructor.
        public Form1()
        {
            InitializeComponent();
            random = new Random();
          
            // set the Properties of the Form
            Top = 0;
            Left = 0;
            Height = FORMHEIGHT;
            Width = FORMWIDTH;
            KeyPreview = true;
            // create a Bitmap object for each image you want to display
            Bitmap k = new Bitmap("kibble.bmp");
            Bitmap w = new Bitmap("wall.bmp");
            Bitmap b = new Bitmap("blank.bmp");

            // create an instance of a Maze:
            maze = new Maze(k, w, b);

            // important, need to add the maze object to the list of controls on the form
            Controls.Add(maze);

            // remember the Timer Enabled Property is set to false as a default

            graphics = CreateGraphics();
            gameEngine = new GameEngine(maze, random, graphics);
            //timer1.Enabled = true;
            intro = new SoundPlayer("intro.wav");
            //intro.PlaySync();
            maze.Draw();
            intro.Play();
        }
        // For every tick of the timer while enabled this method is called.
        private void timer1_Tick(object sender, EventArgs e)
        {
           maze.Draw();
           gameEngine.RunGame();
           gameEngine.GameOver();
           gameEngine.WinGame();
           label2.Text = "Score: " + gameEngine.Score.ToString();
           label3.Text = "Lives: " + gameEngine.Lives.ToString();
           DoubleBuffered = true;
           Application.DoEvents();
        }
        // The method is triggered on the event of key press.
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    gameEngine.SetDirection(Direction.Left);
                    break;

                case Keys.Right:
                    gameEngine.SetDirection(Direction.Right);
                    break;

                case Keys.Up:
                    gameEngine.SetDirection(Direction.Up);
                    break;

                case Keys.Down:
                    gameEngine.SetDirection(Direction.Down);
                    break;

                default:
                    break;
            }
        }
        // This event is used when the user presses the pause button stopping or starting the timer.
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        
        }


        // On the event that the exit button is pressed the Application.Exit will close the form.
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // When the Start Game button is pressed this event is triggered enabling the timer.
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            timer1.Enabled = true;
        }
        // This event is triggered when the restart button is pressed. It calls the restart method restarting the program.
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }


    
    }
}
