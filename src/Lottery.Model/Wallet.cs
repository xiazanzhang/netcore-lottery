using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lottery.Model
{
    /// <summary>
    /// 钱包
    /// </summary>
    public class Wallet
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [Required]
        [DefaultValue(0)]
        public decimal Money { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [Required]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        [Required]
        public DateTime UpdateTime { get; set; }


        public Wallet()
        {
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }
    }
}
