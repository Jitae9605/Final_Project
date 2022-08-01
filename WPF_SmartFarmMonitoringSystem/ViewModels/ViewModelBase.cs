
using System.ComponentModel;

namespace WPF_SmartFarmMonitoringSystem.Bases
{
	/// <summary>
	/// 뷰모델 베이스
	/// </summary>
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

			// 위의 if문 전체와 같다 == PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}