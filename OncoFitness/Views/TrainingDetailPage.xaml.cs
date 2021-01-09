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
	public partial class TrainingDetailPage : ContentPage
	{
		public TrainingDetailPage()
		{
			InitializeComponent();
			
			BindingContext = new TrainingDetailViewModel();
		}
	}
}