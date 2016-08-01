// Class Libraries.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Pacman
{
    public abstract class Creature
    {
        
        // Private data fields.
        protected Bitmap[] body;
        protected Maze maze;
        protected Direction direction;
        protected Point currentPosition;
        
        // This is the contructor for the abstract Creature class.
        public Creature(String fileName, String fileName2, Maze maze)
        {
            this.maze = maze;
            body = new Bitmap[2];
            body[0] = new Bitmap(fileName);
            body[1] = new Bitmap(fileName2);
        }

        public void Draw()
        {
            for (int i = 0; i < body.Length; i++)
            {
                GetGridCellForPosition(currentPosition).Value = Body[i];
                Application.DoEvents();
            }
         
        }
        
        public DataGridViewCell GetGridCellForPosition(Point p)
        {
            return maze.Rows[p.Y].Cells[p.X];
        }

              public void Move()
              {

                  if (CheckValidMove() == true)
                  {
              
                switch (direction)
                {
                    case Direction.Up:
                        currentPosition.Y -= 1;
                        break;
                    case Direction.Down:
                        currentPosition.Y += 1;
                        
                        break;
                    case Direction.Left:
                        currentPosition.X -= 1;
                        break;
                    case Direction.Right:
                        currentPosition.X += 1;
                        break;
                    default:
                        break;
                }
                  }
              }
        // This method checks to see if the next position is a free cell or a wall. If it is a free cell
        // it will return true, if the cell is the wall it returns false. 
        public Boolean CheckValidMove()
        {
            Point tempPosition = currentPosition;
            switch (direction)
            {
                case Direction.Up:
                    tempPosition.Y -= 1;
                    break;
                case Direction.Down:
                    tempPosition.Y += 1;
                    break;
                case Direction.Left:
                    tempPosition.X -= 1;
                    break;
                case Direction.Right:
                    tempPosition.X += 1;
                    break;
                default:
                    break;
            }
            String cellType = Maze.Map[tempPosition.Y, tempPosition.X];

            if (cellType != "w")
            {
                return true;
            }

            return false;
        }

        // Properties

        public Bitmap[] Body
        {
            get { return body; }
            set { body = value; }
        }
        public Direction Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        public Maze Maze
        {
            get { return maze; }
            set { maze = value; }
        }
        public Point CurrentPosition
        {
            get { return currentPosition; }
            set { currentPosition = value; }
        }
    }
}

