﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.ShareTarget;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Param_ItemNamespace.ViewModels
{
    public class wts.ItemNameViewModel : ViewModelBase
    {
        private ShareOperation _shareOperation;

        private SharedDataViewModelBase _sharedData;

        public SharedDataViewModelBase SharedData
        {
            get => _sharedData;
            set => Set(ref _sharedData, value);
        }

        private ICommand _completeCommand;

        public ICommand CompleteCommand => _completeCommand ?? (_completeCommand = new RelayCommand(OnComplete));

        public wts.ItemNameViewModel()
        {
        }

        public async Task LoadAsync(ShareOperation shareOperation)
        {
            // TODO WTS: Configure your Share Target Declaration to allow other data formats.
            // Share Target declarations are defined in Package.appxmanifest.
            // Current declarations allow to share WebLink and image files with the app.
            // ShareTarget can be tested sharing the WebLink from Microsoft Edge or sharing images from Windows Photos.
            // ShareOperation contains all the information required to handle the action.
            _shareOperation = shareOperation;
            if (shareOperation.Data.Contains(StandardDataFormats.StorageItems))
            {
                SharedData = new SharedDataStorageItemsViewModel();
            }

            if (shareOperation.Data.Contains(StandardDataFormats.WebLink))
            {
                SharedData = new SharedDataWebLinkViewModel();
            }

            await SharedData?.LoadDataAsync(_shareOperation);
        }

        private void OnComplete()
        {
            // TODO WTS: Implement the actions you want with the shared data before compleate the share operation.
            // For further details check https://docs.microsoft.com/en-us/windows/uwp/app-to-app/receive-data
            _shareOperation.ReportCompleted();
        }
    }
}
