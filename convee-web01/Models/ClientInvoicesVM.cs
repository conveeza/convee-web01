using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace convee_web01.Models
{
    public class ClientInvoicesVM
    {
        public PagedList.IPagedList<INVOICE> Invoices { get; set; }
        public List<CLIENT> Client { get; set; }

    }
}