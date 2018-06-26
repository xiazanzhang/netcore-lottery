using System;

public static class DateTimeHelper
{
    /// <summary>
    /// Unix时间起始时间
    /// </summary>
    public static readonly DateTime StarTime = new DateTime(1970, 1, 1);

    /// <summary>
    /// 常用日期格式
    /// </summary>
    public static readonly string CommonDateFormat = "yyyy-MM-dd HH:mm:ss.fff";

    /// <summary>
    /// 获取从Unix起始时间到给定时间的毫秒数
    /// </summary>
    /// <param name="datetime"></param>
    /// <returns></returns>
    public static long GetMillisecondsSince1970(this DateTime datetime)
    {
        var ts = datetime.Subtract(StarTime);
        return (long)ts.TotalMilliseconds;
    }

    /// <summary>
    /// 获取从Unix起始时间到给定时间的秒数
    /// </summary>
    /// <param name="datetime"></param>
    /// <returns></returns>
    public static long GetSecondsSince1970(this DateTime datetime)
    {
        var ts = datetime.Subtract(StarTime);
        return (long)ts.TotalSeconds;
    }

    /// <summary>
    /// 明天
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime Tomorrow(this DateTime date)
    {
        return date.AddDays(1);
    }

    /// <summary>
    /// 昨天
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime Yesterday(this DateTime date)
    {
        return date.AddDays(-1);
    }

    /// <summary>
    /// 常用日期格式化字符串
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static string ToCommonFormat(this DateTime date)
    {
        return date.ToString(CommonDateFormat);
    }

    /// <summary>
    /// 给定月份的第1天
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime GetFirstDayOfMonth(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, 1);
    }

    /// <summary>
    /// 给定月份的最后1天
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime GetLastDayOfMonth(this DateTime date)
    {
        return date.GetFirstDayOfMonth().AddMonths(1).AddDays(-1);
    }

    /// <summary>
    /// 给定日期所在月份第1个星期几所对应的日期
    /// </summary>
    /// <param name="date">给定日期</param>
    /// <param name="dayOfWeek">星期几</param>
    /// <returns>所对应的日期</returns>
    public static DateTime GetFirstWeekDayOfMonth(this DateTime date, DayOfWeek dayOfWeek)
    {
        var dt = date.GetFirstDayOfMonth();
        while (dt.DayOfWeek != dayOfWeek)
            dt = dt.AddDays(1);

        return dt;
    }

    /// <summary>
    /// 给定日期所在月份最后1个星期几所对应的日期
    /// </summary>
    /// <param name="date">给定日期</param>
    /// <param name="dayOfWeek">星期几</param>
    /// <returns>所对应的日期</returns>
    public static DateTime GetLastWeekDayOfMonth(this DateTime date, DayOfWeek dayOfWeek)
    {
        var dt = date.GetLastDayOfMonth();
        while (dt.DayOfWeek != dayOfWeek)
            dt = dt.AddDays(-1);

        return dt;
    }

    /// <summary>
    /// 早于给定日期
    /// </summary>
    /// <param name="date"></param>
    /// <param name="other"></param>
    /// <returns></returns>
    public static bool IsBefore(this DateTime date, DateTime other)
    {
        return date.CompareTo(other) < 0;
    }

    /// <summary>
    /// 晚于给定日期
    /// </summary>
    /// <param name="date"></param>
    /// <param name="other"></param>
    /// <returns></returns>
    public static bool IsAfter(this DateTime date, DateTime other)
    {
        return date.CompareTo(other) > 0;
    }

    /// <summary>
    /// 给定日期最后一刻,精确到23:59:59.999
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime EndTimeOfDay(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
    }

    /// <summary>
    ///  给定日期开始一刻,精确到0:0:0.0
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime StartTimeOfDay(this DateTime date)
    {
        return date.Date;
    }

    /// <summary>
    ///  给定日期的中午,精确到12:0:0.0
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime NoonOfDay(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, date.Day, 12, 0, 0);
    }

    /// <summary>
    /// 当前日期与给定日期是否是同一天
    /// </summary>
    /// <param name="date">当前日期</param>
    /// <param name="dateToCompare">给定日期</param>
    /// <returns></returns>
    public static bool IsDateEqual(this DateTime date, DateTime dateToCompare)
    {
        return (date.Date == dateToCompare.Date);
    }

    /// <summary>
    /// 判断是否为今天
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static bool IsToday(this DateTime date)
    {
        return (date.Date == DateTime.Now.Date);
    }

    /// <summary>
    /// 给定日期所在月份共有多少天
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static int GetCountDaysOfMonth(this DateTime date)
    {
        return date.GetLastDayOfMonth().Day;
    }
}