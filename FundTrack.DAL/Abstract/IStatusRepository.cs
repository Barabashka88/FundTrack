﻿using FundTrack.DAL.Entities;

namespace FundTrack.DAL.Abstract
{
    /// <summary>
    /// Interface for work with status repository
    /// </summary>
    public interface IStatusRepository : IRepository<Status>
    {
        /// <summary>
        /// Gets status by its id
        /// </summary>
        /// <param name="id">Id of the status</param>
        /// <returns>Status entity</returns>
        Status GetStatusById(int id);
        
        /// <summary>
        /// Gets status by its name
        /// </summary>
        /// <param name="name">Name of the status</param>
        /// <returns>Status entity</returns>
        Status GetStatusByName(string name);
    }
}
