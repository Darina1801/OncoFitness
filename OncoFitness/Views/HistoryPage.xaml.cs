using OncoFitness.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OncoFitness.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryPage : ContentPage
	{
		HistoryViewModel _viewModel;
		
		public HistoryPage()
		{
			InitializeComponent();

			BindingContext = _viewModel = new HistoryViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_viewModel.OnAppearing();
		}
	}
}
