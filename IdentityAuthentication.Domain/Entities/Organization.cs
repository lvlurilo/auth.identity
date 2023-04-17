namespace IdentityAuthentication.Domain.Entities
{
    public class Organization : EntityBase
    {
        public Guid Code { get; set; }
        public string? Name { get; set; }
    }
}
