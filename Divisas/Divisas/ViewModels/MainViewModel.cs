using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Divisas.ViewModels
{
    public class MainViewModel
    {
        public decimal Pesos { get; set; }

        public decimal Dollars { get; set; }

        public decimal Euros { get; set; }

        public decimal Pounds { get; set; }

        public ICommand ConvertCommand { get { return new RelayCommand(ConvertMoney); } }

        private async void ConvertMoney()
        {
            if (Pesos <= 0)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe ingresar un valor mayor a cero en pesos", "Aceptar");
                return;
            }
        }
    }
}
