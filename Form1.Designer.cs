namespace WindowsFormsApplication1
{
    partial class Forumpointspy
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forumpointspy));
            this.linkbar = new System.Windows.Forms.TextBox();
            this.stratstop = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.checkinterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.savelog = new System.Windows.Forms.Button();
            this.checktimer = new System.Windows.Forms.Timer(this.components);
            this.logtext = new System.Windows.Forms.RichTextBox();
            this.topicreaders = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.checkinterval)).BeginInit();
            this.SuspendLayout();
            // 
            // linkbar
            // 
            this.linkbar.Location = new System.Drawing.Point(12, 25);
            this.linkbar.Name = "linkbar";
            this.linkbar.Size = new System.Drawing.Size(424, 20);
            this.linkbar.TabIndex = 1;
            // 
            // stratstop
            // 
            this.stratstop.Location = new System.Drawing.Point(489, 13);
            this.stratstop.Name = "stratstop";
            this.stratstop.Size = new System.Drawing.Size(112, 23);
            this.stratstop.TabIndex = 2;
            this.stratstop.Text = "Start spying!";
            this.stratstop.UseVisualStyleBackColor = true;
            this.stratstop.Click += new System.EventHandler(this.stratstop_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(388, 349);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(117, 23);
            this.clear.TabIndex = 3;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // checkinterval
            // 
            this.checkinterval.Location = new System.Drawing.Point(12, 91);
            this.checkinterval.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.checkinterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.checkinterval.Name = "checkinterval";
            this.checkinterval.Size = new System.Drawing.Size(120, 20);
            this.checkinterval.TabIndex = 5;
            this.checkinterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.checkinterval.ValueChanged += new System.EventHandler(this.checkinterval_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Check interval(sec):";
            // 
            // savelog
            // 
            this.savelog.Location = new System.Drawing.Point(511, 349);
            this.savelog.Name = "savelog";
            this.savelog.Size = new System.Drawing.Size(117, 23);
            this.savelog.TabIndex = 7;
            this.savelog.Text = "Save...";
            this.savelog.UseVisualStyleBackColor = true;
            this.savelog.Click += new System.EventHandler(this.savelog_Click);
            // 
            // checktimer
            // 
            this.checktimer.Interval = 5000;
            this.checktimer.Tick += new System.EventHandler(this.checktimer_Tick);
            // 
            // logtext
            // 
            this.logtext.Location = new System.Drawing.Point(12, 117);
            this.logtext.Name = "logtext";
            this.logtext.Size = new System.Drawing.Size(616, 214);
            this.logtext.TabIndex = 8;
            this.logtext.Text = "";
            // 
            // topicreaders
            // 
            this.topicreaders.Location = new System.Drawing.Point(213, 51);
            this.topicreaders.Name = "topicreaders";
            this.topicreaders.Size = new System.Drawing.Size(415, 65);
            this.topicreaders.TabIndex = 9;
            this.topicreaders.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Forumreaders:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(15, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(325, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Forum link(It works only Ip board forums and just inside of the topic):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "This program is under zlib licence. ";
            // 
            // Forumpointspy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 384);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.topicreaders);
            this.Controls.Add(this.logtext);
            this.Controls.Add(this.savelog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkinterval);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.stratstop);
            this.Controls.Add(this.linkbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Forumpointspy";
            this.Text = "Forumspy";
            ((System.ComponentModel.ISupportInitialize)(this.checkinterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox linkbar;
        private System.Windows.Forms.Button stratstop;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.NumericUpDown checkinterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button savelog;
        private System.Windows.Forms.Timer checktimer;
        private System.Windows.Forms.RichTextBox logtext;
        private System.Windows.Forms.RichTextBox topicreaders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

