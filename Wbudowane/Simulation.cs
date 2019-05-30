using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wbudowane
{
    public abstract class Simulation
    {
        static string bc = "";
        static string neighbourhood = "";
        static bool ended = false;

        public static string BC
        {
            set
            {
                bc = value;
            }
            get
            {
                return bc;
            }
        }

        public static string Neighbourhood
        {
            set
            {
               neighbourhood = value;
            }
            get
            {
                return neighbourhood;
            }
        }

        public static bool Ended
        {
            get
            {
                return ended;
            }
        }



        public static bool nextItteration(ref Board board)
        {
            ended = true;
            calcNextItteration(ref board);
            return ended;
        }

        private static void calcNextItteration(ref Board board)
        { 
            Board colorContainer = new Board(ref board);
            for (int i = 0; i < board.Size.Width; ++i)
            {
                for (int j = 0; j < board.Size.Height; j++)
                {
                    if (!colorContainer[i,j].Alive)
                    {
                        List<Tuple<Tuple<int, int, int>, int>> colorList = new List<Tuple<Tuple<int, int, int>, int>>();
                        for (int k = 0; k < board[i, j].Neighbours.Count; ++k)
                        {
                            if (board[i, j].Neighbours[k].Alive)
                            {
                                bool addNew = true;
                                for (int l = 0; l < colorList.Count; ++l)
                                {
                                    if (board[i, j].Neighbours[k].State == colorList[l].Item1)
                                    {
                                        colorList[l] = Tuple.Create<Tuple<int, int, int>, int>(colorList[l].Item1, colorList[l].Item2 + 1);
                                        addNew = false;
                                        l = colorList.Count;
                                    }
                                }
                                if (addNew)
                                {
                                    colorList.Add(Tuple.Create<Tuple<int, int, int>, int>(board[i, j].Neighbours[k].State, 1));
                                }
                            }
                        }
                        Tuple<Tuple<int, int, int>, int> maxColor = Tuple.Create<Tuple<int, int, int>, int>(Tuple.Create<int, int, int>(0, 0, 0), 0);
                        for (int l = 0; l < colorList.Count; ++l)
                        {
                            if (colorList[l].Item2 > maxColor.Item2)
                                maxColor = colorList[l];
                        }
                        if (maxColor.Item2 != 0)
                        {
                            colorContainer[i, j].State = maxColor.Item1;
                            ended = false;
                        }
                       
                    }
                }
            }

            for (int i = 0; i < board.Size.Width; ++i)
            {
                for (int j = 0; j < board.Size.Height; j++)
                {
                    board[i, j].State = colorContainer[i,j].State;
                }
            }
        }

       public static void init(ref Board board)
       {
           if (neighbourhood == "von Neumann")
               initVonNeumann(ref board);
           else if (neighbourhood == "Moore")
               initMoore(ref board);
           else if (neighbourhood == "Pentagonal")
               initPentagonal(ref board);
           else if (neighbourhood == "Hexagonal")
               initHexagonal(ref board);
            else if (neighbourhood == "Hexagonal-Right")
                initHexagonalRight(ref board);
            else if (neighbourhood == "Hexagonal-Left")
                initHexagonalLeft(ref board);
            else if (neighbourhood == "Radius")
               initRadius(ref board);
       }

       public static void initVonNeumann(ref Board board)
       {
           for (int i = 0; i < board.Size.Width; i++)
           {
               for (int j = 0; j < board.Size.Height; j++)
               {
                   if (bc == "Periodic")
                   {
                       board[i % board.Size.Width, j % board.Size.Height].Neighbours = new List<Tile>();
                       board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + board.Size.Width) % board.Size.Width, (j - 1 + board.Size.Height) % board.Size.Height]);
                       board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + board.Size.Width) % board.Size.Width, (j + 1 + board.Size.Height) % board.Size.Height]);
                       board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i - 1 + board.Size.Width) % board.Size.Width, (j + board.Size.Height) % board.Size.Height]);
                       board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + 1) % board.Size.Width, (j + board.Size.Height) % board.Size.Height]);
                   }
                   else if (bc == "Sorption")
                   {
                       board[i, j].Neighbours = new List<Tile>();
                       if (j - 1 >= 0)
                           board[i, j].Neighbours.Add(board[i, j - 1]);
                       if (j + 1 < board.Size.Height - 1)
                           board[i, j].Neighbours.Add(board[i, j + 1]);
                       if (i - 1 >= 0)
                           board[i, j].Neighbours.Add(board[i - 1, j]);
                       if (i + 1 < board.Size.Width - 1)
                           board[i, j].Neighbours.Add(board[i + 1, j]);
                   }
               }
           }
       }

       public static void initMoore(ref Board board)
       {
           for (int i = 0; i < board.Size.Width; i++)
           {
               for (int j = 0; j < board.Size.Height; j++)
               {
                   if (bc == "Periodic")
                   {
                       board[i % board.Size.Width, j % board.Size.Height].Neighbours = new List<Tile>();

                       board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i-1 + board.Size.Width) % board.Size.Width, (j - 1 + board.Size.Height) % board.Size.Height]);
                       board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + board.Size.Width) % board.Size.Width, (j - 1 + board.Size.Height) % board.Size.Height]);
                       board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i+1 + board.Size.Width) % board.Size.Width, (j - 1 + board.Size.Height) % board.Size.Height]);

                       board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i-1 + board.Size.Width) % board.Size.Width, (j + 1 + board.Size.Height) % board.Size.Height]);
                       board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + board.Size.Width) % board.Size.Width, (j + 1 + board.Size.Height) % board.Size.Height]);
                       board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i+1 + board.Size.Width) % board.Size.Width, (j + 1 + board.Size.Height) % board.Size.Height]);

                       board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i - 1 + board.Size.Width) % board.Size.Width, (j + board.Size.Height) % board.Size.Height]);
                       board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + 1) % board.Size.Width, (j + board.Size.Height) % board.Size.Height]);
                   }
                   if (bc == "Sorption")
                   {
                       board[i, j].Neighbours = new List<Tile>();
                       if (i - 1 >= 0)
                       {
                           if (j - 1 >= 0)
                               board[i, j].Neighbours.Add(board[i-1, j - 1]);
                           if (j + 1 < board.Size.Height - 1)
                               board[i, j].Neighbours.Add(board[i-1, j + 1]);
                           board[i, j].Neighbours.Add(board[i - 1, j]);
                       }
                       if (i + 1 < board.Size.Width - 1)
                       {
                           if (j - 1 >= 0)
                               board[i, j].Neighbours.Add(board[i+1, j - 1]);
                           if (j + 1 < board.Size.Height - 1)
                               board[i, j].Neighbours.Add(board[i+1, j + 1]);
                           board[i, j].Neighbours.Add(board[i + 1, j]);
                       }
                       if (j - 1 >= 0)
                           board[i, j].Neighbours.Add(board[i, j - 1]);
                       if (j + 1 < board.Size.Height - 1)
                           board[i, j].Neighbours.Add(board[i, j + 1]);
                   }
               }
           }
       }

       public static void initPentagonal(ref Board board)
       {
           for (int i = 0; i < board.Size.Width; i++)
           {
               for (int j = 0; j < board.Size.Height; j++)
               {
                   if (bc == "Periodic")
                   {
                       board[i % board.Size.Width, j % board.Size.Height].Neighbours = new List<Tile>();
                        int random = RandomMachine.Random.Next(4);
                       switch (random)
                       {
                           case 0:
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + board.Size.Width) % board.Size.Width, (j - 1 + board.Size.Height) % board.Size.Height]);
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + 1 + board.Size.Width) % board.Size.Width, (j - 1 + board.Size.Height) % board.Size.Height]);

                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + 1) % board.Size.Width, (j + board.Size.Height) % board.Size.Height]);

                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + board.Size.Width) % board.Size.Width, (j + 1 + board.Size.Height) % board.Size.Height]);
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + 1 + board.Size.Width) % board.Size.Width, (j + 1 + board.Size.Height) % board.Size.Height]);
                               break;

                           case 1:

                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i - 1 + board.Size.Width) % board.Size.Width, (j + 1 + board.Size.Height) % board.Size.Height]);
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + board.Size.Width) % board.Size.Width, (j + 1 + board.Size.Height) % board.Size.Height]);
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + 1 + board.Size.Width) % board.Size.Width, (j + 1 + board.Size.Height) % board.Size.Height]);

                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i - 1 + board.Size.Width) % board.Size.Width, (j + board.Size.Height) % board.Size.Height]);
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + 1) % board.Size.Width, (j + board.Size.Height) % board.Size.Height]);
                               break;

                           case 2:
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i - 1 + board.Size.Width) % board.Size.Width, (j - 1 + board.Size.Height) % board.Size.Height]);
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + board.Size.Width) % board.Size.Width, (j - 1 + board.Size.Height) % board.Size.Height]);

                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i - 1 + board.Size.Width) % board.Size.Width, (j + 1 + board.Size.Height) % board.Size.Height]);
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + board.Size.Width) % board.Size.Width, (j + 1 + board.Size.Height) % board.Size.Height]);

                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i - 1 + board.Size.Width) % board.Size.Width, (j + board.Size.Height) % board.Size.Height]);
                               break;

                           case 3:
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i - 1 + board.Size.Width) % board.Size.Width, (j - 1 + board.Size.Height) % board.Size.Height]);
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + board.Size.Width) % board.Size.Width, (j - 1 + board.Size.Height) % board.Size.Height]);
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + 1 + board.Size.Width) % board.Size.Width, (j - 1 + board.Size.Height) % board.Size.Height]);

                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i - 1 + board.Size.Width) % board.Size.Width, (j + board.Size.Height) % board.Size.Height]);
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + 1) % board.Size.Width, (j + board.Size.Height) % board.Size.Height]);
                               break;

                           default:
                               break;

                       }
                   }
                   if (bc == "Sorption")
                   {
                       board[i, j].Neighbours = new List<Tile>();
                       int random = RandomMachine.Random.Next(4);
                       switch (random)
                       {
                           case 0:
                               if (i + 1 < board.Size.Width - 1)
                               {
                                   if (j - 1 >= 0)
                                       board[i, j].Neighbours.Add(board[i + 1, j - 1]);
                                   if (j + 1 < board.Size.Height - 1)
                                       board[i, j].Neighbours.Add(board[i + 1, j + 1]);
                                   board[i, j].Neighbours.Add(board[i + 1, j]);
                               }

                               if (j - 1 >= 0)
                                   board[i, j].Neighbours.Add(board[i, j - 1]);
                               if (j + 1 < board.Size.Height - 1)
                                   board[i, j].Neighbours.Add(board[i, j + 1]);
                               break;

                           case 1:

                               if (i - 1 >= 0)
                               {
                                   if (j + 1 < board.Size.Height - 1)
                                       board[i, j].Neighbours.Add(board[i - 1, j + 1]);
                                   board[i, j].Neighbours.Add(board[i - 1, j]);
                               }
                               if (i + 1 < board.Size.Width - 1)
                               { 
                                   if (j + 1 < board.Size.Height - 1)
                                       board[i, j].Neighbours.Add(board[i + 1, j + 1]);
                                   board[i, j].Neighbours.Add(board[i + 1, j]);
                               }

                               if (j + 1 < board.Size.Height - 1)
                                   board[i, j].Neighbours.Add(board[i, j + 1]);
                               break;

                           case 2:
                               if (i - 1 >= 0)
                               {
                                   if (j - 1 >= 0)
                                       board[i, j].Neighbours.Add(board[i - 1, j - 1]);
                                   if (j + 1 < board.Size.Height - 1)
                                       board[i, j].Neighbours.Add(board[i - 1, j + 1]);
                                   board[i, j].Neighbours.Add(board[i - 1, j]);
                               }

                               if (j - 1 >= 0)
                                   board[i, j].Neighbours.Add(board[i, j - 1]);
                               if (j + 1 < board.Size.Height - 1)
                                   board[i, j].Neighbours.Add(board[i, j + 1]);
                               break;

                           case 3:
                               if (i - 1 >= 0)
                               {
                                   if (j - 1 >= 0)
                                       board[i, j].Neighbours.Add(board[i - 1, j - 1]);
                                   board[i, j].Neighbours.Add(board[i - 1, j]);
                               }
                               if (i + 1 < board.Size.Width - 1)
                               {
                                   if (j - 1 >= 0)
                                       board[i, j].Neighbours.Add(board[i + 1, j - 1]);
                                   board[i, j].Neighbours.Add(board[i + 1, j]);
                               }
                               if (j - 1 >= 0)
                                   board[i, j].Neighbours.Add(board[i, j - 1]);
                               break;

                           default:
                               break;
                       }
                   }
               }
           }
       }

       public static void initHexagonal(ref Board board)
       {
           for (int i = 0; i < board.Size.Width; i++)
           {
               for (int j = 0; j < board.Size.Height; j++)
               {
                   if (bc == "Periodic")
                   {
                       board[i % board.Size.Width, j % board.Size.Height].Neighbours = new List<Tile>();

                        int random =  RandomMachine.Random.Next(2);
                        switch (random)
                       {
                           case 0:
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + board.Size.Width) % board.Size.Width, (j - 1 + board.Size.Height) % board.Size.Height]);
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + 1 + board.Size.Width) % board.Size.Width, (j - 1 + board.Size.Height) % board.Size.Height]);

                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + 1 + board.Size.Width) % board.Size.Width, (j + board.Size.Height) % board.Size.Height]);
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i - 1 + board.Size.Width) % board.Size.Width, (j + board.Size.Height) % board.Size.Height]);

                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i - 1 + board.Size.Width) % board.Size.Width, (j + 1 + board.Size.Height) % board.Size.Height]);
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + board.Size.Width) % board.Size.Width, (j + 1 + board.Size.Height) % board.Size.Height]);
                               break;

                           case 1:

                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i - 1 + board.Size.Width) % board.Size.Width, (j - 1 + board.Size.Height) % board.Size.Height]);
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + board.Size.Width) % board.Size.Width, (j - 1 + board.Size.Height) % board.Size.Height]);

                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + 1 + board.Size.Width) % board.Size.Width, (j + board.Size.Height) % board.Size.Height]);
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i - 1 + board.Size.Width) % board.Size.Width, (j + board.Size.Height) % board.Size.Height]);

                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + board.Size.Width) % board.Size.Width, (j + 1 + board.Size.Height) % board.Size.Height]);
                               board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + 1 + board.Size.Width) % board.Size.Width, (j + 1 + board.Size.Height) % board.Size.Height]);
                               break;

                           default:
                               break;

                       }
                   }
                   if (bc == "Sorption")
                   {
                       board[i, j].Neighbours = new List<Tile>();
                        int random = RandomMachine.Random.Next(2);
                        switch (random)
                       {
                           case 0:
                                {
                                    if (i - 1 >= 0)
                                    {
                                        if (j - 1 >= 0)
                                            board[i, j].Neighbours.Add(board[i - 1, j - 1]);
                                        board[i, j].Neighbours.Add(board[i - 1, j]);
                                    }

                                    if (i + 1 < board.Size.Width - 1)
                                    {
                                        if (j + 1 < board.Size.Height - 1)
                                            board[i, j].Neighbours.Add(board[i + 1, j + 1]);
                                        board[i, j].Neighbours.Add(board[i + 1, j]);
                                    }

                                    if (j - 1 >= 0)
                                        board[i, j].Neighbours.Add(board[i, j - 1]);
                                    if (j + 1 < board.Size.Height - 1)
                                        board[i, j].Neighbours.Add(board[i, j + 1]);

                                    break;
                                }

                           case 1:
                                {
                                    if (i - 1 >= 0)
                                    {
                                        if (j + 1 < board.Size.Height - 1)
                                            board[i, j].Neighbours.Add(board[i - 1, j + 1]);
                                        board[i, j].Neighbours.Add(board[i - 1, j]);
                                    }
                                    if (i + 1 < board.Size.Width - 1)
                                    {
                                        if (j - 1 >= 0)
                                            board[i, j].Neighbours.Add(board[i + 1, j - 1]);
                                        board[i, j].Neighbours.Add(board[i + 1, j]);
                                    }

                                    if (j - 1 >= 0)
                                        board[i, j].Neighbours.Add(board[i, j - 1]);
                                    if (j + 1 < board.Size.Height - 1)
                                        board[i, j].Neighbours.Add(board[i, j + 1]);

                                    break;
                                }

                           default:
                               break;
                       }
                   }
               }
           }
       }

        public static void initHexagonalLeft(ref Board board)
        {
            for (int i = 0; i < board.Size.Width; i++)
            {
                for (int j = 0; j < board.Size.Height; j++)
                {
                    if (bc == "Periodic")
                    {
                        board[i % board.Size.Width, j % board.Size.Height].Neighbours = new List<Tile>();

                        board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i - 1 + board.Size.Width) % board.Size.Width, (j - 1 + board.Size.Height) % board.Size.Height]);
                        board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + board.Size.Width) % board.Size.Width, (j - 1 + board.Size.Height) % board.Size.Height]);

                        board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + 1) % board.Size.Width, (j + board.Size.Height) % board.Size.Height]);
                        board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i - 1 + board.Size.Width) % board.Size.Width, (j + board.Size.Height) % board.Size.Height]);

                        board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + board.Size.Width) % board.Size.Width, (j + 1 + board.Size.Height) % board.Size.Height]);
                        board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + 1) % board.Size.Width, (j + 1 + board.Size.Height) % board.Size.Height]);

                    }
                    if (bc == "Sorption")
                    {
                        board[i, j].Neighbours = new List<Tile>();

                        if (i - 1 >= 0)
                        {
                            if (j - 1 >= 0)
                                board[i, j].Neighbours.Add(board[i - 1, j - 1]);
                            board[i, j].Neighbours.Add(board[i - 1, j]);
                        }

                        if (i + 1 < board.Size.Width - 1)
                        {
                            if (j + 1 < board.Size.Height - 1)
                                board[i, j].Neighbours.Add(board[i + 1, j + 1]);
                            board[i, j].Neighbours.Add(board[i + 1, j]);
                        }

                        if (j - 1 >= 0)
                            board[i, j].Neighbours.Add(board[i, j - 1]);
                        if (j + 1 < board.Size.Height - 1)
                            board[i, j].Neighbours.Add(board[i, j + 1]);
                    }
                }
            }
        }

        public static void initHexagonalRight(ref Board board)
        {
            for (int i = 0; i < board.Size.Width; i++)
            {
                for (int j = 0; j < board.Size.Height; j++)
                {
                    if (bc == "Periodic")
                    {
                        board[i % board.Size.Width, j % board.Size.Height].Neighbours = new List<Tile>();
                        board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i - 1 + board.Size.Width) % board.Size.Width, (j + 1 + board.Size.Height) % board.Size.Height]);
                        board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + board.Size.Width) % board.Size.Width, (j + 1 + board.Size.Height) % board.Size.Height]);

                        board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + 1) % board.Size.Width, (j + board.Size.Height) % board.Size.Height]);
                        board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i - 1 + board.Size.Width) % board.Size.Width, (j + board.Size.Height) % board.Size.Height]);

                        board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + board.Size.Width) % board.Size.Width, (j - 1 + board.Size.Height) % board.Size.Height]);
                        board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[(i + 1) % board.Size.Width, (j - 1 + board.Size.Height) % board.Size.Height]);
                    }
                    if (bc == "Sorption")
                    {
                        board[i, j].Neighbours = new List<Tile>();

                        if (i - 1 >= 0)
                        {
                            if (j + 1 < board.Size.Height - 1)
                                board[i, j].Neighbours.Add(board[i - 1, j + 1]);
                            board[i, j].Neighbours.Add(board[i - 1, j]);
                        }
                        if (i + 1 < board.Size.Width - 1)
                        {
                            if (j - 1 >= 0)
                                board[i, j].Neighbours.Add(board[i + 1, j - 1]);
                            board[i, j].Neighbours.Add(board[i + 1, j]);
                        }

                        if (j - 1 >= 0)
                            board[i, j].Neighbours.Add(board[i, j - 1]);
                        if (j + 1 < board.Size.Height - 1)
                            board[i, j].Neighbours.Add(board[i, j + 1]);
                    }
                }
            }
        }


        public static void initRadius(ref Board board)
       {
           int radius = Convert.ToInt32(Prompt.ShowDialog("Podaj promień", ""));

           for (int i = 0; i < board.Size.Width; i++)
           {
               for (int j = 0; j < board.Size.Height; j++)
               {
                   board[i, j].newCenterOfMass();
               }
           }

           for (int i = 0; i < board.Size.Width; i++)
           {
               for (int j = 0; j < board.Size.Height; j++)
               {
                   if (bc == "Periodic")
                   {
                       board[i % board.Size.Width, j % board.Size.Height].Neighbours = new List<Tile>();
                       PointF first = board[i % board.Size.Width, j % board.Size.Height].CenterOfMass;
                       first = new PointF(first.X + Convert.ToSingle(i), first.Y + Convert.ToSingle(j));

                       for (int m = 0; m < board.Size.Width; m++)
                       {
                           for (int n = 0; n < board.Size.Height; n++)
                           {
                               PointF second = board[m % board.Size.Width, n % board.Size.Height].CenterOfMass;
                               second = new PointF(second.X + Convert.ToSingle(m), second.Y + Convert.ToSingle(n));
                               double x = Math.Abs(first.X - second.X);
                               if (board.Size.Width - x < x)
                                   x = board.Size.Width - x;
                               double y = Math.Abs(first.Y - second.Y);
                               if (board.Size.Height - y < y)
                                   y = board.Size.Height - y;
                               double r = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                               if (r <= radius)
                               {
                                   if (i % board.Size.Width != m % board.Size.Width || j % board.Size.Height != n % board.Size.Height)
                                   {
                                       board[i % board.Size.Width, j % board.Size.Height].Neighbours.Add(board[m % board.Size.Width, n % board.Size.Height]);
                                   }
                               }
                           }
                       }
                   }
                   if (bc == "Sorption")
                   {
                       board[i, j].Neighbours = new List<Tile>();

                       board[i, j].Neighbours = new List<Tile>();
                       PointF first = board[i, j].CenterOfMass;
                       first = new PointF(first.X + Convert.ToSingle(i), first.Y + Convert.ToSingle(j));

                       for (int m = 0; m < board.Size.Width; m++)
                       {
                           for (int n = 0; n < board.Size.Height; n++)
                           {
                               PointF second = board[m, n].CenterOfMass;
                               second = new PointF(second.X + Convert.ToSingle(m), second.Y + Convert.ToSingle(n));
                               double x = Math.Abs(first.X - second.X);
                               double y = Math.Abs(first.Y - second.Y);
                               double r = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                               if (r <= radius)
                               {
                                   if (i != m || j != n)
                                   {
                                       board[i, j].Neighbours.Add(board[m, n]);
                                   }
                               }
                           }
                       }
                   }

               }
           }
       }

   }
}
