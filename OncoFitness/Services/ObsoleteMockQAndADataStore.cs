using OncoFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoFitness.Services
{
	public class ObsoleteMockQAndADataStore : IDataStore<QuestionAndAnswer>
	{
		readonly List<QuestionAndAnswer> items;

		public ObsoleteMockQAndADataStore()
		{
			items = new List<QuestionAndAnswer>()
			{
				new QuestionAndAnswer 
				{ 
					//QAId = Guid.NewGuid().ToString(), 
					QAQuestion = "Что?", 
					QAAnswer="Ответ на вопрос." 
				},
				new QuestionAndAnswer 
				{ 
					//QAId = Guid.NewGuid().ToString(), 
					QAQuestion = "Где?", 
					QAAnswer="Ответ на вопрос." 
				},
				new QuestionAndAnswer 
				{ 
					//QAId = Guid.NewGuid().ToString(), 
					QAQuestion = "Когда?", 
					QAAnswer="Ответ на вопрос." 
				},
				new QuestionAndAnswer 
				{ 
					//QAId = Guid.NewGuid().ToString(), 
					QAQuestion = "Почему?", 
					QAAnswer="Ответ на вопрос." 
				},
				new QuestionAndAnswer 
				{ 
					//QAId = Guid.NewGuid().ToString(), 
					QAQuestion = "Кто виноват?", 
					QAAnswer="Ответ на вопрос." 
				},
				new QuestionAndAnswer 
				{ 
					//QAId = Guid.NewGuid().ToString(), 
					QAQuestion = "Что делать?", 
					QAAnswer="Ответ на вопрос." 
				}
			};
		}

		public async Task<bool> AddItemAsync(QuestionAndAnswer item)
		{
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(QuestionAndAnswer item)
		{
			var oldItem = items.Where((QuestionAndAnswer arg) => arg.QAId == item.QAId).FirstOrDefault();
			items.Remove(oldItem);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(int id)
		{
			var oldItem = items.Where((QuestionAndAnswer arg) => arg.QAId == id).FirstOrDefault();
			items.Remove(oldItem);

			return await Task.FromResult(true);
		}

		public async Task<QuestionAndAnswer> GetItemAsync(int id)
		{
			return await Task.FromResult(items.FirstOrDefault(s => s.QAId == id));
		}

		public async Task<IEnumerable<QuestionAndAnswer>> GetItemsAsync(bool forceRefresh = false)
		{
			return await Task.FromResult(items);
		}
	}
}