using CommunityToolkit.Maui.Views;

namespace HangOutPA.Views.Popups;

public partial class SplitPopup : Popup
{
    private int _count;
    private double _remaining;

    // ѕередаем в конструктор остаток и количество людей
    public SplitPopup(double remainingAmount, int participantsCount)
    {
        InitializeComponent();

        _count = participantsCount > 0 ? participantsCount : 1;
        _remaining = remainingAmount;

        _count = participantsCount;
        MemberCountLabel.Text = _count.ToString();

        // јвтоматически подставл€ем остаток
        TotalBillEntry.Text = _remaining.ToString("F2");
        UpdateResult(_remaining);
    }

    private void OnAmountChanged(object sender, TextChangedEventArgs e)
    {
        if (double.TryParse(e.NewTextValue, out double amount))
        {
            UpdateResult(amount);
        }
    }

    private void UpdateResult(double total)
    {
        double share = total / _count;
        ResultLabel.Text = $"И{share:F2}";
    }

    private void OnCancelClicked(object sender, EventArgs e) => Close();

    private async void OnSendClicked(object sender, EventArgs e)
    {
        // Ёффект успеха
        await Application.Current.MainPage.DisplayAlert("Success!", "The squad has been notified. ??", "Awesome");
        Close();
    }
}