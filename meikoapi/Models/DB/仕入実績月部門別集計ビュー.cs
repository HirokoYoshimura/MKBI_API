using System;
using System.ComponentModel.DataAnnotations;

namespace MeikoAPI.Models.DB
{
    public class 仕入実績月部門別集計ビュー
    {
        [Key]
        public string 部門 { get; set; }

        public long 数量 { get; set; }

        public long 金額 { get; set; }

        public long 粗利 { get; set; }
    }
}
