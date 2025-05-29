using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;


namespace MoodTrackerAI
{
    public class MoodAnalyzer
    {
        private readonly MLContext mlContext;
        private readonly PredictionEngine<SentimentData, SentimentPrediction> predictionEngine;

        public MoodAnalyzer()
        {
            mlContext = new MLContext();

            var trainingData = new List<SentimentData>
            {
                new SentimentData {Text = "I love today!"},
                new SentimentData {Text = "I'm sad and tired."},
                new SentimentData {Text = "Life is okay."},
                new SentimentData {Text = "This is the worst."},
                new SentimentData {Text = "Amazing day!"}
            };

            var dataView = mlContext.Data.LoadFromEnumerable(trainingData);

            var pipeline = mlContext.Transforms.Text.FeaturizeText("Features", nameof(SentimentData.Text))
                .Append(mlContext.Transforms.CopyColumns("Label", nameof(SentimentData.Text))) //dummy label
                .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
                    labelColumnName: "Label", featureColumnName: "Features"));

            var model = pipeline.Fit(dataView);
            predictionEngine = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);
        }

        public string PredictMood(string text)
        {
            var input = new SentimentData { Text = text };
            var result = predictionEngine.Predict(input);

            return result.PredictedLabel ? "Positive" : "Negative";
        }
    }
}
