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
        private MoodAnalyzer analyzer;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            string userInput = txtEntry.Text;
            string mood = analyzer.PredictMood(userInput);
            lblMood.Text = $"Predicted Mood: {mood}";   

            //add a save button for mood and entry to a list or file
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            analyzer = new MoodAnalyzer();
        }
    }
}
