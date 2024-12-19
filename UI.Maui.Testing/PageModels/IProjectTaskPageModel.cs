using CommunityToolkit.Mvvm.Input;
using UI.Maui.Testing.Models;

namespace UI.Maui.Testing.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}