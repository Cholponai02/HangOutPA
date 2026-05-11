using CommunityToolkit.Maui.Views;
using HangOutPA.Models;

namespace HangOutPA.Views;

// Измените : ContentView на : Popup
public partial class CommentsPopup : Popup
{
    public List<Comment> EventComments { get; set; }

    public CommentsPopup(List<Comment> comments)
    {
        InitializeComponent();
        EventComments = comments;

        // Устанавливаем BindingContext самого попапа на этот же класс
        BindingContext = this;
    }
}