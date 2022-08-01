using System;

namespace WPF_SmartFarmMonitoringSystem.Models
{
	public class Member
	{
		public string Name;
		public string Tel;
		public string Message;

		public Member(string InName, string InTel, string InMessage)
		{
			Name = InName;
			Tel = InTel;
			Message = InMessage;
		}
	}
}
