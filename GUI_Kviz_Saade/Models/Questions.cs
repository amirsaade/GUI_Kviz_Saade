namespace GUI_Kviz_Saade.Models;

public class Question
{
    public string Text { get; set; } = string.Empty;
    public List<string> Options { get; set; } = new();
    public int CorrectOptionIndex { get; set; }
    public string? ImageUrl { get; set; }  
}
