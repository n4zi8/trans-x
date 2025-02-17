using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA_Send_API.DataModel
{
    public class SysAODBModel : ColumnBase
    {

        public string AODBTableSpaceName { get; set; }
        public int AODBiskSizeValue { get; set; }
        public int AODBDiskUsageValue { get; set; }
        public int AODBDiskFreeValue { get; set; }
        public int AODBDiskPrecentage { get; set; }


        public SysAODBModel()
        {
            DataType = ColumnType.DBFOModelType;
        }
    }
}