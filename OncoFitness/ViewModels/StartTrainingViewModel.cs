using OncoFitness.Models;
using OncoFitness.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OncoFitness.ViewModels
{
	public class StartTrainingViewModel : BaseViewModel
	{
		public ObservableCollection<Exercise> Items { get; }
		public Command FinishTrainingCommand { get; }

		public StartTrainingViewModel()
		{
			FinishTrainingCommand = new Command(async () => await ExecuteFinishTrainingCommand());

			Items = new ObservableCollection<Exercise>()
			{ 
				new Exercise{ Name = "Упражнение 1", ImagePath = "OncoFitness_Logo.png", RepeatsCount = 10 }, 
				new Exercise{ Name = "Упражнение 2", ImagePath = "OncoFitness_Logo.png", RepeatsCount = 10 },
				new Exercise{ Name = "Упражнение 3", ImagePath = "OncoFitness_Logo.png", RepeatsCount = 10 },
				new Exercise{ Name = "Упражнение 4", ImagePath = "OncoFitness_Logo.png", RepeatsCount = 10 },
				new Exercise{ Name = "Упражнение 5", ImagePath = "OncoFitness_Logo.png", RepeatsCount = 10 },
			};
		}

		async Task ExecuteFinishTrainingCommand()
		{
			IsBusy = true;

			try
			{
				await Shell.Current.GoToAsync(nameof(EndTrainingPage));
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
