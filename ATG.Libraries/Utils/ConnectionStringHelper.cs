using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATG.Libraries.Utils
{
    public static class ConnectionStringHelper
    {
        public static DbContextOptions GetOptions(string con)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), con).Options;
        }
    }
}
