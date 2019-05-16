using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wbudowane
{
    public abstract class Simulation
    {
        static string bc = "";
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

        public static bool Ended
        {
            get
            {
                return ended;
            }
        }

        public static bool nextItteration(ref Board board, bool randomDirection)
        {
            ended = true;
            if (bc == "Sorption")
                nextItterationAbsorbing(ref board, randomDirection);
            else if (bc == "Periodic")
                nextItterationPeriodic(ref board, randomDirection);
            return ended;
        }

        private static void nextItterationAbsorbing(ref Board board, bool randomDirection)
        {
            Random rand = new Random();
            Board prevBoard = new Board(ref board);
            for (int i = 0; i < board.Size.Width; i++)
            {
                for (int j = 0; j < board.Size.Height; j++)
                {
                    if (prevBoard[i, j].State != 0)
                    {
                        if (randomDirection)
                        {
                            int val = rand.Next(4);

                            switch (val)
                            {
                                case 0:
                                    if (j - 1 >= 0 && board[i, j - 1].State == 0)
                                    {
                                        board[i, j - 1].State = board[i, j].State;
                                        ended = false;
                                    }
                                    break;

                                case 1:
                                    if (j + 1 < board.Size.Height && board[i, j + 1].State == 0)
                                    {
                                        board[i, j + 1].State = board[i, j].State;
                                        ended = false;
                                    }
                                    break;

                                case 2:
                                    if (i - 1 >= 0 && board[i - 1, j].State == 0)
                                    {
                                        board[i - 1, j].State = board[i, j].State;
                                        ended = false;
                                    }
                                    break;

                                case 3:
                                    if (i + 1 < board.Size.Width && board[i + 1, j].State == 0)
                                    {
                                        board[i + 1, j].State = board[i, j].State;
                                        ended = false;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            if (j - 1 >= 0 && board[i, j - 1].State == 0)
                            {
                                board[i, j - 1].State = board[i, j].State;
                                ended = false;
                            }
                            if (j + 1 < board.Size.Height && board[i, j + 1].State == 0)
                            {
                                board[i, j + 1].State = board[i, j].State;
                                ended = false;
                            }
                            if (i - 1 >= 0 && board[i - 1, j].State == 0)
                            {
                                board[i - 1, j].State = board[i, j].State;
                                ended = false;
                            }
                            if (i + 1 < board.Size.Width && board[i + 1, j].State == 0)
                            {
                                board[i + 1, j].State = board[i, j].State;
                                ended = false;
                            }
                        }

                    }
                }
            }
        }

        private static void nextItterationPeriodic(ref Board board, bool randomDirection)
        {
            Random rand = new Random();
            Board prevBoard = new Board(ref board);
            for (int i = 0; i < board.Size.Width; i++)
            {
                for (int j = 0; j < board.Size.Height; j++)
                {
                    if (prevBoard[i, j].State != 0)
                    {
                        if (randomDirection)
                        {
                            int val = rand.Next(4);

                            switch (val)
                            {
                                case 0:
                                    if (board[i, (j - 1 + board.Size.Height) % board.Size.Height].State == 0)
                                    {
                                        board[i, (j - 1 + board.Size.Height) % board.Size.Height].State = board[i, j].State;
                                        ended = false;
                                    }
                                    break;

                                case 1:
                                    if (board[i, (j + 1) % board.Size.Height].State == 0)
                                    {
                                        board[i, (j + 1) % board.Size.Height].State = board[i, j].State;
                                        ended = false;
                                    }
                                    break;

                                case 2:
                                    if (board[(i - 1 + board.Size.Width) % board.Size.Width, j].State == 0)
                                    {
                                        board[(i - 1 + board.Size.Width) % board.Size.Width, j].State = board[i, j].State;
                                        ended = false;
                                    }
                                    break;

                                case 3:
                                    if (board[(i + 1) % board.Size.Width, j].State == 0)
                                    {
                                        board[(i + 1) % board.Size.Width, j].State = board[i, j].State;
                                        ended = false;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            if (board[i, (j - 1 + board.Size.Height) % board.Size.Height].State == 0)
                            {
                                board[i, (j - 1 + board.Size.Height) % board.Size.Height].State = board[i, j].State;
                                ended = false;
                            }
                            if (board[i, (j + 1) % board.Size.Height].State == 0)
                            {
                                board[i, (j + 1) % board.Size.Height].State = board[i, j].State;
                                ended = false;
                            }
                            if (board[(i - 1 + board.Size.Width) % board.Size.Width, j].State == 0)
                            {
                                board[(i - 1 + board.Size.Width) % board.Size.Width, j].State = board[i, j].State;
                                ended = false;
                            }
                            if (board[(i + 1) % board.Size.Width, j].State == 0)
                            {
                                board[(i + 1) % board.Size.Width, j].State = board[i, j].State;
                                ended = false;
                            }
                        }

                    }
                }
            }
        }
    }
}
