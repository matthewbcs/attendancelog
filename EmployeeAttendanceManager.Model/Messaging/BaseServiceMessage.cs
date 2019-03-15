using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendanceManager.Model.Messaging
{
   public class BaseServiceMessage
    {
        public bool WasSuccess { get; set; }
        public string Message { get; set; }
    }
}
