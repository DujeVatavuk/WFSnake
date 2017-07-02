namespace WFSnake
{
    partial class PlayerForm
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
            this.NickLabel = new System.Windows.Forms.Label();
            this.NickTextBox = new System.Windows.Forms.TextBox();
            this.LeaderboardDataGridView = new System.Windows.Forms.DataGridView();
            this.StartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LeaderboardDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // NickLabel
            // 
            this.NickLabel.AutoSize = true;
            this.NickLabel.Location = new System.Drawing.Point(13, 13);
            this.NickLabel.Name = "NickLabel";
            this.NickLabel.Size = new System.Drawing.Size(39, 17);
            this.NickLabel.TabIndex = 0;
            this.NickLabel.Text = "Nick:";
            // 
            // NickTextBox
            // 
            this.NickTextBox.Location = new System.Drawing.Point(59, 13);
            this.NickTextBox.MaxLength = 50;
            this.NickTextBox.Name = "NickTextBox";
            this.NickTextBox.Size = new System.Drawing.Size(330, 22);
            this.NickTextBox.TabIndex = 1;
            // 
            // LeaderboardDataGridView
            // 
            this.LeaderboardDataGridView.AllowUserToAddRows = false;
            this.LeaderboardDataGridView.AllowUserToDeleteRows = false;
            this.LeaderboardDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LeaderboardDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LeaderboardDataGridView.Location = new System.Drawing.Point(0, 42);
            this.LeaderboardDataGridView.MultiSelect = false;
            this.LeaderboardDataGridView.Name = "LeaderboardDataGridView";
            this.LeaderboardDataGridView.ReadOnly = true;
            this.LeaderboardDataGridView.RowTemplate.Height = 24;
            this.LeaderboardDataGridView.RowTemplate.ReadOnly = true;
            this.LeaderboardDataGridView.Size = new System.Drawing.Size(482, 411);
            this.LeaderboardDataGridView.TabIndex = 2;
            // 
            // StartButton
            // 
            this.StartButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.StartButton.Location = new System.Drawing.Point(395, 12);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start Game";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.LeaderboardDataGridView);
            this.Controls.Add(this.NickTextBox);
            this.Controls.Add(this.NickLabel);
            this.Name = "PlayerForm";
            this.Text = "PlayerForm";
            this.Shown += new System.EventHandler(this.PlayerForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.LeaderboardDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NickLabel;
        private System.Windows.Forms.Button StartButton;
        public System.Windows.Forms.DataGridView LeaderboardDataGridView;
        public System.Windows.Forms.TextBox NickTextBox;
    }
}