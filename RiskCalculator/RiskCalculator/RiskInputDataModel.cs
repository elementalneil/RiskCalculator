using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskCalculator {
    public class RiskInputDataModel {
        public RDSDataModel RdsData { get; set; }
        public List<TDSDataModel> TDSDataModels { get; set; }
    }
}
