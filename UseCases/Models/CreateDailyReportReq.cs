using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Models
{
    public class CreateDailyReportReq
    {
        public string ContainerNumber { get; set; }
        public int Size { get; set; }
        public int Chassis { get; set; }
        public bool IsCollect { get; set; }
        public bool IsSend { get; set; }
        public bool IsReceived { get; set; }
        public bool IsHandOver { get; set; }
        public decimal ShippingPrice { get; set; }
    }
}
