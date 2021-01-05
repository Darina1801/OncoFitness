using OncoFitness.ViewModels;
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
		}

		private async void OnMenuItemClicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("//LoginPage");
		}
	}
}
