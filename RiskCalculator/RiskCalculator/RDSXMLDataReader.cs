using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RiskCalculator {
    public class RDSXMLDataReader {
        private string filePath;

        public RDSXMLDataReader() { }

        public RDSXMLDataReader(string filePath) {
            this.filePath = filePath;
        }

        public void setFilePath(string filePath) { 
            this.filePath = filePath;
        }

        public List<RDSDataModel> getRDSDataList() {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            string xPathExpression = "//RDSData";

            XmlNodeList rdsNodes = xmlDocument.SelectNodes(xPathExpression);

            List<RDSDataModel> rdsDataModelList = new List<RDSDataModel>();
            if (rdsNodes != null) {
                foreach (XmlNode rdsNode in rdsNodes) {
                    RDSDataModel rdsData = new RDSDataModel();

                    rdsData.CounterPartyID = rdsNode.SelectSingleNode("counterPartyID")?.InnerText;
                    rdsData.CounterPartyType = rdsNode.SelectSingleNode("counterPartyType")?.InnerText;
                    rdsData.Name = rdsNode.SelectSingleNode("name")?.InnerText;

                    rdsDataModelList.Add(rdsData);
                }
            }

            return rdsDataModelList;
        }
    }
}
