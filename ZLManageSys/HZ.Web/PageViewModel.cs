using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZ.Web
{
    public class PageViewModel
    {
        public IEnumerable rows
        {
            get;
            set;
        }
        public int total
        {
            get;
            set;
        }
    }
}
