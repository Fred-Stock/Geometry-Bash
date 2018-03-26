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
        private int squareHealth = 1;
        private int circleHealth = 1;
        private int diamondHealth = 1;
        private int squareDamage = 1;
        private int circleDamage = 1;
        private int diamondDamage = 1;
        private int squareSpeed = 1;
        private int circleSpeed = 1;
        private int diamondSpeed = 1;

        // properties

        public OptionsMenu()
        {
            InitializeComponent();
        }

        private void SquareTextBox_TextChanged(object sender, EventArgs e)
        {
            squareHealth = int.Parse(SquareTextBox.Text);
        }

        private void CircleTextBox_TextChanged(object sender, EventArgs e)
        {
            circleHealth = int.Parse(CircleTextBox.Text);
        }

        private void DiamondTextBox_TextChanged(object sender, EventArgs e)
        {
            diamondHealth = int.Parse(DiamondTextBox.Text);
        }

        private void SquareDamageText_TextChanged(object sender, EventArgs e)
        {
            squareDamage = int.Parse(SquareDamageText.Text);
        }

        private void CircleDamageText_TextChanged(object sender, EventArgs e)
        {
            circleDamage = int.Parse(CircleDamageText.Text);
        }

        private void DiamondDamageText_TextChanged(object sender, EventArgs e)
        {
            diamondDamage = int.Parse(DiamondDamageText.Text);
        }

        private void SquareSpeedText_TextChanged(object sender, EventArgs e)
        {
            squareSpeed = int.Parse(SquareSpeedText.Text);
        }

        private void CircleSpeedText_TextChanged(object sender, EventArgs e)
        {
            circleSpeed = int.Parse(CircleSpeedText.Text);
        }

        private void DiamondSpeedText_TextChanged(object sender, EventArgs e)
        {
            diamondSpeed = int.Parse(DiamondSpeedText.Text);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //outout is "squareHealth,circleHealth,diamondHealth,squareDamage,circleDamage,diamondDiamond,squareSpeed,circleSpeed,diamondSpeed"

            string output = squareHealth + "," + circleHealth + "," + diamondHealth + "," +
                            squareDamage + "," + circleDamage + "," + diamondDamage + "," +
                            squareSpeed + "," + circleSpeed + "," + diamondSpeed + ",";

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
