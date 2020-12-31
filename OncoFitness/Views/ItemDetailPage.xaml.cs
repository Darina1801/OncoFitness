using OncoFitness.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace OncoFitness.Views
{
	public partial class ItemDetailPage : ContentPage
	{
		public ItemDetailPage()
		{
			InitializeComponent();
			BindingContext = new ItemDetailViewModel();
		}
	}
}