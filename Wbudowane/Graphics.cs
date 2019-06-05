using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wbudowane
{
   
    public class Graphics
    {
        PictureBox pictureBox;
        System.Drawing.Graphics graphics;
        Bitmap bitmap;

        public Graphics( ref PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            graphics = pictureBox.CreateGraphics();
        }

        public Size Size
        {
            get
            {
                return pictureBox.Size;
            }
        }

        public Size BitmapSize
        {
            get
            {
                return bitmap.Size;
            }
            set
            {
                bitmap = new Bitmap(value.Width, value.Height);
            }
        }

        public void draw(ref Board board, bool centersOfMasses, bool energy, bool density)
        {
            bitmap = new Bitmap(board.Size.Width+1, board.Size.Height+1);
            for(int i = 0; i < board.Size.Width; i++)
            {
                for (int j = 0; j < board.Size.Height; j++)
                {
                    Color color;
                    if (energy)
                        color = Color.FromArgb(0, board[i, j].Energy * 10 % 255, 0);
                    else
                    {
                        if (density)
                            color = Color.FromArgb(0, Convert.ToInt32(board[i, j].Density/20000) % 255, 0);
                        else
                            color = Color.FromArgb(board[i, j].State.Item1, board[i, j].State.Item2, board[i, j].State.Item3);
                    }
                    bitmap.SetPixel(i+1, j+1, color);
                }
            }
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            float width = 1;
            float height = 1;
            if (bitmap.Width > bitmap.Height)
            {
                width = pictureBox.Width;
                height = pictureBox.Height * bitmap.Height / bitmap.Width;
            }
            else
            {
                width = pictureBox.Width * bitmap.Width / bitmap.Height;
                height = pictureBox.Height;
            }
            PointF cellSize = new PointF(Convert.ToSingle(1.0 * pictureBox.Width/ bitmap.Width), Convert.ToSingle(1.0 * pictureBox.Height / bitmap.Height));
            graphics.DrawImage(bitmap, 0, 0, width, height);  
            if(centersOfMasses)
            {
                for (int i = 0; i < board.Size.Width; i++)
                {
                    for (int j = 0; j < board.Size.Height; j++)
                    {
                        Rectangle point = new Rectangle(new Point((int)((i + 1 + board[i, j].CenterOfMass.X) * cellSize.X), (int)((j + 1 + board[i, j].CenterOfMass.Y) * cellSize.Y)), new Size(2,2));
                        graphics.FillEllipse(new SolidBrush(Color.Red), point);
                    }
                }
            }
        }

        public void graphicsClear()
        {
            graphics.Clear(Color.Black);
            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
        }
    }
}
