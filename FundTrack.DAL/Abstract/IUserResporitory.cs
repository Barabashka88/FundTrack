﻿using FundTrack.DAL.Entities;
using System.Collections.Generic;

namespace FundTrack.DAL.Abstract
{
    public interface IUserResporitory : IRepository<User>
    {
        bool isUserExisted(string email, string login);

        /// <summary>
        /// Gets Users with their ban status
        /// </summary>
        /// <returns>Users with ban status</returns>
        IEnumerable<User> GetUsersWithBanStatus();

        /// <summary>
        /// Checks if user has reset password link
        /// </summary>
        /// <param name="user">user to check</param>
        /// <returns>User reset link status</returns>
        bool HasUserResetLink(User user);

        /// <summary>
        ///  Unbans user with concrete id
        /// </summary>
        /// <param name="id">Id of User</param>
        void UnbanUser(int id);

        /// <summary>
        /// Bans user
        /// </summary>
        /// <param name="user">User to ban</param>
        /// <returns>Banned User</returns>
        void BanUser(BannedUser user);

        /// <summary>
        /// Addes new Password reset request
        /// </summary>
        /// <param name="passwordReset">Password reset request</param>
        void AddUserRecoveryLink(PasswordReset passwordReset);

        /// <summary>
        /// Removes Recovery link
        /// </summary>
        /// <param name="id">Id of user</param>
        void RemoveUserRecoveryLink(int id);

        /// <summary>
        /// Gets user by guid
        /// </summary>
        /// <param name="guid">guid to get user</param>
        /// <returns>User with specifice guid</returns>
        User GetUserByGuid(string guid);
    }
}
