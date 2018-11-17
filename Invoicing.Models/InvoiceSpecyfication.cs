using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Models
{
    public class InvoiceSpecyfication : BaseModel
    {


        public int InvoiceHeaderId { get; set; }

        public virtual InvoiceHeader InvoiceHeader { get; set; }
    }
}
