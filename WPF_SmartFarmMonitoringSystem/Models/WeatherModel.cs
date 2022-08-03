using System;

namespace WPF_SmartFarmMonitoringSystem.Models
{
	public class WeatherModel
	{
		public string resultCode { get; set; }
		public string resultMsg { get; set; }
		public string numOfRows { get; set; }
		public string pageNo { get; set; }
		public string totalCount { get; set; }
		public string dataType { get; set; }
		public string baseDate { get; set; }
		public string baseTime { get; set; }
		public string nx { get; set; }
		public string ny { get; set; }
		public string category { get; set; }
		public string fcstDate { get; set; }
		public string fcstTime { get; set; }
		public string fcstValue { get; set; }
	}
}
