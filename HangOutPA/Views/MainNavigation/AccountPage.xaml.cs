using CommunityToolkit.Maui.Views;
using HangOutPA.Views.Popups; // Путь к твоему новому файлу Popup

namespace HangOutPA.Views.MainNavigation;

public partial class AccountPage : ContentPage
{
    public AccountPage()
    {
        InitializeComponent();
    }

    // Этот метод сработает при клике на карточку Wallet
    private void OnWalletTapped(object sender, EventArgs e)
    {
        // Создаем экземпляр нашего красивого оранжевого окна
        var walletPopup = new WalletPopup();

        // Показываем его поверх текущей страницы
        this.ShowPopup(walletPopup);
    }
}