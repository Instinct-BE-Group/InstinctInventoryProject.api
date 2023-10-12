using InstinctInventoryProject.Domain.Utilities;

namespace InstinctInventoryProject.Domain.Response
{
    public class APIListResponse<T> where T : class
    {
        public string Description { get; set; }
        public string Code { get; set; }
        public IEnumerable<T> Data { get; set; }
    }

    public class APIListResponse2<T> where T : class
    {
        public string Description { get; set; }
        public string Code { get; set; }
        public string Data { get; set; }
    }

    public class APIListResponse3<T> where T : class
    {
        public string Description { get; set; }
        public string Code { get; set; }
        public string PageInfo { get; set; }
        public PagedList<T> Data { get; set; }
    }
}