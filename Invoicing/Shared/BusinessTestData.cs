using System;
using System.Collections.Generic;
using System.Linq;

namespace Invoicing.Shared
{
    public class BusinessTestData : IBusinessData
    {
        /*private Invoice[] testInvoices =
        {
            new Invoice("B2345", "FOO", 2154.6m     , DateTime.Now),
            new Invoice("B1345", "BAR", 12154.6m    , DateTime.Now),
            new Invoice("R2145", "BAR", 254.6m      , DateTime.Now),
            new Invoice("T2145", "BOO", 32154.52m   , DateTime.Now)
        };*/

        public BusinessTestData()
        {
            Invoices = new List<Invoice>()
            {
                new Invoice { Reference="B2345", Customer="FOO", Amount = 2154.6m, DateReglement = new DateTime(year: 2021, month: 2, day: 19)},
                new Invoice { Reference="B1345", Customer="BAR", Amount = 2154.6m, DateReglement = new DateTime(year: 2021, month: 3, day: 15)},
                new Invoice { Reference="R2145", Customer="BAR", Amount = 254.6m, DateReglement = new DateTime(year: 2021, month: 2, day: 15)},
                new Invoice { Reference="T2145", Customer="BOO", Amount = 32154.52m, DateReglement = new DateTime(year: 2021, month: 5, day: 17)}
            };
        }

        public IEnumerable<Invoice> Invoices { get; }

        public decimal CA => Invoices.Sum(I => I.Amount);

        public void Add(Invoice invoice)
        {
            (Invoices as List<Invoice>).Add(invoice);
        }

        public IEnumerable<Invoice> GetInvoices(DateTime? debut, DateTime? fin) =>
            Invoices.Where(I =>
                (!debut.HasValue || I.DateReglement >= debut) &&
                (!fin.HasValue || I.DateReglement <= fin)
            );
    }
}
