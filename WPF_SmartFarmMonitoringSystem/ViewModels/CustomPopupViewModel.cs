using Caliburn.Micro;
using WPF_SmartFarmMonitoringSystem.Helpers;

namespace WPF_SmartFarmMonitoringSystem.ViewModels
{
	public class CustomPopupViewModel : Conductor<object>
	{
		private string brokerIp;
		private string topic;

		public CustomPopupViewModel(string title)
		{
			this.DisplayName = title;

			BrokerIp = "127.0.0.1";
			Topic = "home/device/#";
		}

		public string BrokerIp
		{
			get => brokerIp; 
			set
			{
				brokerIp = value;
				NotifyOfPropertyChange(() => BrokerIp);
			}
		}
		public string Topic
		{
			get => topic; 
			set
			{
				topic = value;
				NotifyOfPropertyChange(() => Topic);

			}
		}

		public void AcceptClose()
		{
			Commons.BROKERHOST = BrokerIp;
			Commons.PUB_TOPIC = Topic;

			// 창닫기
			TryCloseAsync(true);
		}

	}
}
