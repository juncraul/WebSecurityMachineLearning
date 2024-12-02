namespace WebSecurityMachineLearning
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
            textBoxBrowseTrain = new TextBox();
            S = new Button();
            openFileDialog1 = new OpenFileDialog();
            buttonTrain = new Button();
            buttonTest = new Button();
            buttonBrowseTest = new Button();
            textBoxBrowseTest = new TextBox();
            richTextBoxConsoleOutput = new RichTextBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxBrowseTrain
            // 
            textBoxBrowseTrain.Location = new Point(6, 30);
            textBoxBrowseTrain.Name = "textBoxBrowseTrain";
            textBoxBrowseTrain.Size = new Size(961, 31);
            textBoxBrowseTrain.TabIndex = 0;
            textBoxBrowseTrain.Text = "D:\\juncraul Repo\\WebSecurityMachineLearning\\WebSecurityMachineLearning\\Resources\\phishing_site_urls.csv";
            // 
            // S
            // 
            S.Location = new Point(973, 27);
            S.Name = "S";
            S.Size = new Size(165, 34);
            S.TabIndex = 1;
            S.Text = "Browse";
            S.UseVisualStyleBackColor = true;
            S.Click += buttonBrowse_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonTrain
            // 
            buttonTrain.Location = new Point(973, 67);
            buttonTrain.Name = "buttonTrain";
            buttonTrain.Size = new Size(165, 34);
            buttonTrain.TabIndex = 2;
            buttonTrain.Text = "Start Training";
            buttonTrain.UseVisualStyleBackColor = true;
            buttonTrain.Click += buttonTrain_Click;
            // 
            // buttonTest
            // 
            buttonTest.Location = new Point(973, 67);
            buttonTest.Name = "buttonTest";
            buttonTest.Size = new Size(165, 34);
            buttonTest.TabIndex = 5;
            buttonTest.Text = "Start Testing";
            buttonTest.UseVisualStyleBackColor = true;
            buttonTest.Click += buttonTest_Click;
            // 
            // buttonBrowseTest
            // 
            buttonBrowseTest.Location = new Point(973, 27);
            buttonBrowseTest.Name = "buttonBrowseTest";
            buttonBrowseTest.Size = new Size(165, 34);
            buttonBrowseTest.TabIndex = 4;
            buttonBrowseTest.Text = "Browse";
            buttonBrowseTest.UseVisualStyleBackColor = true;
            buttonBrowseTest.Click += buttonBrowseTest_Click;
            // 
            // textBoxBrowseTest
            // 
            textBoxBrowseTest.Location = new Point(6, 30);
            textBoxBrowseTest.Name = "textBoxBrowseTest";
            textBoxBrowseTest.Size = new Size(961, 31);
            textBoxBrowseTest.TabIndex = 3;
            textBoxBrowseTest.Text = "D:\\juncraul Repo\\WebSecurityMachineLearning\\WebSecurityMachineLearning\\Resources\\phishing_site_urls.csv";
            // 
            // richTextBoxConsoleOutput
            // 
            richTextBoxConsoleOutput.Location = new Point(12, 298);
            richTextBoxConsoleOutput.Name = "richTextBoxConsoleOutput";
            richTextBoxConsoleOutput.Size = new Size(1144, 413);
            richTextBoxConsoleOutput.TabIndex = 6;
            richTextBoxConsoleOutput.Text = "";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxBrowseTrain);
            groupBox1.Controls.Add(S);
            groupBox1.Controls.Add(buttonTrain);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1144, 114);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Training";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBoxBrowseTest);
            groupBox2.Controls.Add(buttonBrowseTest);
            groupBox2.Controls.Add(buttonTest);
            groupBox2.Location = new Point(12, 142);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1144, 150);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Testing";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 723);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(richTextBoxConsoleOutput);
            Name = "Form1";
            Text = "Web Security Machine Learning";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBoxBrowseTrain;
        private Button S;
        private OpenFileDialog openFileDialog1;
        private Button buttonTrain;
        private Button buttonTest;
        private Button buttonBrowseTest;
        private TextBox textBoxBrowseTest;
        private RichTextBox richTextBoxConsoleOutput;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}
