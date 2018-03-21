using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Divisas.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region atributos
        private decimal dollars;

        private decimal euros;

        private decimal pounds;
        #endregion

        #region propetires
        public decimal Pesos { get; set; }

        public decimal Dollars
        {
            set
            {
                if(dollars != value)
                {
                    dollars = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Dollars"));
                }
            }
        }

        public decimal Euros
        {
            set
            {
                if(euros != value)
                {
                    euros = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Euros"));
                }
}
        }

        public decimal Pounds
        {
            set
            {
                if (pounds != value)
                {
                    pounds = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pounds"));
                }
            }
        }
        #endregion

        #region Comandos
        public ICommand ConvertCommand { get { return new RelayCommand(ConvertMoney); } }

        private async void ConvertMoney()
        {
            if (Pesos <= 0)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe ingresar un valor mayor a cero en pesos", "Aceptar");
                return;
            }

            Dollars = Pesos / 18.4706317M;
            Euros = Pesos / 22.7877724M;
            Pounds = Pesos / 26.1165497M;
        }
        #endregion

        #region events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
