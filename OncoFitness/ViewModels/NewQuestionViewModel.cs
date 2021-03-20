using OncoFitness.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OncoFitness.ViewModels
{
	public class NewQuestionViewModel : BaseViewModel
	{
		private string question;
		private string description;

		public NewQuestionViewModel()
		{
			//Change method OnSave to Send to developers
			SaveCommand = new Command(OnSave, ValidateSave);
			CancelCommand = new Command(OnCancel);
			this.PropertyChanged +=
				(_, __) => SaveCommand.ChangeCanExecute();
		}

		private bool ValidateSave()
		{
			return !String.IsNullOrWhiteSpace(question)
				&& !String.IsNullOrWhiteSpace(description);
		}

		public string Question
		{
			get => question;
			set => SetProperty(ref question, value);
		}

		public string Description
		{
			get => description;
			set => SetProperty(ref description, value);
		}

		public Command SaveCommand { get; }
		public Command CancelCommand { get; }

		private async void OnCancel()
		{
			// This will pop the current page off the navigation stack
			await Shell.Current.GoToAsync("..");
		}

		private async void OnSave()
		{
			QuestionAndAnswer newItem = new QuestionAndAnswer()
			{
				QAId = Guid.NewGuid().ToString(),
				QAQuestion = Question,
				QAAnswer = Description
			};

			await QAndADataStore.AddItemAsync(newItem);

			// This will pop the current page off the navigation stack
			await Shell.Current.GoToAsync("..");
		}
	}
}
