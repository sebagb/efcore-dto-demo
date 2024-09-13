using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.VehicleManagement
{
    public class Owner
    {
        public int Id { get; init; }
        public Name Name { get; init; }
        public DateTime From { get; init; } = DateTime.Today;
        public DateTime? To { get; private set; }
    }
}
