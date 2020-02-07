namespace MessagingApp.Users
{
    /// <summary>
    /// A Data Transfer Object (DTO) for requests related to users.
    /// </summary>
    public struct UserQuery
    {
        public UserQuery(long id, string email)
        {
            Id = id;
            Email = email;
        }

        /// <summary>
        /// The ID number of a user.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The email address of a user.
        /// </summary>
        public string Email { get; set; }
    }
}
