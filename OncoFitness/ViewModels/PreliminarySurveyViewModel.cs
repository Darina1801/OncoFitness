using OncoFitness.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OncoFitness.ViewModels
{
	class PreliminarySurveyViewModel : BaseViewModel
	{
		public Command StartTrainingCommand { get; }

		public PreliminarySurveyViewModel()
		{
			Title = "Предварительный опрос";

			StartTrainingCommand = new Command(async () => await ExecuteStartTrainingCommand());
		}

		async Task ExecuteStartTrainingCommand()
		{
			IsBusy = true;

			try
			{
				await Shell.Current.GoToAsync(nameof(StartTrainingPage));
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
