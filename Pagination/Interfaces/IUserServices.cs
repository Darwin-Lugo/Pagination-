#region References
using Pagination.CostumEntities;
using Pagination.Entities;
using Pagination.QueryFilters;

#endregion

namespace Pagination.Interfaces
{
    public interface IUserServices
    {
        PagedList<DataUser> GetData(QueryFilter filter);
    }
}