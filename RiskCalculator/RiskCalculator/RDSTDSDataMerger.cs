using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskCalculator {
    public class RDSTDSDataMerger {
        public List<RiskInputDataModel> mergeData
            (List<RDSDataModel> rdsArray, List<TDSDataModel> tdsArray) {
            List<RiskInputDataModel> riskInputDataModels = new List<RiskInputDataModel> ();

            foreach (RDSDataModel rdsData in rdsArray) {
                List<TDSDataModel> tdsArrayTemp = new List<TDSDataModel> ();
                foreach (TDSDataModel tdsData in tdsArray) {
                    if (rdsData.CounterPartyID == tdsData.CounterPartyIDRef) {
                        tdsArrayTemp.Add(tdsData);
                    }
                }
                
                RiskInputDataModel riskInputData = new RiskInputDataModel ();
                riskInputData.RdsData = rdsData;
                riskInputData.TDSDataModels = tdsArrayTemp;

                riskInputDataModels.Add(riskInputData);
            }

            return riskInputDataModels;
        }
    }
}
