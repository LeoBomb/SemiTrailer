using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SemiTrailer.Data.Entity
{
    [Comment("使用者資料")]
    [Index(nameof(Name), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Comment("名稱(不可重複)")]
        public string Name { get; set; }
        [Comment("Email")]
        public string Email { get; set; }

        [Comment("加鹽後密碼")]
        [MaxLength(300)]
        public string Password { get; set; }

        [Comment("Description")]
        [MaxLength(300)]
        public string Description { get; set; }

        [Comment("是否啟用")]
        [DefaultValue(true)]
        public bool IsEnable { get; set; }
    }
}
