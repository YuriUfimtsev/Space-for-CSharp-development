namespace Calculator
{
    partial class CalculatorUserInterfaceForm : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Zero = new System.Windows.Forms.Button();
            this.One = new System.Windows.Forms.Button();
            this.Two = new System.Windows.Forms.Button();
            this.Three = new System.Windows.Forms.Button();
            this.Four = new System.Windows.Forms.Button();
            this.Five = new System.Windows.Forms.Button();
            this.Six = new System.Windows.Forms.Button();
            this.Seven = new System.Windows.Forms.Button();
            this.Eight = new System.Windows.Forms.Button();
            this.Nine = new System.Windows.Forms.Button();
            this.Plus = new System.Windows.Forms.Button();
            this.Minus = new System.Windows.Forms.Button();
            this.Multiply = new System.Windows.Forms.Button();
            this.Division = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.WindowWithCalculation = new System.Windows.Forms.Label();
            this.Equality = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.Zero, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.One, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Two, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.Three, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.Four, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Five, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Six, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.Seven, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Eight, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Nine, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.Plus, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.Minus, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.Multiply, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.Division, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.Clear, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.WindowWithCalculation, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Equality, 3, 5);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66615F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66924F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66615F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66615F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66615F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66615F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(402, 499);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Zero
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.Zero, 3);
            this.Zero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Zero.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Zero.Location = new System.Drawing.Point(3, 418);
            this.Zero.MinimumSize = new System.Drawing.Size(282, 77);
            this.Zero.Name = "Zero";
            this.Zero.Size = new System.Drawing.Size(294, 78);
            this.Zero.TabIndex = 14;
            this.Zero.Text = "0";
            this.Zero.UseVisualStyleBackColor = true;
            this.Zero.Click += new System.EventHandler(this.ZeroClick);
            // 
            // One
            // 
            this.One.Dock = System.Windows.Forms.DockStyle.Fill;
            this.One.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.One.Location = new System.Drawing.Point(3, 335);
            this.One.MinimumSize = new System.Drawing.Size(90, 75);
            this.One.Name = "One";
            this.One.Size = new System.Drawing.Size(94, 77);
            this.One.TabIndex = 10;
            this.One.Text = "1";
            this.One.UseVisualStyleBackColor = true;
            this.One.Click += new System.EventHandler(this.OneClick);
            // 
            // Two
            // 
            this.Two.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Two.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Two.Location = new System.Drawing.Point(103, 335);
            this.Two.MinimumSize = new System.Drawing.Size(90, 75);
            this.Two.Name = "Two";
            this.Two.Size = new System.Drawing.Size(94, 77);
            this.Two.TabIndex = 11;
            this.Two.Text = "2";
            this.Two.UseVisualStyleBackColor = true;
            this.Two.Click += new System.EventHandler(this.TwoClick);
            // 
            // Three
            // 
            this.Three.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Three.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Three.Location = new System.Drawing.Point(203, 335);
            this.Three.MinimumSize = new System.Drawing.Size(90, 75);
            this.Three.Name = "Three";
            this.Three.Size = new System.Drawing.Size(94, 77);
            this.Three.TabIndex = 12;
            this.Three.Text = "3";
            this.Three.UseVisualStyleBackColor = true;
            this.Three.Click += new System.EventHandler(this.ThreeClick);
            // 
            // Four
            // 
            this.Four.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Four.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Four.Location = new System.Drawing.Point(3, 252);
            this.Four.MinimumSize = new System.Drawing.Size(90, 75);
            this.Four.Name = "Four";
            this.Four.Size = new System.Drawing.Size(94, 77);
            this.Four.TabIndex = 6;
            this.Four.Text = "4";
            this.Four.UseVisualStyleBackColor = true;
            this.Four.Click += new System.EventHandler(this.FourClick);
            // 
            // Five
            // 
            this.Five.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Five.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Five.Location = new System.Drawing.Point(103, 252);
            this.Five.MinimumSize = new System.Drawing.Size(90, 75);
            this.Five.Name = "Five";
            this.Five.Size = new System.Drawing.Size(94, 77);
            this.Five.TabIndex = 7;
            this.Five.Text = "5";
            this.Five.UseVisualStyleBackColor = true;
            this.Five.Click += new System.EventHandler(this.FiveClick);
            // 
            // Six
            // 
            this.Six.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Six.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Six.Location = new System.Drawing.Point(203, 252);
            this.Six.MinimumSize = new System.Drawing.Size(90, 75);
            this.Six.Name = "Six";
            this.Six.Size = new System.Drawing.Size(94, 77);
            this.Six.TabIndex = 8;
            this.Six.Text = "6";
            this.Six.UseVisualStyleBackColor = true;
            this.Six.Click += new System.EventHandler(this.SixClick);
            // 
            // Seven
            // 
            this.Seven.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Seven.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Seven.Location = new System.Drawing.Point(3, 169);
            this.Seven.MinimumSize = new System.Drawing.Size(90, 75);
            this.Seven.Name = "Seven";
            this.Seven.Size = new System.Drawing.Size(94, 77);
            this.Seven.TabIndex = 2;
            this.Seven.Text = "7";
            this.Seven.UseVisualStyleBackColor = true;
            this.Seven.Click += new System.EventHandler(this.SevenClick);
            // 
            // Eight
            // 
            this.Eight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Eight.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Eight.Location = new System.Drawing.Point(103, 169);
            this.Eight.MinimumSize = new System.Drawing.Size(90, 75);
            this.Eight.Name = "Eight";
            this.Eight.Size = new System.Drawing.Size(94, 77);
            this.Eight.TabIndex = 3;
            this.Eight.Text = "8";
            this.Eight.UseVisualStyleBackColor = true;
            this.Eight.Click += new System.EventHandler(this.EightClick);
            // 
            // Nine
            // 
            this.Nine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Nine.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Nine.Location = new System.Drawing.Point(203, 169);
            this.Nine.MinimumSize = new System.Drawing.Size(90, 75);
            this.Nine.Name = "Nine";
            this.Nine.Size = new System.Drawing.Size(94, 77);
            this.Nine.TabIndex = 4;
            this.Nine.Text = "9";
            this.Nine.UseVisualStyleBackColor = true;
            this.Nine.Click += new System.EventHandler(this.NineClick);
            // 
            // Plus
            // 
            this.Plus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Plus.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Plus.Location = new System.Drawing.Point(303, 335);
            this.Plus.MinimumSize = new System.Drawing.Size(90, 75);
            this.Plus.Name = "Plus";
            this.Plus.Size = new System.Drawing.Size(96, 77);
            this.Plus.TabIndex = 13;
            this.Plus.Text = "+";
            this.Plus.UseVisualStyleBackColor = true;
            this.Plus.Click += new System.EventHandler(this.PlusClick);
            // 
            // Minus
            // 
            this.Minus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Minus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Minus.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Minus.Location = new System.Drawing.Point(303, 252);
            this.Minus.MinimumSize = new System.Drawing.Size(90, 75);
            this.Minus.Name = "Minus";
            this.Minus.Size = new System.Drawing.Size(96, 77);
            this.Minus.TabIndex = 9;
            this.Minus.Text = "-";
            this.Minus.UseVisualStyleBackColor = true;
            this.Minus.Click += new System.EventHandler(this.MinusClick);
            // 
            // Multiply
            // 
            this.Multiply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Multiply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Multiply.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Multiply.Location = new System.Drawing.Point(303, 169);
            this.Multiply.MinimumSize = new System.Drawing.Size(90, 75);
            this.Multiply.Name = "Multiply";
            this.Multiply.Size = new System.Drawing.Size(96, 77);
            this.Multiply.TabIndex = 5;
            this.Multiply.Text = "*";
            this.Multiply.UseVisualStyleBackColor = true;
            this.Multiply.Click += new System.EventHandler(this.MultiplyClick);
            // 
            // Division
            // 
            this.Division.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Division.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Division.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Division.Location = new System.Drawing.Point(303, 86);
            this.Division.MinimumSize = new System.Drawing.Size(90, 75);
            this.Division.Name = "Division";
            this.Division.Size = new System.Drawing.Size(96, 77);
            this.Division.TabIndex = 1;
            this.Division.Text = "÷";
            this.Division.UseVisualStyleBackColor = true;
            this.Division.Click += new System.EventHandler(this.DivisionClick);
            // 
            // Clear
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.Clear, 3);
            this.Clear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Clear.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Clear.Location = new System.Drawing.Point(3, 86);
            this.Clear.MinimumSize = new System.Drawing.Size(282, 75);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(294, 77);
            this.Clear.TabIndex = 0;
            this.Clear.Text = "C";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.ClearClick);
            // 
            // WindowWithCalculation
            // 
            this.WindowWithCalculation.AutoSize = true;
            this.WindowWithCalculation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.WindowWithCalculation, 4);
            this.WindowWithCalculation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowWithCalculation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WindowWithCalculation.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WindowWithCalculation.Location = new System.Drawing.Point(3, 0);
            this.WindowWithCalculation.MinimumSize = new System.Drawing.Size(380, 81);
            this.WindowWithCalculation.Name = "WindowWithCalculation";
            this.WindowWithCalculation.Size = new System.Drawing.Size(396, 83);
            this.WindowWithCalculation.TabIndex = 16;
            this.WindowWithCalculation.Text = "2";
            this.WindowWithCalculation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Equality
            // 
            this.Equality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Equality.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Equality.Location = new System.Drawing.Point(303, 418);
            this.Equality.MinimumSize = new System.Drawing.Size(90, 77);
            this.Equality.Name = "Equality";
            this.Equality.Size = new System.Drawing.Size(96, 78);
            this.Equality.TabIndex = 15;
            this.Equality.Text = "=";
            this.Equality.UseVisualStyleBackColor = true;
            this.Equality.Click += new System.EventHandler(this.EqualityClick);
            // 
            // CalculatorUserInterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 499);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(420, 546);
            this.Name = "CalculatorUserInterfaceForm";
            this.Text = "Calculator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button Seven;
        private Button Eight;
        private Button Plus;
        private Button Zero;
        private Button One;
        private Button Two;
        private Button Three;
        private Button Four;
        private Button Five;
        private Button Six;
        private Button Nine;
        private Button Minus;
        private Button Multiply;
        private Button Division;
        private Button Clear;
        public Label WindowWithCalculation;
        private Button Equality;
    }
}