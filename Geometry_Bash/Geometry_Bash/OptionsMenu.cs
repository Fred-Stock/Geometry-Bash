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
        private double squareD = 3;
        private double circleD = 3;
        private double diamondD = 3;
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

        private void DiamondSpeedText_TextChanged(object sender, EventArgs e)
        {
            diamondS = double.Parse(DiamondSpeedText.Text);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // saves new input into fields
            squareH = double.Parse(SquareTextBox.Text);
            circleH = double.Parse(CircleTextBox.Text);
            diamondH = double.Parse(DiamondTextBox.Text);
            squareD = double.Parse(SquareDamageText.Text);
            circleD = double.Parse(CircleDamageText.Text);
            diamondD = double.Parse(DiamondDamageText.Text);
            squareS = double.Parse(SquareSpeedText.Text);
            circleS = double.Parse(CircleSpeedText.Text);
            diamondS = double.Parse(DiamondSpeedText.Text);

            //outout is "squareHealth,circleHealth,diamondHealth,squareDamage,circleDamage,diamondDiamond,squareSpeed,circleSpeed,diamondSpeed"

            string output = squareH + "," + circleH + "," + diamondH + "," +
                            squareD + "," + circleD + "," + diamondD + "," +
                            squareS + "," + circleS + "," + diamondS + ",";

            try
            {
                StreamWriter fileOut = new StreamWriter("../../../../stats.txt");
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
