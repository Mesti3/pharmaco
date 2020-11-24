using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmaco.objects
{
    public class worker_params
    {
       public int offset;
        public int count;
        public string name;
        public int marketing_id;
        public List<string> category_ids;
        public search_mode_enum mode;
        public readonly int worker_run;

        internal worker_params AddOffsetAndReturn()
        {
            offset += 1;
            return this;
        }
        public worker_params(int worker_run)
        {
            this.worker_run = worker_run;
        }
    }
}
