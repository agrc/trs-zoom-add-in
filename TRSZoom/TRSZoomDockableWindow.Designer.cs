namespace TRSZoom
{
    partial class TRSZoomDockableWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_Section = new System.Windows.Forms.ComboBox();
            this.cbo_Range = new System.Windows.Forms.ComboBox();
            this.cbo_Township = new System.Windows.Forms.ComboBox();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.zoomToTRS = new System.Windows.Forms.Button();
            this.S = new System.Windows.Forms.Label();
            this.R = new System.Windows.Forms.Label();
            this.T = new System.Windows.Forms.Label();
            this.Meridian = new System.Windows.Forms.GroupBox();
            this.UB = new System.Windows.Forms.RadioButton();
            this.SL = new System.Windows.Forms.RadioButton();
            this.Meridian.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(124, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 112;
            this.label1.Text = "optional";
            // 
            // cbo_Section
            // 
            this.cbo_Section.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbo_Section.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_Section.FormattingEnabled = true;
            this.cbo_Section.Location = new System.Drawing.Point(11, 172);
            this.cbo_Section.Name = "cbo_Section";
            this.cbo_Section.Size = new System.Drawing.Size(157, 21);
            this.cbo_Section.TabIndex = 2;
            this.cbo_Section.SelectedIndexChanged += new System.EventHandler(this.cbo_Section_SelectedIndexChanged);
            // 
            // cbo_Range
            // 
            this.cbo_Range.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbo_Range.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_Range.FormattingEnabled = true;
            this.cbo_Range.Location = new System.Drawing.Point(11, 132);
            this.cbo_Range.Name = "cbo_Range";
            this.cbo_Range.Size = new System.Drawing.Size(157, 21);
            this.cbo_Range.TabIndex = 1;
            this.cbo_Range.SelectedIndexChanged += new System.EventHandler(this.cbo_Range_SelectedIndexChanged);
            // 
            // cbo_Township
            // 
            this.cbo_Township.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbo_Township.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_Township.FormattingEnabled = true;
            this.cbo_Township.Location = new System.Drawing.Point(11, 92);
            this.cbo_Township.Name = "cbo_Township";
            this.cbo_Township.Size = new System.Drawing.Size(157, 21);
            this.cbo_Township.TabIndex = 0;
            this.cbo_Township.SelectedIndexChanged += new System.EventHandler(this.cbo_Township_SelectedIndexChanged);
            // 
            // messageBox
            // 
            this.messageBox.BackColor = System.Drawing.SystemColors.Control;
            this.messageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBox.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.messageBox.Location = new System.Drawing.Point(11, 242);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(157, 13);
            this.messageBox.TabIndex = 110;
            this.messageBox.TabStop = false;
            this.messageBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // zoomToTRS
            // 
            this.zoomToTRS.Location = new System.Drawing.Point(11, 212);
            this.zoomToTRS.Name = "zoomToTRS";
            this.zoomToTRS.Size = new System.Drawing.Size(157, 24);
            this.zoomToTRS.TabIndex = 3;
            this.zoomToTRS.Text = "Zoom";
            this.zoomToTRS.UseVisualStyleBackColor = true;
            this.zoomToTRS.Click += new System.EventHandler(this.zoomToTRS_Click);
            // 
            // S
            // 
            this.S.AutoSize = true;
            this.S.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.S.Location = new System.Drawing.Point(8, 156);
            this.S.Name = "S";
            this.S.Size = new System.Drawing.Size(50, 13);
            this.S.TabIndex = 109;
            this.S.Text = "Section";
            // 
            // R
            // 
            this.R.AutoSize = true;
            this.R.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R.Location = new System.Drawing.Point(8, 116);
            this.R.Name = "R";
            this.R.Size = new System.Drawing.Size(44, 13);
            this.R.TabIndex = 108;
            this.R.Text = "Range";
            // 
            // T
            // 
            this.T.AutoSize = true;
            this.T.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T.Location = new System.Drawing.Point(8, 76);
            this.T.Name = "T";
            this.T.Size = new System.Drawing.Size(61, 13);
            this.T.TabIndex = 107;
            this.T.Text = "Township";
            // 
            // Meridian
            // 
            this.Meridian.Controls.Add(this.UB);
            this.Meridian.Controls.Add(this.SL);
            this.Meridian.Location = new System.Drawing.Point(11, 10);
            this.Meridian.Name = "Meridian";
            this.Meridian.Size = new System.Drawing.Size(157, 57);
            this.Meridian.TabIndex = 111;
            this.Meridian.TabStop = false;
            this.Meridian.Text = "Meridian";
            // 
            // UB
            // 
            this.UB.Appearance = System.Windows.Forms.Appearance.Button;
            this.UB.AutoSize = true;
            this.UB.Location = new System.Drawing.Point(74, 22);
            this.UB.Name = "UB";
            this.UB.Size = new System.Drawing.Size(71, 23);
            this.UB.TabIndex = 1;
            this.UB.TabStop = true;
            this.UB.Text = "Unita Basin";
            this.UB.UseVisualStyleBackColor = true;
            // 
            // SL
            // 
            this.SL.Appearance = System.Windows.Forms.Appearance.Button;
            this.SL.AutoSize = true;
            this.SL.Checked = true;
            this.SL.Location = new System.Drawing.Point(6, 22);
            this.SL.Name = "SL";
            this.SL.Size = new System.Drawing.Size(62, 23);
            this.SL.TabIndex = 0;
            this.SL.TabStop = true;
            this.SL.Text = "Salt Lake";
            this.SL.UseVisualStyleBackColor = true;
            this.SL.CheckedChanged += new System.EventHandler(this.SL_CheckedChanged);
            // 
            // TRSZoomDockableWindow
            // 
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo_Section);
            this.Controls.Add(this.cbo_Range);
            this.Controls.Add(this.cbo_Township);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.zoomToTRS);
            this.Controls.Add(this.S);
            this.Controls.Add(this.R);
            this.Controls.Add(this.T);
            this.Controls.Add(this.Meridian);
            this.Name = "TRSZoomDockableWindow";
            this.Size = new System.Drawing.Size(179, 269);
            this.Meridian.ResumeLayout(false);
            this.Meridian.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_Section;
        private System.Windows.Forms.ComboBox cbo_Range;
        private System.Windows.Forms.ComboBox cbo_Township;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Button zoomToTRS;
        private System.Windows.Forms.Label S;
        private System.Windows.Forms.Label R;
        private System.Windows.Forms.Label T;
        private System.Windows.Forms.GroupBox Meridian;
        private System.Windows.Forms.RadioButton UB;
        private System.Windows.Forms.RadioButton SL;

    }
}
