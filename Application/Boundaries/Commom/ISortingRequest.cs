namespace Application.Boundaries.Commom
{
    public interface ISortingRequest
    {
        public string? SortField { get; set; }
        public string? SortOrder { get; set; }
    }
}
