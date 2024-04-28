using LlamaClicker.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LlamaClicker
{
    public sealed partial class MainPage : Page
    {
        private Game game = new Game();
        private Multipliers.ExtraHand extraHand = new Multipliers.ExtraHand();
        private Multipliers.Friend friend = new Multipliers.Friend();
        private Multipliers.LlamaFarm llamaFarm = new Multipliers.LlamaFarm();
        private Multipliers.PettingZoo pettingZoo = new Multipliers.PettingZoo();
        private MediaPlayer music = new MediaPlayer();

        private Dictionary<string, StackPanel> achievementSP = new Dictionary<string, StackPanel>();

        private int timeCounter = 0;

        DispatcherTimer dispatcherTimer;

        //Maybe an upgrade will decrease this?
        private int secondsTillPay = 1;

        int timesTicked = 1;

        public MainPage()
        {
            this.InitializeComponent();

            music.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/bensound-clearday.mp3"));
            music.Volume = 0.25;
            music.Play();

            AchievementArchive.InitAchievementArchive();
            foreach (var achievment in AchievementArchive.Achievements)
            {
                StackPanel sp = new StackPanel();
                sp.Margin = new Thickness(0, 6, 0, 6);
                sp.Padding = new Thickness(10);
                sp.Background = new SolidColorBrush(Color.FromArgb(25, 75, 75, 75));

                achievementSP.Add(achievment.Title, sp);

                TextBlock name = new TextBlock();
                name.Text = achievment.Title;
                name.FontSize = 30;

                TextBlock desc = new TextBlock();
                desc.Text = achievment.Description;
                sp.Children.Add(name);
                sp.Children.Add(desc);
                achievementsPanel.Children.Add(sp);
            }

            DispatcherTimerSetup();
        }

        private void mainButton_Click(object sender, RoutedEventArgs e)
        {
            game.TotalPetCount++;
            game.CurrentPetCount++;
            PetLlama();
        }

        private void PetLlama()
        {
            pets.Text = "Pet " + game.CurrentPetCount.ToString() + " times";
            game.CheckAchievements();

            foreach (var ach in game.achieved)
            {
                achievementSP[ach.Title].Background = new SolidColorBrush(Color.FromArgb(100, 75, 75, 75));
            }
        }

        //Call this method to instantiate and start the timer.
        public void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();

            dispatcherTimer.Tick += dispatcherTimer_Tick;

            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1);

            dispatcherTimer.Start();
        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            PetLlama();
            timeCounter++;

            game.TotalPetCount += (int)extraHand.totalBonus;
            game.CurrentPetCount += (int)extraHand.totalBonus;
            extraHand.totalBonus = 0;

            game.TotalPetCount += (int)friend.totalBonus;
            game.CurrentPetCount += (int)friend.totalBonus;
            friend.totalBonus = 0;

            game.TotalPetCount += (int)llamaFarm.totalBonus;
            game.CurrentPetCount += (int)llamaFarm.totalBonus;
            llamaFarm.totalBonus = 0;

            game.TotalPetCount += (int)pettingZoo.totalBonus;
            game.CurrentPetCount += (int)pettingZoo.totalBonus;
            llamaFarm.totalBonus = 0;
        }


        private void ExtraHand_Click(object sender, RoutedEventArgs e)
        {

            if (extraHand.cost <= game.CurrentPetCount)
            {
                extraHand.level += 1;
                game.CurrentPetCount -= extraHand.cost;
                ExtraHandCost.Text = extraHand.cost.ToString();
                PetLlama();
            }

        }

        private void Friend_Click(object sender, RoutedEventArgs e)
        {
            if (friend.cost <= game.CurrentPetCount)
            {
                friend.level += 1;
                game.CurrentPetCount -= friend.cost;
                FriendCost.Text = friend.cost.ToString();
                PetLlama();
            }
        }

        private void LlamaFarm_Click(object sender, RoutedEventArgs e)
        {
            if (llamaFarm.cost <= game.CurrentPetCount)
            {
                llamaFarm.level += 1;
                game.CurrentPetCount -= llamaFarm.cost;
                LlamaFarmCost.Text = llamaFarm.cost.ToString();
                PetLlama();
            }
        }

        private void PettingZoo_Click(object sender, RoutedEventArgs e)
        {
            if (pettingZoo.cost <= game.CurrentPetCount)
            {
                pettingZoo.level += 1;
                game.CurrentPetCount -= pettingZoo.cost;
                PettingZooCost.Text = pettingZoo.cost.ToString();
                PetLlama();
            }
        }

        private async void OnLoadGame(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
            openPicker.FileTypeFilter.Add(".txt");
            StorageFile file = await openPicker.PickSingleFileAsync();
            Stream stream = await file.OpenStreamForReadAsync();
            BinaryFormatter bf = new BinaryFormatter();
            if (stream.Length != 0) game = (Game) bf.Deserialize(stream);
            stream.Close();
        }

        private async void OnSaveGame(object sender, RoutedEventArgs e)
        {
            game.multipliers.Add(extraHand);
            game.multipliers.Add(friend);
            game.multipliers.Add(llamaFarm);
            game.multipliers.Add(pettingZoo);

            FolderPicker picker = new FolderPicker();
            picker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
            picker.FileTypeFilter.Add("*");
            StorageFolder folder = await picker.PickSingleFolderAsync();
            BinaryFormatter bf = new BinaryFormatter();
            StorageFile file = await folder.CreateFileAsync("LlamaClickerSaveFile.txt",
                Windows.Storage.CreationCollisionOption.ReplaceExisting);
            Stream stream = await file.OpenStreamForWriteAsync();
            bf.Serialize(stream, game);
        }
    }
}
