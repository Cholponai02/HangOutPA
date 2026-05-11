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
}