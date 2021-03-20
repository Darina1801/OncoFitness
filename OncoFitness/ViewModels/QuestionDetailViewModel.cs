using OncoFitness.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OncoFitness.ViewModels
{
	[QueryProperty(nameof(ItemId), nameof(ItemId))]
	public class QuestionDetailViewModel : BaseViewModel
	{
		private string itemId;
		private string question;
		private string answer;
		public string Id { get; set; }

		public string Question
		{
			get => question;
			set => SetProperty(ref question, value);
		}

		public string Answer
		{
			get => answer;
			set => SetProperty(ref answer, value);
		}

		public string ItemId
		{
			get
			{
				return itemId;
			}
			set
			{
				itemId = value;
				LoadItemId(value);
			}
		}

		public async void LoadItemId(string itemId)
		{
			try
			{
				var item = await QAndADataStore.GetItemAsync(itemId);
				Id = item.QAId;
				Question = item.QAQuestion;
				Answer = item.QAAnswer;
			}
			catch (Exception)
			{
				Debug.WriteLine("Failed to Load Question");
			}
		}
	}
}
