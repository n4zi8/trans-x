using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA_Send_API.DataModel
{
    public class SysRTDBModel : ColumnBase
    {

        public string RTDBTableSpaceName { get; set; }
        public int RTDBiskSizeValue { get; set; }
        public int RTDBDiskUsageValue { get; set; }
        public int RTDBDiskFreeValue { get; set; }
        public int RTDBDiskPrecentage { get; set; }


        public SysRTDBModel()
        {
            DataType = ColumnType.DBFOModelType;
        }
    }
}