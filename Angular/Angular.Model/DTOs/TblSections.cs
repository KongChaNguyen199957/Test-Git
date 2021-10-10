using System;
using System.Collections.Generic;

namespace Angular.Model.DTOs
{
    public class TblSections
    {
        public int Id { get; set; }
        public string SectionCode { get; set; }
        public string SectionName { get; set; }
        public int? NumberOfSession { get; set; }
        public int? DepartmentId { get; set; }
        public int? OrderNumber { get; set; }
        public DateTime? CreateDate { get; set; }

        public TblDepartments Department { get; set; }
    }
}
