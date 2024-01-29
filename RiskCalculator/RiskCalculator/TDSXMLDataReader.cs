using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskCalculator {
    public class TDSXMLDataReader {
        private string filePath;

        public TDSXMLDataReader() { }

        public TDSXMLDataReader(string filePath) { 
            this.filePath = filePath;
        }

        public void setFilePath(string filePath) {
            this.filePath = filePath;
        }

        public List<TDSDataModel> getTDSDataList() {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            string xPathExpression = "//TDSData";

            XmlNodeList tdsNodes = xmlDocument.SelectNodes(xPathExpression);

            List<TDSDataModel> tdsDataModelList = new List<TDSDataModel>();
            if (tdsNodes != null ) {
                foreach (XmlNode tdsNode in tdsNodes ) {
                    TDSDataModel tdsData = new TDSDataModel();

                    tdsData.TradeID = tdsNode.SelectSingleNode("tradeID")?.InnerText;
                    tdsData.Date = tdsNode.SelectSingleNode("date")?.InnerText;
                    int value = Int32.Parse(tdsNode.SelectSingleNode("value")?.InnerText);
                    tdsData.Value = value;
                    tdsData.CounterPartyIDRef = tdsNode.SelectSingleNode("counterPartyID")?.InnerText;

                    tdsDataModelList.Add(tdsData);
                }
            }

            return tdsDataModelList;
        }
    }
}
