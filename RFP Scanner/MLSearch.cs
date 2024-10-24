using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFP_Scanner
{
    internal class MLSearch
    {
    }
    public class Product
    {
        public string Name { get; set; }
        public List<string> Keywords { get; set; }
    }
    // Input class for ML.NET to handle the RFP text
    public class RfpInput
    {
        public string Text { get; set; }
    }
    // Output class to represent keyword presence or product detection
    public class KeywordPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool IsMatch { get; set; }
    }
}
