namespace SimulationGUI
{
    partial class Form1
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
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            buttonStart = new Button();
            buttonStop = new Button();
            comboBox1 = new ComboBox();
            labelComboBox = new Label();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Location = new Point(12, 152);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(776, 286);
            formsPlot1.TabIndex = 0;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(476, 47);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 1;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(581, 47);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(75, 23);
            buttonStop.TabIndex = 2;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Divinka-Rajecke Teplice-Strecno", "Divinka-Strecno-Rajecke Teplice", "Rajecke Teplice-Divinka-Strecno", "Rajecke Teplice-Strecno-Divinka", "Strecno-Divinka-Rajecke Teplice", "Strecno-Rajecke Teplice-Divinka", "", "" });
            comboBox1.Location = new Point(46, 48);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(204, 23);
            comboBox1.TabIndex = 3;
            // 
            // labelComboBox
            // 
            labelComboBox.AutoSize = true;
            labelComboBox.Location = new Point(46, 30);
            labelComboBox.Name = "labelComboBox";
            labelComboBox.Size = new Size(160, 15);
            labelComboBox.TabIndex = 4;
            labelComboBox.Text = "Choose a trail for the courier:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelComboBox);
            Controls.Add(comboBox1);
            Controls.Add(buttonStop);
            Controls.Add(buttonStart);
            Controls.Add(formsPlot1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private Button buttonStart;
        private Button buttonStop;
        private ComboBox comboBox1;
        private Label labelComboBox;
    }
}
