using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskCalculator {
    public class RiskResult {
        public string CounterPartyID { get; set; }
        public string Name { get; set; }
        public string CounterPartyType { get; set; }
        public double RiskPercentage {  get; set; }    // Add validator
    }
}
