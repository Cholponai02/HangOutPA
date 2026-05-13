using System.Windows.Input;
using HangOutPA.Models;
using HangOutPA.Services;
using Microsoft.Maui.Media; // Essential for MediaPicker
using System.Collections.ObjectModel;

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
    private string _selectedAmount;
    private bool _isChippedIn = false;

    public bool IsNotChippedIn => !_isChippedIn; // Для блокировки кнопок выбора после нажатия
    public bool CanCheckIn => _isChippedIn; // Только после Chip In можно делать Check-in

    private ObservableCollection<string> _uploadedPhotos;
    public ObservableCollection<string> UploadedPhotos
    {
        get => _uploadedPhotos;
        set { _uploadedPhotos = value; OnPropertyChanged(); }
    }

    public ICommand UploadPhotoCommand { get; }
    public ICommand ChipInCommand { get; }
    public ICommand ConfirmChipInCommand { get; }
    public ICommand CheckInCommand { get; }
    public ICommand JoinCommand { get; }

    public EventDetailsViewModel()
    {
        // Команда для кнопок $0, $2, $5
        ChipInCommand = new Command<string>(amount =>
        {
            _selectedAmount = amount;
            // Можно добавить уведомление или подсветку выбранной кнопки
        });

        // Команда для большой кнопки CHIP IN!
        ConfirmChipInCommand = new Command(OnConfirmChipIn);

        // Команда Check-in
        CheckInCommand = new Command(OnCheckIn, () => CanCheckIn);
        UploadedPhotos = new ObservableCollection<string>();

        UploadPhotoCommand = new Command(OnUploadPhoto);
    }

    private void OnChipIn(string amount)
    {
        if (SelectedEvent == null) return;
        SelectedEvent.CurrentFunded += double.Parse(amount);
        // Здесь можно добавить логику обновления UI (OnPropertyChanged)
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnJoin()
    {
        if (SelectedEvent == null) return;

        // Добавляем в общий сервис
        Services.DataService.JoinEvent(SelectedEvent);

        await Application.Current.MainPage.DisplayAlert("Success",
            $"You joined {SelectedEvent.Title}! The group was created in the tab Groups.", "OK");

        // Можно автоматически переключить пользователя на вкладку Groups
        await Shell.Current.GoToAsync("//GroupsPage");
    }

    private async void OnCheckIn()
    {
        if (SelectedEvent == null) return;

        // 1. Ищем группу (она точно там есть, так как Chip In прошел успешно)
        var groupToComplete = Services.DataService.ActiveGroups
            .FirstOrDefault(g => g.Name == SelectedEvent.Title);

        if (groupToComplete != null)
        {
            // 2. Переносим в историю
            Services.DataService.CompleteEvent(groupToComplete.Id);

            // 3. Сообщение (здесь можно добавить расчет времени)
            await Application.Current.MainPage.DisplayAlert("Done!",
                "Event completed. You've earned 2 offline hours!", "Awesome");

            // 4. Уходим на страницу групп
            await Shell.Current.GoToAsync("//GroupsPage");
        }
    }

    private async void OnConfirmChipIn()
    {
        if (string.IsNullOrEmpty(_selectedAmount))
        {
            await Application.Current.MainPage.DisplayAlert("Payment", "Please select $0, $2 or $5", "OK");
            return;
        }

        // ВАЖНО: Именно здесь мы добавляем событие в список активных групп!
        Services.DataService.JoinEvent(SelectedEvent);

        _isChippedIn = true;
        SelectedEvent.CurrentFunded += double.Parse(_selectedAmount);
        OnPropertyChanged(nameof(SelectedEvent));
        OnPropertyChanged(nameof(CanCheckIn));
        OnPropertyChanged(nameof(IsNotChippedIn));
        ((Command)CheckInCommand).ChangeCanExecute();

        await Application.Current.MainPage.DisplayAlert("Success", "You're in! Now you can check-in after the event.", "OK");
    }

    private async void OnUploadPhoto()
    {
        // 1. SECURITY: Don't allow uploads unless they Chipped-in (joined the meeting)
        if (!CanCheckIn)
        {
            await Shell.Current.DisplayAlert("Members Only", "Please Chip-in ($0 is fine) to contribute photos.", "OK");
            return;
        }

        try
        {
            // 2. Ask user: Camera or Gallery?
            string action = await Shell.Current.DisplayActionSheet("Submit Offline Photo", "Cancel", null, "Take Photo", "Pick from Gallery");

            FileResult photo = null;

            if (action == "Take Photo")
            {
                if (MediaPicker.Default.IsCaptureSupported)
                {
                    photo = await MediaPicker.Default.CapturePhotoAsync();
                }
            }
            else if (action == "Pick from Gallery")
            {
                photo = await MediaPicker.Default.PickPhotoAsync();
            }

            // 3. Process the result locally (Simulated "Session" upload)
            if (photo != null)
            {
                // We grab the native path (simulating a success)
                // In a real app, you upload photo.FullPath to a server.
                // Here, we just display the local result.
                string localPath = photo.FullPath;

                // Add to the dynamic collection - UI updates instantly
                UploadedPhotos.Add(localPath);
            }
        }
        catch (PermissionException)
        {
            await Shell.Current.DisplayAlert("Permission Error", "Need permissions to access Camera/Gallery.", "OK");
        }
        catch (Exception ex)
        {
            // Handle other errors (cancelled by user, etc.)
        }
    }

}