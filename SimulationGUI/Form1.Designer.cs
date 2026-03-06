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
            formsPlotDRS = new ScottPlot.WinForms.FormsPlot();
            buttonStart = new Button();
            buttonStop = new Button();
            comboBox1 = new ComboBox();
            labelComboBox = new Label();
            formsPlotDSR = new ScottPlot.WinForms.FormsPlot();
            formsPlotRDS = new ScottPlot.WinForms.FormsPlot();
            formsPlotSRD = new ScottPlot.WinForms.FormsPlot();
            formsPlotSDR = new ScottPlot.WinForms.FormsPlot();
            formsPlotRSD = new ScottPlot.WinForms.FormsPlot();
            SuspendLayout();
            // 
            // formsPlotDRS
            // 
            formsPlotDRS.DisplayScale = 1F;
            formsPlotDRS.Location = new Point(10, 56);
            formsPlotDRS.Name = "formsPlotDRS";
            formsPlotDRS.Size = new Size(384, 251);
            formsPlotDRS.TabIndex = 0;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(284, 25);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 1;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(389, 25);
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
            comboBox1.Location = new Point(45, 26);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(204, 23);
            comboBox1.TabIndex = 3;
            // 
            // labelComboBox
            // 
            labelComboBox.AutoSize = true;
            labelComboBox.Location = new Point(45, 8);
            labelComboBox.Name = "labelComboBox";
            labelComboBox.Size = new Size(160, 15);
            labelComboBox.TabIndex = 4;
            labelComboBox.Text = "Choose a trail for the courier:";
            // 
            // formsPlotDSR
            // 
            formsPlotDSR.DisplayScale = 1F;
            formsPlotDSR.Location = new Point(464, 56);
            formsPlotDSR.Name = "formsPlotDSR";
            formsPlotDSR.Size = new Size(384, 251);
            formsPlotDSR.TabIndex = 5;
            // 
            // formsPlotRDS
            // 
            formsPlotRDS.DisplayScale = 1F;
            formsPlotRDS.Location = new Point(921, 56);
            formsPlotRDS.Name = "formsPlotRDS";
            formsPlotRDS.Size = new Size(384, 251);
            formsPlotRDS.TabIndex = 6;
            // 
            // formsPlotSRD
            // 
            formsPlotSRD.DisplayScale = 1F;
            formsPlotSRD.Location = new Point(921, 342);
            formsPlotSRD.Name = "formsPlotSRD";
            formsPlotSRD.Size = new Size(384, 251);
            formsPlotSRD.TabIndex = 9;
            // 
            // formsPlotSDR
            // 
            formsPlotSDR.DisplayScale = 1F;
            formsPlotSDR.Location = new Point(464, 342);
            formsPlotSDR.Name = "formsPlotSDR";
            formsPlotSDR.Size = new Size(384, 251);
            formsPlotSDR.TabIndex = 8;
            // 
            // formsPlotRSD
            // 
            formsPlotRSD.DisplayScale = 1F;
            formsPlotRSD.Location = new Point(10, 342);
            formsPlotRSD.Name = "formsPlotRSD";
            formsPlotRSD.Size = new Size(384, 251);
            formsPlotRSD.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1317, 610);
            Controls.Add(formsPlotSRD);
            Controls.Add(formsPlotSDR);
            Controls.Add(formsPlotRSD);
            Controls.Add(formsPlotRDS);
            Controls.Add(formsPlotDSR);
            Controls.Add(labelComboBox);
            Controls.Add(comboBox1);
            Controls.Add(buttonStop);
            Controls.Add(buttonStart);
            Controls.Add(formsPlotDRS);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot formsPlotDRS;
        private Button buttonStart;
        private Button buttonStop;
        private ComboBox comboBox1;
        private Label labelComboBox;
        private ScottPlot.WinForms.FormsPlot formsPlotDSR;
        private ScottPlot.WinForms.FormsPlot formsPlotRDS;
        private ScottPlot.WinForms.FormsPlot formsPlotSRD;
        private ScottPlot.WinForms.FormsPlot formsPlotSDR;
        private ScottPlot.WinForms.FormsPlot formsPlotRSD;
    }
}
