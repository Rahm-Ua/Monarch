using MonarchDOL.Models;
using System.Collections.Generic;

namespace MonarchBLL
{
    public interface IBugService
    {
        int? AddBug(BugModel bug);
        int? DeleteBug(int id);
        BugModel GetBug(int id);
        List<BugModel> GetBugs();
        void UpdateBug(BugModel bug);
    }
}