﻿using TrabalhoUWP.Abstract;
using TrabalhoUWP.Service;
using Windows.UI.Xaml.Controls;

namespace TrabalhoUWP.ViewModel
{
    public class AppSettingViewModel : NotifyableClass
    {
        private int? _appThemeSetting;

        public int? AppThemeSetting
        {
            get
            {
                return StorageService.GetSetting(StorageService.Settings.AppTheme, _appThemeSetting);
            }
            set
            {
                StorageService.SaveSetting(StorageService.Settings.AppTheme, value);

                ShowAppResetMessage();
            }
        }

        private bool _dialogTriggered;

        private void ShowAppResetMessage()
        {
            if (_dialogTriggered)
            {
                return;
            }

            _dialogTriggered = true;

            var dialog = new ContentDialog
            {
                Title = "Aviso",
                Content = "Você precisa reiniciar o App para trocar o estilo.",
                PrimaryButtonText = "OK"
            };

            dialog.PrimaryButtonClick += (s, e) =>
            {
                _dialogTriggered = false;
            };

            dialog.ShowAsync();
        }
    }
}
