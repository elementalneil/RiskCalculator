using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskCalculator {
    public class Program {
        static void Main(string[] args) {
            RDSXMLDataReader rdsReader = new RDSXMLDataReader();
            rdsReader.setFilePath(@"C:\Data\rds_data.xml");
            List<RDSDataModel> rdsDataModels = rdsReader.getRDSDataList();

            TDSXMLDataReader tdsReader = new TDSXMLDataReader();
            tdsReader.setFilePath(@"C:\Data\tds_data.xml");
            List<TDSDataModel> tdsDataModels = tdsReader.getTDSDataList();

            RDSTDSDataMerger merger = new RDSTDSDataMerger();
            List<RiskInputDataModel> riskInputs = merger.mergeData(rdsDataModels, tdsDataModels);

            RiskParameter riskParameter = new RiskParameter();
            riskParameter.Param1 = 5.6;
            riskParameter.Param2 = 10.0;

            RiskCalculator riskCalculator = new RiskCalculator();
            riskCalculator.configureRiskParameter(riskParameter);
            List<RiskResult> riskResults = riskCalculator.calculate(riskInputs);

            ExcelRiskReportGenerator excelRiskReportGenerator = new ExcelRiskReportGenerator();
            excelRiskReportGenerator.SetFilePath("C://Data/RiskResult.csv");
            foreach (RiskResult result in riskResults) {
                excelRiskReportGenerator.GenerateReport(result);
            }

            excelRiskReportGenerator.Save();
        }
    }
}
