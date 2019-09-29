using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCConfigurator.Web.Models
{
    public class DataTablesResponse
    {
        public int draw { get; set; }

        public int recordsTotal { get; set; }

        public int recordsFiltered { get; set; }

        public object[] data { get; set; }

        public string error { get; set; }
    }

    //public abstract class DataTableRow
    //{
    //    public string DT_RowId { get; set; }
    //}
}
