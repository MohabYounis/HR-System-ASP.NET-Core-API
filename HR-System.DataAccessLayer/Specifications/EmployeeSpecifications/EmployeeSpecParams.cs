using System.ComponentModel.Design;

namespace HR_System.Core.Specifications.EmployeeSpecifications
{
    public class EmployeeSpecParams
    {
        private const int maxPageIndix = 10;
        private int pageSize = 10;

        public int PageSize                                     // Pagination
        {
            get { return pageSize; }
            set { pageSize = value > maxPageIndix ? maxPageIndix : value; }
        }
        public int PageIndex { get; set; } = 1;                 // Pagination
        public string Sort {  get; set; }                       // Sorting
        public int? DepartmentNum {  get; set; }                // Filtering
        public char? Gender { get; set; }                       // Filtering

        private string search;
        public string Search                                    // Searching
        {
            get { return search; }
            set { search = value?.ToLower(); }
        }
        public bool AllEmployees { get; set; } = true;
    }
}
