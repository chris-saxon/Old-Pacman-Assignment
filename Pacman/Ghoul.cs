// Class libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace Pacman
{
    public class Ghoul : Creature
    {
        private Random random;
   
        // This is the constructor for the ghoul class it inherits it's values from the creature class.
        public Ghoul(String fileName, String fileName2, Maze maze, Random random)
            : base(fileName,fileName2, maze)
        {
            this.Maze = maze;
            this.random = random;
            GetStartingPosition();

        }

        // This method looks for a starting position within the total maze cells using a random number. It then
        // checks to see if the cell is a wall or free to move to. If it is a wall the method is called again until a suitable 
        // starting position is found.
        public Point GetStartingPosition()
        {
            currentPosition = new Point(random.Next(Maze.NCELLS1), random.Next(Maze.NCELLS1));
            String cellType = Maze.Map[currentPosition.Y, currentPosition.X];
            if (cellType == "w")
            {
                GetStartingPosition();
            }
           
            return currentPosition;
	
        }
 
        //public void Move()
        //{
        //    switch (pacmanDirection)
        //    {
        //        case Direction.Up:
        //            if (CheckValidMove() ==  true)
        //            {
        //                currentPosition.Y -= 1;
        //                pacmanDirection = PacmanDirection;
        //            }
        //            else
        //            {
        //                GetNewDirection();
        //            }
        //            break;
        //        case Direction.Down:
        //            if (CheckValidMove() == true)
        //            {
        //                currentPosition.Y += 1;
        //                pacmanDirection = PacmanDirection;
        //            }
        //            else
        //            {
        //                GetNewDirection();
        //            }
        //            break;
        //        case Direction.Left:
        //            if (CheckValidMove() == true)
        //            {
        //                currentPosition.X -= 1;
        //                pacmanDirection = PacmanDirection;
        //            }
        //            else
        //            {
        //                GetNewDirection();
        //            }
        //            break;
        //        case Direction.Right:
        //            if (CheckValidMove() == true)
        //            {
        //                currentPosition.X += 1;
        //                pacmanDirection = PacmanDirection;
        //            }
        //            else
        //            {
        //                GetNewDirection();
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //}


        //public Boolean CheckValidMove()
        //{
        //    Point tempPosition = currentPosition;
          

        //    switch (pacmanDirection)
        //    {
        //        case Direction.Up:
        //            tempPosition.Y -= 1;
        //            break;
        //        case Direction.Down:
        //            tempPosition.Y += 1;
        //            break;
        //        case Direction.Left:
        //            tempPosition.X -= 1;
        //            break;
        //        case Direction.Right:
        //            tempPosition.X += 1;
        //            break;
        //        default:
        //            break;
        //    }
        //    String cellType = Maze.Map[tempPosition.Y, tempPosition.X];
        //    if (cellType != "w")
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        // When this method is called it uses a random number to change the Ghoul's direction.
        public void GetNewDirection()
        {

            switch (random.Next(4))
            {
                case 0:
                    
                   direction = Direction.Up;
                  break;
                case 1:
                  direction = Direction.Down;
                    break;
                case 2:
                    direction = Direction.Left;
                    break;
                case 3:
                    direction = Direction.Right;
                break;
                default:
                    break;
            }
        }
    }
}
