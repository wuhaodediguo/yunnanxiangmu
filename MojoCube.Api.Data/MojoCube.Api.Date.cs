using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MojoCube.Api.Date
{
	public class Get
	{
		public static string ChineseWeek()
		{
			string text = DateTime.Now.DayOfWeek.ToString();
			string result = "";
			string text2 = text;
			switch (text2)
			{
			case "Monday":
				result = "星期一";
				break;
			case "Tuesday":
				result = "星期二";
				break;
			case "Wednesday":
				result = "星期三";
				break;
			case "Thursday":
				result = "星期四";
				break;
			case "Friday":
				result = "星期五";
				break;
			case "Saturday":
				result = "星期六";
				break;
			case "Sunday":
				result = "星期日";
				break;
			}
			return result;
		}

		private DateTime WeekDate(string strTime)
		{
			DateTime result = DateTime.Now;
			if (strTime.Length > 1)
			{
				int num = int.Parse(strTime.Split(new char[]
				{
					'|'
				})[0]);
				int num2 = int.Parse(strTime.Split(new char[]
				{
					'|'
				})[1]);
				int num3 = int.Parse(strTime.Split(new char[]
				{
					'|'
				})[2]);
				string b = strTime.Split(new char[]
				{
					'|'
				})[3];
				string text = strTime.Split(new char[]
				{
					'|'
				})[4];
				int num4 = 0;
				int num5 = DateTime.DaysInMonth(num, num2);
				if (num3 == 0)
				{
					for (int i = 0; i < num5; i++)
					{
						if (Convert.ToDateTime(string.Concat(new object[]
						{
							num,
							"-",
							num2,
							"-",
							(i + 1).ToString(),
							" ",
							text
						})).DayOfWeek.ToString() == b)
						{
							num3++;
						}
					}
				}
				for (int i = 0; i < num5; i++)
				{
					DateTime dateTime = Convert.ToDateTime(string.Concat(new object[]
					{
						num,
						"-",
						num2,
						"-",
						(i + 1).ToString(),
						" ",
						text
					}));
					if (dateTime.DayOfWeek.ToString() == b)
					{
						num4++;
						if (num4 == num3)
						{
							result = dateTime;
						}
					}
				}
			}
			return result;
		}
	}
}
