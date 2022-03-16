using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutoShop.Models
{
    public class Car : BaseModel
    {
        public int  ModelID { get; set; }
        public bool ABS { get; set; }
        public bool PowerWindows { get; set; }
        public bool Bluetooth { get; set; }
        public bool Signalling { get; set; }
        public bool NavigationSystem { get; set; }
        public double Price { get; set; }
    }
}
