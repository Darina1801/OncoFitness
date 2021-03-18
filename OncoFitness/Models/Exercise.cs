using System;
using System.Collections.Generic;
using System.Text;

namespace OncoFitness.Models
{
	public class Exercise
	{
		#region Properties
		//[Primary]
		public int Id { get; set; }
		public string Name { get; set; }
		public string ImagePath { get; set; }
		public int RepeatsCount { get; set; }
		public string Description { get; set; }
		public TimeSpan ExerciseElapsedTime { get; set; }

		#endregion
	}
}
