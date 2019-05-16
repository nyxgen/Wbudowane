using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wbudowane
{
    public class Tile
    {
        int state;
        Point position;
        Size size;
        public Tile(Point position, Size size)
        {
            state = 0;
            this.position = position;
            this.size = size;
        }

        public Tile(ref Tile tile)
        {
            state = tile.State;
            position = tile.Position;
            size = tile.Size;
        }
        public int State
        {
            set
            {
                state = value;
            }
            get
            {
                return state;
            }
        }

        public Point Position
        {
            set
            {
                position = value;
            }
            get
            {
                return position;
            }
        }
       
        public Size Size
        {
            set
            {
                size = value;
            }
            get
            {
                return size;
            }
        }
    }
}
