﻿using FundTrack.DAL.Abstract;
using FundTrack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundTrack.DAL.Concrete
{
    public class OfferImagesRepository : IRepository<OfferedItemImage>
    {
        private readonly FundTrackContext _context;
        public OfferImagesRepository(FundTrackContext context)
        {
            _context = context;
        }

        public OfferedItemImage Create(OfferedItemImage item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            OfferedItemImage offeredItemImage = _context.OfferedItemImages.FirstOrDefault(a => a.Id == id);
            if (offeredItemImage != null)
                _context.OfferedItemImages.Remove(offeredItemImage);
        }

        public OfferedItemImage Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OfferedItemImage> Read()
        {
            return _context.OfferedItemImages;
        }

        public OfferedItemImage Update(OfferedItemImage item)
        {
            throw new NotImplementedException();
        }
    }
}