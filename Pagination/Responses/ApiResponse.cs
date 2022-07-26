using Pagination.CostumEntities;

namespace Pagination.Responses
{
    /// <summary>
    /// class response of system
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Status = string.Empty;
            Errors = null;
            Data = data;
        }

        #region  #Properties
        public T Data { get; set; }
        public string Status { get; set; }
        public bool Succeeded { get; set; }
        public string[]? Errors { get; set; }
        public string Message { get; set; }
        public MetaData? Meta { get; set; } 
        #endregion
    }
}
