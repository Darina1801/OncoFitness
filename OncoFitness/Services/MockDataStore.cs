using OncoFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoFitness.Services
{
	public class MockDataStore : IDataStore<QuestionAndAnswer>
	{
		readonly List<QuestionAndAnswer> items;

		public MockDataStore()
		{
			items = new List<QuestionAndAnswer>()
			{
				new QuestionAndAnswer { Id = Guid.NewGuid().ToString(), Question = "Что?", Answer="Ответ на вопрос." },
				new QuestionAndAnswer { Id = Guid.NewGuid().ToString(), Question = "Где?", Answer="Ответ на вопрос." },
				new QuestionAndAnswer { Id = Guid.NewGuid().ToString(), Question = "Когда?", Answer="Ответ на вопрос." },
				new QuestionAndAnswer { Id = Guid.NewGuid().ToString(), Question = "Почему?", Answer="Ответ на вопрос." },
				new QuestionAndAnswer { Id = Guid.NewGuid().ToString(), Question = "Кто виноват?", Answer="Ответ на вопрос." },
				new QuestionAndAnswer { Id = Guid.NewGuid().ToString(), Question = "Что делать?", Answer="Ответ на вопрос." }
			};
		}

		public async Task<bool> AddItemAsync(QuestionAndAnswer item)
		{
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(QuestionAndAnswer item)
		{
			var oldItem = items.Where((QuestionAndAnswer arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(oldItem);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(string id)
		{
			var oldItem = items.Where((QuestionAndAnswer arg) => arg.Id == id).FirstOrDefault();
			items.Remove(oldItem);

			return await Task.FromResult(true);
		}

		public async Task<QuestionAndAnswer> GetItemAsync(string id)
		{
			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<QuestionAndAnswer>> GetItemsAsync(bool forceRefresh = false)
		{
			return await Task.FromResult(items);
		}
	}
}