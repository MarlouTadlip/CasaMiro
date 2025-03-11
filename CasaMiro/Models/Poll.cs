namespace CasaMiro.Models
{
    public class Poll
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public DateTime DateCreated { get; set; }
    }

    public class Question
    {
        public string QuestionText { get; set; }
        public List<Option> Options { get; set; } = new List<Option>();
    }

    public class Option
    {
        public string OptionText { get; set; }
        public int VoteCount { get; set; } = 0; // Track how many votes this option received
    }
}
