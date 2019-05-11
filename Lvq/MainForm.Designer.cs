namespace Lvq
{
    partial class MainForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.tbTrainCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTestCount = new System.Windows.Forms.TextBox();
            this.tbW = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCodebookCount = new System.Windows.Forms.TextBox();
            this.tbEpsilon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbAlfa = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTourCount = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lMesK = new System.Windows.Forms.Label();
            this.tbMK = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(332, 60);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 20);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tbTrainCount
            // 
            this.tbTrainCount.Location = new System.Drawing.Point(117, 10);
            this.tbTrainCount.Margin = new System.Windows.Forms.Padding(2);
            this.tbTrainCount.Name = "tbTrainCount";
            this.tbTrainCount.Size = new System.Drawing.Size(65, 20);
            this.tbTrainCount.TabIndex = 2;
            this.tbTrainCount.Text = "200";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Train Count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Test Count";
            // 
            // tbTestCount
            // 
            this.tbTestCount.Location = new System.Drawing.Point(117, 35);
            this.tbTestCount.Margin = new System.Windows.Forms.Padding(2);
            this.tbTestCount.Name = "tbTestCount";
            this.tbTestCount.Size = new System.Drawing.Size(65, 20);
            this.tbTestCount.TabIndex = 5;
            this.tbTestCount.Text = "100";
            // 
            // tbW
            // 
            this.tbW.Location = new System.Drawing.Point(263, 10);
            this.tbW.Margin = new System.Windows.Forms.Padding(2);
            this.tbW.Name = "tbW";
            this.tbW.Size = new System.Drawing.Size(65, 20);
            this.tbW.TabIndex = 9;
            this.tbW.Text = "0,25";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "W";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Codebook Count";
            // 
            // tbCodebookCount
            // 
            this.tbCodebookCount.Location = new System.Drawing.Point(117, 60);
            this.tbCodebookCount.Margin = new System.Windows.Forms.Padding(2);
            this.tbCodebookCount.Name = "tbCodebookCount";
            this.tbCodebookCount.Size = new System.Drawing.Size(65, 20);
            this.tbCodebookCount.TabIndex = 6;
            this.tbCodebookCount.Text = "10";
            // 
            // tbEpsilon
            // 
            this.tbEpsilon.Location = new System.Drawing.Point(263, 60);
            this.tbEpsilon.Margin = new System.Windows.Forms.Padding(2);
            this.tbEpsilon.Name = "tbEpsilon";
            this.tbEpsilon.Size = new System.Drawing.Size(65, 20);
            this.tbEpsilon.TabIndex = 13;
            this.tbEpsilon.Text = "0,1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 63);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Epsilon";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Alfa";
            // 
            // tbAlfa
            // 
            this.tbAlfa.Location = new System.Drawing.Point(263, 35);
            this.tbAlfa.Margin = new System.Windows.Forms.Padding(2);
            this.tbAlfa.Name = "tbAlfa";
            this.tbAlfa.Size = new System.Drawing.Size(65, 20);
            this.tbAlfa.TabIndex = 10;
            this.tbAlfa.Text = "0,005";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(332, 11);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(55, 17);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.Text = "LVQ 2";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(390, 11);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(55, 17);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "LVQ 3";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 88);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Tour Count";
            // 
            // tbTourCount
            // 
            this.tbTourCount.Location = new System.Drawing.Point(117, 85);
            this.tbTourCount.Margin = new System.Windows.Forms.Padding(2);
            this.tbTourCount.Name = "tbTourCount";
            this.tbTourCount.Size = new System.Drawing.Size(65, 20);
            this.tbTourCount.TabIndex = 16;
            this.tbTourCount.Text = "10";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1, 125);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(456, 23);
            this.progressBar1.TabIndex = 18;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(332, 85);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 20);
            this.button2.TabIndex = 0;
            this.button2.Text = "Result";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.tbMK);
            this.panel1.Controls.Add(this.lMesK);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbTourCount);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.tbTrainCount);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbTestCount);
            this.panel1.Controls.Add(this.tbEpsilon);
            this.panel1.Controls.Add(this.tbCodebookCount);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbAlfa);
            this.panel1.Controls.Add(this.tbW);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 118);
            this.panel1.TabIndex = 19;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(352, 37);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 17);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "Average";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lMesK
            // 
            this.lMesK.AutoSize = true;
            this.lMesK.Location = new System.Drawing.Point(198, 88);
            this.lMesK.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lMesK.Name = "lMesK";
            this.lMesK.Size = new System.Drawing.Size(43, 13);
            this.lMesK.TabIndex = 18;
            this.lMesK.Text = "Mes. K.";
            // 
            // tbMK
            // 
            this.tbMK.Location = new System.Drawing.Point(263, 85);
            this.tbMK.Margin = new System.Windows.Forms.Padding(2);
            this.tbMK.Name = "tbMK";
            this.tbMK.Size = new System.Drawing.Size(65, 20);
            this.tbMK.TabIndex = 19;
            this.tbMK.Text = "10";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 149);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LVQ 2-3 For Mnist Dataset";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbTrainCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTestCount;
        private System.Windows.Forms.TextBox tbW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCodebookCount;
        private System.Windows.Forms.TextBox tbEpsilon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbAlfa;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTourCount;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox tbMK;
        private System.Windows.Forms.Label lMesK;
    }
}