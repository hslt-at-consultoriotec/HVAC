namespace MEM_CALC_R00
{
    partial class FrmDataViewer
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
            this.dgdDataViewer = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgdDataViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // dgdDataViewer
            // 
            this.dgdDataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdDataViewer.Location = new System.Drawing.Point(12, 12);
            this.dgdDataViewer.Name = "dgdDataViewer";
            this.dgdDataViewer.RowTemplate.Height = 24;
            this.dgdDataViewer.Size = new System.Drawing.Size(871, 428);
            this.dgdDataViewer.TabIndex = 0;
            // 
            // FrmDataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 506);
            this.Controls.Add(this.dgdDataViewer);
            this.Name = "FrmDataViewer";
            this.Text = "FrmDataViewer";
            ((System.ComponentModel.ISupportInitialize)(this.dgdDataViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgdDataViewer;
    }
}