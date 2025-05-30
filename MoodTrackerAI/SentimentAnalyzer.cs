using Microsoft.ML;
using System.Collections.Generic;

namespace MoodTrackerAI
{
    public class SentimentAnalyzer
    {
        private MLContext mlContext;
        private ITransformer model;
        private PredictionEngine<SentimentData, SentimentPrediction> predictionEngine;

        public SentimentAnalyzer()
        {
            mlContext = new MLContext();
            TrainModel();
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

            model = pipeline.Fit(dataView);
            predictionEngine = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);
        }

        public SentimentPrediction Predict(string input)
        {
            var inputData = new SentimentData { Text = input };
            return predictionEngine.Predict(inputData);
        }
    }
}
