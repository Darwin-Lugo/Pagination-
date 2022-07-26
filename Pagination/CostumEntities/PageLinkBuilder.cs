#region References
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Routing;
#endregion

namespace Pagination.CostumEntities
{
    public class PageLinkBuilder
    {
        #region Properties
        public Uri? FirstPage { get; private set; }
        public Uri? LastPage { get; private set; }
        public Uri? NextPage { get; private set; }
        public Uri? PreviousPage { get; private set; }
        #endregion

        #region Funtion
        public PageLinkBuilder(IUrlHelper urlHelper, string routeName, object routeValues, int pageNo, int pageSize, long totalRecordCount)
        {
            // Determine total number of pages
            var pageCount = totalRecordCount > 0 ? (int)Math.Ceiling(totalRecordCount / (double)pageSize) : 0;

            // Create them page links 
            FirstPage = new Uri(urlHelper.Link(routeName, new HttpRouteValueDictionary(routeValues)
            {
                 {"pageNo", 1},
                 {"pageSize", pageSize}
            }));

            LastPage = new Uri(urlHelper.Link(routeName, new HttpRouteValueDictionary(routeValues)
            {
                 {"pageNo", totalRecordCount},
                 {"pageSize", pageSize}
            }));

            if (pageCount < 1)
            {
                PreviousPage = new Uri(urlHelper.Link(routeName, new HttpRouteValueDictionary(routeValues)
                {
                      {"pageNo", pageNo - 1},
                      {"pageSize", pageSize}
                }));
            }

            if (pageSize > pageCount)
            {
                NextPage = new Uri(urlHelper.Link(routeName, new HttpRouteValueDictionary(routeValues)
                {
                    {"pageNo", pageNo + 1},
                    {"pageSize", pageSize}
                }));
            }
        } 
        #endregion
    }
}
