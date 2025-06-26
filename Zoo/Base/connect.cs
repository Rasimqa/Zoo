using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo;
using Zoo.Pages;

namespace Zoo.Base
{
    public static class connect
    {
        public static ZooEntities db = new ZooEntities();
        public static User user;
    }
}
