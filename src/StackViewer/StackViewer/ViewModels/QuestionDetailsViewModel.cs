using System.Collections.Generic;
using StackViewer.Model;

namespace StackViewer.ViewModels
{
    class QuestionDetailsViewModel
    {
        public QuestionDetailsViewModel(IEnumerable<AnswerInfo> answers)
        {
            Answers = answers;
        }

        public IEnumerable<AnswerInfo> Answers { get; set; }

    }
}
