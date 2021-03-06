﻿using OncoFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OncoFitness.Services
{
	class ObsoleteMockTrainingDataStore : IDataStore<Training>
	{
		readonly List<Training> items;

		public ObsoleteMockTrainingDataStore()
		{
			items = new List<Training>()
			{
				new Training 
				{ 
					//TrainingId = Guid.NewGuid().ToString(), 
					TrainingDateTime = DateTime.Now,
					TrainingType = "Равновесие",
					TrainingPatientFeelingsAfter = 5, 
					TrainingElapsedTime = new TimeSpan(0, 3, 45),
					TrainingNotes="Все упражнения дались легко. Надо больше работать над равновесием" 
					
				},
				new Training 
				{ 
					//TrainingId = Guid.NewGuid().ToString(),
					TrainingDateTime = DateTime.Now,
					TrainingType = "Укрепить ноги",
					TrainingPatientFeelingsAfter = 5,
					TrainingElapsedTime = new TimeSpan(0, 3, 45),
					TrainingNotes="Температура 38.9. Не тренировалась." 
				},
				new Training 
				{ 
					//TrainingId = Guid.NewGuid().ToString(),
					TrainingDateTime = DateTime.Now,
					TrainingType = "Укрепить руки",
					TrainingPatientFeelingsAfter = 5,
					TrainingElapsedTime = new TimeSpan(0, 3, 45),
					TrainingNotes="Температура 39.0. Не тренировалась." 
				},
				new Training 
				{ 
					//TrainingId = Guid.NewGuid().ToString(),
					TrainingDateTime = DateTime.Now,
					TrainingType = "Укрепить таз",
					TrainingPatientFeelingsAfter = 5,
					TrainingElapsedTime = new TimeSpan(0, 3, 45),
					TrainingNotes="Не понимаю упражнение \"Ягодичный мостик\". Ноги должны стоять на ширине плеч или шире?" 
				},
				new Training 
				{ 
					//TrainingId = Guid.NewGuid().ToString(),
					TrainingDateTime = DateTime.Now,
					TrainingType = "Укрепить пресс",
					TrainingPatientFeelingsAfter = 5,
					TrainingElapsedTime = new TimeSpan(0, 3, 45),
					TrainingNotes="Очень тяжело. Слишком сложные упражнения." 
				},
				new Training 
				{ 
					//TrainingId = Guid.NewGuid().ToString(),
					TrainingDateTime = DateTime.Now,
					TrainingType = "Дыхательная гимнастика",
					TrainingPatientFeelingsAfter = 5,
					TrainingElapsedTime = new TimeSpan(0, 3, 45),
					TrainingNotes="Все упражнения дались легко, но под конец занятия закружилась голова." 
				},
			};
		}

		public async Task<bool> AddItemAsync(Training item)
		{
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(int id)
		{
			var oldItem = items.Where((Training arg) => arg.TrainingId == id).FirstOrDefault();
			items.Remove(oldItem);

			return await Task.FromResult(true);
		}

		public async Task<Training> GetItemAsync(int id)
		{
			return await Task.FromResult(items.FirstOrDefault(s => s.TrainingId == id));
		}

		public async Task<IEnumerable<Training>> GetItemsAsync(bool forceRefresh = false)
		{
			return await Task.FromResult(items);
		}

		public async Task<bool> UpdateItemAsync(Training item)
		{
			var oldItem = items.Where((Training arg) => arg.TrainingId == item.TrainingId).FirstOrDefault();
			items.Remove(oldItem);
			items.Add(item);

			return await Task.FromResult(true);
		}
	}
}
