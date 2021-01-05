using OncoFitness.Models;
using OncoFitness.ViewModels;
using OncoFitness.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OncoFitness.Views
{
	public partial class HistoryPage : ContentPage
	{
		ItemsViewModel _viewModel;

		public HistoryPage()
		{
			InitializeComponent();

			BindingContext = _viewModel = new ItemsViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_viewModel.OnAppearing();
		}
	}
}