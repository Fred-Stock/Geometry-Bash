namespace GameTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SquareHealth = new System.Windows.Forms.Label();
            this.CircleHealth = new System.Windows.Forms.Label();
            this.DiamondHealth = new System.Windows.Forms.Label();
            this.SquareTextBox = new System.Windows.Forms.TextBox();
            this.CircleTextBox = new System.Windows.Forms.TextBox();
            this.DiamondTextBox = new System.Windows.Forms.TextBox();
            this.SquareDamage = new System.Windows.Forms.Label();
            this.CircleDamage = new System.Windows.Forms.Label();
            this.DiamondDamage = new System.Windows.Forms.Label();
            this.SquareDamageText = new System.Windows.Forms.TextBox();
            this.CircleDamageText = new System.Windows.Forms.TextBox();
            this.DiamondDamageText = new System.Windows.Forms.TextBox();
            this.DiamondSpeed = new System.Windows.Forms.Label();
            this.CircleSpeed = new System.Windows.Forms.Label();
            this.SquareSpeed = new System.Windows.Forms.Label();
            this.DiamondSpeedText = new System.Windows.Forms.TextBox();
            this.CircleSpeedText = new System.Windows.Forms.TextBox();
            this.SquareSpeedText = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SquareHealth
            // 
            this.SquareHealth.AutoSize = true;
            this.SquareHealth.BackColor = System.Drawing.Color.Transparent;
            this.SquareHealth.Font = new System.Drawing.Font("MS Office Symbol Regular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SquareHealth.Location = new System.Drawing.Point(16, 201);
            this.SquareHealth.Margin = new System.Windows.Forms.Padding(3);
            this.SquareHealth.Name = "SquareHealth";
            this.SquareHealth.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.SquareHealth.Size = new System.Drawing.Size(105, 27);
            this.SquareHealth.TabIndex = 0;
            this.SquareHealth.Text = "Square Health";
            this.SquareHealth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CircleHealth
            // 
            this.CircleHealth.AutoSize = true;
            this.CircleHealth.BackColor = System.Drawing.Color.Transparent;
            this.CircleHealth.Font = new System.Drawing.Font("MS Office Symbol Regular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CircleHealth.Location = new System.Drawing.Point(16, 301);
            this.CircleHealth.Margin = new System.Windows.Forms.Padding(3);
            this.CircleHealth.Name = "CircleHealth";
            this.CircleHealth.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.CircleHealth.Size = new System.Drawing.Size(96, 27);
            this.CircleHealth.TabIndex = 1;
            this.CircleHealth.Text = "Circle Health";
            this.CircleHealth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DiamondHealth
            // 
            this.DiamondHealth.AutoSize = true;
            this.DiamondHealth.BackColor = System.Drawing.Color.Transparent;
            this.DiamondHealth.Font = new System.Drawing.Font("MS Office Symbol Regular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiamondHealth.Location = new System.Drawing.Point(16, 401);
            this.DiamondHealth.Margin = new System.Windows.Forms.Padding(3);
            this.DiamondHealth.Name = "DiamondHealth";
            this.DiamondHealth.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.DiamondHealth.Size = new System.Drawing.Size(118, 27);
            this.DiamondHealth.TabIndex = 2;
            this.DiamondHealth.Text = "Diamond Health";
            this.DiamondHealth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SquareTextBox
            // 
            this.SquareTextBox.Location = new System.Drawing.Point(126, 205);
            this.SquareTextBox.Name = "SquareTextBox";
            this.SquareTextBox.Size = new System.Drawing.Size(200, 20);
            this.SquareTextBox.TabIndex = 3;
            this.SquareTextBox.TextChanged += new System.EventHandler(this.SquareTextBox_TextChanged);
            // 
            // CircleTextBox
            // 
            this.CircleTextBox.Location = new System.Drawing.Point(126, 305);
            this.CircleTextBox.Name = "CircleTextBox";
            this.CircleTextBox.Size = new System.Drawing.Size(200, 20);
            this.CircleTextBox.TabIndex = 4;
            this.CircleTextBox.TextChanged += new System.EventHandler(this.CircleTextBox_TextChanged);
            // 
            // DiamondTextBox
            // 
            this.DiamondTextBox.Location = new System.Drawing.Point(140, 405);
            this.DiamondTextBox.Name = "DiamondTextBox";
            this.DiamondTextBox.Size = new System.Drawing.Size(200, 20);
            this.DiamondTextBox.TabIndex = 5;
            this.DiamondTextBox.TextChanged += new System.EventHandler(this.DiamondTextBox_TextChanged);
            // 
            // SquareDamage
            // 
            this.SquareDamage.AutoSize = true;
            this.SquareDamage.BackColor = System.Drawing.Color.Transparent;
            this.SquareDamage.Font = new System.Drawing.Font("MS Office Symbol Regular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SquareDamage.Location = new System.Drawing.Point(426, 201);
            this.SquareDamage.Margin = new System.Windows.Forms.Padding(3);
            this.SquareDamage.Name = "SquareDamage";
            this.SquareDamage.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.SquareDamage.Size = new System.Drawing.Size(119, 27);
            this.SquareDamage.TabIndex = 6;
            this.SquareDamage.Text = "Square Damage";
            this.SquareDamage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CircleDamage
            // 
            this.CircleDamage.AutoSize = true;
            this.CircleDamage.BackColor = System.Drawing.Color.Transparent;
            this.CircleDamage.Font = new System.Drawing.Font("MS Office Symbol Regular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CircleDamage.Location = new System.Drawing.Point(426, 301);
            this.CircleDamage.Margin = new System.Windows.Forms.Padding(3);
            this.CircleDamage.Name = "CircleDamage";
            this.CircleDamage.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.CircleDamage.Size = new System.Drawing.Size(110, 27);
            this.CircleDamage.TabIndex = 7;
            this.CircleDamage.Text = "Circle Damage";
            this.CircleDamage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DiamondDamage
            // 
            this.DiamondDamage.AutoSize = true;
            this.DiamondDamage.BackColor = System.Drawing.Color.Transparent;
            this.DiamondDamage.Font = new System.Drawing.Font("MS Office Symbol Regular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiamondDamage.Location = new System.Drawing.Point(426, 401);
            this.DiamondDamage.Margin = new System.Windows.Forms.Padding(3);
            this.DiamondDamage.Name = "DiamondDamage";
            this.DiamondDamage.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.DiamondDamage.Size = new System.Drawing.Size(132, 27);
            this.DiamondDamage.TabIndex = 8;
            this.DiamondDamage.Text = "Diamond Damage";
            this.DiamondDamage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SquareDamageText
            // 
            this.SquareDamageText.Location = new System.Drawing.Point(551, 205);
            this.SquareDamageText.Name = "SquareDamageText";
            this.SquareDamageText.Size = new System.Drawing.Size(200, 20);
            this.SquareDamageText.TabIndex = 9;
            this.SquareDamageText.TextChanged += new System.EventHandler(this.SquareDamageText_TextChanged);
            // 
            // CircleDamageText
            // 
            this.CircleDamageText.Location = new System.Drawing.Point(551, 305);
            this.CircleDamageText.Name = "CircleDamageText";
            this.CircleDamageText.Size = new System.Drawing.Size(200, 20);
            this.CircleDamageText.TabIndex = 10;
            this.CircleDamageText.TextChanged += new System.EventHandler(this.CircleDamageText_TextChanged);
            // 
            // DiamondDamageText
            // 
            this.DiamondDamageText.Location = new System.Drawing.Point(574, 405);
            this.DiamondDamageText.Name = "DiamondDamageText";
            this.DiamondDamageText.Size = new System.Drawing.Size(200, 20);
            this.DiamondDamageText.TabIndex = 11;
            this.DiamondDamageText.TextChanged += new System.EventHandler(this.DiamondDamageText_TextChanged);
            // 
            // DiamondSpeed
            // 
            this.DiamondSpeed.AutoSize = true;
            this.DiamondSpeed.BackColor = System.Drawing.Color.Transparent;
            this.DiamondSpeed.Font = new System.Drawing.Font("MS Office Symbol Regular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiamondSpeed.Location = new System.Drawing.Point(814, 401);
            this.DiamondSpeed.Margin = new System.Windows.Forms.Padding(3);
            this.DiamondSpeed.Name = "DiamondSpeed";
            this.DiamondSpeed.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.DiamondSpeed.Size = new System.Drawing.Size(118, 27);
            this.DiamondSpeed.TabIndex = 14;
            this.DiamondSpeed.Text = "Diamond Speed";
            this.DiamondSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CircleSpeed
            // 
            this.CircleSpeed.AutoSize = true;
            this.CircleSpeed.BackColor = System.Drawing.Color.Transparent;
            this.CircleSpeed.Font = new System.Drawing.Font("MS Office Symbol Regular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CircleSpeed.Location = new System.Drawing.Point(814, 301);
            this.CircleSpeed.Margin = new System.Windows.Forms.Padding(3);
            this.CircleSpeed.Name = "CircleSpeed";
            this.CircleSpeed.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.CircleSpeed.Size = new System.Drawing.Size(96, 27);
            this.CircleSpeed.TabIndex = 13;
            this.CircleSpeed.Text = "Circle Speed";
            this.CircleSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SquareSpeed
            // 
            this.SquareSpeed.AutoSize = true;
            this.SquareSpeed.BackColor = System.Drawing.Color.Transparent;
            this.SquareSpeed.Font = new System.Drawing.Font("MS Office Symbol Regular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SquareSpeed.Location = new System.Drawing.Point(814, 201);
            this.SquareSpeed.Margin = new System.Windows.Forms.Padding(3);
            this.SquareSpeed.Name = "SquareSpeed";
            this.SquareSpeed.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.SquareSpeed.Size = new System.Drawing.Size(105, 27);
            this.SquareSpeed.TabIndex = 12;
            this.SquareSpeed.Text = "Square Speed";
            this.SquareSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DiamondSpeedText
            // 
            this.DiamondSpeedText.Location = new System.Drawing.Point(971, 405);
            this.DiamondSpeedText.Name = "DiamondSpeedText";
            this.DiamondSpeedText.Size = new System.Drawing.Size(200, 20);
            this.DiamondSpeedText.TabIndex = 17;
            this.DiamondSpeedText.TextChanged += new System.EventHandler(this.DiamondSpeedText_TextChanged);
            // 
            // CircleSpeedText
            // 
            this.CircleSpeedText.Location = new System.Drawing.Point(948, 305);
            this.CircleSpeedText.Name = "CircleSpeedText";
            this.CircleSpeedText.Size = new System.Drawing.Size(200, 20);
            this.CircleSpeedText.TabIndex = 16;
            this.CircleSpeedText.TextChanged += new System.EventHandler(this.CircleSpeedText_TextChanged);
            // 
            // SquareSpeedText
            // 
            this.SquareSpeedText.Location = new System.Drawing.Point(948, 205);
            this.SquareSpeedText.Name = "SquareSpeedText";
            this.SquareSpeedText.Size = new System.Drawing.Size(200, 20);
            this.SquareSpeedText.TabIndex = 15;
            this.SquareSpeedText.TextChanged += new System.EventHandler(this.SquareSpeedText_TextChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveButton.BackgroundImage")));
            this.SaveButton.Font = new System.Drawing.Font("MS Office Symbol Regular", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(464, 578);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.SaveButton.Size = new System.Drawing.Size(350, 100);
            this.SaveButton.TabIndex = 18;
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DiamondSpeedText);
            this.Controls.Add(this.CircleSpeedText);
            this.Controls.Add(this.SquareSpeedText);
            this.Controls.Add(this.DiamondSpeed);
            this.Controls.Add(this.CircleSpeed);
            this.Controls.Add(this.SquareSpeed);
            this.Controls.Add(this.DiamondDamageText);
            this.Controls.Add(this.CircleDamageText);
            this.Controls.Add(this.SquareDamageText);
            this.Controls.Add(this.DiamondDamage);
            this.Controls.Add(this.CircleDamage);
            this.Controls.Add(this.SquareDamage);
            this.Controls.Add(this.DiamondTextBox);
            this.Controls.Add(this.CircleTextBox);
            this.Controls.Add(this.SquareTextBox);
            this.Controls.Add(this.DiamondHealth);
            this.Controls.Add(this.CircleHealth);
            this.Controls.Add(this.SquareHealth);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Stats Changer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SquareHealth;
        private System.Windows.Forms.Label CircleHealth;
        private System.Windows.Forms.Label DiamondHealth;
        private System.Windows.Forms.TextBox SquareTextBox;
        private System.Windows.Forms.TextBox CircleTextBox;
        private System.Windows.Forms.TextBox DiamondTextBox;
        private System.Windows.Forms.Label SquareDamage;
        private System.Windows.Forms.Label CircleDamage;
        private System.Windows.Forms.Label DiamondDamage;
        private System.Windows.Forms.TextBox SquareDamageText;
        private System.Windows.Forms.TextBox CircleDamageText;
        private System.Windows.Forms.TextBox DiamondDamageText;
        private System.Windows.Forms.Label DiamondSpeed;
        private System.Windows.Forms.Label CircleSpeed;
        private System.Windows.Forms.Label SquareSpeed;
        private System.Windows.Forms.TextBox DiamondSpeedText;
        private System.Windows.Forms.TextBox CircleSpeedText;
        private System.Windows.Forms.TextBox SquareSpeedText;
        private System.Windows.Forms.Button SaveButton;
    }
}

