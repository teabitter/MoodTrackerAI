using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace MoodTrackerAI
{
    public class SentimentPrediction : SentimentData
    {
        [ColumnName("PredictedLabel")]
        public bool PredictedLabel { get; set; }   
        public float Probability { get; set; }
        public float Score { get; set; }    
    }
}
