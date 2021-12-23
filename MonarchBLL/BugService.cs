﻿using System;
using MonarchDAL;
using System.Data;
using System.Collections.Generic;
using MonarchDAL.Models;
using System.Data.SqlClient;
using log4net;

namespace MonarchBLL
{
    public class BugService
    {
        private DataAccess dataAccess;
        private static readonly ILog log = LogManager.GetLogger(typeof(BugService));
        public BugService()
        {
            dataAccess = new DataAccess("Data Source = (localdb)\\ProjectsV13; Initial Catalog = MonarchDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False;");
        }

        public List<BugModel> GetBugs()
        {
            try
            {
                return dataAccess.GetBugs();
            }
            catch (SqlException e)
            {
                log.Error("Error in getting bug list", e);
                return null;
            }
        }

        public BugModel GetBug(int Id)
        {
            try
            {
                return dataAccess.GetBug(Id);
            }
            catch (SqlException e)
            {
                log.Error("Error in getting bug", e);
                return null;
            }
        }
        public void DeleteBug(int Id)
        {
            try
            {
                dataAccess.DeleteBug(Id);
            }
            catch (SqlException e)
            {
                log.Error("Error in deleting bug", e);
            }
        }

        public int AddBug(BugModel bug)
        {
            try
            {
                return dataAccess.AddBug(bug);
            }
            catch (SqlException e)
            {
                log.Error("Error in adding bug", e);
                //What is the right thing to do in this situation?//
                return null;
            }
        }

        public void UpdateBug(BugModel bug)
        {
            try
            {
                dataAccess.UpdateBug(bug);
            }
            catch (SqlException e)
            {
                log.Error("Error in updtaing bug", e);
            }
        }
    }
}
