using System;
using System.ComponentModel.DataAnnotations;

namespace Lottery.Model
{
    /// <summary>
    /// 彩票种类
    /// </summary>
    public class LotteryType
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [Required]
        public string Icon { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
