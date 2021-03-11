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

		private Color borderColor;
		private Color thickBorder;

		public ExerciseViewModel()
		{
			borderColor = Color.Black;
			thickBorder = Color.Transparent;
		}
	}
}
