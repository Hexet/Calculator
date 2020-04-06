namespace WinFormInterface
{
    partial class SettingsForm
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
            this.butBack = new System.Windows.Forms.Button();
            this.trackBarSetting = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.numUpDownSetting = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // butBack
            // 
            this.butBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butBack.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butBack.Location = new System.Drawing.Point(52, 401);
            this.butBack.Name = "butBack";
            this.butBack.Size = new System.Drawing.Size(250, 50);
            this.butBack.TabIndex = 0;
            this.butBack.Text = "готово";
            this.butBack.UseVisualStyleBackColor = true;
            // 
            // trackBarSetting
            // 
            this.trackBarSetting.Location = new System.Drawing.Point(82, 64);
            this.trackBarSetting.Maximum = 16;
            this.trackBarSetting.Minimum = 2;
            this.trackBarSetting.Name = "trackBarSetting";
            this.trackBarSetting.Size = new System.Drawing.Size(242, 45);
            this.trackBarSetting.TabIndex = 1;
            this.trackBarSetting.Value = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(23, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Изменить основание системы счисления:";
            // 
            // numUpDownSetting
            // 
            this.numUpDownSetting.Location = new System.Drawing.Point(28, 66);
            this.numUpDownSetting.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numUpDownSetting.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numUpDownSetting.Name = "numUpDownSetting";
            this.numUpDownSetting.Size = new System.Drawing.Size(41, 20);
            this.numUpDownSetting.TabIndex = 3;
            this.numUpDownSetting.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 490);
            this.Controls.Add(this.numUpDownSetting);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarSetting);
            this.Controls.Add(this.butBack);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownSetting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butBack;
        private System.Windows.Forms.TrackBar trackBarSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUpDownSetting;
    }
}