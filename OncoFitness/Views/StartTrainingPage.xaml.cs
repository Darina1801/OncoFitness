using OncoFitness.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OncoFitness.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartTrainingPage : ContentPage
	{
		public StartTrainingPage()
		{
			InitializeComponent();
			this.BindingContext = new StartTrainingViewModel();
		}

		protected async override void OnAppearing()
		{
			await ((StartTrainingViewModel)this.BindingContext).ExecuteLoadItemsCommand();
		}
	}
}