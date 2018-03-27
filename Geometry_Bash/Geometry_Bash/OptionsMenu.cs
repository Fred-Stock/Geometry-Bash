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
        private int squareH = 1;
        private int circleH = 1;
        private int diamondH = 1;
        private int squareD = 1;
        private int circleD = 1;
        private int diamondD = 1;
        private int squareS = 1;
        private int circleS = 1;
        private int diamondS = 1;

        // properties
        public int SquareH { get { return squareH; } }
        public int CircleH { get { return circleH; } }
        public int DiamondH { get { return diamondH; } }
        public int SquareD { get { return squareD; } }
        public int CircleD { get { return circleD; } }
        public int DiamondD { get { return diamondD; } }
        public int SquareS { get { return squareS; } }
        public int CircleS { get { return circleS; } }
        public int DiamondS { get { return diamondS; } }


        public OptionsMenu()
        {
            InitializeComponent();
        }

        private void SquareTextBox_TextChanged(object sender, EventArgs e)
        {
            squareH = int.Parse(SquareTextBox.Text);
        }

        private void CircleTextBox_TextChanged(object sender, EventArgs e)
        {
            circleH = int.Parse(CircleTextBox.Text);
        }

        private void DiamondTextBox_TextChanged(object sender, EventArgs e)
        {
            diamondH = int.Parse(DiamondTextBox.Text);
        }

        private void SquareDamageText_TextChanged(object sender, EventArgs e)
        {
            squareD = int.Parse(SquareDamageText.Text);
        }

        private void CircleDamageText_TextChanged(object sender, EventArgs e)
        {
            circleD = int.Parse(CircleDamageText.Text);
        }

        private void DiamondDamageText_TextChanged(object sender, EventArgs e)
        {
            diamondD = int.Parse(DiamondDamageText.Text);
        }

        private void SquareSpeedText_TextChanged(object sender, EventArgs e)
        {
            squareS = int.Parse(SquareSpeedText.Text);
        }

        private void CircleSpeedText_TextChanged(object sender, EventArgs e)
        {
            circleS = int.Parse(CircleSpeedText.Text);
        }

        private void DiamondSpeedText_TextChanged(object sender, EventArgs e)
        {
            diamondS = int.Parse(DiamondSpeedText.Text);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //outout is "squareHealth,circleHealth,diamondHealth,squareDamage,circleDamage,diamondDiamond,squareSpeed,circleSpeed,diamondSpeed"

            string output = squareH + "," + circleH + "," + diamondH + "," +
                            squareD + "," + circleD + "," + diamondD + "," +
                            squareS + "," + circleS + "," + diamondS + ",";

            try
            {
                StreamWriter fileOut = new StreamWriter("stats.txt");
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
