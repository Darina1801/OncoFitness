using OncoFitness.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OncoFitness.ViewModels
{
	class PreliminarySurveyViewModel : BaseViewModel
	{
		public Command StartSurveyCommand { get; }

		public PreliminarySurveyViewModel()
		{
			Title = "Предварительный опрос";

			StartSurveyCommand = new Command(async () => await ExecuteStartSurveyCommand());
		}

		async Task ExecuteStartSurveyCommand()
		{
			IsBusy = true;

			try
			{
				await Shell.Current.GoToAsync(nameof(PreliminarySurveyPage));
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
