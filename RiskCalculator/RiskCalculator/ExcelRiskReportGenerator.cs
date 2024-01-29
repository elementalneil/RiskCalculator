using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskCalculator {
    public class ExcelRiskReportGenerator {
        private string targetFilePath;
        private List<RiskResult> riskResults;

        public ExcelRiskReportGenerator() {
            riskResults = new List<RiskResult>();
        }

        public void SetFilePath(string filePath) {
            this.targetFilePath = filePath;
        }
                
        public void GenerateReport(RiskResult riskResult) {
            riskResults.Add(riskResult);
        }

        public void Save() {
            // Store data in excel file
            StringBuilder csvContent = new StringBuilder();
            csvContent.AppendLine("CounterPartyID,Name,CounterPartyType,RiskPercentage");
            foreach (RiskResult riskResult in riskResults) {
                csvContent.AppendLine(
                    riskResult.CounterPartyID + "," +
                    riskResult.Name + "," +
                    riskResult.CounterPartyType + "," +
                    riskResult.RiskPercentage);
            }
            File.WriteAllText(targetFilePath, csvContent.ToString());
        }
    }
}
