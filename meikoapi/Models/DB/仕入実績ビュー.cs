using System;
using System.ComponentModel.DataAnnotations;

namespace MeikoAPI.Models.DB
{
    public class 仕入実績ビュー
    {
        [Key]
        public string 部門 { get; set; }

        public long 数量 { get; set; }

        public long 金額 { get; set; }

        public long 粗利 { get; set; }

        public DateTime 売上日 { get; set; }
    }
}