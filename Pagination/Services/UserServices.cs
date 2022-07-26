#region References
using Pagination.CostumEntities;
using Pagination.Entities;
using Pagination.Interfaces;
using Pagination.QueryFilters; 
#endregion

namespace Pagination.Services
{
    public class UserServices : IUserServices
    {
        #region DependencyInjection
        private readonly IRepository _repository;
        public UserServices(IRepository repository)
        {
            _repository = repository;
        } 
        #endregion

        #region GetAllsImagen
        public PagedList<DataUser> GetData(QueryFilter filter)
        {
            var datas = _repository.DataUsers();
            PagedList<DataUser> PageImagenes = PagedList<DataUser>.ToPagedList(datas, filter.PageNumber, filter.PageSize);
            return PageImagenes;
        }
        #endregion
    }
}
