using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exception = System.Exception;

namespace EmployeeAttendanceManager.Repository
{
    public class BaseContext: DbContextFiles.MyDbContext
    {
        public DbContextFiles.MyDbContext Context;
        public BaseContext()
        {
            Context = new DbContextFiles.MyDbContext();
        }


        public bool SaveDbChanges()
        {

            try
            {
                Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                // need to add log tables
            }
            
        }
    }
}
