﻿using TimeTravel.Data;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231

namespace TimeTravel
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class GroupedItemsPage : TimeTravel.Common.LayoutAwarePage
    {
        public GroupedItemsPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected async override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            //SampleDataSource sds = new SampleDataSource();
            ////var sampleDataGroups = SampleDataSource.GetGroups((String)navigationParameter);
            
            //await sds.FillGoogleImages();
            //await sds.FillData();
            //var sampleDataGroups = sds.AllGroups;
            //sds.SampleDataSourceSet = sds;
           
            //this.DefaultViewModel["Groups"] = sampleDataGroups;
            ////itemGridView.ItemsSource = sampleDataGroups;
            if (SampleDataSource.GetGroups("AllGroups") != null && SampleDataSource.GetGroups("AllGroups").Count() > 0)
                this.DefaultViewModel["Groups"] = SampleDataSource.GetGroups("AllGroups");
            else
                LoadData();
            
        }

        private async void LoadData()
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            SampleDataSource sds = new SampleDataSource();
            //var sampleDataGroups = SampleDataSource.GetGroups((String)navigationParameter);

            //await sds.FillGoogleImages();
            //await sds.FillPeopleData();
            await sds.FillFinanceData();
            //await sds.FillData();

            var sampleDataGroups = sds.AllGroups;
            sds.SampleDataSourceSet = sds;
            city.Text =TimeTravel.Common.FormData.City ;
            year.Text =TimeTravel.Common.FormData.Year;

            this.DefaultViewModel["Groups"] = sampleDataGroups;
            //itemGridView.ItemsSource = sampleDataGroups;
        }
        /// <summary>
        /// Invoked when a group header is clicked.
        /// </summary>
        /// <param name="sender">The Button used as a group header for the selected group.</param>
        /// <param name="e">Event data that describes how the click was initiated.</param>
        void Header_Click(object sender, RoutedEventArgs e)
        {
            // Determine what group the Button instance represents
            var group = (sender as FrameworkElement).DataContext;

            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            this.Frame.Navigate(typeof(GroupDetailPage), ((SampleDataGroup)group).UniqueId);
        }

        /// <summary>
        /// Invoked when an item within a group is clicked.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is snapped)
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            var itemId = ((SampleDataItem)e.ClickedItem).UniqueId;
            this.Frame.Navigate(typeof(ItemDetailPage), itemId);
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TimeTravel.Common.FormData.City = city.Text;
            TimeTravel.Common.FormData.Year = year.Text;
            LoadData();
        }
    }
}
