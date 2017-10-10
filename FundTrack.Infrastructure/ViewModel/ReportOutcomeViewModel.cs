﻿using System;

namespace FundTrack.Infrastructure.ViewModel
{
    public class ReportOutcomeViewModel
    {
        public int Id { get; set; }
        public string Target { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal MoneyAmount { get; set; }

    }
}
