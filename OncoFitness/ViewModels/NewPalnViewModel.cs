using System;
using System.Collections.Generic;
using System.Text;

namespace OncoFitness.ViewModels
{
	public class NewPlanViewModel : BaseViewModel
	{
		public NewPlanViewModel()
		{
			Title = "Свой план";

			//Items = new ObservableCollection<Training>();
			//LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
			//StartTrainingCommand = new Command(async () => await ExecuteStartTrainingCommand());

			//ItemTapped = new Command<Training>(OnItemSelected);

			//MyListView.ItemsSource = Items;
		}
	}
}
