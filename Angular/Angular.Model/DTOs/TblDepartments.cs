using System;
using System.Collections.Generic;

namespace Angular.Model.DTOs
{
    public class TblDepartments
    {

        public int Id { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public int? OrderNumber { get; set; }
        public DateTime? CreateDate { get; set; }

        public List<TblClasses> TblClasses { get; set; }
        public List<TblSections> TblSections { get; set; }
    }
}
