using System;
using System.Collections.Generic;
using System.Text;

namespace OncoFitness.Models
{
	public class Training
	{
		public string Id { get; set; }
		public DateTime TrainingDateTime { get; set; }
		public string TrainingType { get; set; }
		public int PatientAfterTraining { get; set; }
		public TimeSpan TrainingElapsedTime { get; set; }
		public string TrainingNotes { get; set; }
	}
}
