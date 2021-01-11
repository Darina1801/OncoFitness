using OncoFitness.Models;
using OncoFitness.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace OncoFitness.ViewModels
{
	public class StartTrainingViewModel : BaseViewModel
	{
		public ObservableCollection<Exercise> Items { get; }
		public Command FinishTrainingCommand { get; }

		public StartTrainingViewModel()
		{
			FinishTrainingCommand = new Command(OnStartTrainingPageClicked);

			Items = new ObservableCollection<Exercise>()
			{ 
				new Exercise{ Name = "Упражнение 1", ImagePath = "OncoFitness_Logo.png", RepeatsCount = 10 }, 
				new Exercise{ Name = "Упражнение 2", ImagePath = "OncoFitness_Logo.png", RepeatsCount = 10 },
				new Exercise{ Name = "Упражнение 3", ImagePath = "OncoFitness_Logo.png", RepeatsCount = 10 },
				new Exercise{ Name = "Упражнение 4", ImagePath = "OncoFitness_Logo.png", RepeatsCount = 10 },
				new Exercise{ Name = "Упражнение 5", ImagePath = "OncoFitness_Logo.png", RepeatsCount = 10 },
			};
		}

		private async void OnStartTrainingPageClicked(object obj)
		{
			// Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
			await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
		}
	}
}
