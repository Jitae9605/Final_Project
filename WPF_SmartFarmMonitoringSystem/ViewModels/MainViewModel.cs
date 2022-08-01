using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_SmartFarmMonitoringSystem.Bases;
using WPF_SmartFarmMonitoringSystem.Models;

namespace WPF_SmartFarmMonitoringSystem.ViewModels
{
	/// <summary>
	/// 메인 뷰모델 클래스
	/// </summary>
	public class MainViewModel : ViewModelBase
	{

		private string inName;
		public string InName
		{
			get => inName;
			set
			{
				inName = value;
				RaisePropertyChanged("InName"); // 값이 바뀌었음을 공지
			}
		}

		private string inTel;
		public string InTel
		{
			get => inTel;
			set
			{
				inTel = value;
				RaisePropertyChanged("InTel"); // 값이 바뀌었음을 공지
			}
		}

		private string inMessage;
		public string InMessage
		{
			get => inMessage;
			set
			{
				inMessage = value;
				RaisePropertyChanged("InMessage"); // 값이 바뀌었음을 공지
			}
		}

		private string outName;
		public string OutName
		{
			get => outName;
			set
			{
				outName = value;
				RaisePropertyChanged("OutName"); // 값이 바뀌었음을 공지
			}
		}

		private string outTel;
		public string OutTel
		{
			get => outTel;
			set
			{
				outTel = value;
				RaisePropertyChanged("OutTel"); // 값이 바뀌었음을 공지
			}
		}

		private string outMessage;
		public string OutMessage
		{
			get => outMessage;
			set
			{
				outMessage = value;
				RaisePropertyChanged("OutMessage"); // 값이 바뀌었음을 공지
			}
		}

		// 값이 전부 적용되서 버튼을 활성화 하기위한 명령
		private ICommand proceedCommand;
		public ICommand ProceedCommand
		{
			get
			{
				return proceedCommand ?? (
				  proceedCommand = new RelayCommand<object>(
					  o => Proceed(), o => !string.IsNullOrEmpty(InName) &&
										  !string.IsNullOrEmpty(InTel) &&
										  !string.IsNullOrEmpty(InMessage)
				  ));
			}
		}

		// 버튼클릭시 일어나는 실제 명령의 실체S
		private async void Proceed()
		{
			try
			{
				//DateTime date = inDate ?? DateTime.Now;
				Member person = new Member(InName, InTel, InMessage);

				await Task.Run(() => OutName = person.Name);
				await Task.Run(() => OutTel = person.Tel);
				await Task.Run(() => OutMessage = person.Message);
				Program();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"예외발생 : {ex.Message}");
			}
		}


		// 공공데이터포탈 초단기예보
		public void Program()
		{
			HttpClient client = new HttpClient();

			string url = "http://apis.data.go.kr/1360000/VilageFcstInfoService_2.0/getUltraSrtFcst"; // URL
			url += "?ServiceKey=" + "4YCQTPPRPGl%2BKP4xb5gVtRyCx%2BjzC7gpfKXt1k%2FHbp3sRxvB9K3P14K52GvE5XuouMRmGCgfZnRaVhQNR%2Bz9kg%3D%3D"; // Service Key
			url += "&pageNo=1";
			url += "&numOfRows=1000";
			url += "&dataType=JSON";
			url += "&base_date=20220801";
			url += "&base_time=0000";
			url += "&nx=55";
			url += "&ny=127";

			var request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "GET";

			string results = string.Empty;
			HttpWebResponse response;
			using (response = request.GetResponse() as HttpWebResponse)
			{
				StreamReader reader = new StreamReader(response.GetResponseStream());
				results = reader.ReadToEnd();
			}

			


			MessageBox.Show(results);
		}
	}
}
