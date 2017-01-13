using System.Collections.Generic;

namespace SouthWorks.Events.Solution.Models
{
    public class DataTableDataModel
    {
        public int sEcho { get; set; }

        public int iTotalRecords { get; set; }

        public int iTotalDisplayRecords { get; set; }

        public List<List<string>> aaData { get; set; }
    }
}