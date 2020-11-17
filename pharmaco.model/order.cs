using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace pharmaco.model
{
    public class order
    {
        public int id { get; set; }
        public DateTime created { get; set; }
        public orderstate state { get; set; }

        public string tag { get; set; }

        public List<orderItem> items {get; set;}
        
        public string receiptCardReference { get; set; }
        public order()
        {
            items = new List<orderItem>();
        }
    }
}
