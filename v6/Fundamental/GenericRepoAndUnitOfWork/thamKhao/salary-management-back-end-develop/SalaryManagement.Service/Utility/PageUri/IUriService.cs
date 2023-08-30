using SalaryManagement.Requests.Paginations.PaginationParams;
using System;

namespace SalaryManagement.Utility.PageUri
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationParams filter, string route);
    }
}
