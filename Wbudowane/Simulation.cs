using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wbudowane
{
    public class Simulation
    {
        public static void nextItteration(ref Board board)
        {
            Random rand = new Random();
            Board prevBoard = new Board(ref board);
            for(int i = 0; i < board.Size.Width; i++)
            {
                for(int j = 0; j < board.Size.Height; j++)
                {
                    if (prevBoard[i,j].State != 0)
                    {
                        int val = rand.Next(4);

                        switch (val)
                        { 
                            case 0:
                                if (j - 1 >= 0 && board[i, j - 1].State == 0)
                                    board[i, j - 1].State = board[i, j].State;
                                break;

                            case 1:
                                if (j + 1 < board.Size.Height && board[i, j + 1].State == 0)
                                    board[i, j + 1].State = board[i, j].State;
                                break;

                            case 2:
                                if (i - 1 >= 0 && board[i - 1, j].State == 0)
                                    board[i-1, j].State = board[i, j].State;
                                break;

                            case 3:
                                if (i + 1 < board.Size.Width && board[i + 1, j].State == 0)
                                    board[i + 1, j].State = board[i, j].State;
                                break;
                        }
                        
                    }
                }
            }
        }
    }
}
