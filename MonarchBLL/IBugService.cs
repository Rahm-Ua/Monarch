using MonarchDAL.Models;
using System.Collections.Generic;

namespace MonarchBLL
{
    public interface IBugService
    {
        int? AddBug(BugModel bug);
        void DeleteBug(int Id);
        BugModel GetBug(int Id);
        List<BugModel> GetBugs();
        void UpdateBug(BugModel bug);
    }
}