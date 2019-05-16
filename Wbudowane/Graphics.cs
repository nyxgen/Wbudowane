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
            bitmap = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
        }

        public Size Size
        {
            get
            {
                return pictureBox.Size;
            }
        }

        public void draw(ref Board board)
        {
            for(int i = 0; i < board.Size.Width; i++)
            {
                for (int j = 0; j < board.Size.Height; j++)
                {
                    Point position = board[i, j].Position;
                    Size size = board[i, j].Size;
                    Color color = Color.FromArgb(board[i,j].State, board[i, j].State, board[i, j].State);
                    for(int k = 0; k < size.Width; k++)
                    {
                        for(int l = 0; l < size.Height; l++)
                        {
                            bitmap.SetPixel(position.X + k, position.Y + l, color);
                        }
                    }
                }
            }
            graphics.DrawImage(bitmap, 0,0);
        }
    }
}
