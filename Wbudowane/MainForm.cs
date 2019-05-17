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
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            graphics = new Graphics(ref mainPictureBox);
            board = new Board(new Size(50, 50), graphics.Size);
            bcComboBox.SelectedIndex = 0;
            Simulation.BC = bcComboBox.SelectedItem.ToString();
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            graphics.draw(ref board);
        }

        private void nextItterationButton_Click(object sender, EventArgs e)
        {
            Simulation.nextItteration(ref board, otherModeCheckBox.Checked);
            graphics.draw(ref board);
        }

        private void randomInitButton_Click(object sender, EventArgs e)
        {
            bool ready = true;
            int numberOfTiles = 1;
            while (ready)
            {
                try
                {
                    string response = Prompt.ShowDialog("How many?", "");
                    numberOfTiles = Convert.ToInt32(response);
                    ready = false;
                }
                catch(Exception exception)
                {
                }
            }
            board.randomInit(numberOfTiles, true);
            graphics.draw(ref board);
        }

        private void homogeneousInitButton_Click(object sender, EventArgs e)
        {
            bool ready = true;
            int numberOfTilesX = 1;
            while (ready)
            {
                try
                {
                    string response = Prompt.ShowDialog("In row:", "");
                    numberOfTilesX = Convert.ToInt32(response);
                    ready = false;
                }
                catch (Exception exception)
                {
                }
            }

            ready = true;
            int numberOfTilesY = 1;
            while (ready)
            {
                try
                {
                    string response = Prompt.ShowDialog("In column:", "");
                    numberOfTilesY = Convert.ToInt32(response);
                    ready = false;
                }
                catch (Exception exception)
                {
                }
            }
            board.homogeneousInit(numberOfTilesX, numberOfTilesY);
            graphics.draw(ref board);
        }

        private void radiusInitButton_Click(object sender, EventArgs e)
        {
            bool ready = true;
            int radius= 1;
            while (ready)
            {
                try
                {
                    string response = Prompt.ShowDialog("Radius:", "");
                    radius = Convert.ToInt32(response);
                    ready = false;
                }
                catch (Exception exception)
                {
                }
            }
            ready = true;

            int numberOfTiles = 1;
            while (ready)
            {
                try
                {
                    string response = Prompt.ShowDialog("How many?", "");
                    numberOfTiles = Convert.ToInt32(response);
                    ready = false;
                }
                catch (Exception exception)
                {
                }
            }
            board.radiusInit(radius, numberOfTiles);
            graphics.draw(ref board);
        }

        private void mainPictureBox_Click(object sender, EventArgs e)
        {
            Point mousePosition = this.PointToClient(Cursor.Position);
            Point relativeMousePosition = new Point(mousePosition.X - mainPictureBox.Left, mousePosition.Y - mainPictureBox.Top);
            int val = 0;
            try
            {
                val = Convert.ToInt32(manualInitTextbox.Text);
            }
            catch(Exception exception)
            {
                return;
            }

            if (val < 0)
                val = 0;
            if (val > 254)
                val = 254;
            int actSize;

            Point chosenPosition = new Point((int)(board.Size.Width * 1.0 * relativeMousePosition.X / (board[0,0].Size.Width*board.Size.Width)), (int)(board.Size.Height * 1.0 * relativeMousePosition.Y / (board[0,0].Size.Height*board.Size.Height)));

            try
            {
                board[chosenPosition.X, chosenPosition.Y].State = val;
            }
            catch(Exception exception) { };
            graphics.draw(ref board);

        }

        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            int val = 0;
            try
            {
                val = Convert.ToInt32(manualInitTextbox.Text);
            }
            catch(Exception exception)
            {
                return;
            }
            val += (int)(1.0* e.Delta/50);
            if (val > 254)
                val = 254;
            if (val < 0)
                val = 0;
            manualInitTextbox.Text = Convert.ToString(val);
        }

        private void bcComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Simulation.BC = bcComboBox.SelectedItem.ToString();
        }

        private void resizeButton_Click(object sender, EventArgs e)
        {
            graphics.graphicsClear();
            bool ready = true;
            int sizeX = 1;
            while (ready)
            {
                try
                {
                    string response = Prompt.ShowDialog("Width:", "");
                    sizeX = Convert.ToInt32(response);
                    if (sizeX <= 0)
                        throw new ArgumentOutOfRangeException();
                    ready = false;
                }
                catch (Exception exception)
                {
                }
            }

            ready = true;
            int sizeY = 1;
            while (ready)
            {
                try
                {
                    string response = Prompt.ShowDialog("Height:", "");
                    sizeY = Convert.ToInt32(response);
                    if (sizeY <= 0)
                        throw new ArgumentOutOfRangeException();
                    ready = false;
                }
                catch (Exception exception)
                {
                }
            }
            board = new Board(new Size(sizeX, sizeY), mainPictureBox.Size);
            graphics.draw(ref board);
        }

        private void toEndButton_Click(object sender, EventArgs e)
        {
            do
            {
                Simulation.nextItteration(ref board, otherModeCheckBox.Checked);
                graphics.draw(ref board);
                if (createCheckBox.Checked)
                {
                    Random rand = new Random();
                    if (rand.Next(4) == 1)
                    {
                        board.randomInit(rand.Next(4), false);
                    }
                }
            }
            while (Simulation.Ended == false);
        }

        private void clearBoardButton_Click(object sender, EventArgs e)
        {
            board = new Board(new Size(board.Size.Width, board.Size.Height), mainPictureBox.Size);
            graphics.draw(ref board);
        }
    }

    
}
