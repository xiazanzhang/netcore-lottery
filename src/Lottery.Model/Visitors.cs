using System;
using System.ComponentModel.DataAnnotations;

namespace Lottery.Model
{
    /// <summary>
    /// 游客
    /// </summary>
    public class Visitors
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 游客ID
        /// </summary>
        [Required]
        public Guid Uid { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [Required]
        public DateTime LastUpdated { get; set; }

        public Visitors()
        {
            CreateTime = DateTime.Now;
            LastUpdated = DateTime.Now;
        }
    }
}
