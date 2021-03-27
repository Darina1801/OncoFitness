using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace OncoFitness.Models
{
	[Table("Training")]
	public class Training
	{
		#region Properties
		[PrimaryKey, NotNull, Unique, Column("training_id")]
		public string TrainingId { get; set; }

		[NotNull, Column("training_name")]
		public string TrainingName { get; set; }

		[NotNull, Column("training_goal")]
		public string TrainingGoal { get; set; }

		[Column("training_date_time")]
		public DateTime TrainingDateTime { get; set; }

		[Column("training_elapsed_time")]
		public TimeSpan TrainingElapsedTime { get; set; }

		public List<int> ExercisesId { get; set; }

		[Column("training_parient_feelings")]
		public int TrainingPatientFeelingsAfter { get; set; }

		[Column("training_notes")]
		public string TrainingNotes { get; set; }

		[NotNull, Column("training_type")]
		public string TrainingType { get; set; }

		#endregion
	}
}
