using OncoFitness.Models;
using OncoFitness.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OncoFitness.ViewModels
{
	public class HistoryViewModel : BaseViewModel
	{
		private Training _selectedItem;
		private DateTime? _date;
		private ObservableCollection<XamForms.Controls.SpecialDate> attendances;

		public ObservableCollection<Training> Items { get; set; }
		public Command LoadItemsCommand { get; }
		public Command StartSurveyCommand { get; }
		public Command<Training> ItemTapped { get; }
		public DateTime? Date
		{
			get
			{
				return _date;
			}
			set
			{
				_date = value;
				OnPropertyChanged(nameof(Date));
			}
		}
		public ObservableCollection<XamForms.Controls.SpecialDate> Attendances
		{
			get
			{
				return attendances;
			}
			set
			{
				attendances = value;
				OnPropertyChanged(nameof(Attendances));
			}
		}
		public Command DateChosen
		{
			get
			{
				return new Command((obj) =>
				{
					System.Diagnostics.Debug.WriteLine(obj as DateTime?);
				});
			}
		}

		public HistoryViewModel()
		{
			Title = "История";

			Items = new ObservableCollection<Training>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
			StartSurveyCommand = new Command(async () => await ExecuteStartSurveyCommand());

			ItemTapped = new Command<Training>(OnItemSelected);

			Date = DateTime.Now;

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

		async Task ExecuteStartSurveyCommand()
		{
			IsBusy = true;

			try
			{
				await Shell.Current.GoToAsync(nameof(PreliminarySurveyPage));
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
			await Shell.Current.GoToAsync($"{nameof(TrainingDetailPage)}?{nameof(TrainingDetailViewModel.ItemId)}={item.TrainingId}");
		}
	}
}
