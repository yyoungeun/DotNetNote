using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace DotNetNote.Services
{
    public class CopyrightService : ICopyrightService
    {
        public string GetCopyrightString()
        {
            return $"Copyright {DateTime.Now.Year} all right reserved"
                + $"from CopyrightService.{GetHashCode()}";
        }
    }
}
