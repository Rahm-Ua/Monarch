using MonarchDAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MonarchDAL
{
    public class DataAccess
    {
        private string ConnectionString { get; set; }
        public DataAccess(string connection)
        { ConnectionString = connection; }

        public List<BugModel> GetBugs()
        {
            List<BugModel> bugs = new List<BugModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT i.Id, LineNumber, Title, Severity, CategoryId, Description," +
                    " Status, ResolutionId, CreatedDate, ModifiedDate,r.Name as 'ResolutionName', c.Name as CategoryName " +
                    " FROM Item i " +
                    " inner join Category c on c.Id = CategoryId" +
                    " inner join Resolution r on r.Id = ResolutionId"
                    
                    , con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        BugModel model = new BugModel();
                        model.Id = reader.GetInt32(0);
                        model.LineNumber = reader.IsDBNull(1) ? null : reader.GetInt32(1);
                        model.Title = reader.GetString(2);
                        model.Severity = (Severity)reader.GetByte(3);
                        model.CategoryId = reader.GetInt32(4);
                        model.Description = reader.GetString(5);
                        model.Status = (Status)reader.GetByte(6);
                        model.ResolutionId = reader.GetInt32(7);
                        model.CreatedDate = reader.GetDateTime(8);
                        model.ModifiedDate = reader.IsDBNull(9) ? null : reader.GetDateTime(9);
                        model.CategoryName = reader.GetString(10);
                        model.ResolutionName = reader.GetString(11);
                        bugs.Add(model);
                    }
                }
            }

            return bugs;
        }

    }

}
