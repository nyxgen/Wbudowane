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
        Tuple <int, int, int>state;
        List<Tile> neighbours;
        bool alive;
        PointF centerOfMass;
        public Tile()
        {
            neighbours = new List<Tile>();
            state = Tuple.Create<int,int,int>(0,0,0);
            alive = false;
            centerOfMass = new PointF(Convert.ToSingle(RandomMachine.Random.NextDouble()), Convert.ToSingle(RandomMachine.Random.NextDouble()));
        }

        public Tile(ref Tile tile)
        {
            state = tile.State;
            neighbours = new List<Tile>();
            if (state.Item1 == 0 && state.Item2 == 0 && state.Item3 == 0)
                alive = false;
            else
                alive = true;
            centerOfMass = tile.CenterOfMass;
        }
        public Tuple<int,int,int> State
        {
            set
            {
                state = value;
                if (state.Item1 == 0 && state.Item2 == 0 && state.Item3 == 0)
                    alive = false;
                else
                    alive = true;
            }
            get
            {
                return state;
            }
        }

        public bool Alive
        {
            get
            {
                return alive;
            }
        }

        public PointF CenterOfMass
        {
            get
            {
                return centerOfMass;
            }
        }

        public void newCenterOfMass()
        {
            centerOfMass = new PointF(Convert.ToSingle(RandomMachine.Random.NextDouble()), Convert.ToSingle(RandomMachine.Random.NextDouble()));
        }

        public ref List<Tile> Neighbours
        {
            get
            {
                return ref neighbours;
            }
        }
    }
}
