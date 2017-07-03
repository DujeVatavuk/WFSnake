namespace WFSnake
{
    partial class GameForm
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
            this.CanvasPictureBox = new System.Windows.Forms.PictureBox();
            this.RezultLabel = new System.Windows.Forms.Label();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.SnakeUpButton = new System.Windows.Forms.Button();
            this.SnakeDownButton = new System.Windows.Forms.Button();
            this.SnakeLeftButton = new System.Windows.Forms.Button();
            this.SnakeRightButton = new System.Windows.Forms.Button();
            this.SpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.WallDisabledCheckBox = new System.Windows.Forms.CheckBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.NickLabel = new System.Windows.Forms.Label();
            this.PlayerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CanvasPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // CanvasPictureBox
            // 
            this.CanvasPictureBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CanvasPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CanvasPictureBox.Location = new System.Drawing.Point(17, 16);
            this.CanvasPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.CanvasPictureBox.Name = "CanvasPictureBox";
            this.CanvasPictureBox.Size = new System.Drawing.Size(533, 492);
            this.CanvasPictureBox.TabIndex = 0;
            this.CanvasPictureBox.TabStop = false;
            this.CanvasPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.CanvasPictureBox_Paint);
            // 
            // RezultLabel
            // 
            this.RezultLabel.AutoSize = true;
            this.RezultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RezultLabel.Location = new System.Drawing.Point(589, 16);
            this.RezultLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RezultLabel.Name = "RezultLabel";
            this.RezultLabel.Size = new System.Drawing.Size(177, 46);
            this.RezultLabel.TabIndex = 1;
            this.RezultLabel.Text = "Rezultat:";
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ScoreLabel.Location = new System.Drawing.Point(787, 16);
            this.ScoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(0, 46);
            this.ScoreLabel.TabIndex = 2;
            // 
            // SnakeUpButton
            // 
            this.SnakeUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SnakeUpButton.Location = new System.Drawing.Point(695, 316);
            this.SnakeUpButton.Margin = new System.Windows.Forms.Padding(4);
            this.SnakeUpButton.Name = "SnakeUpButton";
            this.SnakeUpButton.Size = new System.Drawing.Size(100, 92);
            this.SnakeUpButton.TabIndex = 4;
            this.SnakeUpButton.TabStop = false;
            this.SnakeUpButton.Text = "▲";
            this.SnakeUpButton.UseVisualStyleBackColor = true;
            this.SnakeUpButton.Click += new System.EventHandler(this.SnakeUpButton_Click);
            // 
            // SnakeDownButton
            // 
            this.SnakeDownButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SnakeDownButton.Location = new System.Drawing.Point(695, 416);
            this.SnakeDownButton.Margin = new System.Windows.Forms.Padding(4);
            this.SnakeDownButton.Name = "SnakeDownButton";
            this.SnakeDownButton.Size = new System.Drawing.Size(100, 92);
            this.SnakeDownButton.TabIndex = 5;
            this.SnakeDownButton.TabStop = false;
            this.SnakeDownButton.Text = "▼";
            this.SnakeDownButton.UseVisualStyleBackColor = true;
            this.SnakeDownButton.Click += new System.EventHandler(this.SnakeDownButton_Click);
            // 
            // SnakeLeftButton
            // 
            this.SnakeLeftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SnakeLeftButton.Location = new System.Drawing.Point(587, 416);
            this.SnakeLeftButton.Margin = new System.Windows.Forms.Padding(4);
            this.SnakeLeftButton.Name = "SnakeLeftButton";
            this.SnakeLeftButton.Size = new System.Drawing.Size(100, 92);
            this.SnakeLeftButton.TabIndex = 6;
            this.SnakeLeftButton.TabStop = false;
            this.SnakeLeftButton.Text = "◀";
            this.SnakeLeftButton.UseVisualStyleBackColor = true;
            this.SnakeLeftButton.Click += new System.EventHandler(this.SnakeLeftButton_Click);
            // 
            // SnakeRightButton
            // 
            this.SnakeRightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SnakeRightButton.Location = new System.Drawing.Point(803, 416);
            this.SnakeRightButton.Margin = new System.Windows.Forms.Padding(4);
            this.SnakeRightButton.Name = "SnakeRightButton";
            this.SnakeRightButton.Size = new System.Drawing.Size(100, 92);
            this.SnakeRightButton.TabIndex = 7;
            this.SnakeRightButton.TabStop = false;
            this.SnakeRightButton.Text = "▶";
            this.SnakeRightButton.UseVisualStyleBackColor = true;
            this.SnakeRightButton.Click += new System.EventHandler(this.SnakeRightButton_Click);
            // 
            // SpeedTrackBar
            // 
            this.SpeedTrackBar.BackColor = System.Drawing.SystemColors.Control;
            this.SpeedTrackBar.Location = new System.Drawing.Point(992, 316);
            this.SpeedTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.SpeedTrackBar.Maximum = 40;
            this.SpeedTrackBar.Minimum = 10;
            this.SpeedTrackBar.Name = "SpeedTrackBar";
            this.SpeedTrackBar.Size = new System.Drawing.Size(271, 56);
            this.SpeedTrackBar.TabIndex = 11;
            this.SpeedTrackBar.TabStop = false;
            this.SpeedTrackBar.Value = 20;
            this.SpeedTrackBar.Scroll += new System.EventHandler(this.SpeedTrackBar_Scroll);
            // 
            // WallDisabledCheckBox
            // 
            this.WallDisabledCheckBox.AutoSize = true;
            this.WallDisabledCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WallDisabledCheckBox.Location = new System.Drawing.Point(992, 416);
            this.WallDisabledCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.WallDisabledCheckBox.Name = "WallDisabledCheckBox";
            this.WallDisabledCheckBox.Size = new System.Drawing.Size(272, 50);
            this.WallDisabledCheckBox.TabIndex = 12;
            this.WallDisabledCheckBox.Text = "zid isključen";
            this.WallDisabledCheckBox.UseVisualStyleBackColor = true;
            this.WallDisabledCheckBox.CheckedChanged += new System.EventHandler(this.WallEnabledCheckBox_CheckedChanged);
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StartButton.ForeColor = System.Drawing.Color.Red;
            this.StartButton.Location = new System.Drawing.Point(992, 15);
            this.StartButton.Margin = new System.Windows.Forms.Padding(4);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(472, 117);
            this.StartButton.TabIndex = 13;
            this.StartButton.Text = "Nova igra";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // NickLabel
            // 
            this.NickLabel.AutoSize = true;
            this.NickLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NickLabel.Location = new System.Drawing.Point(787, 173);
            this.NickLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NickLabel.Name = "NickLabel";
            this.NickLabel.Size = new System.Drawing.Size(0, 46);
            this.NickLabel.TabIndex = 15;
            // 
            // PlayerLabel
            // 
            this.PlayerLabel.AutoSize = true;
            this.PlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PlayerLabel.Location = new System.Drawing.Point(589, 173);
            this.PlayerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PlayerLabel.Name = "PlayerLabel";
            this.PlayerLabel.Size = new System.Drawing.Size(119, 46);
            this.PlayerLabel.TabIndex = 14;
            this.PlayerLabel.Text = "Igrač:";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1476, 526);
            this.Controls.Add(this.NickLabel);
            this.Controls.Add(this.PlayerLabel);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.WallDisabledCheckBox);
            this.Controls.Add(this.SpeedTrackBar);
            this.Controls.Add(this.SnakeRightButton);
            this.Controls.Add(this.SnakeLeftButton);
            this.Controls.Add(this.SnakeDownButton);
            this.Controls.Add(this.SnakeUpButton);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.RezultLabel);
            this.Controls.Add(this.CanvasPictureBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.Text = "Zmija";
            ((System.ComponentModel.ISupportInitialize)(this.CanvasPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label RezultLabel;
        private System.Windows.Forms.Button SnakeUpButton;
        private System.Windows.Forms.Button SnakeDownButton;
        private System.Windows.Forms.Button SnakeLeftButton;
        private System.Windows.Forms.Button SnakeRightButton;
        private System.Windows.Forms.Button StartButton;

        public System.Windows.Forms.Timer GameTimer;
        public System.Windows.Forms.PictureBox CanvasPictureBox;
        public System.Windows.Forms.Label ScoreLabel;
        public System.Windows.Forms.CheckBox WallDisabledCheckBox;
        public System.Windows.Forms.TrackBar SpeedTrackBar;
        public System.Windows.Forms.Label NickLabel;
        private System.Windows.Forms.Label PlayerLabel;
    }
}

