using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Geometry_Bash
{
    public partial class OptionsMenu : Form
    {
        //fields
        // IF THESE ARE SWITCHED, SWITCH IN FORM TEXT BOXES TOO
        private double squareH = 10;
        private double circleH = 10;
        private double diamondH = 10;
        private double squareD = 1;
        private double circleD = 1;
        private double diamondD = 1;
        private double squareS = 5;
        private double circleS = 5;
        private double diamondS = 5;

        // properties
        public double SquareH { get { return squareH; } }
        public double CircleH { get { return circleH; } }
        public double DiamondH { get { return diamondH; } }
        public double SquareD { get { return squareD; } }
        public double CircleD { get { return circleD; } }
        public double DiamondD { get { return diamondD; } }
        public double SquareS { get { return squareS; } }
        public double CircleS { get { return circleS; } }
        public double DiamondS { get { return diamondS; } }


        public OptionsMenu()
        {
            InitializeComponent();
        }

        private void SquareTextBox_TextChanged(object sender, EventArgs e)
        {
            squareH = double.Parse(SquareTextBox.Text);
        }

        private void CircleTextBox_TextChanged(object sender, EventArgs e)
        {
            circleH = double.Parse(CircleTextBox.Text);
        }

        private void DiamondTextBox_TextChanged(object sender, EventArgs e)
        {
            diamondH = double.Parse(DiamondTextBox.Text);
        }

        private void SquareDamageText_TextChanged(object sender, EventArgs e)
        {
            squareD = double.Parse(SquareDamageText.Text);
        }

        private void CircleDamageText_TextChanged(object sender, EventArgs e)
        {
            circleD = double.Parse(CircleDamageText.Text);
        }

        private void DiamondDamageText_TextChanged(object sender, EventArgs e)
        {
            diamondD = double.Parse(DiamondDamageText.Text);
        }

        private void SquareSpeedText_TextChanged(object sender, EventArgs e)
        {
            squareS = double.Parse(SquareSpeedText.Text);
        }

        private void CircleSpeedText_TextChanged(object sender, EventArgs e)
        {
            circleS = double.Parse(CircleSpeedText.Text);
        }

        private void DiamondSpeedText_TextChanged(object sender, EventArgs e)
        {
            diamondS = double.Parse(DiamondSpeedText.Text);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //outout is "squareHealth,circleHealth,diamondHealth,squareDamage,circleDamage,diamondDiamond,squareSpeed,circleSpeed,diamondSpeed"

            string output = squareH + "," + circleH + "," + diamondH + "," +
                            squareD + "," + circleD + "," + diamondD + "," +
                            squareS + "," + circleS + "," + diamondS + ",";

            try
            {
                StreamWriter fileOut = new StreamWriter(File.OpenRead("stats.txt"));
                fileOut.Write(output);
                fileOut.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex);
            }
        }
    }
}
