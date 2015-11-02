using StudyApplication.viewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DemoPage : Page
    {
        InsertModule insert = null;
        private string selectedGrade = string.Empty;
        private SubjectViewModel model = null;
        public DemoPage()
        {
            this.InitializeComponent();
            model = new SubjectViewModel();
        }

        private void linkQuit_Click(object sender, RoutedEventArgs e)
        {
            comboList.Visibility = Windows.UI.Xaml.Visibility.Visible;
            lblSelectedGrade.Text = "No Grade Selected";
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            insert = new InsertModule();
            model.removeAll(); //insert.populateEnglishTables();
            model.removeAllPhysicsQuestions(); //insert.pupulatePhysicsTable();
            model.removeAllMathsQuestions(); 
            if (comboList.SelectedItem == null)
            {
                linkQuit.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                lblSelectedGrade.Text = "No Grade Selected";
            }
            
            if (model.getEnglish() == null)
            {
                insert.populateEnglishTables();
            }
            if (model.getMaths() == null)
            {
                insert.pupulateMathsTable();
                //insert.pupulateMathsTable();
            }
            if (model.getBusiness() == null)
            {
                insert.pupulateBusinessTable();
            }
            if (model.getAccounting() == null)
            {
                insert.pupulateAccountingTable();
            }
            if (model.getPhysics() == null)
            {
                insert.pupulatePhysicsTable();
            }
            comboList.Items.Add("GRADE 8");
            comboList.Items.Add("GRADE 10");
            comboList.Items.Add("GRADE 12");
            base.OnNavigatedFrom(e);
        }
        private void btnEnglish_Click(object sender, RoutedEventArgs e)
        {

            //string myGrade = item.Substring(0,item.IndexOf(':'));
            if (comboList.SelectedItem == null)
            {

                messageBox("You must select the grade first");
            }
            else
            {
                string item = comboList.SelectedItem.ToString() + ":English";
                this.Frame.Navigate(typeof(QuestionsPage), item);
            }

        }

        private void btnMaths_Click(object sender, RoutedEventArgs e)
        {
            if (comboList.SelectedItem == null)
            {

                messageBox("You must select the grade first");
            }
            else
            {
                string item = comboList.SelectedItem.ToString() + ":Maths";
                this.Frame.Navigate(typeof(QuestionsPage), item);
            }
        }

        private void comboList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string items = comboList.SelectedItem.ToString();
            selectedGrade = items;
            //messageBox("You clicked "+items);
            comboList.Items.Remove(comboList.SelectedIndex);
            comboList.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            lblSelectedGrade.Text = "Select " + selectedGrade + " Subjects Below";
            linkQuit.Visibility = Windows.UI.Xaml.Visibility.Visible;

        }
        private async void messageBox(string msg)
        {
            var dialog = new Windows.UI.Popups.MessageDialog(msg);
            await dialog.ShowAsync();
        }

        private void btnBusiness_Click(object sender, RoutedEventArgs e)
        {
            if (comboList.SelectedItem == null)
            {

                messageBox("You must select the grade first");
            }
            else
            {
                string item = comboList.SelectedItem.ToString() + ":Business";
                this.Frame.Navigate(typeof(QuestionsPage), item);
            }
        }

        private void btnAccounting_Click(object sender, RoutedEventArgs e)
        {
            if (comboList.SelectedItem == null)
            {

                messageBox("You must select the grade first");
            }
            else
            {
                string item = comboList.SelectedItem.ToString() + ":Accounting";
                this.Frame.Navigate(typeof(QuestionsPage), item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            comboList.Visibility = Windows.UI.Xaml.Visibility.Visible;
            //this.Frame.Navigate(typeof(DemoPage));
        }

        private void btnPhysicalSciences_Click(object sender, RoutedEventArgs e)
        {
            if (comboList.SelectedItem == null)
            {

                messageBox("You must select the grade first");
            }
            else
            {
                string item = comboList.SelectedItem.ToString() + ":Physics";
                this.Frame.Navigate(typeof(QuestionsPage), item);
            }
        }
    }
}
