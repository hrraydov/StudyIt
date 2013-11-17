using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyIt.Web.ViewModels
{
    public class TestListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TestDoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public int QuestionCount { get; set; }
        public int[] Answers { get; set; }
        public int[] QuestionIds { get; set; }
    }

    public class TestShowResultViewModel
    {
        public string Name { get; set; }
        public int TotalScore { get; set; }
        public int Value { get; set; }
        public Dictionary<int, int> GivenAnswers { get; set; }
        public List<Question> WrongQuestions { get; set; }
        public bool ShowTrueAnswers { get; set; }
    }

}