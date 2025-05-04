using CommunityToolkit.Mvvm.Input;
using GUI_Kviz_Saade.Models;

namespace GUI_Kviz_Saade.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}