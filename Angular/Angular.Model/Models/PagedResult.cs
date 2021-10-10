using System;
using System.Collections.Generic;
using System.Text;

namespace Angular.Model.Models
{
    public abstract class PagedResultBase
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public int TotalItem { get; set; }
        public int FirstRowOnPage
        {
            get { return (CurrentPage - 1) * PageSize + 1; }
        }
        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, TotalItem); }
        }
    }
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public List<T> Results { get; set; }
        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}
