using MonarchDAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MonarchDAL
{
    public class DataAccess
    {
        private string ConnectionString { get; set; }
        public DataAccess(string connection)
        { 
            ConnectionString = connection;
        }

        public List<BugModel> GetBugs()
        {
            List<BugModel> bugs = new List<BugModel>();
            using (SqlConnection con = new(ConnectionString))
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
                        bugs.Add(Populate(reader));
                    }
                }
            }
            return bugs;
        }

        public BugModel GetBug(int Id)
        {
            using (SqlConnection con = new(ConnectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT i.Id, LineNumber, Title, Severity, CategoryId, Description," +
                    " Status, ResolutionId, CreatedDate, ModifiedDate,r.Name as 'ResolutionName', c.Name as CategoryName " +
                    " FROM Item i " +
                    " inner join Category c on c.Id = CategoryId" +
                    " inner join Resolution r on r.Id = ResolutionId" +
                    $" where i.Id = {Id}"

                    , con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            return Populate(reader);
                        }
                    }
                }
            }

            return null;
        }

        public int DeleteBug(int Id)
        {

            int rc = 0;
            using (SqlConnection con = new(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand($"DELETE FROM Item WHERE Id = {Id}", con))
                {
                    rc = cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            return rc;
        }

        private BugModel Populate(SqlDataReader reader)
        {
            var model = new BugModel();

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
            return model;
        }

        public int AddBug(BugModel bug)
        {
            using (SqlConnection con = new(ConnectionString))
            {
                con.Open();

                string sql = "INSERT INTO Item(LineNumber, Title, Severity, CategoryId, Description, Status, ResolutionId)" +
                       " VALUES(@LineNumber, @Title, @Severity, @CategoryId, @Description, @Status, @ResolutionId);" +
                       "SELECT CAST(SCOPE_IDENTITY() as int);";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@LineNumber", SqlDbType.Int).Value = bug.LineNumber;
                    cmd.Parameters.Add("@Title", SqlDbType.NVarChar, -1).Value = bug.Title;
                    cmd.Parameters.Add("@Severity", SqlDbType.TinyInt).Value = bug.Severity;
                    cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = bug.CategoryId;
                    cmd.Parameters.Add("@Description", SqlDbType.Text).Value = bug.Description;
                    cmd.Parameters.Add("@Status", SqlDbType.TinyInt).Value = bug.Status;
                    cmd.Parameters.Add("@ResolutionId", SqlDbType.Int).Value = bug.ResolutionId;
                    int id = (int)cmd.ExecuteScalar();
                    con.Close();
                    return id;
                }
            }
        }

        public void UpdateBug(BugModel bug)
        {
            using (SqlConnection con = new(ConnectionString))
            {
                con.Open();

                string sql = "Update Item set LineNumber=@LineNumber, Title=@Title, Severity=@Severity, CategoryId=@CategoryId, Description=@Description, Status=@Status," +
                    " ResolutionId=@ResolutionId, ModifiedDate=@ModifiedDate WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@LineNumber", SqlDbType.Int).Value = bug.LineNumber;
                    cmd.Parameters.Add("@Title", SqlDbType.NVarChar, -1).Value = bug.Title;
                    cmd.Parameters.Add("@Severity", SqlDbType.TinyInt).Value = bug.Severity;
                    cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = bug.CategoryId;
                    cmd.Parameters.Add("@Description", SqlDbType.Text).Value = bug.Description;
                    cmd.Parameters.Add("@Status", SqlDbType.TinyInt).Value = bug.Status;
                    cmd.Parameters.Add("@ResolutionId", SqlDbType.Int).Value = bug.ResolutionId;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = bug.Id;
                    cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
