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

            DrawArea = new Bitmap(MainPictureBox.Size.Width, MainPictureBox.Size.Height);
            MainPictureBox.Image = DrawArea;
            G = Graphics.FromImage(DrawArea);
          

            CheckBoxes = new CheckBox[] 
            {
                checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6,
                checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12
            };

            foreach (var box in CheckBoxes)
            {
                box.CheckedChanged += (s, e) => UpdatePictureBox();
            }


            Frequencies = new double[12];
            for (int i = 0; i < Frequencies.Length; i++)
            {
                Frequencies[i] = Math.PI * 2 + Math.PI / 6 * i;
            }
        }



        private void MainForm_Shown(object sender, EventArgs e)
        {
            UpdatePictureBox();
        } 



        private void DrawСoordinatesGrid()
        {           
            Pen pen = new Pen(Brushes.Black);
            G.DrawLine(pen, 0, MainPictureBox.Size.Height / 2, MainPictureBox.Size.Width, MainPictureBox.Size.Height / 2);
        }



        private void DrawFrequencies()
        {
            //Pen pen = new Pen(Brushes.Red);

            for (int x = 0; x < MainPictureBox.Width; x++)
            {
                int y = MainPictureBox.Height / 2;

                for (int i = 0; i < CheckBoxes.Length; i++)
                {
                    if (CheckBoxes[i].Checked)
                    {
                        y += (int) (Math.Sin((MainPictureBox.Width / 2 + x) / (Frequencies[i] * 5)) * 50);
                    }
                }
                G.FillRectangle(Brushes.Red, x, y, 1, 1);
            }         
        }



        private void UpdatePictureBox()
        {
            G.Clear(Color.White);
            DrawСoordinatesGrid();
            DrawFrequencies();
            MainPictureBox.Refresh();
        }
    }
}
