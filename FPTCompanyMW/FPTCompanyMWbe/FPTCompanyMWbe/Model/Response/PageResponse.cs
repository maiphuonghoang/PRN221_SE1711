namespace FPTCompanyMWbe.Model.Response
{
    public class PageResponse<T>
    {
        public List<T> Content { get; set; }
        public int TotalPages { get; set; }
        public int PageIndex { get; set; }
        public int TotalElements { get; set; }

    }
}
