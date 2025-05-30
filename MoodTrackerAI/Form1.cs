using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoodTrackerAI
{
    public partial class Form1 : Form
    {
        private SentimentAnalyzer analyzer;
        public Form1()
        {
            InitializeComponent();
            analyzer = new SentimentAnalyzer();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            string input = txtEntry.Text;
            if(!string.IsNullOrWhiteSpace(input))
            {
                var prediction = analyzer.Predict(input);   
                lblMood.Text = prediction.PredictedLabel ? "Positive Mood" : "Negative Mood";
            }
            else
            {
                lblMood.Text = "Please enter some text to analyze.";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            analyzer = new SentimentAnalyzer();
        }
    }
}
