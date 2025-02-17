using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA_Send_API.DataModel
{
    public class SysBridgeModel : ColumnBase
    {

        public string BRIDGETableSpaceName { get; set; }
        public int BRIDGEiskSizeValue { get; set; }
        public int BRIDGEDiskUsageValue { get; set; }
        public int BRIDGEDiskFreeValue { get; set; }
        public int BRIDGEDiskPrecentage { get; set; }


        public SysBridgeModel()
        {
            DataType = ColumnType.DBFOModelType;
        }
    }
}