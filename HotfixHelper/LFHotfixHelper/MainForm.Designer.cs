
namespace LFHotfixHelper
{
    partial class MainForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rbConsole = new System.Windows.Forms.RichTextBox();
            this.plBottom = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.plBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbConsole
            // 
            this.rbConsole.BackColor = System.Drawing.Color.White;
            this.rbConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rbConsole.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbConsole.ForeColor = System.Drawing.Color.White;
            this.rbConsole.HideSelection = false;
            this.rbConsole.Location = new System.Drawing.Point(0, 0);
            this.rbConsole.Name = "rbConsole";
            this.rbConsole.ReadOnly = true;
            this.rbConsole.Size = new System.Drawing.Size(800, 389);
            this.rbConsole.TabIndex = 3;
            this.rbConsole.Text = "";
            // 
            // plBottom
            // 
            this.plBottom.BackColor = System.Drawing.SystemColors.Control;
            this.plBottom.Controls.Add(this.lblName);
            this.plBottom.Controls.Add(this.pbProgress);
            this.plBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plBottom.Location = new System.Drawing.Point(0, 389);
            this.plBottom.Name = "plBottom";
            this.plBottom.Size = new System.Drawing.Size(800, 61);
            this.plBottom.TabIndex = 4;
            this.plBottom.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(9, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(32, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "File : ";
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(12, 26);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(776, 23);
            this.pbProgress.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.plBottom);
            this.Controls.Add(this.rbConsole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotfix Helper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.plBottom.ResumeLayout(false);
            this.plBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rbConsole;
        private System.Windows.Forms.Panel plBottom;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ProgressBar pbProgress;
    }
}

