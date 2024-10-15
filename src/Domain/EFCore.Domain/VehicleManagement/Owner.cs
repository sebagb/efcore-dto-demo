
namespace EFCore.Domain.VehicleManagement;
public class Owner
{
    private Person person;

    private Owner(Person person)
    {
        this.person = person;
    }

    public static Owner Create(Person owner) => new Owner(owner);

    public int Id => person.Id;
    public Name Name => person.Name;
    public DateTime From { get; init; } = DateTime.Today;
    public DateTime? To { get; private set; }
}
