using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTime.Booking.Infrastructure.Refit.RefitModels
{
    public class InTimeGroup
    {
        public Guid id {  get; set; }
        public string name { get; set; }
        public bool isSubgroup { get; set; }
    }
}
