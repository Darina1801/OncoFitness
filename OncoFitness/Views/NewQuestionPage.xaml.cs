using OncoFitness.Models;
using OncoFitness.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OncoFitness.Views
{
	public partial class NewQuestionPage : ContentPage
	{
		public QuestionAndAnswer Question { get; set; }

		public NewQuestionPage()
		{
			InitializeComponent();
			BindingContext = new NewQuestionViewModel();
		}
	}
}