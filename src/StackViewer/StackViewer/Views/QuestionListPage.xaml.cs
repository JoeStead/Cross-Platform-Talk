using System;
using StackViewer.Model;
using StackViewer.ViewModels;

using Xamarin.Forms;

namespace StackViewer.Views
{
    public partial class QuestionListPage : ContentPage
    {
        private readonly QuestionListViewModel _viewModel;

        public QuestionListPage()
        {
            InitializeComponent();
            _viewModel = new QuestionListViewModel(Navigation);
            BindingContext = _viewModel;


            Appearing += OnPageAppearing;
        }

        public void OnPageAppearing(object sender, EventArgs args)
        {
            _viewModel.LoadingPage();
        }

        public void QuestionSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var selectedQuestion = (QuestionInfo)args.SelectedItem;
            _viewModel.SelectQuestion(selectedQuestion);
        }
    }
}
