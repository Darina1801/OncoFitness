using OncoFitness.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OncoFitness.ViewModels
{
	public class ExerciseViewModel : BaseViewModel
	{
		public Exercise Exercise { get; set; }
		public TimerViewModel ExerciseTimer { get; set; }

		public Color BorderColor 
		{
			get { return borderColor; }
			set 
			{ 
				borderColor = value;
				OnPropertyChanged();
			}
		}
		public Color ThickBorder
		{
			get { return thickBorder; }
			set 
			{
				thickBorder = value;
				OnPropertyChanged();
			}
		}

		private bool timerVisibility;

		public bool TimerVisibility
		{
			get { return timerVisibility; }
			set
			{
				timerVisibility = value;
				OnPropertyChanged();
			}
		}

		private bool isFinished;

		public bool IsFinished
		{
			get { return isFinished; }
			set
			{
				isFinished = value;
				OnPropertyChanged();
			}
		}

		private Color borderColor;
		private Color thickBorder;

		public ExerciseViewModel()
		{
			borderColor = Color.Black;
			thickBorder = Color.Transparent;
			isFinished = false;
			timerVisibility = false;
			ExerciseTimer = new TimerViewModel();
		}

		public void StartExerciseDateTime()
		{
			ExerciseTimer.DisplayedTimerDateTime = new TimeSpan();
		}
	}
}
