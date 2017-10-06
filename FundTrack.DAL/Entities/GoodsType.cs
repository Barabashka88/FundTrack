﻿using FundTrack.Infrastructure.ViewModel;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FundTrack.DAL.Entities
{
    public class GoodsType
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the goods categories.
        /// </summary>
        /// <value>
        /// The goods categories.
        /// </value>
        public virtual ICollection<GoodsCategory> GoodsCategories { get; set; }

        public static implicit operator GoodsTypeViewModel(GoodsType type)
        {
            return new GoodsTypeViewModel
            {
                Id = type.Id,
                Name=type.Name
            
            };
        }

        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GoodsType>(entity =>
            {
                entity.HasKey(gt => gt.Id).HasName("PK_GoodsType");

                entity.Property(gt => gt.Name).IsRequired().HasMaxLength(50);
            });
        }
    }
}
