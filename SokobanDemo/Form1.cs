using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //needed for working with external files
using System.Collections; //needed for stacks and queues
using System.Reflection; //needed for reasons

namespace SokobanDemo
{
    public partial class Form1 : Form
    {
        //some of the new skills you will learn in this project:
        //work with external files to open our maps, and potentially save/load our games
        //work with keyboard controls
        //work with a data structure called a "stack" to create an undo/redo function
        //work with a graphics strip
        //switch statements

        //GLOBAL VARIABLES
        enum CellTypes { wall = 0, worker = 1, destination = 2, bag = 3, bagOnDest = 4, workerOnDest = 5, blank = 6 }

        CellTypes[,] gameData;

        Size cellSize = new Size(25, 25); //same size as graphics
        Size gridSize; //this will be set based on the map that is imported

        int level = 1;

        int direction;

        int xDirection = 0;
        int yDirection = 0;
        int xBagDirection = 0;
        int yBagDirection = 0;

        //the graphics
        Bitmap graphics = new Bitmap(typeof(Form1), "graphics.png");

        //the position of the worker
        Point workerLocation;

        //a stack is a collection of data (like an array, or a list) 
        //LIFO - Last In, First Out (like drying dishes)

        //each time we move we will save a copy of the 2d gameboard
        Stack<CellTypes[,]> savedStates = new Stack<CellTypes[,]>();

        //save the worker's location each time we move
        Stack<Point> savedWorkerLoc = new Stack<Point>();

        public Form1()
        {
            InitializeComponent();
            createLevel();
        }

        private void SaveForUndo()
        {
            CellTypes[,] savedMove = new CellTypes[gridSize.Width, gridSize.Height];

            //now we need to copy te gameData array to the savedMOve array
            for (int i = 0; i < gridSize.Width; i++)
            {
                for (int j = 0; j < gridSize.Height; j++)
                {
                    savedMove[i, j] = gameData[i, j];
                }
            }

            //push the copy onto the savedState stack
            savedStates.Push(savedMove);

            //push the worker's location onto the stack
            savedWorkerLoc.Push(workerLocation);
        }

        private void Undo()
        {
            //let's pop a copy off the stack
            if (savedStates.Count > 0)
            {


                CellTypes[,] thisCopy = new CellTypes[gridSize.Width, gridSize.Height];
                thisCopy = savedStates.Pop();

                //copy the saved state to the gameData array
                for (int i = 0; i < gridSize.Width; i++)
                {
                    for (int j = 0; j < gridSize.Height; j++)
                    {
                        gameData[i, j] = thisCopy[i, j];
                    }
                }

                //get the worker's location as well
                workerLocation = savedWorkerLoc.Pop();
            }

            Invalidate();
        }

        private void openMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //the user will pick a map and it will be loaded
            //opne the dialog box
            //if OK is pressed, we will read the file
            //if cancel is pressed, nothing happens

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //open the text file
                StreamReader mapFile = new StreamReader(openFileDialog1.FileName);

                while (!mapFile.EndOfStream)
                {
                    //read the file line by line
                    string lineOfText = mapFile.ReadLine();
                    //skip the lines beginning with a '-' (comments)
                    if (lineOfText[0] == '-')
                    {
                        continue;
                    }
                    if (lineOfText[0] == '*' && lineOfText[1] == Convert.ToChar(level.ToString())) //we found the map for level one!
                    {
                        lineOfText = mapFile.ReadLine(); //read the next line
                        string[] data = lineOfText.Split(',');

                        //now lets set the gridSize
                        gridSize.Width = Convert.ToInt32(data[0]); //first number
                        gridSize.Height = Convert.ToInt32(data[1]); //second number

                        //we need to intitialize the gameData array
                        gameData = new CellTypes[gridSize.Width, gridSize.Height];

                        //now we will loop through the text file and read in the
                        //characters from the map
                        for (int i = 0; i < gridSize.Height; i++)
                        {
                            lineOfText = mapFile.ReadLine();
                            //read each character from the line
                            for (int j = 0; j < gridSize.Width; j++)
                            {
                                setCharacters(j, i, lineOfText[j]);
                            }
                        }

                    }
                }

                //we are done with the map file
                mapFile.Dispose();
                //set the size of the window
                ClientSize = new Size(cellSize.Width * gridSize.Width, cellSize.Height * gridSize.Height + menuStrip1.Height);

                //call paint
                Invalidate();
            }
        }

        private void setCharacters(int col, int row, char c)
        {
            switch (c)
            {
                case '#': //wall
                    gameData[col, row] = CellTypes.wall;
                    break; //leaves the switch statement

                case 'w': //worker
                    gameData[col, row] = CellTypes.worker;
                    workerLocation = new Point(col, row);
                    break;

                case 'b': //bag
                    gameData[col, row] = CellTypes.bag;
                    break;

                case 'd': //destination
                    gameData[col, row] = CellTypes.destination;
                    break;

                case 'B': //bag on dest
                    gameData[col, row] = CellTypes.bagOnDest;
                    break;

                case 'W': //worker on dest
                    gameData[col, row] = CellTypes.workerOnDest;
                    break;

                case ' ': //blank
                    gameData[col, row] = CellTypes.blank;
                    break;
            }
        }

        private void checkWin()
        {
            int numBags = 0;

            //in order to win, all the bags must be on a destination, and all destinations must be bagOnDest
            //we need to check if there are any bags left
            for (int i = 0; i < gridSize.Width; i++)
            {
                for (int j = 0; j < gridSize.Height; j++)
                {
                    if (gameData[i, j] == CellTypes.bag)
                    {
                        numBags++;
                    }
                }
            }

            //now that we know how many bags are in the game, we want to
            //see if there are none left
            //then we can change the level
            if (numBags == 0 && level <= 5)
            {
                level++;
                if(level <=5)
                {
                    MessageBox.Show("You did it! Start level " + level);
                    createLevel();
                    savedStates.Clear();
                    savedWorkerLoc.Clear();
                }

                else if (level == 6)
                {
                    MessageBox.Show("Congratulations! You beat all the levels!", "Game Over");
                    Application.Exit();
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //shift the graphics down by the height of the menuStrip
            e.Graphics.TranslateTransform(0, menuStrip1.Height);

            //loop through the entire board and draw the appropriate graphic
            for (int i = 0; i < gridSize.Width; i++)
            {
                for (int j = 0; j < gridSize.Height; j++)
                {
                    //create 2 rectangles

                    //the image to choose from the graphic strip
                    Rectangle srcRect = new Rectangle();

                    //where to draw the image on the game board
                    Rectangle destRect = new Rectangle(i * cellSize.Width, j * cellSize.Height, cellSize.Width, cellSize.Height);

                    if (gameData[i, j] == CellTypes.worker)
                    {
                        srcRect = new Rectangle(0, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(graphics, destRect, srcRect, GraphicsUnit.Pixel);
                    }

                    else if (gameData[i, j] == CellTypes.destination)
                    {
                        srcRect = new Rectangle(2 * cellSize.Width, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(graphics, destRect, srcRect, GraphicsUnit.Pixel);
                    }

                    else if (gameData[i, j] == CellTypes.wall)
                    {
                        srcRect = new Rectangle(3 * cellSize.Width, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(graphics, destRect, srcRect, GraphicsUnit.Pixel);
                    }

                    else if (gameData[i, j] == CellTypes.bag)
                    {
                        srcRect = new Rectangle(4 * cellSize.Width, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(graphics, destRect, srcRect, GraphicsUnit.Pixel);
                    }

                    else if (gameData[i, j] == CellTypes.bagOnDest)
                    {
                        srcRect = new Rectangle(1 * cellSize.Width, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(graphics, destRect, srcRect, GraphicsUnit.Pixel);
                    }

                    if (workerLocation.X == i && workerLocation.Y == j) //found the worker
                    {
                        srcRect = new Rectangle(0, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(graphics, destRect, srcRect, GraphicsUnit.Pixel);
                    }

                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //this event is triggered when any key is pressed

            //we can move into a space:
            /*  1. that is blank
             *  2. that is a destination
             *  3. that is a bag onto a blank
             *  4. that is a bag onto a destination
             */

            if (e.KeyCode == Keys.Up)
            {
                direction = 0;

                //only save a move that actually did something
                if (move() == true)
                {
                    SaveForUndo();
                }
            }

            else if (e.KeyCode == Keys.Down)
            {
                direction = 1;
                if (move() == true)
                {
                    SaveForUndo();
                }
            }

            else if (e.KeyCode == Keys.Left)
            {
                direction = 2;
                if (move() == true)
                {
                    SaveForUndo();
                }
            }

            else if (e.KeyCode == Keys.Right)
            {
                direction = 3;
                if (move() == true)
                {
                    SaveForUndo();
                }
            }

            checkWin();
        }

        private bool move()
        {
            bool didMove = false;

            //cuz we're lazy (or efficient)
            int x = workerLocation.X;
            int y = workerLocation.Y;

            CellTypes originalWorker = gameData[x, y];

            //up
            if (direction == 0)
            {
                xDirection = x;
                yDirection = y - 1;
                xBagDirection = x;
                yBagDirection = y - 2;
            }

            //down
            else if (direction == 1)
            {
                xDirection = x;
                yDirection = y + 1;
                xBagDirection = x;
                yBagDirection = y + 2;
            }

            //left
            else if (direction == 2)
            {
                xDirection = x - 1;
                yDirection = y;
                xBagDirection = x - 2;
                yBagDirection = y;
            }

            //right
            else if (direction == 3)
            {
                xDirection = x + 1;
                yDirection = y;
                xBagDirection = x + 2;
                yBagDirection = y;
            }

            kindOfWorker();

            //is there a blank 1 up?
            if (gameData[xDirection, yDirection] == CellTypes.blank)
            {
                //move the worker
                gameData[xDirection, yDirection] = CellTypes.worker;

                //but what "kind of worker moved?
                //what do we need to leave behind?
                kindOfWorker();

                updateWorkerLoc();
                didMove = true;
            }

            else if (gameData[xDirection, yDirection] == CellTypes.destination)
            {
                //move the worker
                gameData[xDirection, yDirection] = CellTypes.workerOnDest;

                //but what kind of worker moved
                kindOfWorker();

                updateWorkerLoc();
                didMove = true;
            }

            //push a bag onto a blank
            else if (gameData[xDirection, yDirection] == CellTypes.bag && gameData[xBagDirection, yBagDirection] == CellTypes.blank)
            {
                //move the worker and the bag
                gameData[xDirection, yDirection] = CellTypes.worker;
                gameData[xBagDirection, yBagDirection] = CellTypes.bag;

                //but what "kind of worker moved?
                //what do we need to leave behind?
                kindOfWorker();

                updateWorkerLoc();
                didMove = true;
            }

            //push a bag onto a destination
            else if (gameData[xDirection, yDirection] == CellTypes.bag && gameData[xBagDirection, yBagDirection] == CellTypes.destination)
            {
                //move the worker and the bag
                gameData[xDirection, yDirection] = CellTypes.worker;
                gameData[xBagDirection, yBagDirection] = CellTypes.bagOnDest;

                //but what "kind of worker moved?
                //what do we need to leave behind?
                kindOfWorker();

                updateWorkerLoc();
                didMove = true;
            }

            //push a bag from a destination onto a blank
            else if (gameData[xDirection, yDirection] == CellTypes.bagOnDest && gameData[xBagDirection, yBagDirection] == CellTypes.blank)
            {
                //move the worker and the bag
                gameData[xDirection, yDirection] = CellTypes.workerOnDest;
                gameData[xBagDirection, yBagDirection] = CellTypes.bag;

                //but what "kind of worker moved?
                //what do we need to leave behind?
                kindOfWorker();

                updateWorkerLoc();
                didMove = true;
            }

            //push a bag from one destination onto another destination
            else if (gameData[xDirection, yDirection] == CellTypes.bagOnDest && gameData[xBagDirection, yBagDirection] == CellTypes.destination)
            {
                //move the worker and the bag
                gameData[xDirection, yDirection] = CellTypes.workerOnDest;
                gameData[xBagDirection, yBagDirection] = CellTypes.bagOnDest;

                //but what "kind" of worker moved?
                //what do we need to leave behind?
                kindOfWorker();

                updateWorkerLoc();
                didMove = true;
            }

            Invalidate();
            return didMove; //did we move? this will be true or false
        }

        private void updateWorkerLoc()
        {
            //down
            if (direction == 0)
                workerLocation.Y--;
            //up
            else if (direction == 1)
                workerLocation.Y++;
            //left
            else if (direction == 2)
                workerLocation.X--;
            //right
            else if (direction == 3)
                workerLocation.X++;
        }

        private void kindOfWorker()
        {
            //cuz we're lazy (or efficient)
            int x = workerLocation.X;
            int y = workerLocation.Y;

            CellTypes originalWorker = gameData[x, y];

            //but what "kind of worker moved?
            //what do we need to leave behind?
            if (originalWorker == CellTypes.worker) //a blank underneath
            {
                gameData[x, y] = CellTypes.blank;
            }

            else if (originalWorker == CellTypes.workerOnDest)//there was a destination underneath
            {
                gameData[x, y] = CellTypes.destination;
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //call the undo function
            Undo();
        }

        //call this on the start page
        private void createLevel()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var mapName = "maps.txt";

            using (Stream s = assembly.GetManifestResourceStream(mapName))
            {
                using (StreamReader reader = new StreamReader(mapName))
                {
                    //this line is needed if multiple maps on one text file
                    bool mapLoaded = false;

                    while (!mapLoaded)
                    {
                        //read the file line by line
                        string lineOfText = reader.ReadLine();
                        //skip the lines beginning with a '-' (comments)
                        if (lineOfText[0] == '-')
                        {
                            continue;
                        }
                        if (lineOfText[0] == '*' && lineOfText[1] == Convert.ToChar(level.ToString())) //we found the map for level one!
                        {
                            lineOfText = reader.ReadLine(); //read the next line
                            string[] data = lineOfText.Split(',');

                            //now lets set the gridSize
                            gridSize.Width = Convert.ToInt32(data[0]); //first number
                            gridSize.Height = Convert.ToInt32(data[1]); //second number

                            //we need to intitialize the gameData array
                            gameData = new CellTypes[gridSize.Width, gridSize.Height];

                            //now we will loop through the text file and read in the
                            //characters from the map
                            for (int i = 0; i < gridSize.Height; i++)
                            {
                                lineOfText = reader.ReadLine();
                                //read each character from the line
                                for (int j = 0; j < gridSize.Width; j++)
                                {
                                    setCharacters(j, i, lineOfText[j]);
                                }
                            }

                            mapLoaded = true;

                        }
                    }

                    //set the size of the window
                    ClientSize = new Size(cellSize.Width * gridSize.Width, cellSize.Height * gridSize.Height + menuStrip1.Height);

                    //call paint
                    Invalidate();
                }
            }

        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            instructions instructions = new instructions();
            instructions.ShowDialog();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
