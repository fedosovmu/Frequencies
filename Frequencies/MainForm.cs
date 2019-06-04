using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frequencies
{
    public partial class MainForm : Form
    {
        Bitmap DrawArea;
        Graphics G;
        double[] Frequencies;
        CheckBox[] CheckBoxes;


        public MainForm()
        {
            InitializeComponent();

            DrawArea = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            pictureBox.Image = DrawArea;
            G = Graphics.FromImage(DrawArea);

            checkBox1.Checked = true;
            CheckBoxes = new CheckBox[] 
            {
                checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6,
                checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12,
                checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18,
                checkBox19, checkBox20, checkBox21, checkBox22, checkBox23, checkBox24
            };

            trackBar.ValueChanged += (s, e) => UpdatePictureBox();
            foreach (var box in CheckBoxes)
            {
                box.CheckedChanged += (s, e) => UpdatePictureBox();
            }           


            Frequencies = new double[CheckBoxes.Length];
            for (int i = 0; i < Frequencies.Length; i++)
            {
                Frequencies[i] = Math.PI * 2 + (Math.PI / 6 * i);
            }
        }



        private void MainForm_Shown(object sender, EventArgs e)
        {
            UpdatePictureBox();
        } 



        private void DrawСoordinatesGrid()
        {           
            Pen pen = new Pen(Brushes.Black);
            G.DrawLine(pen, 0, pictureBox.Height / 2, pictureBox.Width, pictureBox.Height / 2);
            G.DrawLine(pen, pictureBox.Width / 2, 0, pictureBox.Width / 2, pictureBox.Height);
        }



        private void DrawFrequencies()
        {
            Pen pen = new Pen(Brushes.Red);
            int? lastY = null;

            for (int x = 0; x < pictureBox.Width; x++)
            {
                int y = pictureBox.Height / 2;

                for (int i = 0; i < CheckBoxes.Length; i++)
                {
                    if (CheckBoxes[i].Checked)
                    {
                        y += (int) (Math.Sin((x - (pictureBox.Width / 2)) / (Frequencies[i] * (25.0 / trackBar.Value))) * 50);
                    }
                }
                //G.FillRectangle(Brushes.Red, x, y, 1, 1);

                if (lastY == null) lastY = y;
                G.DrawLine(pen, x - 1, (float)lastY, x, y);
                lastY = y;
            }         
        }



        private void UpdatePictureBox()
        {
            G.Clear(Color.White);
            DrawСoordinatesGrid();
            DrawFrequencies();
            pictureBox.Refresh();
        }
    }
}
