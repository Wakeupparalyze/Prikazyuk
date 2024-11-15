using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prikazyuk
{
    public static class DB
    {
        private static PrikazyukContext instance;
        public static PrikazyukContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PrikazyukContext();
                }
                return instance;
            }
        }
    }
}
