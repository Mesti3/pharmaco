using System;
using System.Collections.Generic;
using System.Text;

namespace pharmaco.model
{
    public enum orderstate
    {
        created = 1,
        seen = 2,
        processed = 3,
        sold = 4, 
        cancelled = 5
    }
}
