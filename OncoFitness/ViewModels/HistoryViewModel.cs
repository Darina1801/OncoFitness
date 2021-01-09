using OncoFitness.Models;
using OncoFitness.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OncoFitness.ViewModels
{
	public class HistoryViewModel : BaseViewModel
	{
		private Training _selectedItem;
		public ObservableCollection<Training> Items { get; set; }
		public Command LoadItemsCommand { get; }
		public Command<Training> ItemTapped { get; }
		public HistoryViewModel()
		{
			Title = "История";

			Items = new ObservableCollection<Training>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

			ItemTapped = new Command<Training>(OnItemSelected);

			//MyListView.ItemsSource = Items;
		}

		async Task ExecuteLoadItemsCommand()
		{
			IsBusy = true;

			try
			{
				Items.Clear();
				var items = (await TrainingDataStore.GetItemsAsync(true)).ToList();
				items.Reverse();
				foreach (var item in items)
				{
					Items.Add(item);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			finally
			{
				IsBusy = false;
			}
		}
		public void OnAppearing()
		{
			IsBusy = true;
			SelectedItem = null;
		}

		public Training SelectedItem
		{
			get => _selectedItem;
			set
			{
				SetProperty(ref _selectedItem, value);
				OnItemSelected(value);
			}
		}

		async void OnItemSelected(Training item)
		{
			if (item == null)
				return;

			// This will push the TrainingDetailPage onto the navigation stack
			await Shell.Current.GoToAsync($"{nameof(TrainingDetailPage)}?{nameof(TrainingDetailViewModel.ItemId)}={item.Id}");
		}
	}
}
