#region References
using Microsoft.AspNetCore.Mvc;
using Pagination.CostumEntities;
using Pagination.Entities;
using Pagination.Interfaces;
using Pagination.QueryFilters;
using Pagination.Responses;
using System.Net;
#endregion

namespace Pagination.Controllers
{
    #region Decorator
    [Route("api/[controller]")]
    [ApiController] 
    #endregion
    public class UsersController : ControllerBase
    {
        #region DependencyInjection
        private readonly IUserServices _userServices;
        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        #endregion

        #region GetAlls
        [ActionName(nameof(GetAlls))]
        [HttpGet(template: "", Name = nameof(GetAlls))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<IQueryable<DataUser>>))]
        public IActionResult GetAlls([FromQuery] QueryFilter filter)
        {
            try
            {
                var userData = _userServices.GetData(filter);
                var metadata = new MetaData
                {
                    TotalCount = userData.TotalCount,
                    PageSize = userData.PageSize,
                    CurrentPage = userData.CurrentPage,
                    TotalPages = userData.TotalPages,
                    HasNextPage = userData.HasNext,
                    HasPreviousPage = userData.HasPrevious,
                };
                var linkBuilder = new PageLinkBuilder(Url, "GetAlls", null, userData.TotalPages, userData.PageSize, userData.TotalPages);
                var paging = new
                {
                    First = linkBuilder.FirstPage,
                    Previous = linkBuilder.PreviousPage,
                    Next = linkBuilder.NextPage,
                    Last = linkBuilder.LastPage
                };
                var response = new ApiResponse<IQueryable<DataUser>>(userData.AsQueryable())
                {
                    Meta = metadata,
                    Status = Convert.ToString((int)HttpStatusCode.OK),
                    Message = $"Exitoso"
                };
                Response.Headers.Add("X-Fist", Convert.ToString(paging.First));
                Response.Headers.Add("X-Previus", Convert.ToString(paging.Previous));
                Response.Headers.Add("X-Next", Convert.ToString(paging.Next));
                Response.Headers.Add("X-Last", Convert.ToString(paging.Last));
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion
    }
}
