using System.Collections.Generic;
using System.Net;

namespace StackViewer.Model
{
    internal class QuestionInfo
    {
        private string _title;
        public IEnumerable<string> Tags { get; set; }

        public bool Is_Answered { get; set; }

        public int Answer_Count { get; set; }

        public int Score { get; set; }

        public int Question_Id { get; set; }

        public string TagDisplay
        {
            get { return string.Join(", ", Tags); }
        }

        public string Title
        {
            get { return _title; }
            set { _title = WebUtility.HtmlDecode(value); }
        }

        public Owner Owner { get; set; }
    }

}
