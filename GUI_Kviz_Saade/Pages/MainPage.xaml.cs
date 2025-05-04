using GUI_Kviz_Saade.Models;
using GUI_Kviz_Saade.PageModels;

namespace GUI_Kviz_Saade.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}