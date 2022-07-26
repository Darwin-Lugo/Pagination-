using Pagination.Entities;

namespace Pagination.Interfaces
{
    public interface IRepository
    {
        IQueryable<DataUser> DataUsers();
    }
}