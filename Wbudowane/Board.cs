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
        Size drawSize;
        Size size;
        Tile[] tiles;
        public Board(Size size, Size drawSize)
        {
            this.size = size;
            this.drawSize = drawSize;
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
                    tiles[j * size.Width + i] = new Tile(new Point((int)(Math.Floor(1.0 * i * drawSize.Width / actSize)), (int)(Math.Floor(1.0 * j * drawSize.Height / actSize))), new Size((int)(Math.Ceiling(1.0 * drawSize.Width / actSize)), (int)(Math.Ceiling(1.0 * drawSize.Height / actSize))));
                }
            }
        }

        public Board(ref Board board)
        {
            this.size = board.size;
            this.drawSize = board.drawSize;
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
                Tile[] tmp = tiles.ToArray();
                if (i < size.Width && j < size.Height)
                {
                    return ref tmp[j * size.Width + i];
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

        public Size DrawSize
        {
            get
            {

                return drawSize;
            }
        }

        public void randomInit(int numberOfTiles, bool clear)
        {
            int actSize;
            if (size.Width > size.Height)
                actSize = size.Width;
            else
                actSize = size.Height;

            if (clear)
            {
                for (int i = 0; i < size.Width; i++)
                {
                    for (int j = 0; j < size.Height; j++)
                    {
                        tiles[j * size.Width + i] = new Tile(new Point((int)(Math.Floor(1.0 * i * drawSize.Width / actSize)), (int)(Math.Floor(1.0 * j * drawSize.Height / actSize))), new Size((int)(Math.Floor(1.0 * drawSize.Width / actSize)), (int)(Math.Floor(1.0 * drawSize.Height / actSize))));
                    }
                }
            }

            Random r = new Random();
            int error = 0;
            for (int i = 0; i < numberOfTiles; i++)
            {
                int rx = r.Next(size.Width);
                int ry = r.Next(size.Height);
                int state = r.Next(254);
                if (tiles[ry * size.Width + rx].State == 0)
                {
                    tiles[ry * size.Width + rx].State = 1 + state;
                }
                else
                {
                    error++;
                    i--;
                }
                if (error > size.Width * size.Height)
                {
                    i = numberOfTiles;
                }
            }
        }

        public void homogeneousInit(int numberOfTilesInRow, int numberOfTilesInColumn)
        {

            if (numberOfTilesInRow > size.Width)
                return;
            if (numberOfTilesInColumn > size.Height)
                return;

            numberOfTilesInRow += 1;
            numberOfTilesInColumn += 1;

            int actSize;
            if (size.Width > size.Height)
                actSize = size.Width;
            else
                actSize = size.Height;

            for (int i = 0; i < size.Width; i++)
            {
                for (int j = 0; j < size.Height; j++)
                {
                    tiles[j * size.Width + i] = new Tile(new Point((int)(Math.Floor(1.0 * i * drawSize.Width / actSize)), (int)(Math.Floor(1.0 * j * drawSize.Height / actSize))), new Size((int)(Math.Ceiling(1.0 * drawSize.Width / actSize)), (int)(Math.Ceiling(1.0 * drawSize.Height / actSize))));
                }
            }
            int dx = size.Width/(numberOfTilesInRow);
            int dy = size.Height/(numberOfTilesInColumn);
            int dS = 255 / (numberOfTilesInColumn * numberOfTilesInRow);
            for (int i = 0; i < numberOfTilesInRow; i++)
            {
              for(int j = 0; j < numberOfTilesInColumn; j++)
                {
                    tiles[dy*j * size.Width + dx * i].State = dS * i * j;
                }
            }
        }

        public void radiusInit(int radius, int numberOfTiles)
        {
            int actSize;
            if (size.Width > size.Height)
                actSize = size.Width;
            else
                actSize = size.Height;

            for (int i = 0; i < size.Width; i++)
            {
                for (int j = 0; j < size.Height; j++)
                {
                    tiles[j * size.Width + i] = new Tile(new Point((int)(Math.Floor(1.0 * i * drawSize.Width / actSize)), (int)(Math.Floor(1.0 * j * drawSize.Height / actSize))), new Size((int)(Math.Ceiling(1.0 * drawSize.Width / actSize)), (int)(Math.Ceiling(1.0 * drawSize.Height / actSize))));
                }
            }

            Random r = new Random();
            int error = 0;
            for (int i = 0; i < numberOfTiles; i++)
            {
                int rx = r.Next(size.Width);
                int ry = r.Next(size.Height);
                int state = r.Next(254);
                if (tiles[rx * size.Width + rx].State == 0)
                {
                    int minX, maxX, minY, maxY;
                    if (rx - radius < 0)
                        minX = 0;
                    else
                        minX = rx - radius;

                    if (rx + radius > size.Width - 1)
                        maxX = size.Width - 1;
                    else
                        maxX = rx + radius;

                    if (ry - radius < 0)
                        minY = 0;
                    else
                        minY = ry - radius;

                    if (ry + radius > size.Height - 1)
                        maxY = size.Height - 1;
                    else
                        maxY = ry + radius;

                    bool isInRange = false;
                    for (int j = minX; j <= maxX; j++)
                    {
                        for (int k = minY; k <= maxY; k++)
                        {
                            if (tiles[k * size.Width + j].State != 0)
                                isInRange = true;
                        }
                    }
                    if (isInRange)
                    {
                        error++;
                        i--;
                    }
                    else
                        tiles[ry * size.Width + rx].State = 1 + state;
                }
                else
                {
                    error++;
                    i--;
                }
                if (error > size.Width * size.Height)
                {
                    i = numberOfTiles;
                }
            }
        }


    }
}
