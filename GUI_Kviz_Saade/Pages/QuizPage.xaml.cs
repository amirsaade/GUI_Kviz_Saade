using System.Reflection;
using System.Text.Json;
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
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "GUI_Kviz_Saade.Resources.questions.json";

        using Stream stream = assembly.GetManifestResourceStream(resourceName);
        using StreamReader reader = new(stream);
        string json = reader.ReadToEnd();

        _questions = JsonSerializer.Deserialize<List<Question>>(json) ?? new List<Question>();
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
