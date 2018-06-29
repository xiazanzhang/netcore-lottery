using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lottery.Model
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class Administrators
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(11)]
        [MinLength(4)]
        [Required]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Salt
        /// </summary>
        [Required]
        public string Salt { get; set; }

        /// <summary>
        /// 账户状态 (1：正常 2：锁定)
        /// </summary>
        [DefaultValue(1)]
        public int Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public DateTime CreateTime { get; set; }

        public Administrators()
        {
            CreateTime = DateTime.Now;
            Status = 1;
        }
    }
}
