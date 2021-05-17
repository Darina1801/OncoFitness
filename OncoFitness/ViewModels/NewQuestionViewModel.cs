using OncoFitness.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OncoFitness.ViewModels
{
	public class NewQuestionViewModel : BaseViewModel
	{
		protected List<string> emailsList = new List<string>() { "kuz-dana@mail.ru" };
		private string question;
		private string description;

		public NewQuestionViewModel()
		{
			//Change method OnSave to Send to developers
			//Add validation to SendCommand(..., ValidateSend);
			SendCommand = new Command(OnSend);
			CancelCommand = new Command(OnCancel);
			this.PropertyChanged +=
				(_, __) => SendCommand.ChangeCanExecute();
		}

		private bool ValidateSend()
		{
			return !String.IsNullOrWhiteSpace(question);
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

		public Command SendCommand { get; }
		public Command CancelCommand { get; }

		private async void OnCancel()
		{
			// This will pop the current page off the navigation stack
			await Shell.Current.GoToAsync("..");
		}

		public string MessageBuilder(string question, string description)
		{
			return question + Environment.NewLine + description;
		}

		private async void OnSend()
		{
			EmailMessage newQuestionMessage = new EmailMessage 
			{ 
				Subject = "OncoFitness New Question", 
				To = emailsList, 
				Body = MessageBuilder(Question, Description),
			};
			try
			{
				await Email.ComposeAsync(newQuestionMessage);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			finally
			{
				// This will pop the current page off the navigation stack
				await Shell.Current.GoToAsync("..");
			}
		}
	}
}
