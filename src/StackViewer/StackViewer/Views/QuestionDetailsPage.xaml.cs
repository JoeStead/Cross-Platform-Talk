using System.Collections.Generic;
using StackViewer.Model;
using StackViewer.ViewModels;
using Xamarin.Forms;

namespace StackViewer.Views
{
    public partial class QuestionDetailsPage : ContentPage
    {
        public QuestionDetailsPage(IEnumerable<AnswerInfo> answers)
        {
            InitializeComponent();
            BindingContext = new QuestionDetailsViewModel(answers);
        }
    }
}
