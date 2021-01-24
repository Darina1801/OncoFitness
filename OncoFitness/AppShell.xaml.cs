﻿using OncoFitness.ViewModels;
using OncoFitness.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace OncoFitness
{
	public partial class AppShell : Xamarin.Forms.Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute(nameof(QuestionDetailPage), typeof(QuestionDetailPage));
			Routing.RegisterRoute(nameof(NewQuestionPage), typeof(NewQuestionPage));
			Routing.RegisterRoute(nameof(TrainingDetailPage), typeof(TrainingDetailPage));
			Routing.RegisterRoute(nameof(StartTrainingPage), typeof(StartTrainingPage));
			Routing.RegisterRoute(nameof(EndTrainingPage), typeof(EndTrainingPage));
		}

		private async void OnMenuItemClicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("//LoginPage");
		}
	}
}
