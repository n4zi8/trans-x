using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA_Send_API.DataModel
{
    public class SysLedgerModel : ColumnBase
    {

        public string LedgerTableSpaceName { get; set; }
        public int LedefDiskSizeValue { get; set; }
        public int LedgerDiskUsageValue { get; set; }
        public int LedgerDiskFreeValue { get; set; }
        public int LedgerDiskPrecentage { get; set; }



        public SysLedgerModel()
        {
            DataType = ColumnType.DBFOModelType;
        }
    }
}