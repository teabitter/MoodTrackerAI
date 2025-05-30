using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;


namespace MoodTrackerAI
{
    public partial class Form1 : Form
    {
        private MLContext mlContext = new MLContext();
        private PredictionEngine<SentimentData, SentimentPrediction> predEngine;
        private List<(DateTime Time, bool IsPositive)> moodEntries = new List<(DateTime, bool)>();

        public Form1()
        {
            InitializeComponent();
            TrainModel();
            SetupChart();

        }

        private void TrainModel()
        {
            var trainingData = new List<SentimentData>
        {
            new SentimentData { Text = "I love today!", Label = true },
            new SentimentData { Text = "I'm sad and tired.", Label = false },
            new SentimentData { Text = "Life is okay.", Label = true },
            new SentimentData { Text = "This is the worst.", Label = false },
            new SentimentData { Text = "Amazing day!", Label = true }
        };

            var dataView = mlContext.Data.LoadFromEnumerable(trainingData);

            var pipeline = mlContext.Transforms.Text.FeaturizeText("Features", nameof(SentimentData.Text))
                .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));

            var model = pipeline.Fit(dataView);

            predEngine = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            var input = new SentimentData { Text = txtEntry.Text };
            var prediction = predEngine.Predict(input);

            lblMood.Text = prediction.Prediction ? "Positive 😊" : "Negative 😞";

            moodEntries.Add((DateTime.Now, prediction.Prediction));
            //UpdateChart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // This method can be used to initialize any components or settings when the form loads.
            // For example, you could set up the chart here if you decide to use it later.
        }
        private void SetupChart()
        {
            chartMood.Series.Clear();
            chartMood.Series.Add("Mood");
            chartMood.Series["Mood"].ChartType = SeriesChartType.Line;
            chartMood.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            chartMood.Series["Mood"].YValueType = ChartValueType.Int32;
            chartMood.ChartAreas[0].AxisY.Minimum = 0;
            chartMood.ChartAreas[0].AxisY.Maximum = 1;
            chartMood.ChartAreas[0].AxisY.Title = "Mood (0 = 😞, 1 = 😊)";
        }

        private void UpdateChart()
        {
            chartMood.Series["Mood"].Points.Clear();
            foreach (var entry in moodEntries)
            {
                chartMood.Series["Mood"].Points.AddXY(entry.Time, entry.IsPositive ? 1 : 0);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.Title = "Save Mood History";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.WriteLine("Time,Mood");
                        foreach (var entry in moodEntries)
                        {
                            string mood = entry.IsPositive ? "Positive" : "Negative";
                            writer.WriteLine($"{entry.Time},{mood}");
                        }
                    }

                    MessageBox.Show("Mood history saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
