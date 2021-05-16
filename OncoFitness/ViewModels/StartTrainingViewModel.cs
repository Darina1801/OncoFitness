using OncoFitness.Models;
using OncoFitness.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OncoFitness.ViewModels
{
	public class StartTrainingViewModel : BaseViewModel
	{
		#region Fields 

		private string trainingGoal;
		private ExerciseViewModel currentExercise;
		private TimerViewModel totalTrainingTimer;
		private int currentExerciseNumber = 0;
		private bool trainingGoalVisibility;
		private bool totalTrainingTimerVisibility;
		private bool playVisibility;
		private bool stopVisibility;
		private bool pauseVisibility;
		private bool finishTrainingVisibility;

		#endregion

		#region Properties

		public ObservableCollection<ExerciseViewModel> Items { get; }
		public Command FinishTrainingCommand { get; }
		public Command StartNewExerciseCommand { get; }
		public Command PauseExerciseCommand { get; }
		public Command StopExerciseCommand { get; }
		public Command LoadItemsCommand { get; }
		public string TrainingGoal
		{
			get { return trainingGoal; }
			set { trainingGoal = value; }
		}
		public ExerciseViewModel CurrentExercise
		{
			get { return currentExercise; }
			set { currentExercise = value;
				OnPropertyChanged();
			}
		}
		public bool PlayVisibility
		{
			get { return playVisibility; }
			set
			{
				playVisibility = value;
				OnPropertyChanged();
			}
		}
		public bool StopVisibility
		{
			get { return stopVisibility; }
			set
			{
				stopVisibility = value;
				OnPropertyChanged();
			}
		}
		public bool PauseVisibility
		{
			get { return pauseVisibility; }
			set
			{
				pauseVisibility = value;
				OnPropertyChanged();
			}
		}
		public bool FinishTrainingVisibility
		{
			get { return finishTrainingVisibility; }
			set
			{
				finishTrainingVisibility = value;
				OnPropertyChanged();
			}
		}
		public TimerViewModel TotalTrainingTimer
		{
			get { return totalTrainingTimer; }
			set
			{
				totalTrainingTimer = value;
				OnPropertyChanged();
			}
		}
		public bool TotalTrainingTimerVisibility 
		{
			get {return totalTrainingTimerVisibility; }
			set 
			{
				totalTrainingTimerVisibility = value;
				OnPropertyChanged();
			}
		}
		public bool TrainingGoalVisibility
		{
			get { return trainingGoalVisibility; }
			set 
			{
				trainingGoalVisibility = value;
				OnPropertyChanged();
			}
		}

		#endregion

		#region Constructor

		public StartTrainingViewModel()
		{
			trainingGoal = "Цель тренировки";
			trainingGoalVisibility = true;
			totalTrainingTimerVisibility = false;

			FinishTrainingCommand = new Command(async () => await ExecuteFinishTrainingCommand());
			StartNewExerciseCommand = new Command(async () => await ExecuteStartNewExerciseCommand());
			PauseExerciseCommand = new Command(async () => await ExecutePauseExerciseCommand());
			StopExerciseCommand = new Command(async () => await ExecuteStopExerciseCommand()); 

			PlayVisibility = true;
			StopVisibility = false;
			PauseVisibility = false;
			FinishTrainingVisibility = true;

			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
			Items = new ObservableCollection<ExerciseViewModel>();
			ExecuteLoadItemsCommand();
		}

		#endregion

		#region Methods

		public async Task OnAppearing()
		{
			IsBusy = true;
		}

		public async Task ExecuteLoadItemsCommand()
		{
			IsBusy = true;

			try
			{
				Items.Clear();
				var RepositoryDB = App.Database;
				var items = await RepositoryDB.GetExerciseItemsAsync();
				foreach (var item in items)
				{
					Items.Add
					(
						new ExerciseViewModel
						{
							Exercise = item
						}
					);
				}
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

		async Task ExecuteFinishTrainingCommand()
		{
			IsBusy = true;

			try
			{
				TotalTrainingTimer.StopTimer = true;
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

				//Start after pause
				if (CurrentExercise != null && !CurrentExercise.IsFinished)
				{
					CurrentExercise.BorderColor = Color.Blue;
					CurrentExercise.ThickBorder = CurrentExercise.BorderColor;
					IsBusy = false;
					PlayVisibility = false;
					StopVisibility = true;
					PauseVisibility = true;
					FinishTrainingVisibility = false;
					CurrentExercise.ExerciseTimer.PauseTimer = false;
					return;
				}
				//First exercise start
				else
				{
					if (CurrentExercise == null)
					{
						TotalTrainingTimer = new TimerViewModel();
						TrainingGoalVisibility = false;
						TotalTrainingTimerVisibility = true;
					}
					CurrentExercise = Items[currentExerciseNumber];
					CurrentExercise.BorderColor = Color.Blue;
					CurrentExercise.ThickBorder = CurrentExercise.BorderColor;
					currentExerciseNumber++;
					PlayVisibility = false;
					StopVisibility = true;
					PauseVisibility = true;
					FinishTrainingVisibility = false;
					CurrentExercise.StartExerciseDateTime();
					CurrentExercise.TimerVisibility = true;
					CurrentExercise.ExerciseTimer.PauseTimer = false;
				}
				
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
				CurrentExercise.BorderColor = Color.Orange;
				CurrentExercise.ThickBorder = CurrentExercise.BorderColor;
				PauseVisibility = false;
				PlayVisibility = true;
				StopVisibility = true;
				FinishTrainingVisibility = false;
				CurrentExercise.ExerciseTimer.PauseTimer = true;
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
				CurrentExercise.BorderColor = Color.LightGreen;
				CurrentExercise.ThickBorder = Color.Transparent;
				PlayVisibility = true;
				StopVisibility = false;
				FinishTrainingVisibility = true;
				PauseVisibility = false;
				CurrentExercise.IsFinished = true;
				CurrentExercise.ExerciseTimer.StopTimer = true;
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

		#endregion
	}
}
