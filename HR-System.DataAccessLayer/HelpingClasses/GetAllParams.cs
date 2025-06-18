namespace HR_System.DataAccessLayer.HelpingClasses
{
    public class GetAllParams
    {
        public string searchTxt {  get; set; }
        public string returnEntities {  get; set; }
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 10;
    }
}
