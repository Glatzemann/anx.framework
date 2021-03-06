﻿namespace ANX.ContentCompiler.GUI.Controls
{
    partial class RibbonButton
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelText = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelText
            // 
            this.labelText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelText.Location = new System.Drawing.Point(2, 61);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(57, 16);
            this.labelText.TabIndex = 1;
            this.labelText.Text = "Button";
            this.labelText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RibbonButtonMouseDown);
            this.labelText.MouseEnter += new System.EventHandler(this.RibbonButtonMouseEnter);
            this.labelText.MouseLeave += new System.EventHandler(this.RibbonButtonMouseLeave);
            this.labelText.MouseHover += new System.EventHandler(this.RibbonButtonMouseHover);
            this.labelText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RibbonButtonMouseUp);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(60, 60);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RibbonButtonMouseDown);
            this.pictureBox.MouseEnter += new System.EventHandler(this.RibbonButtonMouseEnter);
            this.pictureBox.MouseLeave += new System.EventHandler(this.RibbonButtonMouseLeave);
            this.pictureBox.MouseHover += new System.EventHandler(this.RibbonButtonMouseHover);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RibbonButtonMouseUp);
            // 
            // RibbonButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.pictureBox);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "RibbonButton";
            this.Size = new System.Drawing.Size(60, 79);
            this.Load += new System.EventHandler(this.RibbonButtonLoad);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RibbonButtonMouseDown);
            this.MouseEnter += new System.EventHandler(this.RibbonButtonMouseEnter);
            this.MouseLeave += new System.EventHandler(this.RibbonButtonMouseLeave);
            this.MouseHover += new System.EventHandler(this.RibbonButtonMouseHover);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RibbonButtonMouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}
