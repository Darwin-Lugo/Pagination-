#region References
using Pagination.Entities;
using Pagination.Interfaces; 
#endregion

namespace Pagination.Repositories
{
    public class Repository : IRepository
    {
        //
        public IQueryable<DataUser> DataUsers()
        {
            var datas = Enumerable.Range(0, 100).Select(x => new DataUser
            {
                Id = x,
                Name = $"Numero {x}",
                Email = $"Numero@{x}.com"

            }).AsQueryable();
            
            return datas;
        }
    }
}
