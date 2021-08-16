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