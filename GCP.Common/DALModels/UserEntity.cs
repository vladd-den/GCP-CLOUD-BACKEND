namespace GCP.Common.DALModels
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public string StripeCustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
