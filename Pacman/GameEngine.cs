// Class libraries.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Media;


namespace Pacman
{
    public class GameEngine
    {
        // Constants/
        private const int NUMBEROFCELLS = 20;
        private const String GAMEOVER = "Game Over";
        private const int NUMOFLIVES = 3;

        // Instances of classes
        private Maze maze;
        private Ghoul[] ghoul;
        private Pacman pacman;
        private SoundPlayer moveAudio;
        private Random random;
        private Graphics graphics;
        
        // Private data fields.
        private int lives;
        private int score;

        // This is the game engine constructor.
        public GameEngine(Maze maze,Random random, Graphics graphics)
        { 
            this.maze = maze;
            this.random = random;
            this.graphics = graphics;
            ghoul = new Ghoul[3];
            pacman = new Pacman("pacman1.bmp", "pacman2.bmp", maze);
            ghoul[0] = new Ghoul("orange1.bmp", "orange2.bmp", maze, random);
            ghoul[1] = new Ghoul("red1.bmp", "red2.bmp", maze, random);
            ghoul[2] = new Ghoul("purple1.bmp", "purple2.bmp", maze, random);
            moveAudio = new SoundPlayer("wakka.wav");
            lives = NUMOFLIVES;
            score = 0;
        }
        // This method runs on the tick of the timer . . .
        public void RunGame()
        {
            pacman.Move();
            if (pacman.CheckValidMove() == true)
            {
                moveAudio.Play();
            }
            pacman.Draw();
            pacman.Eat();
            for (int i = 0; i < ghoul.Length; i++)
            {
                ghoul[i].GetNewDirection();
                ghoul[i].Move();
                ghoul[i].Draw();
         
            if (pacman.CurrentPosition == ghoul[i].CurrentPosition)
            {
                pacman.Die();
                lives--;
            }
            }
            score = pacman.KibbleEaten;
        }

        // If all the kibbles have been eaten this method is called 
        public void WinGame()
        {
            if (score == maze.NKibbles)
            {
                //MessageBox.Show("You Win");
            }

        }
        // Once pacman runs out of lives this method is called.
        public void GameOver()
        {
            if (Lives <= 0) 
            {
               
                Application.Restart();
                MessageBox.Show("GAME OVER");
            }
        }
        // This method changes pacmans direction.
        public void SetDirection(Direction direction)
        {
            pacman.Direction = direction;
        }


        // These are the properties.
        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }
        public Pacman Pacman
        {
            get { return pacman; }
            set { pacman = value; }
        }
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
    }

}
