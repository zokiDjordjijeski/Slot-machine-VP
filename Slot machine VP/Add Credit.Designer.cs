namespace Slot_machine_VP
{
    partial class Add_Credit
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
            label1 = new Label();
            nudAMOUNT = new NumericUpDown();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)nudAMOUNT).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 21);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 0;
            label1.Text = "Enter amount:";
            // 
            // nudAMOUNT
            // 
            nudAMOUNT.Location = new Point(12, 44);
            nudAMOUNT.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            nudAMOUNT.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudAMOUNT.Name = "nudAMOUNT";
            nudAMOUNT.Size = new Size(238, 27);
            nudAMOUNT.TabIndex = 1;
            nudAMOUNT.TextAlign = HorizontalAlignment.Center;
            nudAMOUNT.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudAMOUNT.ValueChanged += nudAMOUNT_ValueChanged;
            // 
            // button1
            // 
            button1.Location = new Point(11, 88);
            button1.Name = "button1";
            button1.Size = new Size(102, 44);
            button1.TabIndex = 2;
            button1.Text = "Continue";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(148, 88);
            button2.Name = "button2";
            button2.Size = new Size(102, 44);
            button2.TabIndex = 3;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Add_Credit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(266, 160);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(nudAMOUNT);
            Controls.Add(label1);
            Name = "Add_Credit";
            Text = "Add Credit";
            ((System.ComponentModel.ISupportInitialize)nudAMOUNT).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown nudAMOUNT;
        private Button button1;
        private Button button2;
    }
}