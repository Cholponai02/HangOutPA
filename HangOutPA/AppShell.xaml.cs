using HangOutPA.Views;
namespace HangOutPA
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutingPages();
        }
        private void RegisterRoutingPages()
        {
            //Routing.RegisterRoute("CalculatorPage", typeof(CalculatorPage));
        }
    }
}
