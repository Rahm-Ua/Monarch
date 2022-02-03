using System;
using System.ComponentModel;


namespace MonarchDOL.Models
{
    public class BugModel
    {
        public int Id { get; set; }
        [DisplayName("Line Number")]
        public int? LineNumber { get; set; }
        public string Title { get; set; }
        public Severity Severity { get; set; }
        public int CategoryId { get; set; }
        [DisplayName("Category")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public int ResolutionId { get;set; }
        [DisplayName("Resolution")]
        public string ResolutionName { get; set; }
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Modified Date")]
        public DateTime? ModifiedDate { get; set; }
    }
}
