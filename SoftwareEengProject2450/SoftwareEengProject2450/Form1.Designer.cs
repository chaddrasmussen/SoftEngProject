namespace Library
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
            this.tabControlLibrary = new System.Windows.Forms.TabControl();
            this.tabLibraryMain = new System.Windows.Forms.TabPage();
            this.btnViewChkedPerPatron = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCheckInOut = new System.Windows.Forms.Button();
            this.btnSelectMedia = new System.Windows.Forms.Button();
            this.btnSelectPatron = new System.Windows.Forms.Button();
            this.txtDisplayChickInOut = new System.Windows.Forms.RichTextBox();
            this.txtDisplayMedia = new System.Windows.Forms.RichTextBox();
            this.btnDisplayAllMedia = new System.Windows.Forms.Button();
            this.txtSearchMedia = new System.Windows.Forms.TextBox();
            this.btnSearchMedia = new System.Windows.Forms.Button();
            this.lblSelectMedia = new System.Windows.Forms.Label();
            this.txtDisplayPatron = new System.Windows.Forms.RichTextBox();
            this.btnDisplayAllPatrons = new System.Windows.Forms.Button();
            this.txtSearchPatron = new System.Windows.Forms.TextBox();
            this.btnSearchPatron = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabListOverdue = new System.Windows.Forms.TabPage();
            this.btnDisplayOverdue = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.displayOverdueMedia = new System.Windows.Forms.RichTextBox();
            this.tabAddRemovePatron = new System.Windows.Forms.TabPage();
            this.tabAddRemoveMedia = new System.Windows.Forms.TabPage();
            this.btnQuit = new System.Windows.Forms.Button();
            this.tabControlLibrary.SuspendLayout();
            this.tabLibraryMain.SuspendLayout();
            this.tabListOverdue.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlLibrary
            // 
            this.tabControlLibrary.Controls.Add(this.tabLibraryMain);
            this.tabControlLibrary.Controls.Add(this.tabListOverdue);
            this.tabControlLibrary.Controls.Add(this.tabAddRemovePatron);
            this.tabControlLibrary.Controls.Add(this.tabAddRemoveMedia);
            this.tabControlLibrary.Location = new System.Drawing.Point(12, 12);
            this.tabControlLibrary.Name = "tabControlLibrary";
            this.tabControlLibrary.SelectedIndex = 0;
            this.tabControlLibrary.Size = new System.Drawing.Size(1004, 513);
            this.tabControlLibrary.TabIndex = 2;
            // 
            // tabLibraryMain
            // 
            this.tabLibraryMain.Controls.Add(this.btnViewChkedPerPatron);
            this.tabLibraryMain.Controls.Add(this.dateTimePicker);
            this.tabLibraryMain.Controls.Add(this.label2);
            this.tabLibraryMain.Controls.Add(this.btnCheckInOut);
            this.tabLibraryMain.Controls.Add(this.btnSelectMedia);
            this.tabLibraryMain.Controls.Add(this.btnSelectPatron);
            this.tabLibraryMain.Controls.Add(this.txtDisplayChickInOut);
            this.tabLibraryMain.Controls.Add(this.txtDisplayMedia);
            this.tabLibraryMain.Controls.Add(this.btnDisplayAllMedia);
            this.tabLibraryMain.Controls.Add(this.txtSearchMedia);
            this.tabLibraryMain.Controls.Add(this.btnSearchMedia);
            this.tabLibraryMain.Controls.Add(this.lblSelectMedia);
            this.tabLibraryMain.Controls.Add(this.txtDisplayPatron);
            this.tabLibraryMain.Controls.Add(this.btnDisplayAllPatrons);
            this.tabLibraryMain.Controls.Add(this.txtSearchPatron);
            this.tabLibraryMain.Controls.Add(this.btnSearchPatron);
            this.tabLibraryMain.Controls.Add(this.label1);
            this.tabLibraryMain.Location = new System.Drawing.Point(4, 22);
            this.tabLibraryMain.Name = "tabLibraryMain";
            this.tabLibraryMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabLibraryMain.Size = new System.Drawing.Size(996, 487);
            this.tabLibraryMain.TabIndex = 0;
            this.tabLibraryMain.Text = "Library Main";
            this.tabLibraryMain.UseVisualStyleBackColor = true;
            // 
            // btnViewChkedPerPatron
            // 
            this.btnViewChkedPerPatron.Location = new System.Drawing.Point(39, 437);
            this.btnViewChkedPerPatron.Name = "btnViewChkedPerPatron";
            this.btnViewChkedPerPatron.Size = new System.Drawing.Size(156, 23);
            this.btnViewChkedPerPatron.TabIndex = 27;
            this.btnViewChkedPerPatron.Text = "View Checked Out Media";
            this.btnViewChkedPerPatron.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(28, 38);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 18);
            this.label2.TabIndex = 25;
            this.label2.Text = "Select Date";
            // 
            // btnCheckInOut
            // 
            this.btnCheckInOut.Location = new System.Drawing.Point(695, 279);
            this.btnCheckInOut.Name = "btnCheckInOut";
            this.btnCheckInOut.Size = new System.Drawing.Size(267, 23);
            this.btnCheckInOut.TabIndex = 24;
            this.btnCheckInOut.Text = "CheckIn/Out";
            this.btnCheckInOut.UseVisualStyleBackColor = true;
            // 
            // btnSelectMedia
            // 
            this.btnSelectMedia.Location = new System.Drawing.Point(550, 437);
            this.btnSelectMedia.Name = "btnSelectMedia";
            this.btnSelectMedia.Size = new System.Drawing.Size(100, 23);
            this.btnSelectMedia.TabIndex = 23;
            this.btnSelectMedia.Text = "Select";
            this.btnSelectMedia.UseVisualStyleBackColor = true;
            // 
            // btnSelectPatron
            // 
            this.btnSelectPatron.Location = new System.Drawing.Point(229, 437);
            this.btnSelectPatron.Name = "btnSelectPatron";
            this.btnSelectPatron.Size = new System.Drawing.Size(96, 23);
            this.btnSelectPatron.TabIndex = 22;
            this.btnSelectPatron.Text = "Select";
            this.btnSelectPatron.UseVisualStyleBackColor = true;
            // 
            // txtDisplayChickInOut
            // 
            this.txtDisplayChickInOut.Location = new System.Drawing.Point(695, 161);
            this.txtDisplayChickInOut.Name = "txtDisplayChickInOut";
            this.txtDisplayChickInOut.ReadOnly = true;
            this.txtDisplayChickInOut.Size = new System.Drawing.Size(267, 96);
            this.txtDisplayChickInOut.TabIndex = 21;
            this.txtDisplayChickInOut.Text = "";
            // 
            // txtDisplayMedia
            // 
            this.txtDisplayMedia.Location = new System.Drawing.Point(354, 161);
            this.txtDisplayMedia.Name = "txtDisplayMedia";
            this.txtDisplayMedia.Size = new System.Drawing.Size(296, 270);
            this.txtDisplayMedia.TabIndex = 20;
            this.txtDisplayMedia.Text = "";
            // 
            // btnDisplayAllMedia
            // 
            this.btnDisplayAllMedia.Location = new System.Drawing.Point(354, 132);
            this.btnDisplayAllMedia.Name = "btnDisplayAllMedia";
            this.btnDisplayAllMedia.Size = new System.Drawing.Size(138, 23);
            this.btnDisplayAllMedia.TabIndex = 19;
            this.btnDisplayAllMedia.Text = "Display All";
            this.btnDisplayAllMedia.UseVisualStyleBackColor = true;
            // 
            // txtSearchMedia
            // 
            this.txtSearchMedia.Location = new System.Drawing.Point(354, 106);
            this.txtSearchMedia.Name = "txtSearchMedia";
            this.txtSearchMedia.Size = new System.Drawing.Size(296, 20);
            this.txtSearchMedia.TabIndex = 18;
            // 
            // btnSearchMedia
            // 
            this.btnSearchMedia.Location = new System.Drawing.Point(522, 132);
            this.btnSearchMedia.Name = "btnSearchMedia";
            this.btnSearchMedia.Size = new System.Drawing.Size(128, 23);
            this.btnSearchMedia.TabIndex = 17;
            this.btnSearchMedia.Text = "Search";
            this.btnSearchMedia.UseVisualStyleBackColor = true;
            // 
            // lblSelectMedia
            // 
            this.lblSelectMedia.AutoSize = true;
            this.lblSelectMedia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectMedia.Location = new System.Drawing.Point(351, 75);
            this.lblSelectMedia.Name = "lblSelectMedia";
            this.lblSelectMedia.Size = new System.Drawing.Size(105, 18);
            this.lblSelectMedia.TabIndex = 16;
            this.lblSelectMedia.Text = "Select Media";
            // 
            // txtDisplayPatron
            // 
            this.txtDisplayPatron.Location = new System.Drawing.Point(29, 160);
            this.txtDisplayPatron.Name = "txtDisplayPatron";
            this.txtDisplayPatron.Size = new System.Drawing.Size(296, 270);
            this.txtDisplayPatron.TabIndex = 15;
            this.txtDisplayPatron.Text = "";
            // 
            // btnDisplayAllPatrons
            // 
            this.btnDisplayAllPatrons.Location = new System.Drawing.Point(29, 131);
            this.btnDisplayAllPatrons.Name = "btnDisplayAllPatrons";
            this.btnDisplayAllPatrons.Size = new System.Drawing.Size(138, 23);
            this.btnDisplayAllPatrons.TabIndex = 14;
            this.btnDisplayAllPatrons.Text = "Display All";
            this.btnDisplayAllPatrons.UseVisualStyleBackColor = true;
            this.btnDisplayAllPatrons.Click += new System.EventHandler(this.btnDisplayAllPatrons_Click);
            // 
            // txtSearchPatron
            // 
            this.txtSearchPatron.Location = new System.Drawing.Point(29, 105);
            this.txtSearchPatron.Name = "txtSearchPatron";
            this.txtSearchPatron.Size = new System.Drawing.Size(296, 20);
            this.txtSearchPatron.TabIndex = 13;
            // 
            // btnSearchPatron
            // 
            this.btnSearchPatron.Location = new System.Drawing.Point(197, 131);
            this.btnSearchPatron.Name = "btnSearchPatron";
            this.btnSearchPatron.Size = new System.Drawing.Size(128, 23);
            this.btnSearchPatron.TabIndex = 12;
            this.btnSearchPatron.Text = "Search";
            this.btnSearchPatron.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Select Patron";
            // 
            // tabListOverdue
            // 
            this.tabListOverdue.Controls.Add(this.btnDisplayOverdue);
            this.tabListOverdue.Controls.Add(this.dateTimePicker2);
            this.tabListOverdue.Controls.Add(this.label4);
            this.tabListOverdue.Controls.Add(this.label3);
            this.tabListOverdue.Controls.Add(this.displayOverdueMedia);
            this.tabListOverdue.Location = new System.Drawing.Point(4, 22);
            this.tabListOverdue.Name = "tabListOverdue";
            this.tabListOverdue.Padding = new System.Windows.Forms.Padding(3);
            this.tabListOverdue.Size = new System.Drawing.Size(996, 487);
            this.tabListOverdue.TabIndex = 1;
            this.tabListOverdue.Text = "List Overdue Media";
            this.tabListOverdue.UseVisualStyleBackColor = true;
            // 
            // btnDisplayOverdue
            // 
            this.btnDisplayOverdue.Location = new System.Drawing.Point(362, 54);
            this.btnDisplayOverdue.Name = "btnDisplayOverdue";
            this.btnDisplayOverdue.Size = new System.Drawing.Size(75, 23);
            this.btnDisplayOverdue.TabIndex = 29;
            this.btnDisplayOverdue.Text = "Go!";
            this.btnDisplayOverdue.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(142, 55);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 18);
            this.label4.TabIndex = 27;
            this.label4.Text = "Select Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 18);
            this.label3.TabIndex = 26;
            this.label3.Text = "Overdue Books";
            // 
            // displayOverdueMedia
            // 
            this.displayOverdueMedia.Location = new System.Drawing.Point(24, 97);
            this.displayOverdueMedia.Name = "displayOverdueMedia";
            this.displayOverdueMedia.ReadOnly = true;
            this.displayOverdueMedia.Size = new System.Drawing.Size(947, 364);
            this.displayOverdueMedia.TabIndex = 0;
            this.displayOverdueMedia.Text = "";
            // 
            // tabAddRemovePatron
            // 
            this.tabAddRemovePatron.Location = new System.Drawing.Point(4, 22);
            this.tabAddRemovePatron.Name = "tabAddRemovePatron";
            this.tabAddRemovePatron.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddRemovePatron.Size = new System.Drawing.Size(996, 487);
            this.tabAddRemovePatron.TabIndex = 2;
            this.tabAddRemovePatron.Text = "Add/Remove Patron";
            this.tabAddRemovePatron.UseVisualStyleBackColor = true;
            // 
            // tabAddRemoveMedia
            // 
            this.tabAddRemoveMedia.Location = new System.Drawing.Point(4, 22);
            this.tabAddRemoveMedia.Name = "tabAddRemoveMedia";
            this.tabAddRemoveMedia.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddRemoveMedia.Size = new System.Drawing.Size(996, 487);
            this.tabAddRemoveMedia.TabIndex = 3;
            this.tabAddRemoveMedia.Text = "Add/Remove Media";
            this.tabAddRemoveMedia.UseVisualStyleBackColor = true;
            // 
            // btnQuit
            // 
            this.btnQuit.AutoSize = true;
            this.btnQuit.Location = new System.Drawing.Point(913, 541);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(99, 26);
            this.btnQuit.TabIndex = 27;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 579);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.tabControlLibrary);
            this.Name = "Form1";
            this.Text = "Library";
            this.tabControlLibrary.ResumeLayout(false);
            this.tabLibraryMain.ResumeLayout(false);
            this.tabLibraryMain.PerformLayout();
            this.tabListOverdue.ResumeLayout(false);
            this.tabListOverdue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlLibrary;
        private System.Windows.Forms.TabPage tabLibraryMain;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCheckInOut;
        private System.Windows.Forms.Button btnSelectMedia;
        private System.Windows.Forms.Button btnSelectPatron;
        private System.Windows.Forms.RichTextBox txtDisplayChickInOut;
        private System.Windows.Forms.RichTextBox txtDisplayMedia;
        private System.Windows.Forms.Button btnDisplayAllMedia;
        private System.Windows.Forms.TextBox txtSearchMedia;
        private System.Windows.Forms.Button btnSearchMedia;
        private System.Windows.Forms.Label lblSelectMedia;
        private System.Windows.Forms.RichTextBox txtDisplayPatron;
        private System.Windows.Forms.Button btnDisplayAllPatrons;
        private System.Windows.Forms.TextBox txtSearchPatron;
        private System.Windows.Forms.Button btnSearchPatron;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabListOverdue;
        private System.Windows.Forms.TabPage tabAddRemovePatron;
        private System.Windows.Forms.TabPage tabAddRemoveMedia;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnDisplayOverdue;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox displayOverdueMedia;
        private System.Windows.Forms.Button btnViewChkedPerPatron;

    }
}

