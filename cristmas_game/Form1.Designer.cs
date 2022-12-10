
namespace cristmas_game
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.PresentLBL = new System.Windows.Forms.Label();
            this.PointLBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(18, 426);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Visible = false;
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // PresentLBL
            // 
            this.PresentLBL.AutoSize = true;
            this.PresentLBL.Location = new System.Drawing.Point(639, 83);
            this.PresentLBL.Name = "PresentLBL";
            this.PresentLBL.Size = new System.Drawing.Size(35, 13);
            this.PresentLBL.TabIndex = 1;
            this.PresentLBL.Text = "label1";
            // 
            // PointLBL
            // 
            this.PointLBL.AutoSize = true;
            this.PointLBL.Location = new System.Drawing.Point(639, 123);
            this.PointLBL.Name = "PointLBL";
            this.PointLBL.Size = new System.Drawing.Size(35, 13);
            this.PointLBL.TabIndex = 2;
            this.PointLBL.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PointLBL);
            this.Controls.Add(this.PresentLBL);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label PresentLBL;
        private System.Windows.Forms.Label PointLBL;
    }
}

