using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OncoFitness.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OncoFitness.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewPlanPage : ContentPage
	{
		NewPlanViewModel _viewModel;

		public NewPlanPage()
		{
			InitializeComponent();

			BindingContext = _viewModel = new NewPlanViewModel();
		}
	}
}