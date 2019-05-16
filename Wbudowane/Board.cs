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
            for (uint i = 0; i < size.Height; i++)
            {
                for (uint j = 0; j < size.Width; j++)
                {
                    tiles[j * size.Height + i] = new Tile(new Point((int)(Math.Floor(1.0 * i * drawSize.Width / size.Width)), (int)(Math.Floor(1.0 * j * drawSize.Height / size.Height))), new Size((int)(Math.Ceiling(1.0 * drawSize.Width / size.Width)), (int)(Math.Ceiling(1.0 * drawSize.Height / size.Height))));
                }
            }
        }

        public Board(ref Board board)
        {
            this.size = board.size;
            this.drawSize = board.drawSize;
            tiles = new Tile[size.Height * size.Width];
            for (int i = 0; i < size.Height; i++)
            {
                for (int j = 0; j < size.Width; j++)
                {
                    tiles[j * size.Height + i] = new Tile(ref board[i,j]);
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
                    return ref tmp[j * size.Height + i];
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

    }
}
