namespace CelilCavus.RepositoryDesiginPattern.Data.Entites
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
