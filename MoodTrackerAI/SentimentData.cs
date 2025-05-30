using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace MoodTrackerAI
{
    public class SentimentData
    {
        [LoadColumn(0)]
        public string Text { get; set; }
        [LoadColumn(1)]
        public bool Label { get; set; } // true for positive, false for negative
    }
}
