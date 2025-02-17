using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA_Send_API.DataModel
{
    public class SysDBFOModel : ColumnBase
    {

        public string DBFOTableSpaceName { get; set; }
        public string DBFODiskSizeValue { get; set; }
        public string DBFODiskUsageValue { get; set; }
        public string DBFODiskFreeValue { get; set; }
        public string DBFODiskPrecentage { get; set; }



        public SysDBFOModel()
        {
            DataType = ColumnType.DBFOModelType;
        }
    }
}