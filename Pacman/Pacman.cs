// Class libraries.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace Pacman
{
    public class Pacman: Creature
    {
        // Private data fields.
        private int kibbleEaten;
        private SoundPlayer death;
        
        // This is the Pacman constructor.
        public Pacman(String fileName, String fileName2, Maze maze)
            : base(fileName, fileName2, maze)
        {
            direction = Direction.Right;
            death = new SoundPlayer("death.wav");
            currentPosition = new Point(9,10);
        }

        // This method is used to see if Pacman lands on a cell with a kibble. If he does then the cell becomes blank
        // and the score increments.
        public void Eat()
        {
            String cellType = Maze.Map[currentPosition.Y, currentPosition.X];
            if (cellType == "k")
            {
                Maze.Map[currentPosition.Y, currentPosition.X] = "b";
                kibbleEaten++;
            }
        }
        // This method is called when by the gameEngine when Pacman's position equals a Ghoul's position.
        public void Die()
        {
       
            death.Play();
            currentPosition = new Point(9,10);
            direction = Direction.Left;
            Thread.Sleep(200);
            direction = Direction.Right;
        }
        
        // Properties
        public int KibbleEaten
        {
            get { return kibbleEaten; }
            set { kibbleEaten = value; }
        }
    }
}

