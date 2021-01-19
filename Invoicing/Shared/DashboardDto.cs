using System;
using System.Collections.Generic;
using System.Linq;

namespace Invoicing.Shared
{ 
	public class DashboardDto
	{
		public DashboardDto()
		{

		}
		public DashboardDto(IBusinessData from)
		{
			CA = from.CA;
			AmountOf = from
				.GetInvoices(DateTime.Now, null)
				.Select(I => new AmountOfDto(I));
        }

		public decimal CA { get; set; }

		public IEnumerable<AmountOfDto> AmountOf { get; set; }
	}

}
