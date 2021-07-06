
namespace FakeMenu
{
    partial class NDBO_T1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NDBO_T1));
            this.AddProcessOverlay = new System.Windows.Forms.Button();
            this.RemoveProcessOverlay = new System.Windows.Forms.Button();
            this.OverlayProcessList = new System.Windows.Forms.CheckedListBox();
            this.OverlaySettings = new System.Windows.Forms.Panel();
            this.ProcessOverlayImage = new System.Windows.Forms.PictureBox();
            this.ProcessHelp = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.RefreshProcessList = new System.Windows.Forms.Button();
            this.OverlayInfo = new System.Windows.Forms.Panel();
            this.RefreshOverlayInfo = new System.Windows.Forms.Button();
            this.OverlayNamesDisp = new System.Windows.Forms.Label();
            this.OverlayObjectsDisp = new System.Windows.Forms.Label();
            this.OverlaySettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessOverlayImage)).BeginInit();
            this.ProcessHelp.SuspendLayout();
            this.OverlayInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddProcessOverlay
            // 
            this.AddProcessOverlay.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddProcessOverlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddProcessOverlay.Location = new System.Drawing.Point(0, 0);
            this.AddProcessOverlay.Name = "AddProcessOverlay";
            this.AddProcessOverlay.Size = new System.Drawing.Size(281, 27);
            this.AddProcessOverlay.TabIndex = 0;
            this.AddProcessOverlay.Text = "Overlay Selected Process";
            this.AddProcessOverlay.UseVisualStyleBackColor = true;
            this.AddProcessOverlay.Click += new System.EventHandler(this.AddProcessOverlay_Click);
            // 
            // RemoveProcessOverlay
            // 
            this.RemoveProcessOverlay.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RemoveProcessOverlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveProcessOverlay.Location = new System.Drawing.Point(0, 166);
            this.RemoveProcessOverlay.Name = "RemoveProcessOverlay";
            this.RemoveProcessOverlay.Size = new System.Drawing.Size(281, 30);
            this.RemoveProcessOverlay.TabIndex = 1;
            this.RemoveProcessOverlay.Text = "RemoveProcessOverlay";
            this.RemoveProcessOverlay.UseVisualStyleBackColor = true;
            this.RemoveProcessOverlay.Click += new System.EventHandler(this.RemoveProcessOverlay_Click);
            // 
            // OverlayProcessList
            // 
            this.OverlayProcessList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverlayProcessList.FormattingEnabled = true;
            this.OverlayProcessList.Location = new System.Drawing.Point(0, 57);
            this.OverlayProcessList.Name = "OverlayProcessList";
            this.OverlayProcessList.ScrollAlwaysVisible = true;
            this.OverlayProcessList.Size = new System.Drawing.Size(259, 139);
            this.OverlayProcessList.TabIndex = 4;
            this.OverlayProcessList.ThreeDCheckBoxes = true;
            this.OverlayProcessList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OverlayProcessList_ItemCheck);
            // 
            // OverlaySettings
            // 
            this.OverlaySettings.Controls.Add(this.ProcessOverlayImage);
            this.OverlaySettings.Controls.Add(this.RemoveProcessOverlay);
            this.OverlaySettings.Controls.Add(this.AddProcessOverlay);
            this.OverlaySettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.OverlaySettings.Location = new System.Drawing.Point(259, 0);
            this.OverlaySettings.Name = "OverlaySettings";
            this.OverlaySettings.Size = new System.Drawing.Size(281, 196);
            this.OverlaySettings.TabIndex = 5;
            // 
            // ProcessOverlayImage
            // 
            this.ProcessOverlayImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessOverlayImage.Location = new System.Drawing.Point(0, 27);
            this.ProcessOverlayImage.Name = "ProcessOverlayImage";
            this.ProcessOverlayImage.Size = new System.Drawing.Size(281, 139);
            this.ProcessOverlayImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProcessOverlayImage.TabIndex = 3;
            this.ProcessOverlayImage.TabStop = false;
            // 
            // ProcessHelp
            // 
            this.ProcessHelp.Controls.Add(this.label1);
            this.ProcessHelp.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProcessHelp.Location = new System.Drawing.Point(0, 0);
            this.ProcessHelp.Name = "ProcessHelp";
            this.ProcessHelp.Size = new System.Drawing.Size(259, 30);
            this.ProcessHelp.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Checked Box\'s Mean An Overlay Exists";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RefreshProcessList
            // 
            this.RefreshProcessList.Dock = System.Windows.Forms.DockStyle.Top;
            this.RefreshProcessList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshProcessList.Location = new System.Drawing.Point(0, 30);
            this.RefreshProcessList.Name = "RefreshProcessList";
            this.RefreshProcessList.Size = new System.Drawing.Size(259, 27);
            this.RefreshProcessList.TabIndex = 4;
            this.RefreshProcessList.Text = "Refresh Process List";
            this.RefreshProcessList.UseVisualStyleBackColor = true;
            this.RefreshProcessList.Click += new System.EventHandler(this.RefreshProcessList_Click);
            // 
            // OverlayInfo
            // 
            this.OverlayInfo.Controls.Add(this.RefreshOverlayInfo);
            this.OverlayInfo.Controls.Add(this.OverlayNamesDisp);
            this.OverlayInfo.Controls.Add(this.OverlayObjectsDisp);
            this.OverlayInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OverlayInfo.Location = new System.Drawing.Point(0, 196);
            this.OverlayInfo.Name = "OverlayInfo";
            this.OverlayInfo.Size = new System.Drawing.Size(540, 38);
            this.OverlayInfo.TabIndex = 4;
            // 
            // RefreshOverlayInfo
            // 
            this.RefreshOverlayInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.RefreshOverlayInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshOverlayInfo.Location = new System.Drawing.Point(0, 0);
            this.RefreshOverlayInfo.Name = "RefreshOverlayInfo";
            this.RefreshOverlayInfo.Size = new System.Drawing.Size(84, 38);
            this.RefreshOverlayInfo.TabIndex = 2;
            this.RefreshOverlayInfo.Text = "Refresh";
            this.RefreshOverlayInfo.UseVisualStyleBackColor = true;
            this.RefreshOverlayInfo.Click += new System.EventHandler(this.RefreshOverlayInfo_Click);
            // 
            // OverlayNamesDisp
            // 
            this.OverlayNamesDisp.AutoSize = true;
            this.OverlayNamesDisp.Location = new System.Drawing.Point(90, 21);
            this.OverlayNamesDisp.Name = "OverlayNamesDisp";
            this.OverlayNamesDisp.Size = new System.Drawing.Size(35, 13);
            this.OverlayNamesDisp.TabIndex = 1;
            this.OverlayNamesDisp.Text = "label3";
            // 
            // OverlayObjectsDisp
            // 
            this.OverlayObjectsDisp.AutoSize = true;
            this.OverlayObjectsDisp.Location = new System.Drawing.Point(90, 3);
            this.OverlayObjectsDisp.Name = "OverlayObjectsDisp";
            this.OverlayObjectsDisp.Size = new System.Drawing.Size(35, 13);
            this.OverlayObjectsDisp.TabIndex = 0;
            this.OverlayObjectsDisp.Text = "label2";
            // 
            // NDBO_T1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 234);
            this.Controls.Add(this.OverlayProcessList);
            this.Controls.Add(this.RefreshProcessList);
            this.Controls.Add(this.ProcessHelp);
            this.Controls.Add(this.OverlaySettings);
            this.Controls.Add(this.OverlayInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(9986, 9994);
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "NDBO_T1";
            this.Text = "Testing: NHA DirtBoxOverlay";
            this.OverlaySettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProcessOverlayImage)).EndInit();
            this.ProcessHelp.ResumeLayout(false);
            this.OverlayInfo.ResumeLayout(false);
            this.OverlayInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddProcessOverlay;
        private System.Windows.Forms.Button RemoveProcessOverlay;
        private System.Windows.Forms.PictureBox ProcessOverlayImage;
        private System.Windows.Forms.Panel OverlaySettings;
        private System.Windows.Forms.Panel ProcessHelp;
        public System.Windows.Forms.CheckedListBox OverlayProcessList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RefreshProcessList;
        private System.Windows.Forms.Panel OverlayInfo;
        private System.Windows.Forms.Button RefreshOverlayInfo;
        private System.Windows.Forms.Label OverlayNamesDisp;
        private System.Windows.Forms.Label OverlayObjectsDisp;
    }
}

