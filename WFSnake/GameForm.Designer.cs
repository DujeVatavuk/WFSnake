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
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.SnkUp = new System.Windows.Forms.Button();
            this.SnkDown = new System.Windows.Forms.Button();
            this.SnkLeft = new System.Windows.Forms.Button();
            this.SnkRight = new System.Windows.Forms.Button();
            this.TBSpeed = new System.Windows.Forms.TrackBar();
            this.WallDisabledCheckBox = new System.Windows.Forms.CheckBox();
            this.StartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pbCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCanvas.Location = new System.Drawing.Point(17, 16);
            this.pbCanvas.Margin = new System.Windows.Forms.Padding(4);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(533, 492);
            this.pbCanvas.TabIndex = 0;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvas_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(589, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rezultat:";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblScore.Location = new System.Drawing.Point(787, 16);
            this.lblScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(0, 46);
            this.lblScore.TabIndex = 2;
            // 
            // SnkUp
            // 
            this.SnkUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SnkUp.Location = new System.Drawing.Point(695, 316);
            this.SnkUp.Margin = new System.Windows.Forms.Padding(4);
            this.SnkUp.Name = "SnkUp";
            this.SnkUp.Size = new System.Drawing.Size(100, 92);
            this.SnkUp.TabIndex = 4;
            this.SnkUp.TabStop = false;
            this.SnkUp.Text = "▲";
            this.SnkUp.UseVisualStyleBackColor = true;
            this.SnkUp.Click += new System.EventHandler(this.SnkUp_Click);
            // 
            // SnkDown
            // 
            this.SnkDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SnkDown.Location = new System.Drawing.Point(695, 416);
            this.SnkDown.Margin = new System.Windows.Forms.Padding(4);
            this.SnkDown.Name = "SnkDown";
            this.SnkDown.Size = new System.Drawing.Size(100, 92);
            this.SnkDown.TabIndex = 5;
            this.SnkDown.TabStop = false;
            this.SnkDown.Text = "▼";
            this.SnkDown.UseVisualStyleBackColor = true;
            this.SnkDown.Click += new System.EventHandler(this.SnkDown_Click);
            // 
            // SnkLeft
            // 
            this.SnkLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SnkLeft.Location = new System.Drawing.Point(587, 416);
            this.SnkLeft.Margin = new System.Windows.Forms.Padding(4);
            this.SnkLeft.Name = "SnkLeft";
            this.SnkLeft.Size = new System.Drawing.Size(100, 92);
            this.SnkLeft.TabIndex = 6;
            this.SnkLeft.TabStop = false;
            this.SnkLeft.Text = "◀";
            this.SnkLeft.UseVisualStyleBackColor = true;
            this.SnkLeft.Click += new System.EventHandler(this.SnkLeft_Click);
            // 
            // SnkRight
            // 
            this.SnkRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SnkRight.Location = new System.Drawing.Point(803, 416);
            this.SnkRight.Margin = new System.Windows.Forms.Padding(4);
            this.SnkRight.Name = "SnkRight";
            this.SnkRight.Size = new System.Drawing.Size(100, 92);
            this.SnkRight.TabIndex = 7;
            this.SnkRight.TabStop = false;
            this.SnkRight.Text = "▶";
            this.SnkRight.UseVisualStyleBackColor = true;
            this.SnkRight.Click += new System.EventHandler(this.SnkRight_Click);
            // 
            // TBSpeed
            // 
            this.TBSpeed.BackColor = System.Drawing.SystemColors.Control;
            this.TBSpeed.Location = new System.Drawing.Point(992, 316);
            this.TBSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.TBSpeed.Maximum = 40;
            this.TBSpeed.Minimum = 10;
            this.TBSpeed.Name = "TBSpeed";
            this.TBSpeed.Size = new System.Drawing.Size(271, 56);
            this.TBSpeed.TabIndex = 11;
            this.TBSpeed.TabStop = false;
            this.TBSpeed.Value = 20;
            this.TBSpeed.Scroll += new System.EventHandler(this.TBSpeed_Scroll);
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
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1476, 526);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.WallDisabledCheckBox);
            this.Controls.Add(this.TBSpeed);
            this.Controls.Add(this.SnkRight);
            this.Controls.Add(this.SnkLeft);
            this.Controls.Add(this.SnkDown);
            this.Controls.Add(this.SnkUp);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbCanvas);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.Text = "Zmija";
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SnkUp;
        private System.Windows.Forms.Button SnkDown;
        private System.Windows.Forms.Button SnkLeft;
        private System.Windows.Forms.Button SnkRight;
        private System.Windows.Forms.Button StartButton;

        public System.Windows.Forms.Timer GameTimer;
        public System.Windows.Forms.PictureBox pbCanvas;
        public System.Windows.Forms.Label lblScore;
        public System.Windows.Forms.CheckBox WallDisabledCheckBox;
        public System.Windows.Forms.TrackBar TBSpeed;
    }
}

