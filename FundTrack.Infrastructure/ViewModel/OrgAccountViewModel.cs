﻿using System.Collections.Generic;
using System;

namespace FundTrack.Infrastructure.ViewModel
{
    public class OrgAccountViewModel
    {
        public int Id { get; set; }
        public int OrgId { get; set; }
        public int? BankAccId { get; set; }
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
        public string CardNumber { get; set; }
        public string Currency { get; set; }
        public string CurrencyShortName { get; set; }
        public string OrgAccountName { get; set; }
        public string AccountType { get; set; }
        public string Description { get; set; }
        public decimal CurrentBalance { get; set; }
        public int OrganizationId { get; set; }
        public int CurrencyId { get; set; }
        public List<string> FinOpsFrom { get; set; }
        public List<string> FinOpsTo { get; set; }
        public string AccNumber { get; set; }
        public string MFO { get; set; }
        public string EDRPOU { get; set; }
        public string BankName { get; set; }
        public string Error { get; set; }
        public int? TargetId { get; set; }
    }
}
