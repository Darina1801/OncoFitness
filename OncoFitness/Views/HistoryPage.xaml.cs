using OncoFitness.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OncoFitness.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryPage : ContentPage
	{
		HistoryViewModel _viewModel;
		public ObservableCollection<string> Items { get; set; }

		public HistoryPage()
		{
			InitializeComponent();

			BindingContext = _viewModel = new HistoryViewModel();

			Items = new ObservableCollection<string>
			{
				"Что?",
				"Где?",
				"Когда?",
				"Кто виноват?",
				"Что делать?"
			};

			MyListView.ItemsSource = Items;
		}

		async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (e.Item == null)
				return;

			await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

			//Deselect Item
			((ListView)sender).SelectedItem = null;
		}
	}
}
