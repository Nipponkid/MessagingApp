using System.Collections.Generic;

using MessagingApp.Domain;

namespace MessagingApp.Data
{
    /// <summary>
    /// A service for managing users.
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// All the known users currently being managed.
        /// </summary>
        public IEnumerable<User> Users { get; }

        /// <summary>
        /// Find a specific user being managed.
        /// </summary>
        /// <param name="id">The ID of the user to find.</param>
        /// <returns>The managed user with the given ID.</returns>
        public User FindUserWithId(long id);

        /// <summary>
        /// Start managing a new user.
        /// </summary>
        /// <returns>The new user being managed.</returns>
        /// <param name="user">The new user to manage.</param>
        public User AddUser(User user);

        /// <summary>
        /// Stop managing a user with a given ID.
        /// </summary>
        /// <param name="id">The ID a user to stop managing.</param>
        public void DeleteUserWithId(long id);
    }
}
