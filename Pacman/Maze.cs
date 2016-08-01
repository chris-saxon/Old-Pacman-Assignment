// Class libraries.
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pacman
{ 
        public class Maze : DataGridView
        {
            // Constants.
            private const int NCELLS = 20;
            private const int CELLSIZE = 27;
            private const int SPACESIZE = 4;
            private const int NKIBBLES = 184;

            private const string INITMAP =  "wwwwwwwwwwwwwwwwwwww" +
                                            "wkkkkkkkkkkkkkkkkkkw" +
                                            "wkwwkwwwwkwwwwwwkwkw" +
                                            "wkwwkkkkkkwwkkkkkwkw" +
                                            "wkkkkwwwwkwwkwwwkkkw" +
                                            "wkwwkwwwwkwwkwwwkwkw" +
                                            "wkwwkwwwwkwwkwwwkwkw" +
                                            "wkwwkkkkkkkkkkkkkwkw" +
                                            "wkwwwwkwwkwwkwwkwwkw" +
                                            "wkkkkkkwkkkwkwwkwwkw" +
                                            "wkwwwwkwkkkwkkkkwwkw" +
                                            "wkwwwwkwwwwwkwwwwwkw" +
                                            "wkkkkkkkkkkkkkkkkkkw" +
                                            "wkwwwwkwkwwwwkwkwwkw" +
                                            "wkwwkkkwkkkwwkwkwwkw" +
                                            "wkwwkwkwkwkwwkkkwwkw" +
                                            "wkkkkwkwkwkwwkwwkkkw" +
                                            "wkwwkwkwkwkwwkwwkwkw" +
                                            "wkkkkkkkkkkkkkkkkkkw" +
                                            "wwwwwwwwwwwwwwwwwwww" ;

            // Private data fields.
            private String[,] map;
            private Bitmap wall;
            private Bitmap kibble;
            private Bitmap blank;
            private int nKibbles;
            
            //constructor
            public Maze(Bitmap k, Bitmap w, Bitmap b)
                :base()
            {
                //initialise fields
                map = new string[NCELLS,NCELLS];
                wall = w;
                kibble = k;
                blank = b;
                nKibbles = NKIBBLES;

                // convert one dimensional string into 2 dimensional array of strings
                {
                    for (int i = 0; i < NCELLS; i++)
                    {
                        for (int j = 0; j < NCELLS; j++)
                        {
                            int position = (i * NCELLS) + j;
                            map[i, j] = INITMAP.Substring(position, 1);
                        }
                    }
                }

                // set position of maze on the Form
                Top = 0;
                Left = 0;
                
                // set up the columns to display images. We want to display images, so we set 5 columns worth of Image columns
                for (int x = 0; x < NCELLS; x++)
                {
                    Columns.Add(new DataGridViewImageColumn());  
                }
                // then we can tell the grid the number of rows we want to display
                RowCount = NCELLS;

                // set the properties of the Maze(which is a DataGridView object)
                Height = NCELLS * CELLSIZE + SPACESIZE;
                Width = NCELLS * CELLSIZE + SPACESIZE; 
                ScrollBars = ScrollBars.None;
                ColumnHeadersVisible = false;
                RowHeadersVisible = false; 
                
                // set size of cells:
                foreach (DataGridViewRow r in Rows)
                    r.Height = CELLSIZE;

                foreach (DataGridViewColumn c in Columns)
                    c.Width = CELLSIZE;

                // rows and columns should never resize themselves to fit cell contents:
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

                // prevent user from resizing rows or columns:
                AllowUserToResizeColumns = false;
                AllowUserToResizeRows = false;
            }

            // methods
            public void Draw()
            {
                for (int i = 0; i < NCELLS; i++)
                {
                    for (int j = 0; j < NCELLS; j++)
                    {
                         switch (map[i,j])
                         {
                             case "w":                                 
                                 Rows[i].Cells[j].Value = wall;
                                 break;
                             case "k":
                                 Rows[i].Cells[j].Value = kibble;
                                 break;
                             case "b":
                                 Rows[i].Cells[j].Value = blank;
                                 break;
                             default:
                                 MessageBox.Show("Unidentified value in string");
                                 break;
                         }
                     }
                }
            }

            // properties
            public string[,] Map
            {
                get { return map; }
                set { map = value; }
            }

            public int NKibbles
            {
                get { return nKibbles; }
                set { nKibbles = value; }
            }
            public Bitmap Blank
            {
                get { return blank; }
                set { blank = value; }
            }
            public Bitmap Wall
            {
                get { return wall; }
                set { wall = value; }
            }
            public Bitmap Kibble
            {
                get { return kibble; }
                set { kibble = value; }
            }
            public int NCELLS1
            {
                get { return NCELLS; }
            } 

        }
}
