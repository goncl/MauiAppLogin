using Microsoft.Maui.Storage;
using Microsoft.Maui.Dispatching;

namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            string? usuario_logado = null;

            // Enviando o usuário ara página de login por padrão.
            MainPage = new Login();

            Task.Run(async () =>
            {
                usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

                if (usuario_logado != null)
                {
                    MainPage = new Protegida();
                }

                /*if(usuario_logado == null)
                {
                    MainPage = new Login();

                } else
                {
                    MainPage = new Protegida();
                }*/
            });
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = 400;
            window.Height = 600;

            return window;
        }

    } // Fecha classe
} // Fecha namespace