using OncoFitness.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OncoFitness.ViewModels
{
	public class StartTrainingViewModel : BaseViewModel
	{
		public Command LoginCommand { get; }

		public StartTrainingViewModel()
		{
			LoginCommand = new Command(OnStartTrainingPageClicked);
		}

		private async void OnStartTrainingPageClicked(object obj)
		{
			// Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
			await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
		}
	}
}
