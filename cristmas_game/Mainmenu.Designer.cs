
namespace cristmas_game
{
    partial class Mainmenu
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
            this.start_Btn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // start_Btn
            // 
            this.start_Btn.BackColor = System.Drawing.Color.Transparent;
            this.start_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.start_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.start_Btn.Font = new System.Drawing.Font("Ravie", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_Btn.ForeColor = System.Drawing.Color.Red;
            this.start_Btn.Location = new System.Drawing.Point(384, 212);
            this.start_Btn.Name = "start_Btn";
            this.start_Btn.Size = new System.Drawing.Size(312, 78);
            this.start_Btn.TabIndex = 0;
            this.start_Btn.Text = "Start Game";
            this.start_Btn.UseVisualStyleBackColor = false;
            this.start_Btn.Click += new System.EventHandler(this.start_Btn_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Mainmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::cristmas_game.Properties.Resources.hatter1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1068, 477);
            this.Controls.Add(this.start_Btn);
            this.MaximumSize = new System.Drawing.Size(1084, 516);
            this.MinimumSize = new System.Drawing.Size(1084, 516);
            this.Name = "Mainmenu";
            this.Text = "Mainmenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button start_Btn;
        private System.Windows.Forms.Timer timer1;
    }
}