using OncoFitness.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace OncoFitness.ViewModels
{
	[QueryProperty(nameof(ItemId), nameof(ItemId))]
	public class TrainingDetailViewModel : BaseViewModel
	{
		private string itemId;
		private string trainingType;
		private string trainingNotes; 
		private DateTime trainingDateTime;
		private TimeSpan trainingElapsedTime;
		private int patientAfterTraining;

		public string Id { get; set; }

		public string TrainingType
		{
			get => trainingType;
			set => SetProperty(ref trainingType, value);
		}

		public string TrainingNotes
		{
			get => trainingNotes;
			set => SetProperty(ref trainingNotes, value);
		}
		public DateTime TrainingDateTime
		{
			get => trainingDateTime;
			set => SetProperty(ref trainingDateTime, value);
		}

		public TimeSpan TrainingElapsedTime
		{
			get => trainingElapsedTime;
			set => SetProperty(ref trainingElapsedTime, value);
		}

		public int PatientAfterTraining
		{
			get => patientAfterTraining;
			set => SetProperty(ref patientAfterTraining, value);
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

		public ObservableCollection<object> Items { get; set; }

		public async void LoadItemId(string itemId)
		{
			try
			{
				var item = await TrainingDataStore.GetItemAsync(itemId);
				Id = item.TrainingId;
				TrainingType = item.TrainingType;
				TrainingNotes = item.TrainingNotes;
			}
			catch (Exception)
			{
				Debug.WriteLine("Failed to Load Training");
			}
		}

		public TrainingDetailViewModel()
		{
			Items = new ObservableCollection<object>();
			Items.Add(new object());
			Items.Add(new object());
			Items.Add(new object());
			Items.Add(new object());
			Items.Add(new object());
			Items.Add(new object());
			Items.Add(new object());
			Items.Add(new object());
			Items.Add(new object());
			Items.Add(new object());
			Items.Add(new object());
			Items.Add(new object());
			Items.Add(new object());
			Items.Add(new object());
			Items.Add(new object());
			Items.Add(new object());
			Items.Add(new object());
			Items.Add(new object());
		}
	}
}
