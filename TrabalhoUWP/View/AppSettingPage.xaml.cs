using TrabalhoUWP.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TrabalhoUWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppSettingPage : Page
    {
        public AppSettingViewModel ViewModel { get; set; }
        public ContatoViewModel ViewModelContato { get; set; }

        public AppSettingPage()
        {
            this.InitializeComponent();
            ViewModel = new AppSettingViewModel();
            ViewModelContato = new ContatoViewModel();

            VisualStateGroupScreenWidth.CurrentStateChanged += AppSettingPage_CurrentStateChanged;
            UpdateViewModelState(VisualStateGroupScreenWidth.CurrentState);
        }

        private void UpdateViewModelState(VisualState currentState)
        {
            ViewModelContato.State = currentState == VisualStateMinWidth1 ? ContatoViewModel.PageState.MinWidth0 : ContatoViewModel.PageState.MinWidth700;

            if (ViewModelContato.State == ContatoViewModel.PageState.MinWidth700)
            {
                ViewModelContato.IsSplitViewOpen = true;
            }
        }

        private void AppSettingPage_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            UpdateViewModelState(e.NewState);
        }
    }
}
