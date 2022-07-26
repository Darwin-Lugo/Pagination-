namespace Pagination.CostumEntities
{
    public class MetaData
    {
        /// <summary>
        /// page data
        /// </summary>
        #region Properties
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; } 
        #endregion
    }
}
