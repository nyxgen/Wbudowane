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
            board = new Board(new Size(50, 50));
            bcComboBox.SelectedIndex = 0;
            neighbourhoodComboBox.SelectedIndex = 0;
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            graphics.draw(ref board, centerOfMassCheckBox.Checked);
        }

        private void nextItterationButton_Click(object sender, EventArgs e)
        {
            Simulation.nextItteration(ref board);
            graphics.draw(ref board, centerOfMassCheckBox.Checked);
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
            board.randomInit(numberOfTiles);
            graphics.draw(ref board, centerOfMassCheckBox.Checked);
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
            graphics.draw(ref board, centerOfMassCheckBox.Checked);
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
            if(Simulation.BC == "Periodic")
                board.radiusInit(radius, numberOfTiles, true);
            else
                board.radiusInit(radius, numberOfTiles, false);
            graphics.draw(ref board, centerOfMassCheckBox.Checked);
        }

        private void mainPictureBox_Click(object sender, EventArgs e)
        {
            Point mousePosition = this.PointToClient(Cursor.Position);
            Point relativeMousePosition = new Point(mousePosition.X - mainPictureBox.Left, mousePosition.Y - mainPictureBox.Top);
            int r = 0;
            int g = 0;
            int b = 0;
            try
            {
                r = Convert.ToInt32(manualInitRTextbox.Text);
                g = Convert.ToInt32(manualInitGTextbox.Text);
                b = Convert.ToInt32(manualInitBTextbox.Text);
            }
            catch(Exception exception)
            {
                return;
            }

            if (r < 0)
                r = 0;
            if (r > 254)
                r = 254;

            if (g < 0)
                g = 0;
            if (g > 254)
                g = 254;

            if (b < 0)
                b = 0;
            if (b > 254)
                b = 254;

            Size boardDrawSize = new Size(board.Size.Width, board.Size.Height);

            Point chosenPosition = new Point((int)(boardDrawSize.Width * 1.0 * relativeMousePosition.X / graphics.Size.Width), (int)(boardDrawSize.Height * 1.0 * relativeMousePosition.Y / graphics.Size.Height));
            MouseEventArgs me = (MouseEventArgs)e;
            try
            {
                if(me.Button == System.Windows.Forms.MouseButtons.Left)
                    board[chosenPosition.X, chosenPosition.Y].State = Tuple.Create<int,int,int>(r,g,b);
                if(me.Button == System.Windows.Forms.MouseButtons.Right)
                    board[chosenPosition.X, chosenPosition.Y].State = Tuple.Create<int, int, int>(0, 0, 0);
            }
            catch(Exception exception) { };
            graphics.draw(ref board, centerOfMassCheckBox.Checked);

        }

        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            int r = 0;
            int g = 0;
            int b = 0;
            try
            {
                r = Convert.ToInt32(manualInitRTextbox.Text);
                g = Convert.ToInt32(manualInitGTextbox.Text);
                b = Convert.ToInt32(manualInitBTextbox.Text);
            }
            catch(Exception exception)
            {
                return;
            }
            r += (int)(1.0 * e.Delta / 50);
            g += (int)(1.0 * e.Delta / 50);
            b += (int)(1.0 * e.Delta / 50);

            if (r > 254)
                r = 254;
            if (r < 0)
                r = 0;

            if (g < 0)
                g = 0;
            if (g > 254)
                g = 254;

            if (b < 0)
                b = 0;
            if (b > 254)
                b = 254;
            manualInitRTextbox.Text = Convert.ToString(r);
            manualInitGTextbox.Text = Convert.ToString(g);
            manualInitBTextbox.Text = Convert.ToString(b);
        }

        private void bcComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Simulation.BC = bcComboBox.SelectedItem.ToString();
            Simulation.init(ref board);
        }

        private void neighbourhoodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Simulation.Neighbourhood = neighbourhoodComboBox.SelectedItem.ToString();
            Simulation.init(ref board);
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
            board = new Board(new Size(sizeX, sizeY));
            Simulation.initVonNeumann(ref board);
            graphics.draw(ref board, centerOfMassCheckBox.Checked);
        }

        private void toEndButton_Click(object sender, EventArgs e)
        {
            do
            {
                Simulation.nextItteration(ref board);
                graphics.draw(ref board, centerOfMassCheckBox.Checked);
            }
            while (Simulation.Ended == false);
        }

        private void clearBoardButton_Click(object sender, EventArgs e)
        {
            board.clear();
            graphics.draw(ref board, centerOfMassCheckBox.Checked);
        }

        private void centerOfMassCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            graphics.draw(ref board, centerOfMassCheckBox.Checked);
        }

        private void monteCarloButton_Click(object sender, EventArgs e)
        {
            string response = Prompt.ShowDialog("How many?", "");
            int n = 1;
            try
            {
                n = Convert.ToInt32(response);
            }
            catch(Exception exc)
            {

            }
            for (int i = 0; i < n; ++i)
            {
                Simulation.monteCarlo(ref board);
                graphics.draw(ref board, centerOfMassCheckBox.Checked);
            }
        }
    }

    
}
