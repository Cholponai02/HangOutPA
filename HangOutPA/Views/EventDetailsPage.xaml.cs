using CommunityToolkit.Maui.Views;
using HangOutPA.ViewModels;
using HangOutPA.Views.Popups;

namespace HangOutPA.Views;

public partial class EventDetailsPage : ContentPage
{
    public EventDetailsPage()
    {
        InitializeComponent();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        // Используем Shell для возврата на предыдущую страницу
        await Shell.Current.GoToAsync("..");
    }


    private void OnOpenSplitPopupClicked(object sender, EventArgs e)
    {
        var vm = BindingContext as EventDetailsViewModel;
        if (vm?.SelectedEvent == null) return;

        // Считаем математику: цель минус собрано
        double remaining = vm.SelectedEvent.GoalAmount - vm.SelectedEvent.CurrentFunded;
        int people = vm.SelectedEvent.Participants.Count;

        // Открываем наш новый Popup
        var popup = new SplitPopup(remaining, people);
        this.ShowPopup(popup);
    }
}