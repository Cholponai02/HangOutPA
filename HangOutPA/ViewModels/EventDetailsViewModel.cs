using System.Windows.Input;
using HangOutPA.Models;

namespace HangOutPA.ViewModels;

[QueryProperty(nameof(SelectedEvent), "SelectedEvent")] // Позволяет принимать объект через навигацию
public class EventDetailsViewModel : BindableObject
{
    private Event _selectedEvent;
    public Event SelectedEvent
    {
        get => _selectedEvent;
        set { _selectedEvent = value; OnPropertyChanged(); }
    }

    public ICommand ChipInCommand { get; }
    public ICommand CheckInCommand { get; }

    public EventDetailsViewModel()
    {
        ChipInCommand = new Command<string>(OnChipIn);
        CheckInCommand = new Command(OnCheckIn);
    }

    private void OnChipIn(string amount)
    {
        if (SelectedEvent == null) return;
        SelectedEvent.CurrentFunded += double.Parse(amount);
        // Здесь можно добавить логику обновления UI (OnPropertyChanged)
    }

    private async void OnCheckIn()
    {
        // Логика завершения события
        await Application.Current.MainPage.DisplayAlert("Success", "Check-in Complete!", "OK");
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

}