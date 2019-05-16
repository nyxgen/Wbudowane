namespace Wbudowane
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.drawButton = new System.Windows.Forms.Button();
            this.nextItterationButton = new System.Windows.Forms.Button();
            this.randomInitButton = new System.Windows.Forms.Button();
            this.homogeneousInitButton = new System.Windows.Forms.Button();
            this.radiusInitButton = new System.Windows.Forms.Button();
            this.manualInitTextbox = new System.Windows.Forms.TextBox();
            this.bcComboBox = new System.Windows.Forms.ComboBox();
            this.manualInitLabel = new System.Windows.Forms.Label();
            this.bcLabel = new System.Windows.Forms.Label();
            this.resizeButton = new System.Windows.Forms.Button();
            this.toEndButton = new System.Windows.Forms.Button();
            this.initLabel = new System.Windows.Forms.Label();
            this.clearBoardButton = new System.Windows.Forms.Button();
            this.createCheckBox = new System.Windows.Forms.CheckBox();
            this.otherModeCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BackColor = System.Drawing.Color.Black;
            this.mainPictureBox.Location = new System.Drawing.Point(12, 12);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(550, 550);
            this.mainPictureBox.TabIndex = 1;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.Click += new System.EventHandler(this.mainPictureBox_Click);
            // 
            // drawButton
            // 
            this.drawButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.drawButton.Location = new System.Drawing.Point(583, 11);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(89, 23);
            this.drawButton.TabIndex = 2;
            this.drawButton.Text = "Draw";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // nextItterationButton
            // 
            this.nextItterationButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.nextItterationButton.Location = new System.Drawing.Point(583, 40);
            this.nextItterationButton.Name = "nextItterationButton";
            this.nextItterationButton.Size = new System.Drawing.Size(89, 23);
            this.nextItterationButton.TabIndex = 3;
            this.nextItterationButton.Text = "Next";
            this.nextItterationButton.UseVisualStyleBackColor = true;
            this.nextItterationButton.Click += new System.EventHandler(this.nextItterationButton_Click);
            // 
            // randomInitButton
            // 
            this.randomInitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.randomInitButton.Location = new System.Drawing.Point(583, 177);
            this.randomInitButton.Name = "randomInitButton";
            this.randomInitButton.Size = new System.Drawing.Size(89, 23);
            this.randomInitButton.TabIndex = 4;
            this.randomInitButton.Text = "Random";
            this.randomInitButton.UseVisualStyleBackColor = true;
            this.randomInitButton.Click += new System.EventHandler(this.randomInitButton_Click);
            // 
            // homogeneousInitButton
            // 
            this.homogeneousInitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.homogeneousInitButton.Location = new System.Drawing.Point(583, 206);
            this.homogeneousInitButton.Name = "homogeneousInitButton";
            this.homogeneousInitButton.Size = new System.Drawing.Size(89, 23);
            this.homogeneousInitButton.TabIndex = 5;
            this.homogeneousInitButton.Text = "Homogeneous";
            this.homogeneousInitButton.UseVisualStyleBackColor = true;
            this.homogeneousInitButton.Click += new System.EventHandler(this.homogeneousInitButton_Click);
            // 
            // radiusInitButton
            // 
            this.radiusInitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radiusInitButton.Location = new System.Drawing.Point(584, 236);
            this.radiusInitButton.Name = "radiusInitButton";
            this.radiusInitButton.Size = new System.Drawing.Size(88, 23);
            this.radiusInitButton.TabIndex = 6;
            this.radiusInitButton.Text = "Radius";
            this.radiusInitButton.UseVisualStyleBackColor = true;
            this.radiusInitButton.Click += new System.EventHandler(this.radiusInitButton_Click);
            // 
            // manualInitTextbox
            // 
            this.manualInitTextbox.BackColor = System.Drawing.Color.Silver;
            this.manualInitTextbox.ForeColor = System.Drawing.SystemColors.MenuText;
            this.manualInitTextbox.Location = new System.Drawing.Point(584, 297);
            this.manualInitTextbox.Name = "manualInitTextbox";
            this.manualInitTextbox.Size = new System.Drawing.Size(89, 20);
            this.manualInitTextbox.TabIndex = 8;
            this.manualInitTextbox.Text = "0";
            this.manualInitTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bcComboBox
            // 
            this.bcComboBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.bcComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bcComboBox.FormattingEnabled = true;
            this.bcComboBox.Items.AddRange(new object[] {
            "Sorption",
            "Periodic"});
            this.bcComboBox.Location = new System.Drawing.Point(584, 341);
            this.bcComboBox.Name = "bcComboBox";
            this.bcComboBox.Size = new System.Drawing.Size(89, 21);
            this.bcComboBox.TabIndex = 9;
            this.bcComboBox.SelectedIndexChanged += new System.EventHandler(this.bcComboBox_SelectedIndexChanged);
            // 
            // manualInitLabel
            // 
            this.manualInitLabel.AutoSize = true;
            this.manualInitLabel.Location = new System.Drawing.Point(609, 281);
            this.manualInitLabel.Name = "manualInitLabel";
            this.manualInitLabel.Size = new System.Drawing.Size(31, 13);
            this.manualInitLabel.TabIndex = 10;
            this.manualInitLabel.Text = "Color";
            // 
            // bcLabel
            // 
            this.bcLabel.AutoSize = true;
            this.bcLabel.Location = new System.Drawing.Point(619, 325);
            this.bcLabel.Name = "bcLabel";
            this.bcLabel.Size = new System.Drawing.Size(21, 13);
            this.bcLabel.TabIndex = 11;
            this.bcLabel.Text = "BC";
            // 
            // resizeButton
            // 
            this.resizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.resizeButton.Location = new System.Drawing.Point(584, 368);
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.Size = new System.Drawing.Size(89, 23);
            this.resizeButton.TabIndex = 12;
            this.resizeButton.Text = "Resize";
            this.resizeButton.UseVisualStyleBackColor = true;
            this.resizeButton.Click += new System.EventHandler(this.resizeButton_Click);
            // 
            // toEndButton
            // 
            this.toEndButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.toEndButton.Location = new System.Drawing.Point(583, 69);
            this.toEndButton.Name = "toEndButton";
            this.toEndButton.Size = new System.Drawing.Size(89, 23);
            this.toEndButton.TabIndex = 13;
            this.toEndButton.Text = "To end";
            this.toEndButton.UseVisualStyleBackColor = true;
            this.toEndButton.Click += new System.EventHandler(this.toEndButton_Click);
            // 
            // initLabel
            // 
            this.initLabel.AutoSize = true;
            this.initLabel.Location = new System.Drawing.Point(619, 161);
            this.initLabel.Name = "initLabel";
            this.initLabel.Size = new System.Drawing.Size(21, 13);
            this.initLabel.TabIndex = 14;
            this.initLabel.Text = "Init";
            // 
            // clearBoardButton
            // 
            this.clearBoardButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearBoardButton.Location = new System.Drawing.Point(584, 398);
            this.clearBoardButton.Name = "clearBoardButton";
            this.clearBoardButton.Size = new System.Drawing.Size(89, 23);
            this.clearBoardButton.TabIndex = 15;
            this.clearBoardButton.Text = "Clear";
            this.clearBoardButton.UseVisualStyleBackColor = true;
            this.clearBoardButton.Click += new System.EventHandler(this.clearBoardButton_Click);
            // 
            // createCheckBox
            // 
            this.createCheckBox.AutoSize = true;
            this.createCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.createCheckBox.Location = new System.Drawing.Point(592, 98);
            this.createCheckBox.Name = "createCheckBox";
            this.createCheckBox.Size = new System.Drawing.Size(80, 17);
            this.createCheckBox.TabIndex = 16;
            this.createCheckBox.Text = "Create new";
            this.createCheckBox.UseVisualStyleBackColor = true;
            // 
            // otherModeCheckBox
            // 
            this.otherModeCheckBox.AutoSize = true;
            this.otherModeCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.otherModeCheckBox.Location = new System.Drawing.Point(591, 121);
            this.otherModeCheckBox.Name = "otherModeCheckBox";
            this.otherModeCheckBox.Size = new System.Drawing.Size(81, 17);
            this.otherModeCheckBox.TabIndex = 17;
            this.otherModeCheckBox.Text = "Other mode";
            this.otherModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(694, 581);
            this.Controls.Add(this.otherModeCheckBox);
            this.Controls.Add(this.createCheckBox);
            this.Controls.Add(this.clearBoardButton);
            this.Controls.Add(this.initLabel);
            this.Controls.Add(this.toEndButton);
            this.Controls.Add(this.resizeButton);
            this.Controls.Add(this.bcLabel);
            this.Controls.Add(this.manualInitLabel);
            this.Controls.Add(this.bcComboBox);
            this.Controls.Add(this.manualInitTextbox);
            this.Controls.Add(this.radiusInitButton);
            this.Controls.Add(this.homogeneousInitButton);
            this.Controls.Add(this.randomInitButton);
            this.Controls.Add(this.nextItterationButton);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.mainPictureBox);
            this.Name = "MainForm";
            this.Text = "MW 0.5";
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseWheel);
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Button nextItterationButton;
        private System.Windows.Forms.Button randomInitButton;
        private System.Windows.Forms.Button homogeneousInitButton;
        private System.Windows.Forms.Button radiusInitButton;
        private System.Windows.Forms.TextBox manualInitTextbox;
        private System.Windows.Forms.ComboBox bcComboBox;
        private System.Windows.Forms.Label manualInitLabel;
        private System.Windows.Forms.Label bcLabel;
        private System.Windows.Forms.Button resizeButton;
        private System.Windows.Forms.Button toEndButton;
        private System.Windows.Forms.Label initLabel;
        private System.Windows.Forms.Button clearBoardButton;
        private System.Windows.Forms.CheckBox createCheckBox;
        private System.Windows.Forms.CheckBox otherModeCheckBox;
    }
}

