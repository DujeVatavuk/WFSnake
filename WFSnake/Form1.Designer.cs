namespace WFSnake
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
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.lblGameOver = new System.Windows.Forms.Label();
            this.SnkUp = new System.Windows.Forms.Button();
            this.SnkDown = new System.Windows.Forms.Button();
            this.SnkLeft = new System.Windows.Forms.Button();
            this.SnkRight = new System.Windows.Forms.Button();
            this.RBTipkovnica = new System.Windows.Forms.RadioButton();
            this.RBBotuni = new System.Windows.Forms.RadioButton();
            this.BtnUnos = new System.Windows.Forms.Button();
            this.TBSpeed = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pbCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCanvas.Location = new System.Drawing.Point(13, 13);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(360, 360);
            this.pbCanvas.TabIndex = 0;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Click += new System.EventHandler(this.pbCanvas_Click);
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvas_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(442, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rezultat:";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblScore.Location = new System.Drawing.Point(590, 13);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(0, 37);
            this.lblScore.TabIndex = 2;
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblGameOver.Location = new System.Drawing.Point(21, 19);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(86, 31);
            this.lblGameOver.TabIndex = 3;
            this.lblGameOver.Text = "label2";
            this.lblGameOver.Visible = false;
            // 
            // SnkUp
            // 
            this.SnkUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SnkUp.Location = new System.Drawing.Point(493, 217);
            this.SnkUp.Name = "SnkUp";
            this.SnkUp.Size = new System.Drawing.Size(75, 75);
            this.SnkUp.TabIndex = 4;
            this.SnkUp.Text = "▲";
            this.SnkUp.UseVisualStyleBackColor = true;
//            this.SnkUp.Click += new System.EventHandler(this.SnkUp_Click);
            // 
            // SnkDown
            // 
            this.SnkDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SnkDown.Location = new System.Drawing.Point(493, 298);
            this.SnkDown.Name = "SnkDown";
            this.SnkDown.Size = new System.Drawing.Size(75, 75);
            this.SnkDown.TabIndex = 5;
            this.SnkDown.Text = "▼";
            this.SnkDown.UseVisualStyleBackColor = true;
      //      this.SnkDown.Click += new System.EventHandler(this.SnkDown_Click);
            // 
            // SnkLeft
            // 
            this.SnkLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SnkLeft.Location = new System.Drawing.Point(412, 298);
            this.SnkLeft.Name = "SnkLeft";
            this.SnkLeft.Size = new System.Drawing.Size(75, 75);
            this.SnkLeft.TabIndex = 6;
            this.SnkLeft.Text = "◀";
            this.SnkLeft.UseVisualStyleBackColor = true;
      //      this.SnkLeft.Click += new System.EventHandler(this.SnkLeft_Click);
            // 
            // SnkRight
            // 
            this.SnkRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SnkRight.Location = new System.Drawing.Point(574, 298);
            this.SnkRight.Name = "SnkRight";
            this.SnkRight.Size = new System.Drawing.Size(75, 75);
            this.SnkRight.TabIndex = 7;
            this.SnkRight.Text = "▶";
            this.SnkRight.UseVisualStyleBackColor = true;
     //       this.SnkRight.Click += new System.EventHandler(this.SnkRight_Click);
            // 
            // RBTipkovnica
            // 
            this.RBTipkovnica.Checked = true;
            this.RBTipkovnica.Location = new System.Drawing.Point(697, 227);
            this.RBTipkovnica.Name = "RBTipkovnica";
            this.RBTipkovnica.Size = new System.Drawing.Size(78, 17);
            this.RBTipkovnica.TabIndex = 8;
            this.RBTipkovnica.TabStop = true;
            this.RBTipkovnica.Text = "Tipkovnica";
            this.RBTipkovnica.UseVisualStyleBackColor = true;
            // 
            // RBBotuni
            // 
            this.RBBotuni.AutoSize = true;
            this.RBBotuni.Location = new System.Drawing.Point(697, 250);
            this.RBBotuni.Name = "RBBotuni";
            this.RBBotuni.Size = new System.Drawing.Size(55, 17);
            this.RBBotuni.TabIndex = 9;
            this.RBBotuni.Text = "Botuni";
            this.RBBotuni.UseVisualStyleBackColor = true;
            // 
            // BtnUnos
            // 
            this.BtnUnos.Location = new System.Drawing.Point(781, 227);
            this.BtnUnos.Name = "BtnUnos";
            this.BtnUnos.Size = new System.Drawing.Size(119, 40);
            this.BtnUnos.TabIndex = 10;
            this.BtnUnos.Text = "Promjeni unos";
            this.BtnUnos.UseVisualStyleBackColor = true;
            this.BtnUnos.Click += new System.EventHandler(this.BtnUnos_Click);
            // 
            // TBSpeed
            // 
            this.TBSpeed.BackColor = System.Drawing.SystemColors.Control;
            this.TBSpeed.Location = new System.Drawing.Point(697, 298);
            this.TBSpeed.Maximum = 32;
            this.TBSpeed.Minimum = 16;
            this.TBSpeed.Name = "TBSpeed";
            this.TBSpeed.Size = new System.Drawing.Size(203, 45);
            this.TBSpeed.TabIndex = 11;
            this.TBSpeed.Value = 16;
            this.TBSpeed.Scroll += new System.EventHandler(this.TBSpeed_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 389);
            this.Controls.Add(this.TBSpeed);
            this.Controls.Add(this.BtnUnos);
            this.Controls.Add(this.RBBotuni);
            this.Controls.Add(this.RBTipkovnica);
            this.Controls.Add(this.SnkRight);
            this.Controls.Add(this.SnkLeft);
            this.Controls.Add(this.SnkDown);
            this.Controls.Add(this.SnkUp);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbCanvas);
            this.Name = "Form1";
            this.Text = "Zmija";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.Button SnkUp;
        private System.Windows.Forms.Button SnkDown;
        private System.Windows.Forms.Button SnkLeft;
        private System.Windows.Forms.Button SnkRight;
        private System.Windows.Forms.RadioButton RBTipkovnica;
        private System.Windows.Forms.RadioButton RBBotuni;
        private System.Windows.Forms.Button BtnUnos;
        private System.Windows.Forms.TrackBar TBSpeed;
    }
}

