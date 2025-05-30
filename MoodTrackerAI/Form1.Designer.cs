namespace MoodTrackerAI
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txtEntry = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.lblMood = new System.Windows.Forms.Label();
            this.moodChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lstHistory = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.moodChart)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEntry
            // 
            this.txtEntry.Location = new System.Drawing.Point(107, 242);
            this.txtEntry.Multiline = true;
            this.txtEntry.Name = "txtEntry";
            this.txtEntry.Size = new System.Drawing.Size(273, 67);
            this.txtEntry.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(240, 378);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(140, 39);
            this.btnAnalyze.TabIndex = 2;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // lblMood
            // 
            this.lblMood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMood.Location = new System.Drawing.Point(474, 78);
            this.lblMood.Name = "lblMood";
            this.lblMood.Size = new System.Drawing.Size(202, 54);
            this.lblMood.TabIndex = 3;
            // 
            // moodChart
            // 
            chartArea1.Name = "ChartArea1";
            this.moodChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.moodChart.Legends.Add(legend1);
            this.moodChart.Location = new System.Drawing.Point(829, 182);
            this.moodChart.Name = "moodChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.moodChart.Series.Add(series1);
            this.moodChart.Size = new System.Drawing.Size(323, 329);
            this.moodChart.TabIndex = 4;
            this.moodChart.Text = "chart1";
            // 
            // lstHistory
            // 
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.ItemHeight = 25;
            this.lstHistory.Location = new System.Drawing.Point(528, 182);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(205, 329);
            this.lstHistory.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 634);
            this.Controls.Add(this.lstHistory);
            this.Controls.Add(this.moodChart);
            this.Controls.Add(this.lblMood);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.txtEntry);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.moodChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEntry;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Label lblMood;
        private System.Windows.Forms.DataVisualization.Charting.Chart moodChart;
        private System.Windows.Forms.ListBox lstHistory;
    }
}

