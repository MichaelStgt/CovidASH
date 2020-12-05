// <copyright file="DashboardViewModel.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

namespace CovidASH.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Covid19Tracker.Models;
    using Covid19Tracker.Services;
    using CovidASH.Views;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="ItemsViewModel" />.
    /// </summary>
    public class DashboardViewModel : BaseViewModel
    {
        #region Fields

        /// <summary>
        /// Defines the sortOrderDictionary.
        /// </summary>
        private readonly Dictionary<string, int> sortOrderDictionary = new Dictionary<string, int>();

        /// <summary>
        /// Defines the globalData.
        /// </summary>
        private GlobalData globalData;

        /// <summary>
        /// Defines the items.
        /// </summary>
        private ObservableCollection<CountryData> items;

        /// <summary>
        /// Defines the sortImageTrigger.
        /// </summary>
        private string sortImageTrigger;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardViewModel"/> class.
        /// </summary>
        public DashboardViewModel()
        {
            this.Title = "Browse";
            this.CountryDataCollection = new ObservableCollection<CountryData>();
            this.CountrySelectedCommand = new Command<CountryData>(async (country) => await this.Navigation.PushAsync(new CountryDetailPage(new CountryDetailViewModel(country))));
            this.LoadCountriesCommand = new Command(async () => await this.LoadCountriesCommandExecute());

            this.sortOrderDictionary.Add(nameof(CountryData.CountryName), 0);
            this.sortOrderDictionary.Add(nameof(CountryData.Active), 0);
            this.sortOrderDictionary.Add(nameof(CountryData.Cases), 0);
            this.sortOrderDictionary.Add(nameof(CountryData.Deaths), 0);
            this.sortOrderDictionary.Add(nameof(CountryData.Recovered), 0);

            this.SortImageTrigger = "CountryNameDown"; // the countries list is sorted by Country Name ascending

            this.SortCommand = new Command<string>(async (s) => await this.SortCommandExecute(s).ConfigureAwait(false));
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the CountrySelectedCommand.
        /// </summary>
        public Command<CountryData> CountrySelectedCommand
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the GlobalData.
        /// </summary>
        public GlobalData GlobalData
        {
            get
            {
                return this.globalData;
            }

            set
            {
                this.SetProperty(ref this.globalData, value);
            }
        }

        /// <summary>
        /// Gets or sets the CountryDataCollection.
        /// </summary>
        public ObservableCollection<CountryData> CountryDataCollection
        {
            get
            {
                return this.items;
            }

            set
            {
                this.SetProperty(ref this.items, value);
            }
        }

        /// <summary>
        /// Gets or sets the LoadCountriesCommand.
        /// </summary>
        public Command LoadCountriesCommand
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the SortCommand.
        /// </summary>
        public Command<string> SortCommand
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the SortImageTrigger.
        /// </summary>
        public string SortImageTrigger
        {
            get
            {
                return this.sortImageTrigger;
            }

            set
            {
                this.SetProperty(ref this.sortImageTrigger, value);
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// The ExecuteLoadCountriesCommand.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1108:Block statements should not contain embedded comments", Justification = "<Pending>")]
        private async Task LoadCountriesCommandExecute()
        {
            this.IsBusy = true;

            try
            {
                this.CountryDataCollection.Clear();

                this.GlobalData = await Covid19TrackerAPI.GetGlobalDataAsync();

                List<CountryData> countryData = await Covid19TrackerAPI.GetCountriesDataAsync();

                var x = from country in countryData
                        group country by country.Continent into continentGroup
                        select continentGroup;

                // foreach (var continent in x)
                // {
                //    Debug.WriteLine(string.Format("Continent: {0}", continent.Key));

                // foreach (var country in x)
                //    {
                //        foreach (var xx in country)
                //        {
                //            Debug.WriteLine(string.Format("Country: {0}", xx.CountryName));
                //        }
                //    }
                // }

                foreach (CountryData country in countryData) // .Where(w => w.Continent.Equals("Asia")))
                {
                    Device.BeginInvokeOnMainThread(() => this.CountryDataCollection.Add(country));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        /// <summary>
        /// The ExecuteLoadCountriesCommand.
        /// </summary>
        /// <param name="property">The property<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task SortCommandExecute(string property)
        {
            this.IsBusy = true;

            try
            {
                IOrderedEnumerable<CountryData> filteredQuery;

                var propertyInfo = typeof(CountryData).GetProperty(property);

                KeyValuePair<string, int> sortCount = this.sortOrderDictionary.FirstOrDefault(so => so.Key.Equals(property));

                if (sortCount.Value % 2 == 0)
                {
                    filteredQuery = this.CountryDataCollection.OrderByDescending(od => propertyInfo.GetValue(od, null));
                    this.SortImageTrigger = property + "Up";
                }
                else
                {
                    filteredQuery = this.CountryDataCollection.OrderBy(o => propertyInfo.GetValue(o, null));
                    this.SortImageTrigger = property + "Down";
                }

                this.sortOrderDictionary.Remove(sortCount.Key);
                this.sortOrderDictionary.Add(sortCount.Key, sortCount.Value + 1);

                // Reset all other Keys in the Dictionary to Value = 0
                IEnumerable<KeyValuePair<string, int>> temp = this.sortOrderDictionary.Where(w => !w.Key.Equals(sortCount.Key)).ToList();
                foreach (var key in temp)
                {
                    this.sortOrderDictionary.Remove(key.Key);
                    this.sortOrderDictionary.Add(key.Key, 0);
                }

                await Task.Delay(100);

                this.CountryDataCollection = new ObservableCollection<CountryData>(filteredQuery);

                // this.OnPropertyChanged(nameof(this.CountryDataCollection));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                this.IsBusy = false;
            }

            // return Task.FromResult(true);
        }

        #endregion Methods
    }
}