using MauiAppViewModels;
using Plugin.Maui.Audio;

namespace Week3MAUIS00310830
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        MainViewModel MainViewModel;
        public IAudioManager AudioManager { get; set; }
        public IAudioPlayer AudioPlayer { get; set; }

        public MainPage(IAudioManager audioManager)
        {
            AudioManager = audioManager;
            this.MainViewModel = new MainViewModel(audioManager);
            BindingContext = this.MainViewModel;
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            MainViewModel.PlaySoundCommand.Execute("29.wav");
            MainViewModel.ShowTheConfettiCommand.Execute(null);
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        protected override void OnAppearing()
        {
            MainThread.InvokeOnMainThreadAsync(() =>
            {
                System.IO.Stream s = Task.Run(() => FileSystem.OpenAppPackageFileAsync("puccininessundorma.mp3")).Result;
                AudioPlayer = AudioManager.CreatePlayer(s);
                AudioPlayer.Play();
            });

            base.OnAppearing();
        }
    }
}
