using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantDb.Tenant.Data.Entity
{
    [Comment("日報表")]
    public class DailyReport
    {
        public int Id { get; set; }
        [MaxLength(60)]
        public string ContainerNumber { get; set; }
        public int Size { get; set; }
        public int Chassis { get; set; }
        [Comment("是否領取")]
        public bool IsCollect { get; set; }
        [Comment("是否送達")]
        public bool IsSend { get; set; }
        [Comment("是否收穫")]
        public bool IsReceived { get; set; }
        [Comment("是否交櫃")]
        public bool IsHandOver { get; set; }
        [Comment("運費")]
        public decimal ShippingPrice { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
