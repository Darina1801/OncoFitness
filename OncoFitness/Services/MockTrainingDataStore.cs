using OncoFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OncoFitness.Services
{
	class MockTrainingDataStore : IDataStore<Training>
	{
		readonly List<Training> items;

		public MockTrainingDataStore()
		{
			items = new List<Training>()
			{
				new Training { Id = Guid.NewGuid().ToString(), TrainingType = "Равновесие", TrainingNotes="Все упражнения дались легко. Надо больше работать над равновесием", TrainingDateTime=DateTime.Now },
				new Training { Id = Guid.NewGuid().ToString(), TrainingType = "Укрепить ноги", TrainingNotes="Температура 38.9. Не тренировалась.", TrainingDateTime=DateTime.Now },
				new Training { Id = Guid.NewGuid().ToString(), TrainingType = "Укрепить руки", TrainingNotes="Температура 39.0. Не тренировалась.", TrainingDateTime=DateTime.Now },
				new Training { Id = Guid.NewGuid().ToString(), TrainingType = "Укрепить таз", TrainingNotes="Не понимаю упражнение \"Ягодичный мостик\". Ноги должны стоять на ширине плеч или шире?", TrainingDateTime=DateTime.Now },
				new Training { Id = Guid.NewGuid().ToString(), TrainingType = "Укрепить пресс", TrainingNotes="Очень тяжело. Слишком сложные упражнения.", TrainingDateTime=DateTime.Now },
				new Training { Id = Guid.NewGuid().ToString(), TrainingType = "Дыхательная гимнастика", TrainingNotes="Все упражнения дались легко, но под конец занятия закружилась голова.", TrainingDateTime=DateTime.Now },
			};
		}

		public async Task<bool> AddItemAsync(Training item)
		{
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(string id)
		{
			var oldItem = items.Where((Training arg) => arg.Id == id).FirstOrDefault();
			items.Remove(oldItem);

			return await Task.FromResult(true);
		}

		public async Task<Training> GetItemAsync(string id)
		{
			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Training>> GetItemsAsync(bool forceRefresh = false)
		{
			return await Task.FromResult(items);
		}

		public async Task<bool> UpdateItemAsync(Training item)
		{
			var oldItem = items.Where((Training arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(oldItem);
			items.Add(item);

			return await Task.FromResult(true);
		}
	}
}
