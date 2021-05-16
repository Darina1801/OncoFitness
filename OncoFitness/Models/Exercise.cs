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
		
		[PrimaryKey, AutoIncrement, NotNull, Unique, Column("exercise_id")]
		public int ExerciseId { get; set; }
		
		[NotNull, Unique, Column("exercise_name")]
		public string ExerciseName { get; set; }
		
		[NotNull, Column("exercise_image_path")]
		public string ExerciseImagePath { get; set; }
		
		[NotNull, Column("exercise_repeats_count")]
		public int ExerciseRepeatsCount { get; set; }
		
		[Column("exercise_description")]
		public string ExerciseDescription { get; set; }
		
		[Column("exercise_elapsed_time")]
		public string ExerciseElapsedTime { get; set; }

		#endregion
	}
}
