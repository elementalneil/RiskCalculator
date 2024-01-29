using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskCalculator {
    public class TDSDataModel {
        public string TradeID { get; set; }
        public string Date { get; set; }
        public int Value { get; set; }
        public string CounterPartyIDRef {  get; set; }
    }
}
