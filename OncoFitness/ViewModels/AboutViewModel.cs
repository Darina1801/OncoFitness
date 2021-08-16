using OncoFitness.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OncoFitness.ViewModels
{
	public class AboutViewModel : BaseViewModel
	{
		public Command StartSurveyCommand { get; }

		public AboutViewModel()
		{
			Title = "О программе";

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