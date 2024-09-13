namespace EFCore.Domain.VehicleManagement
{
    public class Vehicle
    {
        private List<Owner> owners = new List<Owner>();
        public Vin VIN { get; private set; }
        public Owner? CurrentOwner => owners.FirstOrDefault(x => x.To == null);
        public Owner? PreviousOwners => owners.Where(x => x.To != null).ToArray();

        private Vehicle(Vin vin)
        {
            VIN = vin;
        }
    }
}
