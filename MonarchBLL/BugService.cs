using System;
using MonarchDAL;
using System.Data;
using System.Collections.Generic;
using MonarchDOL.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MonarchBLL
{
    public class BugService : IBugService
    {
        private DataAccess dataAccess;
        private readonly ILogger<BugService> _logger;
        public BugService(IConfiguration configuration, ILogger<BugService> logger)
        {
            string cs = configuration.GetConnectionString("DefaultConnection");
            dataAccess = new DataAccess(cs);
            _logger = logger;
        }

        public List<BugModel> GetBugs()
        {
            try
            {
                return dataAccess.GetBugs();
            }
            catch (SqlException e)
            {
                _logger.LogError("Error in getting bug list", e);
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
                _logger.LogError("Error in getting bug", e);
                return null;
            }
        }
        public int? DeleteBug(int Id)
        {
            try
            {
               return dataAccess.DeleteBug(Id);
            }
            catch (SqlException e)
            {
                _logger.LogError("Error in deleting bug", e);
                return null;
            }
        }

        public int? AddBug(BugModel bug)
        {
            try
            {
                return dataAccess.AddBug(bug);
            }
            catch (SqlException e)
            {
                _logger.LogError("Error in adding bug", e);
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
                _logger.LogError("Error in updtaing bug", e);
            }
        }
    }
}
