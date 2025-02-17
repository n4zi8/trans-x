using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA_Send_API.DataModel
{
    public class SysOTDBModel : ColumnBase
    {

        public string OTDBTableSpaceName { get; set; }
        public int OTDBiskSizeValue { get; set; }
        public int OTDBDiskUsageValue { get; set; }
        public int OTDBDiskFreeValue { get; set; }
        public int OTDBDiskPrecentage { get; set; }


        public SysOTDBModel()
        {
            DataType = ColumnType.DBFOModelType;
        }
    }
}