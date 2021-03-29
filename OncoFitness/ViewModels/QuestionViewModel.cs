using OncoFitness.Database;
using OncoFitness.Models;
using OncoFitness.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OncoFitness.ViewModels
{
	public class QuestionViewModel : BaseViewModel
	{
		private QuestionAndAnswer _selectedItem;

		public ObservableCollection<QuestionAndAnswer> Items { get; }
		public Command LoadItemsCommand { get; }
		public Command AddItemCommand { get; }
		public Command<QuestionAndAnswer> ItemTapped { get; }

		public QuestionViewModel()
		{
			Title = "Частые вопросы";
			Items = new ObservableCollection<QuestionAndAnswer>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

			ItemTapped = new Command<QuestionAndAnswer>(OnItemSelected);

			AddItemCommand = new Command(OnAddItem);
		}

		async Task ExecuteLoadItemsCommand()
		{
			IsBusy = true;

			try
			{
				Items.Clear();
				//var items = await QAndADataStore.GetItemsAsync(true);
				//var RepositoryDB = new OncoFitnessAsyncRepository(@"OncoFitnessDatabase.DB");
				var RepositoryDB = App.Database;
				//await RepositoryDB.CreateQandATable();
				var items = await RepositoryDB.GetQAItemsAsync();
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

		public QuestionAndAnswer SelectedItem
		{
			get => _selectedItem;
			set
			{
				SetProperty(ref _selectedItem, value);
				OnItemSelected(value);
			}
		}

		private async void OnAddItem(object obj)
		{
			await Shell.Current.GoToAsync(nameof(NewQuestionPage));
		}

		async void OnItemSelected(QuestionAndAnswer item)
		{
			if (item == null)
				return;

			// This will push the QuestionDetailPage onto the navigation stack
			await Shell.Current.GoToAsync($"{nameof(QuestionDetailPage)}?{nameof(QuestionDetailViewModel.ItemId)}={item.QAId}");
		}
	}
}