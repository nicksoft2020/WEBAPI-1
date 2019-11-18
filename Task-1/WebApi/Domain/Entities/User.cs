namespace Domain.Entities
{
    /// <summary>
    /// There is a user model
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}
