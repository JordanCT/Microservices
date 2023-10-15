using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Muchik.Invoicement.Application.Dtos
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int State { get; set; }
    }
}
