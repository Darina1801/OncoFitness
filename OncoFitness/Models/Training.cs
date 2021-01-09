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
		public int TraineeArterTraining { get; set; }
		public TimeSpan TriningElapsedTime { get; set; }
		public string TrainingNotes { get; set; }
	}
}
