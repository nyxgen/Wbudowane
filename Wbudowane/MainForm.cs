using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wbudowane
{
    public partial class MainForm : Form
    {
        Graphics graphics;
        Board board;
        public MainForm()
        {
            InitializeComponent();
            graphics = new Graphics(ref mainPictureBox);
            board = new Board(new Size(50, 50), graphics.Size);
            board[10, 10].State = 125;
            board[25, 25].State = 200;
            board[49, 49].State = 170;
            board[5, 45].State = 50;
            board[45, 10].State = 225;
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            graphics.draw(ref board);
        }

        private void nextItterationButton_Click(object sender, EventArgs e)
        {
            Simulation.nextItteration(ref board);
            graphics.draw(ref board);
        }
    }

    
}
