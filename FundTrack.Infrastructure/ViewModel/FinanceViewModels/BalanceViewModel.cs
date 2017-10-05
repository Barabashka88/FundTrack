﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FundTrack.Infrastructure.ViewModel.FinanceViewModels
{
    public class BalanceViewModel
    {
        public decimal Amount { get; set; }
        public DateTime BalanceDate { get; set; }
        public int OrgAccountId { get; set; }
    }
}