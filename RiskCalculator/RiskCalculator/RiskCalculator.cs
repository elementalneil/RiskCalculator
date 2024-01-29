using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskCalculator {
    public class RiskCalculator {
        private RiskParameter riskParameter;

        public RiskCalculator() {
            // Setting default Risk Parameters
            riskParameter = new RiskParameter();
            riskParameter.Param1 = 1.0;
            riskParameter.Param2 = 5.0;
        }

        public void configureRiskParameter(RiskParameter riskParameter) {
            this.riskParameter = riskParameter;
        }

        public List<RiskResult> calculate(List<RiskInputDataModel> riskInputs) {
            List<RiskResult> riskResults = new List<RiskResult>();

            foreach(RiskInputDataModel riskInputData in riskInputs) {
                double riskPercentage;

                // Business Logic to Calculate Risk Percentage
                double totalTradeVal = 0.0;
                int numTrades = 0;
                foreach(TDSDataModel tdsDataModel in riskInputData.TDSDataModels) {
                    totalTradeVal += tdsDataModel.Value;
                    numTrades++;
                }
                double avgTradeVal = totalTradeVal / numTrades;
                riskPercentage = 
                    avgTradeVal / (riskParameter.Param1 * avgTradeVal + riskParameter.Param2) * 100;

                RiskResult riskResult = new RiskResult();
                riskResult.CounterPartyID = riskInputData.RdsData.CounterPartyID;
                riskResult.CounterPartyType = riskInputData.RdsData.CounterPartyType;
                riskResult.Name = riskInputData.RdsData.Name;
                riskResult.RiskPercentage = riskPercentage;

                riskResults.Add(riskResult);
            }

            return riskResults;
        }
    }
}
