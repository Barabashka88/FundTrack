﻿using FundTrack.DAL.Entities;
using FundTrack.Infrastructure.ViewModel;
using System.Collections.Generic;

namespace FundTrack.BLL.Abstract
{
    public interface IOfferedItemService
    {
        /// <summary>
        /// Gets offereditem viewModel by offeritem id
        /// </summary>
        /// <param name="id">offeritem id</param>
        /// <returns>OfferedItemViewModel</returns>
        OfferedItemViewModel GetOfferedItemViewModel(int id);
        /// <summary>
        /// Gets offered items of user by his id
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>collection of OfferedItemViewModels</returns>
        IEnumerable<OfferedItemViewModel> GetUserOfferedItems(int userId);
        /// <summary>
        /// Gets all offered item view models
        /// </summary>
        /// <returns>Collection of all offered item view models</returns>
        IEnumerable<OfferedItemViewModel> GetAllOfferedItemViewModels();
        /// <summary>
        /// Deletes offered item by its id
        /// </summary>
        /// <param name="id"></param>
        void DeleteOfferedItem(int id);
        /// <summary>
        /// Creates new Offer Item
        /// </summary>
        /// <param name="model">base model for new offer item</param>
        /// <returns>OfferedItemViewModel</returns>
        OfferedItemViewModel CreateOfferedItem(OfferedItemViewModel model);
        /// <summary>
        /// Initializes offered item view model based on offer item entity
        /// </summary>
        /// <param name="item">offer item</param>
        /// <returns>OfferedItemViewModel</returns>
        OfferedItemViewModel InitializeOfferedItemViewModel(OfferedItem item);
        /// <summary>
        /// Edits offered item, accordingly to received view model
        /// </summary>
        /// <param name="model">view model of the offer item</param>
        /// <returns>updated item</returns>
        OfferedItemViewModel EditOfferedItem(OfferedItemViewModel model);
        /// <summary>
        /// Gets paged offer item view models
        /// </summary>
        /// <param name="userId">id of the user</param>
        /// <param name="itemsToLoad"></param>
        /// <param name="itemsToSkip"></param>
        /// <returns>filtered offer item view models</returns>
        IEnumerable<OfferedItemViewModel> GetPagedUserOfferedItems(int userId, int itemsToLoad, int itemsToSkip);
        /// <summary>
        /// Changes status of offer item
        /// </summary>
        /// <param name="model">model, containing data about offer item status, id</param>
        /// <returns>offer item view model</returns>
        OfferItemChangeStatusViewModel ChangeOfferItemStatus(OfferItemChangeStatusViewModel model);
    }
}
