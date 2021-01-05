using OncoFitness.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace OncoFitness.Views
{
	public partial class QuestionDetailPage : ContentPage
	{
		public QuestionDetailPage()
		{
			InitializeComponent();
			BindingContext = new QuestionDetailViewModel();
		}
	}
}