using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonarchDAL.Models
{
    public class BugModel
    {
        public int Id { get; set; }
        public int? LineNumber { get; set; }
        public string Title { get; set; }
        public Severity Severity { get; set; }
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public int ResolutionId { get;set; }

        public string ResolutionName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
