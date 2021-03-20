using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace OncoFitness.Models
{
	[Table("Exercise")]
	public class Exercise
	{
		#region Properties
		
		[PrimaryKey, NotNull, Unique, Column("exercise_id")]
		public int ExerciseId { get; set; }
		
		[NotNull, Unique, Column("exercise_name")]
		public string ExerciseName { get; set; }
		
		[NotNull, Unique, Column("exercise_image_path")]
		public string ExeciseImagePath { get; set; }
		
		[NotNull, Unique, Column("exercise_name")]
		public int ExerciseRepeatsCount { get; set; }
		
		[Column("exercise_count")]
		public string ExerciseDescription { get; set; }
		
		[Column("exercise_elapsed_time")]
		public TimeSpan ExerciseElapsedTime { get; set; }

		#endregion
	}
}
