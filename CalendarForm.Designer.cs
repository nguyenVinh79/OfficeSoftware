namespace OfficeSoftware
{
    partial class CalendarForm
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
            this.CalendarDTGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ScrollTimer = new System.Windows.Forms.Timer(this.components);
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarDTGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // CalendarDTGV
            // 
            this.CalendarDTGV.AllowUserToAddRows = false;
            this.CalendarDTGV.AllowUserToDeleteRows = false;
            this.CalendarDTGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CalendarDTGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CalendarDTGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.CalendarDTGV.BackgroundColor = System.Drawing.SystemColors.Control;
            this.CalendarDTGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CalendarDTGV.Location = new System.Drawing.Point(0, 64);
            this.CalendarDTGV.Name = "CalendarDTGV";
            this.CalendarDTGV.ReadOnly = true;
            this.CalendarDTGV.RowHeadersWidth = 51;
            this.CalendarDTGV.Size = new System.Drawing.Size(1246, 489);
            this.CalendarDTGV.TabIndex = 0;
            this.CalendarDTGV.Text = "dataGridView1";
            this.CalendarDTGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CalendarDTGV_CellContentClick_1);
            this.CalendarDTGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.CalendarDTGV_CellFormatting);
            this.CalendarDTGV.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.CalendarDTGV_CellPainting);
            this.CalendarDTGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.CalendarDTGV_DataBindingComplete);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(419, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(424, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "LỊCH CÔNG TÁC CÁC PHÒNG/BAN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScrollTimer
            // 
            this.ScrollTimer.Interval = 10000;
            this.ScrollTimer.Tick += new System.EventHandler(this.ScrollTimer_Tick);
            // 
            // webView21
            // 
            this.webView21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(0, 551);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(1246, 71);
            this.webView21.TabIndex = 2;
            this.webView21.ZoomFactor = 1D;
            // 
            // CalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 622);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CalendarDTGV);
            this.DoubleBuffered = true;
            this.Name = "CalendarForm";
            this.Text = "CalendarForm";
            this.Load += new System.EventHandler(this.CalendarForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CalendarDTGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CalendarDTGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer ScrollTimer;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}