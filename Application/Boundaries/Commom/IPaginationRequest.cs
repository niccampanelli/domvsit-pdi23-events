namespace Application.Boundaries.Commom
{
    public interface IPaginationRequest
    {
        public int? Page { get; set; }
        public int? Limit { get; set; }
    }
}
