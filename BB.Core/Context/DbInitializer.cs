using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.Core
{
    public class DbInitializer
    {
        public static void Initialize(BBEntities context)
        {
            context.Database.CreateIfNotExists();
        }
    }
}
