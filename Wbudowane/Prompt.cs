using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wbudowane
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 150,
                Height = 100,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false,
                ControlBox = false,
                BackColor = System.Drawing.SystemColors.AppWorkspace
        };
            Label textLabel = new Label() { Left = 10, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 10, Top = 40, Width = 125, BackColor = System.Drawing.Color.Silver };
            Button confirmation = new Button() { Text = "Ok", Left = 10, Width = 125, Top = 70, DialogResult = DialogResult.OK, BackColor = System.Drawing.SystemColors.AppWorkspace, FlatStyle = System.Windows.Forms.FlatStyle.Popup };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        public static void ShowDialog(string text)
        {
            Form prompt = new Form()
            {
                Width = 200,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = text,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false,
                ControlBox = false,
                BackColor = System.Drawing.SystemColors.AppWorkspace
            };
            Label textLabel = new Label() { Left = 10, Top = 20, Text = text };
            Button confirmation = new Button() { Text = "Ok", Left = 10, Width = 125, Top = 70, DialogResult = DialogResult.OK, BackColor = System.Drawing.SystemColors.AppWorkspace, FlatStyle = System.Windows.Forms.FlatStyle.Popup };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            prompt.ShowDialog();
        }
    }
}
