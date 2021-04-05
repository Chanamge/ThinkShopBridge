using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.BL
{
    public class PagedResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public int PreviousPage { get; set; }
        public int NextPage { get; set; }
        public T Data { get; set; }
        public PagedResponse(T data, int pageNumber, int pageSize, int totalPages, int totalRecords, int previousPage, int nextPage)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalPages = totalPages;
            this.TotalRecords = totalRecords;
            this.PreviousPage = previousPage;
            this.NextPage = nextPage;
            this.Data = data;
        }
    }
}
