using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Design
    {
        public string DesignName { get; set; }
        public int DesignId { get; set; }
    }
    public class Dress
    {
        public int drsId { get; set; }
        public string drsName { get; set; }
        public string drsDesign { get; set; }
        public int drsPrice { get; set; }
        public int DesignId { get; set; }
        public Design DesignInfo { get; set; }
    }
}