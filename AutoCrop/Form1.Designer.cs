namespace AutoCrop
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCrop = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.FolderBrowseOutput = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.foldernameOutput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.FolderBrowse = new System.Windows.Forms.Button();
            this.folderPathLabel = new System.Windows.Forms.Label();
            this.folderPath = new System.Windows.Forms.TextBox();
            this.textBoxHue = new System.Windows.Forms.TextBox();
            this.textBoxSat = new System.Windows.Forms.TextBox();
            this.textBoxBright = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxStartHue = new System.Windows.Forms.TextBox();
            this.textBoxStartSat = new System.Windows.Forms.TextBox();
            this.textBoxStartBright = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonGo = new System.Windows.Forms.Button();
            this.scrollStartHue = new System.Windows.Forms.HScrollBar();
            this.scrollEndHue = new System.Windows.Forms.HScrollBar();
            this.scrollEndSat = new System.Windows.Forms.HScrollBar();
            this.scrollStartSat = new System.Windows.Forms.HScrollBar();
            this.scrollEndBright = new System.Windows.Forms.HScrollBar();
            this.scrollStartBright = new System.Windows.Forms.HScrollBar();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.buttonCropImage = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TestRectangle = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 608);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 657);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 708);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bright";
            // 
            // buttonCrop
            // 
            this.buttonCrop.Location = new System.Drawing.Point(895, 699);
            this.buttonCrop.Name = "buttonCrop";
            this.buttonCrop.Size = new System.Drawing.Size(75, 23);
            this.buttonCrop.TabIndex = 7;
            this.buttonCrop.Text = "CropFolder";
            this.buttonCrop.UseVisualStyleBackColor = true;
            this.buttonCrop.Click += new System.EventHandler(this.buttonCrop_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(152, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "OUTPUT";
            // 
            // FolderBrowseOutput
            // 
            this.FolderBrowseOutput.Location = new System.Drawing.Point(204, 47);
            this.FolderBrowseOutput.Name = "FolderBrowseOutput";
            this.FolderBrowseOutput.Size = new System.Drawing.Size(75, 23);
            this.FolderBrowseOutput.TabIndex = 43;
            this.FolderBrowseOutput.Text = "Browse Folder";
            this.FolderBrowseOutput.UseVisualStyleBackColor = true;
            this.FolderBrowseOutput.Click += new System.EventHandler(this.FolderBrowseOutput_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "FolderPath";
            // 
            // foldernameOutput
            // 
            this.foldernameOutput.Location = new System.Drawing.Point(356, 50);
            this.foldernameOutput.Name = "foldernameOutput";
            this.foldernameOutput.Size = new System.Drawing.Size(371, 20);
            this.foldernameOutput.TabIndex = 41;
            this.foldernameOutput.TextChanged += new System.EventHandler(this.foldernameOutput_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "INPUT";
            // 
            // FolderBrowse
            // 
            this.FolderBrowse.Location = new System.Drawing.Point(204, 18);
            this.FolderBrowse.Name = "FolderBrowse";
            this.FolderBrowse.Size = new System.Drawing.Size(75, 23);
            this.FolderBrowse.TabIndex = 39;
            this.FolderBrowse.Text = "Browse Folder";
            this.FolderBrowse.UseVisualStyleBackColor = true;
            this.FolderBrowse.Click += new System.EventHandler(this.FolderBrowse_Click);
            // 
            // folderPathLabel
            // 
            this.folderPathLabel.AutoSize = true;
            this.folderPathLabel.Location = new System.Drawing.Point(292, 23);
            this.folderPathLabel.Name = "folderPathLabel";
            this.folderPathLabel.Size = new System.Drawing.Size(58, 13);
            this.folderPathLabel.TabIndex = 38;
            this.folderPathLabel.Text = "FolderPath";
            // 
            // folderPath
            // 
            this.folderPath.Location = new System.Drawing.Point(356, 21);
            this.folderPath.Name = "folderPath";
            this.folderPath.Size = new System.Drawing.Size(371, 20);
            this.folderPath.TabIndex = 37;
            this.folderPath.TextChanged += new System.EventHandler(this.folderPath_TextChanged);
            // 
            // textBoxHue
            // 
            this.textBoxHue.Location = new System.Drawing.Point(794, 596);
            this.textBoxHue.Name = "textBoxHue";
            this.textBoxHue.Size = new System.Drawing.Size(63, 20);
            this.textBoxHue.TabIndex = 45;
            // 
            // textBoxSat
            // 
            this.textBoxSat.Location = new System.Drawing.Point(794, 647);
            this.textBoxSat.Name = "textBoxSat";
            this.textBoxSat.Size = new System.Drawing.Size(63, 20);
            this.textBoxSat.TabIndex = 46;
            // 
            // textBoxBright
            // 
            this.textBoxBright.Location = new System.Drawing.Point(794, 699);
            this.textBoxBright.Name = "textBoxBright";
            this.textBoxBright.Size = new System.Drawing.Size(63, 20);
            this.textBoxBright.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(812, 728);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "Ends";
            // 
            // textBoxStartHue
            // 
            this.textBoxStartHue.Location = new System.Drawing.Point(697, 596);
            this.textBoxStartHue.Name = "textBoxStartHue";
            this.textBoxStartHue.Size = new System.Drawing.Size(63, 20);
            this.textBoxStartHue.TabIndex = 49;
            // 
            // textBoxStartSat
            // 
            this.textBoxStartSat.Location = new System.Drawing.Point(697, 647);
            this.textBoxStartSat.Name = "textBoxStartSat";
            this.textBoxStartSat.Size = new System.Drawing.Size(63, 20);
            this.textBoxStartSat.TabIndex = 50;
            // 
            // textBoxStartBright
            // 
            this.textBoxStartBright.Location = new System.Drawing.Point(697, 699);
            this.textBoxStartBright.Name = "textBoxStartBright";
            this.textBoxStartBright.Size = new System.Drawing.Size(63, 20);
            this.textBoxStartBright.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(711, 728);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 52;
            this.label8.Text = "Start";
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(895, 594);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 53;
            this.buttonGo.Text = "RefreshPicturbox";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // scrollStartHue
            // 
            this.scrollStartHue.Location = new System.Drawing.Point(199, 583);
            this.scrollStartHue.Name = "scrollStartHue";
            this.scrollStartHue.Size = new System.Drawing.Size(478, 20);
            this.scrollStartHue.TabIndex = 54;
            this.scrollStartHue.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollStartHue_Scroll);
            // 
            // scrollEndHue
            // 
            this.scrollEndHue.Location = new System.Drawing.Point(199, 608);
            this.scrollEndHue.Name = "scrollEndHue";
            this.scrollEndHue.Size = new System.Drawing.Size(478, 22);
            this.scrollEndHue.TabIndex = 55;
            this.scrollEndHue.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollEndHue_Scroll);
            // 
            // scrollEndSat
            // 
            this.scrollEndSat.Location = new System.Drawing.Point(199, 664);
            this.scrollEndSat.Name = "scrollEndSat";
            this.scrollEndSat.Size = new System.Drawing.Size(478, 22);
            this.scrollEndSat.TabIndex = 57;
            this.scrollEndSat.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollEndSat_Scroll);
            // 
            // scrollStartSat
            // 
            this.scrollStartSat.Location = new System.Drawing.Point(199, 639);
            this.scrollStartSat.Name = "scrollStartSat";
            this.scrollStartSat.Size = new System.Drawing.Size(478, 20);
            this.scrollStartSat.TabIndex = 56;
            this.scrollStartSat.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollStartSat_Scroll);
            // 
            // scrollEndBright
            // 
            this.scrollEndBright.Location = new System.Drawing.Point(199, 725);
            this.scrollEndBright.Name = "scrollEndBright";
            this.scrollEndBright.Size = new System.Drawing.Size(478, 22);
            this.scrollEndBright.TabIndex = 59;
            this.scrollEndBright.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollEndBright_Scroll);
            // 
            // scrollStartBright
            // 
            this.scrollStartBright.Location = new System.Drawing.Point(199, 700);
            this.scrollStartBright.Name = "scrollStartBright";
            this.scrollStartBright.Size = new System.Drawing.Size(478, 20);
            this.scrollStartBright.TabIndex = 58;
            this.scrollStartBright.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollStartBright_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(167, 590);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 60;
            this.label9.Text = "Start";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(167, 639);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 61;
            this.label10.Text = "Start";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(167, 700);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 62;
            this.label11.Text = "Start";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(170, 725);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 63;
            this.label12.Text = "End";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(170, 664);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 13);
            this.label13.TabIndex = 64;
            this.label13.Text = "End";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(167, 608);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 65;
            this.label14.Text = "End";
            // 
            // buttonCropImage
            // 
            this.buttonCropImage.Location = new System.Drawing.Point(895, 647);
            this.buttonCropImage.Name = "buttonCropImage";
            this.buttonCropImage.Size = new System.Drawing.Size(75, 23);
            this.buttonCropImage.TabIndex = 66;
            this.buttonCropImage.Text = "CropImage";
            this.buttonCropImage.UseVisualStyleBackColor = true;
            this.buttonCropImage.Click += new System.EventHandler(this.buttonCropImage_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(734, 77);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBox1.Size = new System.Drawing.Size(248, 381);
            this.listBox1.TabIndex = 67;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // buttonNext
            // 
            this.buttonNext.Image = global::AutoCrop.Properties.Resources.arrow;
            this.buttonNext.Location = new System.Drawing.Point(805, 524);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(123, 23);
            this.buttonNext.TabIndex = 69;
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Image = global::AutoCrop.Properties.Resources.arrow180;
            this.buttonPrevious.Location = new System.Drawing.Point(804, 495);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(123, 23);
            this.buttonPrevious.TabIndex = 68;
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(7, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(720, 480);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 70;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TestRectangle
            // 
            this.TestRectangle.Location = new System.Drawing.Point(23, 608);
            this.TestRectangle.Name = "TestRectangle";
            this.TestRectangle.Size = new System.Drawing.Size(75, 93);
            this.TestRectangle.TabIndex = 71;
            this.TestRectangle.Text = "Test Rectangle";
            this.TestRectangle.UseVisualStyleBackColor = true;
            this.TestRectangle.Click += new System.EventHandler(this.TestRectangle_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(292, 559);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(291, 13);
            this.label15.TabIndex = 72;
            this.label15.Text = "Restrict the pixel profile you want to crop out with the scrolls.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 752);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.TestRectangle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonCropImage);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.scrollEndBright);
            this.Controls.Add(this.scrollStartBright);
            this.Controls.Add(this.scrollEndSat);
            this.Controls.Add(this.scrollStartSat);
            this.Controls.Add(this.scrollEndHue);
            this.Controls.Add(this.scrollStartHue);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxStartBright);
            this.Controls.Add(this.textBoxStartSat);
            this.Controls.Add(this.textBoxStartHue);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxBright);
            this.Controls.Add(this.textBoxSat);
            this.Controls.Add(this.textBoxHue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FolderBrowseOutput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.foldernameOutput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FolderBrowse);
            this.Controls.Add(this.folderPathLabel);
            this.Controls.Add(this.folderPath);
            this.Controls.Add(this.buttonCrop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCrop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button FolderBrowseOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox foldernameOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button FolderBrowse;
        private System.Windows.Forms.Label folderPathLabel;
        private System.Windows.Forms.TextBox folderPath;
        private System.Windows.Forms.TextBox textBoxHue;
        private System.Windows.Forms.TextBox textBoxSat;
        private System.Windows.Forms.TextBox textBoxBright;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxStartHue;
        private System.Windows.Forms.TextBox textBoxStartSat;
        private System.Windows.Forms.TextBox textBoxStartBright;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.HScrollBar scrollStartHue;
        private System.Windows.Forms.HScrollBar scrollEndHue;
        private System.Windows.Forms.HScrollBar scrollEndSat;
        private System.Windows.Forms.HScrollBar scrollStartSat;
        private System.Windows.Forms.HScrollBar scrollEndBright;
        private System.Windows.Forms.HScrollBar scrollStartBright;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button buttonCropImage;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button TestRectangle;
        private System.Windows.Forms.Label label15;
    }
}

