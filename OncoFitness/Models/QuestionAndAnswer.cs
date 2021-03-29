using SQLite;
using System;

namespace OncoFitness.Models
{
	[Table("Question_And_Answer")]
	public class QuestionAndAnswer
	{
		#region Properties

		[PrimaryKey, AutoIncrement, NotNull, Unique, Column("QA_id")]
		public int QAId { get; set; }

		[NotNull, Unique, Column("QA_question")]
		public string QAQuestion { get; set; }

		[NotNull, Column("QA_answer")]
		public string QAAnswer { get; set; }

		#endregion
	}
}