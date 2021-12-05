using System;
using MonarchDAL;
using MonarchDAL.Models;

namespace DBTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess("Data Source = (localdb)\\ProjectsV13; Initial Catalog = MonarchDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False;");
            try
            {
                var bugs = dataAccess.GetBugs();
                foreach (var bug in bugs)
                {
                    Console.WriteLine($"Bug Id:{bug.Id}");
                    Console.WriteLine($"Bug LineNumber:{bug.LineNumber}");
                    Console.WriteLine($"Bug Title:{bug.Title}");
                    Console.WriteLine($"Bug Severity:{bug.Severity}");
                    Console.WriteLine($"Bug CategoryId:{bug.CategoryId}");
                    Console.WriteLine($"Bug Description:{bug.Description}");
                    Console.WriteLine($"Bug Status:{bug.Status}");
                    Console.WriteLine($"Bug ResolutionId:{bug.ResolutionId}");
                    Console.WriteLine($"Bug CreatedDate:{bug.CreatedDate}");
                    Console.WriteLine($"Bug ModifiedDate:{bug.ModifiedDate}");
                    Console.WriteLine($"Bug CategoryName:{bug.CategoryName}");
                    Console.WriteLine($"Bug ResolutionName:{bug.ResolutionName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
            }

        }

    }
}
