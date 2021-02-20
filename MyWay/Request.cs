using System;
using System.Collections.Generic;
using System.Text;

namespace MyWay
{
    public class Request
    {
        public int id { get; set; }
        public int me { get; set; }
        public int other { get; set; }
        public int status_id { get; set; }

        public Request()
        {
        }
        public Request(int me, int other, int status_id)
        {
            this.me = me;
            this.other = other;
            this.status_id = status_id;
        }
    }
}
