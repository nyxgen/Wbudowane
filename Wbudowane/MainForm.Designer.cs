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
            this.manualInitRTextbox = new System.Windows.Forms.TextBox();
            this.bcComboBox = new System.Windows.Forms.ComboBox();
            this.resizeButton = new System.Windows.Forms.Button();
            this.fillButton = new System.Windows.Forms.Button();
            this.clearBoardButton = new System.Windows.Forms.Button();
            this.manualInitGTextbox = new System.Windows.Forms.TextBox();
            this.manualInitBTextbox = new System.Windows.Forms.TextBox();
            this.bcGroupBox = new System.Windows.Forms.GroupBox();
            this.neighbourhoodComboBox = new System.Windows.Forms.ComboBox();
            this.drawingToolsGroupBox = new System.Windows.Forms.GroupBox();
            this.colorGroupBox = new System.Windows.Forms.GroupBox();
            this.initGroupBox = new System.Windows.Forms.GroupBox();
            this.itterationGroupBox = new System.Windows.Forms.GroupBox();
            this.displayGroupBox = new System.Windows.Forms.GroupBox();
            this.centerOfMassCheckBox = new System.Windows.Forms.CheckBox();
            this.monteCarloButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.bcGroupBox.SuspendLayout();
            this.drawingToolsGroupBox.SuspendLayout();
            this.colorGroupBox.SuspendLayout();
            this.initGroupBox.SuspendLayout();
            this.itterationGroupBox.SuspendLayout();
            this.displayGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BackColor = System.Drawing.Color.Black;
            this.mainPictureBox.Location = new System.Drawing.Point(12, 12);
            this.mainPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(550, 550);
            this.mainPictureBox.TabIndex = 1;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.Click += new System.EventHandler(this.mainPictureBox_Click);
            // 
            // drawButton
            // 
            this.drawButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.drawButton.Location = new System.Drawing.Point(6, 15);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(58, 23);
            this.drawButton.TabIndex = 2;
            this.drawButton.Text = "Draw";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // nextItterationButton
            // 
            this.nextItterationButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.nextItterationButton.Location = new System.Drawing.Point(30, 19);
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
            this.randomInitButton.Location = new System.Drawing.Point(31, 19);
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
            this.homogeneousInitButton.Location = new System.Drawing.Point(31, 49);
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
            this.radiusInitButton.Location = new System.Drawing.Point(31, 78);
            this.radiusInitButton.Name = "radiusInitButton";
            this.radiusInitButton.Size = new System.Drawing.Size(88, 23);
            this.radiusInitButton.TabIndex = 6;
            this.radiusInitButton.Text = "Radius";
            this.radiusInitButton.UseVisualStyleBackColor = true;
            this.radiusInitButton.Click += new System.EventHandler(this.radiusInitButton_Click);
            // 
            // manualInitRTextbox
            // 
            this.manualInitRTextbox.BackColor = System.Drawing.Color.Silver;
            this.manualInitRTextbox.ForeColor = System.Drawing.SystemColors.MenuText;
            this.manualInitRTextbox.Location = new System.Drawing.Point(6, 19);
            this.manualInitRTextbox.Name = "manualInitRTextbox";
            this.manualInitRTextbox.Size = new System.Drawing.Size(32, 20);
            this.manualInitRTextbox.TabIndex = 8;
            this.manualInitRTextbox.Text = "0";
            this.manualInitRTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bcComboBox
            // 
            this.bcComboBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.bcComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bcComboBox.FormattingEnabled = true;
            this.bcComboBox.Items.AddRange(new object[] {
            "Sorption",
            "Periodic"});
            this.bcComboBox.Location = new System.Drawing.Point(12, 19);
            this.bcComboBox.Name = "bcComboBox";
            this.bcComboBox.Size = new System.Drawing.Size(118, 21);
            this.bcComboBox.TabIndex = 9;
            this.bcComboBox.SelectedIndexChanged += new System.EventHandler(this.bcComboBox_SelectedIndexChanged);
            // 
            // resizeButton
            // 
            this.resizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.resizeButton.Location = new System.Drawing.Point(31, 83);
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.Size = new System.Drawing.Size(89, 23);
            this.resizeButton.TabIndex = 12;
            this.resizeButton.Text = "Resize";
            this.resizeButton.UseVisualStyleBackColor = true;
            this.resizeButton.Click += new System.EventHandler(this.resizeButton_Click);
            // 
            // fillButton
            // 
            this.fillButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fillButton.Location = new System.Drawing.Point(30, 48);
            this.fillButton.Name = "fillButton";
            this.fillButton.Size = new System.Drawing.Size(89, 23);
            this.fillButton.TabIndex = 13;
            this.fillButton.Text = "Fill";
            this.fillButton.UseVisualStyleBackColor = true;
            this.fillButton.Click += new System.EventHandler(this.toEndButton_Click);
            // 
            // clearBoardButton
            // 
            this.clearBoardButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearBoardButton.Location = new System.Drawing.Point(73, 15);
            this.clearBoardButton.Name = "clearBoardButton";
            this.clearBoardButton.Size = new System.Drawing.Size(57, 23);
            this.clearBoardButton.TabIndex = 15;
            this.clearBoardButton.Text = "Clear";
            this.clearBoardButton.UseVisualStyleBackColor = true;
            this.clearBoardButton.Click += new System.EventHandler(this.clearBoardButton_Click);
            // 
            // manualInitGTextbox
            // 
            this.manualInitGTextbox.BackColor = System.Drawing.Color.Silver;
            this.manualInitGTextbox.ForeColor = System.Drawing.SystemColors.MenuText;
            this.manualInitGTextbox.Location = new System.Drawing.Point(44, 19);
            this.manualInitGTextbox.Name = "manualInitGTextbox";
            this.manualInitGTextbox.Size = new System.Drawing.Size(32, 20);
            this.manualInitGTextbox.TabIndex = 18;
            this.manualInitGTextbox.Text = "0";
            this.manualInitGTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // manualInitBTextbox
            // 
            this.manualInitBTextbox.BackColor = System.Drawing.Color.Silver;
            this.manualInitBTextbox.ForeColor = System.Drawing.SystemColors.MenuText;
            this.manualInitBTextbox.Location = new System.Drawing.Point(82, 19);
            this.manualInitBTextbox.Name = "manualInitBTextbox";
            this.manualInitBTextbox.Size = new System.Drawing.Size(32, 20);
            this.manualInitBTextbox.TabIndex = 19;
            this.manualInitBTextbox.Text = "0";
            this.manualInitBTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bcGroupBox
            // 
            this.bcGroupBox.Controls.Add(this.neighbourhoodComboBox);
            this.bcGroupBox.Controls.Add(this.bcComboBox);
            this.bcGroupBox.Controls.Add(this.resizeButton);
            this.bcGroupBox.Location = new System.Drawing.Point(571, 325);
            this.bcGroupBox.Name = "bcGroupBox";
            this.bcGroupBox.Size = new System.Drawing.Size(143, 112);
            this.bcGroupBox.TabIndex = 20;
            this.bcGroupBox.TabStop = false;
            this.bcGroupBox.Text = "BC";
            // 
            // neighbourhoodComboBox
            // 
            this.neighbourhoodComboBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.neighbourhoodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.neighbourhoodComboBox.FormattingEnabled = true;
            this.neighbourhoodComboBox.Items.AddRange(new object[] {
            "von Neumann",
            "Moore",
            "Pentagonal",
            "Hexagonal",
            "Hexagonal-Right",
            "Hexagonal-Left",
            "Radius"});
            this.neighbourhoodComboBox.Location = new System.Drawing.Point(12, 47);
            this.neighbourhoodComboBox.Name = "neighbourhoodComboBox";
            this.neighbourhoodComboBox.Size = new System.Drawing.Size(118, 21);
            this.neighbourhoodComboBox.TabIndex = 13;
            this.neighbourhoodComboBox.SelectedIndexChanged += new System.EventHandler(this.neighbourhoodComboBox_SelectedIndexChanged);
            // 
            // drawingToolsGroupBox
            // 
            this.drawingToolsGroupBox.Controls.Add(this.colorGroupBox);
            this.drawingToolsGroupBox.Controls.Add(this.drawButton);
            this.drawingToolsGroupBox.Controls.Add(this.clearBoardButton);
            this.drawingToolsGroupBox.Location = new System.Drawing.Point(571, 219);
            this.drawingToolsGroupBox.Name = "drawingToolsGroupBox";
            this.drawingToolsGroupBox.Size = new System.Drawing.Size(143, 100);
            this.drawingToolsGroupBox.TabIndex = 21;
            this.drawingToolsGroupBox.TabStop = false;
            this.drawingToolsGroupBox.Text = "Drawing tools";
            // 
            // colorGroupBox
            // 
            this.colorGroupBox.Controls.Add(this.manualInitRTextbox);
            this.colorGroupBox.Controls.Add(this.manualInitGTextbox);
            this.colorGroupBox.Controls.Add(this.manualInitBTextbox);
            this.colorGroupBox.Location = new System.Drawing.Point(6, 44);
            this.colorGroupBox.Name = "colorGroupBox";
            this.colorGroupBox.Size = new System.Drawing.Size(124, 50);
            this.colorGroupBox.TabIndex = 0;
            this.colorGroupBox.TabStop = false;
            this.colorGroupBox.Text = "Color";
            // 
            // initGroupBox
            // 
            this.initGroupBox.Controls.Add(this.randomInitButton);
            this.initGroupBox.Controls.Add(this.homogeneousInitButton);
            this.initGroupBox.Controls.Add(this.radiusInitButton);
            this.initGroupBox.Location = new System.Drawing.Point(571, 99);
            this.initGroupBox.Name = "initGroupBox";
            this.initGroupBox.Size = new System.Drawing.Size(143, 114);
            this.initGroupBox.TabIndex = 22;
            this.initGroupBox.TabStop = false;
            this.initGroupBox.Text = "Init";
            // 
            // itterationGroupBox
            // 
            this.itterationGroupBox.Controls.Add(this.nextItterationButton);
            this.itterationGroupBox.Controls.Add(this.fillButton);
            this.itterationGroupBox.Location = new System.Drawing.Point(571, 12);
            this.itterationGroupBox.Name = "itterationGroupBox";
            this.itterationGroupBox.Size = new System.Drawing.Size(143, 81);
            this.itterationGroupBox.TabIndex = 23;
            this.itterationGroupBox.TabStop = false;
            this.itterationGroupBox.Text = "Itteration";
            // 
            // displayGroupBox
            // 
            this.displayGroupBox.Controls.Add(this.centerOfMassCheckBox);
            this.displayGroupBox.Location = new System.Drawing.Point(571, 452);
            this.displayGroupBox.Name = "displayGroupBox";
            this.displayGroupBox.Size = new System.Drawing.Size(143, 52);
            this.displayGroupBox.TabIndex = 24;
            this.displayGroupBox.TabStop = false;
            this.displayGroupBox.Text = "Display";
            // 
            // centerOfMassCheckBox
            // 
            this.centerOfMassCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.centerOfMassCheckBox.AutoSize = true;
            this.centerOfMassCheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.centerOfMassCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.centerOfMassCheckBox.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.centerOfMassCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.centerOfMassCheckBox.Location = new System.Drawing.Point(30, 19);
            this.centerOfMassCheckBox.Name = "centerOfMassCheckBox";
            this.centerOfMassCheckBox.Size = new System.Drawing.Size(88, 23);
            this.centerOfMassCheckBox.TabIndex = 0;
            this.centerOfMassCheckBox.Text = "Center of Mass";
            this.centerOfMassCheckBox.UseVisualStyleBackColor = true;
            this.centerOfMassCheckBox.CheckedChanged += new System.EventHandler(this.centerOfMassCheckBox_CheckedChanged);
            // 
            // monteCarloButton
            // 
            this.monteCarloButton.Location = new System.Drawing.Point(601, 510);
            this.monteCarloButton.Name = "monteCarloButton";
            this.monteCarloButton.Size = new System.Drawing.Size(88, 23);
            this.monteCarloButton.TabIndex = 1;
            this.monteCarloButton.Text = "Monte Carlo";
            this.monteCarloButton.UseVisualStyleBackColor = true;
            this.monteCarloButton.Click += new System.EventHandler(this.monteCarloButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(719, 581);
            this.Controls.Add(this.monteCarloButton);
            this.Controls.Add(this.displayGroupBox);
            this.Controls.Add(this.itterationGroupBox);
            this.Controls.Add(this.initGroupBox);
            this.Controls.Add(this.drawingToolsGroupBox);
            this.Controls.Add(this.bcGroupBox);
            this.Controls.Add(this.mainPictureBox);
            this.Name = "MainForm";
            this.Text = "MW 0.5";
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseWheel);
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.bcGroupBox.ResumeLayout(false);
            this.drawingToolsGroupBox.ResumeLayout(false);
            this.colorGroupBox.ResumeLayout(false);
            this.colorGroupBox.PerformLayout();
            this.initGroupBox.ResumeLayout(false);
            this.itterationGroupBox.ResumeLayout(false);
            this.displayGroupBox.ResumeLayout(false);
            this.displayGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Button nextItterationButton;
        private System.Windows.Forms.Button randomInitButton;
        private System.Windows.Forms.Button homogeneousInitButton;
        private System.Windows.Forms.Button radiusInitButton;
        private System.Windows.Forms.TextBox manualInitRTextbox;
        private System.Windows.Forms.ComboBox bcComboBox;
        private System.Windows.Forms.Button resizeButton;
        private System.Windows.Forms.Button fillButton;
        private System.Windows.Forms.Button clearBoardButton;
        private System.Windows.Forms.TextBox manualInitGTextbox;
        private System.Windows.Forms.TextBox manualInitBTextbox;
        private System.Windows.Forms.GroupBox bcGroupBox;
        private System.Windows.Forms.GroupBox drawingToolsGroupBox;
        private System.Windows.Forms.GroupBox colorGroupBox;
        private System.Windows.Forms.GroupBox initGroupBox;
        private System.Windows.Forms.GroupBox itterationGroupBox;
        private System.Windows.Forms.ComboBox neighbourhoodComboBox;
        private System.Windows.Forms.GroupBox displayGroupBox;
        private System.Windows.Forms.CheckBox centerOfMassCheckBox;
        private System.Windows.Forms.Button monteCarloButton;
    }
}

