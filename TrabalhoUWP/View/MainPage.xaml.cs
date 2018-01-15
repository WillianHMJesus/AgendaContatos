using TrabalhoUWP.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TrabalhoUWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ContatoViewModel ViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = new ContatoViewModel();

            VisualStateGroupScreenWidth.CurrentStateChanged += MainPage_CurrentStateChanged;
            UpdateViewModelState(VisualStateGroupScreenWidth.CurrentState);
        }

        private void UpdateViewModelState(VisualState currentState)
        {
            ViewModel.State = currentState == VisualStateMinWidth1 ? ContatoViewModel.PageState.MinWidth0 : ContatoViewModel.PageState.MinWidth700;

            if (ViewModel.State == ContatoViewModel.PageState.MinWidth700)
            {
                ViewModel.IsSplitViewOpen = true;
            }
        }

        private void MainPage_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            UpdateViewModelState(e.NewState);
        }
    }
}
