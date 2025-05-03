using Microsoft.Maui.Storage;
using Microsoft.Maui.Dispatching;

namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Página temporária com indicador de carregamento
            MainPage = new ContentPage
            {
                Content = new ActivityIndicator
                {
                    IsRunning = true,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                }
            };

            // Executa na thread principal
            MainThread.InvokeOnMainThreadAsync(async () =>
            {
                try
                {
                    var usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

                    if (usuario_logado == null)
                        MainPage = new Login();
                    else
                        MainPage = new Protegida();
                }
                catch (Exception ex)
                {
                    await MainPage.DisplayAlert("Erro", $"Falha ao acessar dados seguros: {ex.Message}", "Fechar");
                    MainPage = new Login();
                }
            });
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Width = 400;
            window.Height = 600;
            return window;
        }
    }
}
