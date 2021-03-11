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
		public Command StartNewExerciseCommand { get; }
		public Command PauseExerciseCommand { get; }
		public Command StopExerciseCommand { get; }
		public Exercise CurrentExercise { get; set; }
		public bool PlayFinishTrainingButtonsVisibility 
		{
			get { return playFinishTrainingButtonsVisibility; }
			set 
			{ 
				playFinishTrainingButtonsVisibility = value;
				OnPropertyChanged(); 
			} 
		}
		public bool PauseStopButtonsVisibility
		{
			get { return pauseStopButtonsVisibility; }
			set
			{
				pauseStopButtonsVisibility = value;
				OnPropertyChanged();
			}
		}

		private int currentExerciseNumber = 0;
		private bool playFinishTrainingButtonsVisibility;
		private bool pauseStopButtonsVisibility;

		public StartTrainingViewModel()
		{
			FinishTrainingCommand = new Command(async () => await ExecuteFinishTrainingCommand());
			StartNewExerciseCommand = new Command(async () => await ExecuteStartNewExerciseCommand());
			PauseExerciseCommand = new Command(async () => await ExecutePauseExerciseCommand());
			StopExerciseCommand = new Command(async () => await ExecuteStopExerciseCommand()); 

			PlayFinishTrainingButtonsVisibility = true;
			PauseStopButtonsVisibility = false;

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

		async Task ExecuteStartNewExerciseCommand()
		{
			IsBusy = true;

			try
			{
				if (currentExerciseNumber == Items.Count)
				{
					IsBusy = false;
					return;
				}
				CurrentExercise = Items[currentExerciseNumber];
				currentExerciseNumber++;
				PlayFinishTrainingButtonsVisibility = false;
				PauseStopButtonsVisibility = true;
				//Implement StartTimer call
				//await Shell.Current.GoToAsync(nameof(EndTrainingPage));
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

		async Task ExecutePauseExerciseCommand()
		{
			IsBusy = true;

			try
			{
				//Implement PauseTimer call
				//await Shell.Current.GoToAsync(nameof(EndTrainingPage));
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

		async Task ExecuteStopExerciseCommand()
		{
			IsBusy = true;

			try
			{
				PlayFinishTrainingButtonsVisibility = true;
				PauseStopButtonsVisibility = false;
				//Implement StopTimer call
				//await Shell.Current.GoToAsync(nameof(EndTrainingPage));
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
