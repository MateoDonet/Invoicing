using System;
using System.Collections.Generic;

namespace Invoicing.Shared
{
    public interface IBusinessData
    {
        IEnumerable<Invoice> Invoices { get; }

        decimal CA { get; }
        
        void Add(Invoice invoice);

        IEnumerable<Invoice> GetInvoices(DateTime? debut, DateTime? fin);
    }
}
