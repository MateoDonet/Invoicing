using System;

namespace Invoicing.Shared
{

	public class AmountOfDto
	{
		public AmountOfDto()
		{
		}
		public AmountOfDto(Invoice from)
		{
			Date = from.DateReglement;
			Amount = from.Amount;
		}

		public DateTime Date { get; set; }
		public decimal Amount { get; set; }
	}

}
