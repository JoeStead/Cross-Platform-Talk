using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using StackViewer.Model;
using StackViewer.Views;
using Xamarin.Forms;

namespace StackViewer.ViewModels
{
    class QuestionListViewModel
    {
        private readonly INavigation _navigation;
        private readonly StackRetriever _retriever;

        public async void LoadingPage()
        {
            var questionsJson = await _retriever.GetQuestions();

            QuestionList = JsonConvert.DeserializeObject<Questions>(questionsJson);

        }

        public async void SelectQuestion(QuestionInfo selectedQuestion)
        {
            var answerText = await _retriever.GetAnswers(selectedQuestion.Question_Id);

            var answerInfo = JsonConvert.DeserializeObject<Answers>(answerText);

            await _navigation.PushModalAsync(new QuestionDetailsPage(answerInfo.Items));
        }

        public QuestionListViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _retriever = new StackRetriever();
        }


        public Questions QuestionList
        {
            get;
            set;
        }

    }
}
