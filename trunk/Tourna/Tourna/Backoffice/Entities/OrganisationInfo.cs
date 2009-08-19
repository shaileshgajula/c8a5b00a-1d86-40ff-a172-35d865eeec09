﻿using Tourna.Backoffice.Entities;
using System;
using Tourna.Backoffice.Entities.OrganisationInfoTableAdapters;
using System.Data.SqlClient;
using System.Configuration;
public class OrganisationManager
{
    public static OrganisationInfo.OrganisationEntityRow GetOrganisationInfo(Guid organisationId)
    {
        OrganisationEntityTableAdapter adapter = new OrganisationEntityTableAdapter();
        adapter.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString);
        OrganisationInfo.OrganisationEntityDataTable dt= adapter.GetData(organisationId);
        if (dt.Rows.Count > 0)
        {
            return dt[0];
        }
        else
        {
            //log that compnay not found 
            throw new ArgumentException(string.Format("Organisation Id: {0} can't be found", organisationId.ToString())); 
        }
        
    }
}