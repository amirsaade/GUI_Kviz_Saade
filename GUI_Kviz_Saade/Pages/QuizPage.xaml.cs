using GUI_Kviz_Saade.Models;

namespace GUI_Kviz_Saade.Pages;

public partial class QuizPage : ContentPage
{
    private List<Question> _questions = new();
    private int _currentQuestionIndex = 0;
    private int _score = 0;

    public QuizPage()
    {
        InitializeComponent();
        LoadQuestions();
        ShowQuestion();
    }

    private void LoadQuestions()
    {
        // Zatiaľ natvrdo pridáme otázky, neskôr môžeme načítať zo súboru
        _questions = new List<Question>
        {
            new Question
            {
                Text = "Aké je hlavné mesto Slovenska?",
                Options = new List<string> { "Bratislava", "Košice", "Nitra", "Žilina" },
                CorrectOptionIndex = 0
            },
            new Question
            {
                Text = "Koľko má človek prstov na rukách?",
                Options = new List<string> { "4", "5", "6", "10" },
                CorrectOptionIndex = 1
            }
        };
    }

    private void ShowQuestion()
    {
        if (_currentQuestionIndex >= _questions.Count)
        {
            DisplayAlert("Koniec kvízu", $"Tvoj výsledok: {_score} / {_questions.Count}", "OK");
            _currentQuestionIndex = 0;
            _score = 0;
            ShowQuestion();
            return;
        }

        var q = _questions[_currentQuestionIndex];
        QuestionTextLabel.Text = q.Text;

        OptionAButton.Text = "a) " + q.Options[0];
        OptionBButton.Text = "b) " + q.Options[1];
        OptionCButton.Text = "c) " + q.Options[2];
        OptionDButton.Text = "d) " + q.Options[3];

        if (!string.IsNullOrEmpty(q.ImageUrl))
        {
            QuestionImage.IsVisible = true;
            QuestionImage.Source = q.ImageUrl;
        }
        else
        {
            QuestionImage.IsVisible = false;
        }
    }

    private void OnOptionClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        int selectedIndex = button == OptionAButton ? 0 :
                            button == OptionBButton ? 1 :
                            button == OptionCButton ? 2 : 3;

        if (selectedIndex == _questions[_currentQuestionIndex].CorrectOptionIndex)
        {
            _score++;
        }

        _currentQuestionIndex++;
        ShowQuestion();
    }
}
