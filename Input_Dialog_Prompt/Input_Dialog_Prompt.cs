using System.Windows.Forms;
using System.Drawing;
using System;
namespace Dialog
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption, string phold = null)
        {
            int h = Convert.ToInt32(Math.Round(((Graphics.FromImage(new Bitmap(1, 1))).MeasureString(text, new Font("Calibri", 12)).Height)));
            Form prompt = new Form()
            {
                Width = 500,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                Font = new Font("Calibri", 12)
            };
            Label textLabel = new Label() { AutoSize = false, Height = h, Left = 50, Top = 20, Width = 400, Text = text, Font = new Font("Calibri", 12) };
            TextBox textBox = new TextBox() { Size = new Size(400, 100), Left = 50, Top = (h + 30), Font = new Font("Calibri", 12) };
            if (phold != null)
            {
                textBox.Text = phold;
            };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = (h + 60), Font = new Font("Calibri", 12), DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}