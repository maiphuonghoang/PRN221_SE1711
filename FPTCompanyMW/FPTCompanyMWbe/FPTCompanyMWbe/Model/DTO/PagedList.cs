namespace FPTCompanyMWbe.Model.DTO
{
    public class PagedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int TotalElements { get; set; }
        public List<T> Content { get; set; } = new List<T>();
        public PagedList(List<T> items, int count, int pageIndex, int pageSize) { 
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalElements = count;
            Content = items.ToList();
            AddRange(items);
        }


        public static PagedList<T> Create(List<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex-1)*pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
