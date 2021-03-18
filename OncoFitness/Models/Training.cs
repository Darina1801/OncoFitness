using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace OncoFitness.Models
{
	public class Training
	{
		#region Properties

		public int Id { get; set; }
		public string TrainingName { get; set; }
		public string TrainingGoal { get; set; }
		public DateTime TrainingDateTime { get; set; }
		public TimeSpan TrainingElapsedTime { get; set; }
		public List<int> ExercisesId { get; set; }
		public int PatientAfterTrainingFeelings { get; set; }
		public string TrainingNotes { get; set; }
		public string TrainingType { get; set; }

		#endregion
	}
}
