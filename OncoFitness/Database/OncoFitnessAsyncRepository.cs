using OncoFitness.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoFitness.Database
{
	public class OncoFitnessAsyncRepository
	{
        SQLiteAsyncConnection database;

        public OncoFitnessAsyncRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
        }

		#region Create table

		//public async Task CreateTable()
		//{
		//    await database.CreateTableAsync<Friend>();
		//}

		#endregion

		#region Get items from DB

		public async Task<List<Exercise>> GetExerciseItemsAsync()
        {
            return await database.Table<Exercise>().ToListAsync();
        }
        public async Task<List<QuestionAndAnswer>> GetQAItemsAsync()
        {
            return await database.Table<QuestionAndAnswer>().ToListAsync();
        }
        public async Task<List<Training>> GetTrainingItemsAsync()
        {
            return await database.Table<Training>().ToListAsync();
        }

		#endregion

		#region Get item id from DB

		public async Task<Exercise> GetExerciseIdItemAsync(int id)
        {
            return await database.GetAsync<Exercise>(id);
        }
        public async Task<QuestionAndAnswer> GetQAIdItemAsync(string id)
        {
            return await database.GetAsync<QuestionAndAnswer>(id);
        }
        public async Task<Training> GetTrainingIdItemAsync(int id)
        {
            return await database.GetAsync<Training>(id);
        }

		#endregion

		#region Delete item from DB

		public async Task<int> DeleteExerciseItemAsync(Exercise item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> DeleteQAItemAsync(QuestionAndAnswer item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> DeleteTrainingItemAsync(Training item)
        {
            return await database.DeleteAsync(item);
        }

		#endregion

		#region Add new item to DB

		public async Task<int> SaveExerciseItemAsync(Exercise item)
        {
            if (item.ExerciseId != 0)
            {
                await database.UpdateAsync(item);
                return item.ExerciseId;
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }
        public async Task<int> SaveItemAsync(QuestionAndAnswer item)
        {
            if (item.QAId != 0)
            {
                await database.UpdateAsync(item);
                return item.QAId;
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }
        public async Task<int> SaveItemAsync(Training item)
        {
            if (item.TrainingId != 0)
            {
                await database.UpdateAsync(item);
                return item.TrainingId;
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }

        #endregion
    }
}
