using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wbudowane
{
    public class Board
    {
        Size size;
        Tile[] tiles;
        public Board(Size size)
        {
            this.size = size;
            tiles = new Tile[size.Height * size.Width];
            int actSize;
            if (size.Width > size.Height)
                actSize = size.Width;
            else
                actSize = size.Height;

            for (uint i = 0; i < size.Width; i++)
            {
                for (uint j = 0; j < size.Height; j++)
                {
                    tiles[j * size.Width + i] = new Tile();
                }
            }
        }

        public Board(ref Board board)
        {
            this.size = board.size;
            tiles = new Tile[size.Height * size.Width];
            for (int i = 0; i < size.Width; i++)
            {
                for (int j = 0; j < size.Height; j++)
                {
                    tiles[j * size.Width + i] = new Tile(ref board[i,j]);
                }
            }
        }

        public ref Tile this[int i, int j]
        {
            get
            {
                if (i < size.Width && j < size.Height)
                {
                    return ref tiles[j * size.Width + i];
                }
                else
                {
                    throw new IndexOutOfRangeException("Tile not found");
                }
            }
        }

        public Size Size
        {
            get
            {
                return size;
            }
        }

        public void randomInit(int numberOfTiles)
        {
            for (int i = 0; i < size.Width; i++)
            {
                for (int j = 0; j < size.Height; j++)
                {
                    tiles[j * size.Width + i].State = Tuple.Create<int, int, int>(0, 0, 0);
                }
            }
            int m = 0;
            int error = 0;
            for (int i = 0; i < numberOfTiles; i++)
            {
                int rx = RandomMachine.Random.Next(size.Width-1);
                int ry = RandomMachine.Random.Next(size.Height-1);
                if (!tiles[ry * size.Width + rx].Alive)
                {
                    tiles[ry * size.Width + rx].State = Tuple.Create<int,int,int>(1 + RandomMachine.Random.Next(254), 1 + RandomMachine.Random.Next(254), 1 + RandomMachine.Random.Next(254));
                }
                else
                {
                    error++;
                    i--;
                }
                m = i + 1;
                if (error > size.Width * size.Height)
                {
                   
                    i = numberOfTiles;
                }
            }

            for (int i = 0; i < size.Width; i++)
            {
                for (int k = 0; k < size.Height; k++)
                {
                    if (m < numberOfTiles && !tiles[k * size.Width + i].Alive)
                    {
                        tiles[k * size.Width + i].State = Tuple.Create<int, int, int>(1 + RandomMachine.Random.Next(254), 1 + RandomMachine.Random.Next(254), 1 + RandomMachine.Random.Next(254));
                        m++;
                    }
                }
            }
            if (m < numberOfTiles)
             Prompt.ShowDialog("Wylosowano " + m.ToString());
        }

        public void homogeneousInit(int numberOfTilesInRow, int numberOfTilesInColumn)
        {
            if(numberOfTilesInRow > size.Width || numberOfTilesInColumn > size.Height)
            {
                Prompt.ShowDialog("Podano błędne dane");
                return;
            }

            for (int i = 0; i < size.Width; i++)
            {
                for (int j = 0; j < size.Height; j++)
                {
                    tiles[j * size.Width + i].State = Tuple.Create<int, int, int>(0, 0, 0);
                }
            }

            double dx = (1.0*size.Width)/(numberOfTilesInRow+1);
            double dy = (1.0*size.Height)/(numberOfTilesInColumn+1);
            for (int i = 1; i < numberOfTilesInRow+1; i++)
            {
              for(int j = 1; j < numberOfTilesInColumn+1; j++)
                {
                    tiles[(int)(Math.Floor(dy*j) * size.Width+Math.Floor(dx * i))].State = Tuple.Create<int,int,int>(RandomMachine.Random.Next(255), RandomMachine.Random.Next(255), RandomMachine.Random.Next(255));
                }
            }
        }

        public void radiusInit(int radius, int numberOfTiles, bool periodic)
        {
            for (int i = 0; i < size.Width; i++)
            {
                for (int j = 0; j < size.Height; j++)
                {
                    tiles[j * size.Width + i].State = Tuple.Create<int, int, int>(0, 0, 0);
                }
            }

            int error = 0;
            for (int i = 0; i < numberOfTiles; i++)
            {
                if (periodic)
                {
                    int rx = RandomMachine.Random.Next(size.Width - 1);
                    int ry = RandomMachine.Random.Next(size.Height - 1);
                    if (!tiles[ry * size.Width + rx].Alive)
                    {
                        bool inRange = false;
                        for(int m = 0; m < size.Width; ++m)
                        {
                            for(int n = 0; n < size.Height; ++n)
                            {
                                if (tiles[n * size.Width + m].Alive)
                                {
                                    double x = Math.Abs(rx - m);
                                    if (size.Width - x < x)
                                        x = size.Width - x;
                                    double y = Math.Abs(ry - n);
                                    if (size.Height - y < y)
                                        y = size.Height - y;
                                    double r = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                                    if (r <= radius)
                                    {
                                        inRange = true;
                                        m = size.Width;
                                        n = size.Height;
                                    }
                                }
                            }
                        }
                        if(inRange)
                        {
                            error++;
                            i--;
                        }
                        else
                            tiles[ry * size.Width + rx].State = Tuple.Create<int, int, int>(1 + RandomMachine.Random.Next(254), 1 + RandomMachine.Random.Next(254), 1 + RandomMachine.Random.Next(254));
                    }
                    else
                    {
                        error++;
                        i--;
                    }
                    if (error > size.Width * size.Height)
                    {
                        Prompt.ShowDialog("Wylosowano " + i);
                        i = numberOfTiles;
                    }
                }
                else
                {
                    int rx = RandomMachine.Random.Next(size.Width - 1);
                    int ry = RandomMachine.Random.Next(size.Height - 1);
                    if (!tiles[ry * size.Width + rx].Alive)
                    {
                        bool inRange = false;
                        for (int m = 0; m < size.Width; ++m)
                        {
                            for (int n = 0; n < size.Height; ++n)
                            {
                                if (tiles[n * size.Width + m].Alive)
                                {
                                    double x = Math.Abs(rx - m);
                                    double y = Math.Abs(ry - n);
                                    double r = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                                    if (r <= radius)
                                    {
                                        inRange = true;
                                        m = size.Width;
                                        n = size.Height;
                                    }
                                }
                            }
                        }
                        if (inRange)
                        {
                            error++;
                            i--;
                        }
                        else
                            tiles[ry * size.Width + rx].State = Tuple.Create<int, int, int>(1 + RandomMachine.Random.Next(254), 1 + RandomMachine.Random.Next(254), 1 + RandomMachine.Random.Next(254));
                    }
                    else
                    {
                        error++;
                        i--;
                    }
                    if (error > size.Width * size.Height)
                    {
                        Prompt.ShowDialog("Wylosowano " + i);
                        i = numberOfTiles;
                    }
                }
            }
        }

        public void clear()
        {
            for (int i = 0; i < size.Width; i++)
            {
                for (int j = 0; j < size.Height; j++)
                {
                    tiles[j * size.Width + i].State = Tuple.Create<int, int, int>(0, 0, 0);
                }
            }
        }

    }
}
