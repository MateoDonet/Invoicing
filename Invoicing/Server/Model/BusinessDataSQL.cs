using Invoicing.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Invoicing.Server.Model
{
    public class BusinessDataSQL : IBusinessData, IDisposable
    {
        private SqlConnection cnct;
        public BusinessDataSQL(string connectionString)
        {
            cnct = new SqlConnection(connectionString);
        }
        public void Dispose()
        {
            cnct.Dispose();
        }


        public IEnumerable<Invoice> Invoices
            => cnct.Query<Invoice>("SELECT * FROM Invoices");

        public decimal CA
            => Invoices.Sum(I => I.Amount);

        public void Add(Invoice invoice)
        {
            String query = "INSERT INTO dbo.invoices (references, customer, datereglement, amount) VALUES (@ref, @ctmr, @drglmt, @amt)";

            SqlCommand command = new SqlCommand(query, cnct);
            command.Parameters.AddWithValue("@ref", invoice.Reference);
            command.Parameters.AddWithValue("@ctmr", invoice.Customer);
            command.Parameters.AddWithValue("@drglmt", invoice.DateReglement);
            command.Parameters.AddWithValue("@amt", invoice.Amount);
        }

        public IEnumerable<Invoice> GetInvoices(DateTime? debut, DateTime? fin)
            => /*cnct.Query<Invoice>("SELECT * FROM Invoices WHERE datereglement >= \"" + debut + "\" AND datereglement <= \"" + fin + "\"");*/
        Invoices.Where(I =>
            (!debut.HasValue || I.DateReglement >= debut) &&
            (!fin.HasValue || I.DateReglement <= fin)
        );

    }
}
