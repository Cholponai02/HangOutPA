using CommunityToolkit.Maui.Views;

namespace HangOutPA.Views.Popups;

public partial class WalletPopup : Popup
{
    public WalletPopup()
    {
        InitializeComponent();
    }

    private async void OnAddFundsClicked(object sender, EventArgs e)
    {
        // Простая проверка заполнения
        if (string.IsNullOrWhiteSpace(AmountEntry.Text))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Please enter amount", "OK");
            return;
        }

        // Здесь будет логика сохранения данных в базу или сервис

        // Показываем успех
        await Application.Current.MainPage.DisplayAlert("Success", $"€{AmountEntry.Text} added to your wallet!", "Sweet!");

        // Закрываем Popup
        Close();
    }
}