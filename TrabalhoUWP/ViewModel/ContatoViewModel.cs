using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoUWP.Abstract;
using TrabalhoUWP.Model;
using TrabalhoUWP.Repository;
using TrabalhoUWP.Service;
using TrabalhoUWP.View;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace TrabalhoUWP.ViewModel
{
    public class ContatoViewModel : NotifyableClass
    {
        Repository<Contato> repository = new Repository<Contato>();

        public ContatoViewModel()
        {
            ListaContatos = repository.CarregarTodos();
            ListaContatosFavoritos = ListaContatos.Where(x => x.Favorito == true).ToList();
        }

        public Contato _contato;
        public Contato Contato
        {
            get { return _contato; }
            set { Set(ref _contato, value); }
        }

        public List<Contato> _listaContatos;

        public List<Contato> ListaContatos
        {
            get { return _listaContatos; }
            set { Set(ref _listaContatos, value); }
        }

        public List<Contato> _listaContatosFavoritos;

        public List<Contato> ListaContatosFavoritos
        {
            get { return _listaContatosFavoritos; }
            set { Set(ref _listaContatosFavoritos, value); }
        }

        private ImageSource _imageSource;
        public ImageSource ImageSource
        {
            get
            {
                if (_imageSource != null)
                    return _imageSource;

                LoadImage();

                return _imageSource;
            }
            set { Set(ref _imageSource, value); }
        }

        private bool _isSplitViewOpen;

        public bool IsSplitViewOpen
        {
            get { return _isSplitViewOpen; }
            set { Set(ref _isSplitViewOpen, value); }
        }

        public PageState State { get; set; }

        public enum PageState
        {
            MinWidth0 = 0,
            MinWidth700
        }

        private async void LoadImage()
        {
            if (Contato.Picture == null || Contato.Picture.Length == 0)
                return;

            using (var ms = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(ms.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(Contato.Picture);
                    await writer.StoreAsync();
                }

                var image = new BitmapImage();
                image.DecodePixelHeight = 200;

                await image.SetSourceAsync(ms);

                ImageSource = image;
            }
        }

        public async void CameraButton_Click()
        {
            var picture = await MediaService.TakePicture();

            if (picture != null)
            {
                Contato.Picture = picture;
                LoadImage();
            }
        }

        public async void OpenPictureButton_Click()
        {
            var picture = await MediaService.OpenPicture();

            if (picture != null)
            {
                Contato.Picture = picture;
                LoadImage();
            }
        }

        public async void SalvarButton_Click()
        {
            var contato = this.Contato;
            repository.Inserir(contato);
            CaixaDialogo("Cadastro", "Cadastro realizado com sucesso");
            NavigationService.Navigate<MainPage>();
        }

        public async void AddButton_Click()
        {
            NavigationService.Navigate<Cadastro>();
        }

        public async void Remove_Click()
        {
            ContentDialogResult dialogResult = await CaixaDialogoRemove("Remove", "Tem certeza que deseja excluir o contato ?");
            if (dialogResult == ContentDialogResult.Primary)
            {
                if (_selectedDeleteContato != null)
                {
                    repository.Excluir(_selectedDeleteContato);

                    ListaContatos = repository.CarregarTodos();
                    ListaContatosFavoritos = ListaContatos.Where(x => x.Favorito == true).ToList();

                    _selectedDeleteContato = null;
                }
            }
        }

        public async void AppSettingsButton_Click()
        {
            NavigationService.Navigate<AppSettingPage>();
        }

        public async void HamburguerButton_Click()
        {
            IsSplitViewOpen = !IsSplitViewOpen;
        }

        public async void ListaContatoButton_Click()
        {
            NavigationService.Navigate<MainPage>();
        }

        public async void ListaContatoFavorito_Click()
        {
            NavigationService.Navigate<Favoritos>();
        }

        public async void NovoContatoButton_Click()
        {
            NavigationService.Navigate<Cadastro>();
        }

        public void ListaContatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = (ListView)sender;

            if (listView.SelectedItem == null)
            {
                return;
            }

            if (State == PageState.MinWidth700)
            {
                Contato = JsonConvert.DeserializeObject<Contato>(JsonConvert.SerializeObject(listView.SelectedItem));
            }
            else
            {
                NavigationService.Navigate<MainPage>(listView.SelectedItem);
            }
        }

        private Contato _selectedDeleteContato;

        public void ListaContatos_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            _selectedDeleteContato = ((FrameworkElement)e.OriginalSource).DataContext as Contato;
        }

        public async void CaixaDialogo(string titulo, string mensagem)
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = titulo,
                Content = mensagem,
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }

        public async Task<ContentDialogResult> CaixaDialogoRemove(string titulo, string mensagem)
        {
            ContentDialog deleteFileDialog = new ContentDialog
            {
                Title = titulo,
                Content = mensagem,
                PrimaryButtonText = "Sim",
                CloseButtonText = "Não"
            };

            return await deleteFileDialog.ShowAsync();
        }
    }
}
