﻿import { Injectable, Inject, NgZone } from '@angular/core';

@Injectable()
export class GlobalUrlService {
    // urls to server for all components
    public static getAllOrganizationsUrl: string = "api/OrganizationDetail/";
    public static getOrganizationDetailUrl: string = "api/OrganizationDetail/";
    public static getFixingBalanceUrl: string = "api/FixingBalance/";

    //organization account
    public static getExtractStatus: string = "api/OrgAccount/ExtractStatus/";
    public static getExtractCredentials: string = "api/OrgAccount/ExtractCredentials/";
    public static connectExtracts: string = "api/OrgAccount/ConnectExtracts";

    //organization profile
    public static editLogo: string = "api/organizationProfile/EditLogo";

    //register organization
    public static registerOrganization = "api/OrganizationRegistration/RegisterNewOrganization/";
    public static readonly banksUrl: string = "api/Bank";

    //donation URLs
    public static userDonations: string = "api/Donate/User/";
    public static userDonationsByDate: string = "api/Donate/UserByDate/";
}