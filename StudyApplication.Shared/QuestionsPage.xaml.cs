using StudyApplication.model;
using StudyApplication.viewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace StudyApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuestionsPage : Page
    {
        InsertModule module = null;
        English correct_answer = null;
        Maths maths = null;
        Business business = null;
        Accounting accounting = null;
        Geography geography = null;
        History history = null;
        Life life = null;
        Physics physics = null;

        int marks = 0;
        List<string> list = new List<string>();
        private ObservableCollection<SubjectViewModel> subjects = null;
        private SubjectViewModel subject = null;
        private SubjectsViewModel subjectModel = null;
        string[] question;
        string[] questionss, answers;
        string[] names = null;
        DispatcherTimer time = new DispatcherTimer();
        private ObservableCollection<SubjectViewModel> questions = null;
        List<SubjectViewModel> myList;
        List<SubjectViewModel> subjectsList = null;
        Random random = new Random();
        string it;
        int pressed = 0;
        int countTimer = 120, countTimer20 =240, countTimer30 = 480, countTimer50 = 800;
        string item;
        int readQuestion = 0;
        string myQuestion = null;
        string pass_question = string.Empty;
        int countButton = 1;
        string selectedItem = "";
        string table = "";
        string myGrade = "";
        int selItem = 0;
        public QuestionsPage()
        {
            this.InitializeComponent();
            subject = new SubjectViewModel();
            correct_answer = new English();
            maths = new Maths();
            business = new Business();
            accounting = new Accounting();
            geography = new Geography();
            history = new History();
            life = new Life();
            physics = new Physics();
            time.Start();

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // btnNext.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            lblPopup.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            item = e.Parameter as string;
            table = item.Substring(item.IndexOf(":") + 1);
            myGrade = item.Substring(0, item.IndexOf(":"));
            lblTable.Text = table + " Studdy Questions for " + myGrade;
            combo.Items.Add("10");
            combo.Items.Add("20");
            combo.Items.Add("30");
            combo.Items.Add("50");
            radAnswer1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            //lblWait.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            radAnswer2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            myProgressBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            radAnswer3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            lblTop.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            lblTop2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            lblDisplayMark.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            // btnFinish.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            //btnStartAgain.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            //btnStartAgain.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            // lblTotalMarks.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            btnFinish.IsEnabled = false;
            btnStartAgain.IsEnabled = false;
            btnNext.IsEnabled = false;
        }



        private async void messageBox(string msg)
        {
            var dialog = new Windows.UI.Popups.MessageDialog(msg);
            await dialog.ShowAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                subject.updateEnglishToNotRead();
                this.Frame.Navigate(typeof(DemoPage));
            }
            catch
            {

            }
        }
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var dialog = new MessageDialog("Select option");
            dialog.Commands.Add(new UICommand("Write Test Again", new UICommandInvokedHandler(testCommandhandler)));
            dialog.Commands.Add(new UICommand("Previous Quetions", new UICommandInvokedHandler(testCommandhandler)));
            await dialog.ShowAsync();
        }
        private void testCommandhandler(IUICommand cmd)
        {
            var lable = cmd.Label;
            switch (lable)
            {
                case "Write Test Again":
                    this.Frame.Navigate(typeof(DemoPage));
                    break;
                case "Previous Quetions":
                    break;
            }
        }
        private void startAgainCommandhandler(IUICommand cmd)
        {
            var lable = cmd.Label;
            switch (lable)
            {
                case "Yes":
                    //myProgressBar.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    lblWait.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    lblWait.Text = "Please wait";
                    //myProgressBar.Minimum = 50;
                    if (table.Equals("Accounting"))
                    {
                        //subject.removeAllAccountingQuestions(); module.pupulateAccountingTable();
                    }
                    else if (table.Equals("Business"))
                    {
                        //subject.removeAllBusinessQuestions(); module.pupulateBusinessTable();
                    }
                    else if (table.Equals("English"))
                    {
                        subject.removeAll(); module.populateEnglishTables();
                    }
                    else if (table.Equals("Geography"))
                    {
                        //subject.removeAllGeographyQuestions(); module.pupulateGeographyTable();
                    }
                    else if (table.Equals("History"))
                    {
                        subject.removeAllHistoryQuestions(); module.pupulateHistoryTable();
                    }
                    else if (table.Equals("Life"))
                    {
                        subject.removeAllLifeQuestions(); module.pupulateLifeOrientationTable();
                    }
                    else if (table.Equals("Maths"))
                    {
                        subject.removeAllMathsQuestions(); module.pupulateMathsTable();
                    }
                    else if (table.Equals("Physics"))
                    {
                        subject.removeAllPhysicsQuestions(); module.pupulatePhysicsTable();
                    }
                    this.Frame.Navigate(typeof(QuestionsPage), item);
                    break;
                case "No":
                    break;
            }
        }
        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Start Again");
            dialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(startAgainCommandhandler)));
            dialog.Commands.Add(new UICommand("No", new UICommandInvokedHandler(startAgainCommandhandler)));
            await dialog.ShowAsync();

        }
        private void radAnswer1_Checked(object sender, RoutedEventArgs e)
        {
            radAnswer2.IsEnabled = false;
            radAnswer3.IsEnabled = false;
            if (radAnswer1.IsChecked == true)
            {
                if (table.Equals("English"))
                {
                    subject.remove(pass_question);
                    if (radAnswer1.Content.Equals(correct_answer.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("Maths"))
                {
                    subject.removeMaths(pass_question);
                    if (radAnswer1.Content.Equals(maths.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("Accounting"))
                {
                    subject.removeAccounting(pass_question);
                    if (radAnswer1.Content.Equals(accounting.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("Business"))
                {
                    subject.removeBusiness(pass_question);
                    if (radAnswer1.Content.Equals(business.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("Geography"))
                {
                    subject.removeGeography(pass_question);
                    if (radAnswer1.Content.Equals(geography.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("History"))
                {
                    subject.removeHistory(pass_question);
                    if (radAnswer1.Content.Equals(history.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("Life"))
                {
                    subject.removeGeography(pass_question);
                    if (radAnswer1.Content.Equals(life.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("Physics"))
                {
                    subject.removePhysics(pass_question);
                    if (radAnswer1.Content.Equals(physics.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
            }
            lblMarks.Text = "Mark: " + marks + "";
        }
        private void time_tick(object sender, object e)
        {
            countTimer--;
            lblTimer.Text = "Remaining Seconds " + countTimer.ToString();
            if (countTimer == 0)
            {
                time.Stop();
            }
        }
        private void time_tick20(object sender, object e)
        {
            countTimer20--;
            lblTimer.Text = "Remaining Seconds " + countTimer20.ToString();
            if (countTimer20 == 0)
            {
                time.Stop();
            }
        }
        private void time_tick30(object sender, object e)
        {
            countTimer30--;
            lblTimer.Text = "Remaining Seconds " + countTimer30.ToString();
            if (countTimer30 == 0)
            {
                time.Stop();
            }
        }
        private void time_tick50(object sender, object e)
        {
            countTimer50--;
            lblTimer.Text = "Remaining Seconds " + countTimer50.ToString();
            if (countTimer50 == 0)
            {
                time.Stop();
            }
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            lblPopup.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            lblNumberOfQuestions.Text = selItem + " questions will be generated randomly";
            btnFinish.IsEnabled = true;
            btnStartAgain.IsEnabled = true;
            //lblTotalMarks.Visibility = Windows.UI.Xaml.Visibility.Visible;
            if (countTimer < 5 || countTimer < 15 || countTimer20 < 61 || countTimer30 < 75 || countTimer50 < 120)
            {
                lblTimeRunning.Text = "Dear learner, you are running out of time";
            }
            btnStartAgain.Visibility = Windows.UI.Xaml.Visibility.Visible;
            if (countTimer == 0)
            {
                messageBox("You have ran out of time ,your total mark = " + marks + "/" + 10);
                lblTimeElapsed.Text = "You have ran out of time ,your total mark = " + marks + "/" + 10;
                radAnswer1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                radAnswer2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                radAnswer3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                lblTop.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                lblTop2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                lblQuestion.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                btnStartAgain.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else if (countTimer20 == 0)
            {
                messageBox("You have ran out of time ,your total mark = " + marks + "/" + 20);
                lblTimeElapsed.Text = "You have ran out of time ,your total mark = " + marks + "/" + 20;
                radAnswer1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                radAnswer2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                radAnswer3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                lblTop.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                lblTop2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                lblQuestion.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                btnFinish.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else if (countTimer30 == 0)
            {
                messageBox("You have ran out of time ,your total mark = " + marks + "/" + 30);
                lblTimeElapsed.Text = "You have ran out of time ,your total mark = " + marks + "/" + 30;
                radAnswer1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                radAnswer2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                radAnswer3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                lblTop.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                lblTop2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                lblQuestion.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                btnFinish.Visibility = Windows.UI.Xaml.Visibility.Visible;
                btnNext.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            else if (countTimer50 == 0)
            {
                messageBox("You have ran out of time ,your total mark = " + marks + "/" + 50);
                lblTimeElapsed.Text = "You have ran out of time ,your total mark = " + marks + "/" + 50;
                radAnswer1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                radAnswer2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                radAnswer3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                lblTop.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                lblTop2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                lblQuestion.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                btnFinish.Visibility = Windows.UI.Xaml.Visibility.Visible;
                btnNext.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            radAnswer1.Visibility = Windows.UI.Xaml.Visibility.Visible;
            radAnswer2.Visibility = Windows.UI.Xaml.Visibility.Visible;
            radAnswer3.Visibility = Windows.UI.Xaml.Visibility.Visible;
            lblDisplayMark.Visibility = Windows.UI.Xaml.Visibility.Visible;
            lblTop.Visibility = Windows.UI.Xaml.Visibility.Visible;
            lblTop2.Visibility = Windows.UI.Xaml.Visibility.Visible;
            btnFinish.Visibility = Windows.UI.Xaml.Visibility.Visible;
            btnNext.Visibility = Windows.UI.Xaml.Visibility.Visible;

            module = new InsertModule();
            int number = 0;
            myList = new List<SubjectViewModel>();
            subjects = new ObservableCollection<SubjectViewModel>();
            subjectsList = new List<SubjectViewModel>();

            subjectModel = new SubjectsViewModel();

            string grade = item.Substring(0, item.IndexOf(":"));
            table = item.Substring(item.IndexOf(":") + 1);

            btnNext.Content = "Question " + countButton + ".";
            try
            {
                if (table.Equals("English"))
                {

                    subjects = subjectModel.getEnglishQuestions1(grade);
                    subjectsList = subjectModel.getEnglishQuestion(grade);
                    myList = subjectModel.getEnglishQuestion(grade);
                    int totalItems = subjects.Count();
                    int count = 0;
                    names = new string[subjects.Count()];
                    foreach (var i in subjects)
                    {
                        names[count] = i.QUESTION + "#" + i.ANSWER + "#" + i.ANSWER1 + "#" + i.ANSWER2;
                        count++;
                    }
                    combo.SelectedIndex.ToString();
                    string answer1 = string.Empty, answer2 = string.Empty, answer3 = string.Empty;
                    if (readQuestion.Equals(number)) { }
                    number = random.Next(0, totalItems);
                    readQuestion = number;

                    it = names[number];

                    names = it.Split('#');
                    answer1 = names[1];
                    answer2 = names[2];
                    answer3 = names[3];
                    pass_question = it.Substring(0, it.IndexOf("#"));

                    myQuestion = pass_question;
                    lblQuestion.Text = countButton + "." + it.Substring(0, it.IndexOf("#"));
                    correct_answer = subject.getEnglishCorrectAnswer(pass_question);

                    if (subject.verifyExist(pass_question, answer1))
                    {
                        string[] answers_array = { answer1, answer2, answer3 };
                        Random ran = new Random();
                        int num = 0;
                        num = ran.Next(0, 2);
                        int num1 = ran.Next(0, 2);
                        int num2 = ran.Next(0, 2);
                        if (num == num1)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[1];
                            radAnswer3.Content = answers_array[0];

                        }
                        else if (num == num2)
                        {
                            radAnswer1.Content = answers_array[0];
                            radAnswer2.Content = answers_array[1];
                            radAnswer3.Content = answers_array[2];
                        }
                        else if (num1 == num2)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[0];
                            radAnswer3.Content = answers_array[1];
                        }
                        else if (num == num1 && num == num2)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[0];
                            radAnswer3.Content = answers_array[1];
                        }
                        else
                        {
                            radAnswer1.Content = answers_array[num];
                            radAnswer2.Content = answers_array[num1];
                            radAnswer3.Content = answers_array[num2];
                        }
                    }
                }
                else if (table.Equals("Maths"))
                {
                    subjects = subjectModel.getMathsQuestions1(grade);
                    int totalItems = subjects.Count();
                    int count = 0;
                    names = new string[subjects.Count()];
                    foreach (var i in subjects)
                    {
                        names[count] = i.QUESTION + "#" + i.ANSWER + "#" + i.ANSWER1 + "#" + i.ANSWER2;
                        count++;
                    }
                    combo.SelectedIndex.ToString();
                    string answer1 = string.Empty, answer2 = string.Empty, answer3 = string.Empty;
                    if (readQuestion.Equals(number)) { }
                    number = random.Next(0, totalItems);
                    readQuestion = number;
                    it = names[number];
                    names = it.Split('#');
                    answer1 = names[1];
                    answer2 = names[2];
                    answer3 = names[3];
                    pass_question = it.Substring(0, it.IndexOf("#"));
                    myQuestion = pass_question;
                    lblQuestion.Text = countButton + "." + it.Substring(0, it.IndexOf("#"));
                    maths = subject.getMathsCorrectAnswer(pass_question);
                    if (subject.verifyMathsExist(pass_question, answer1))
                    {
                        string[] answers_array = { answer1, answer2, answer3 };
                        Random ran = new Random();
                        int num = 0;
                        num = ran.Next(0, 2);
                        int num1 = ran.Next(0, 2);
                        int num2 = ran.Next(0, 2);
                        if (num == num1)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[1];
                            radAnswer3.Content = answers_array[0];
                        }
                        else if (num == num2)
                        {
                            radAnswer1.Content = answers_array[0];
                            radAnswer2.Content = answers_array[1];
                            radAnswer3.Content = answers_array[2];
                        }
                        else if (num1 == num2)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[0];
                            radAnswer3.Content = answers_array[1];
                        }
                        else if (num == num1 && num == num2)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[0];
                            radAnswer3.Content = answers_array[1];
                        }
                        else
                        {
                            radAnswer1.Content = answers_array[num];
                            radAnswer2.Content = answers_array[num1];
                            radAnswer3.Content = answers_array[num2];
                        }
                    }

                }
                else if (table.Equals("Business"))
                {
                    subjects = subjectModel.getBusinessQuestions1(grade);
                    int totalItems = subjects.Count();
                    int count = 0;
                    names = new string[subjects.Count()];
                    foreach (var i in subjects)
                    {
                        names[count] = i.QUESTION + "#" + i.ANSWER + "#" + i.ANSWER1 + "#" + i.ANSWER2;
                        count++;
                    }
                    combo.SelectedIndex.ToString();
                    string answer1 = string.Empty, answer2 = string.Empty, answer3 = string.Empty;
                    if (readQuestion.Equals(number)) { }
                    number = random.Next(0, totalItems);
                    readQuestion = number;
                    it = names[number];
                    names = it.Split('#');
                    answer1 = names[1];
                    answer2 = names[2];
                    answer3 = names[3];
                    pass_question = it.Substring(0, it.IndexOf("#"));
                    myQuestion = pass_question;
                    lblQuestion.Text = countButton + "." + it.Substring(0, it.IndexOf("#"));
                    business = subject.getBusinessCorrectAnswer(pass_question);
                    if (subject.verifyBusinessExist(pass_question, answer1))
                    {
                        string[] answers_array = { answer1, answer2, answer3 };
                        Random ran = new Random();
                        int num = 0;
                        num = ran.Next(0, 2);
                        int num1 = ran.Next(0, 2);
                        int num2 = ran.Next(0, 2);
                        if (num == num1)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[1];
                            radAnswer3.Content = answers_array[0];
                        }
                        else if (num == num2)
                        {
                            radAnswer1.Content = answers_array[0];
                            radAnswer2.Content = answers_array[1];
                            radAnswer3.Content = answers_array[2];
                        }
                        else if (num1 == num2)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[0];
                            radAnswer3.Content = answers_array[1];
                        }
                        else if (num == num1 && num == num2)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[0];
                            radAnswer3.Content = answers_array[1];
                        }
                        else
                        {
                            radAnswer1.Content = answers_array[num];
                            radAnswer2.Content = answers_array[num1];
                            radAnswer3.Content = answers_array[num2];
                        }
                    }

                }
                else if (table.Equals("Accounting"))
                {
                    subjects = subjectModel.getAccountingQuestions1(grade);
                    int totalItems = subjects.Count();
                    int count = 0;
                    names = new string[subjects.Count()];
                    foreach (var i in subjects)
                    {
                        names[count] = i.QUESTION + "#" + i.ANSWER + "#" + i.ANSWER1 + "#" + i.ANSWER2;
                        count++;
                    }
                    combo.SelectedIndex.ToString();
                    string answer1 = string.Empty, answer2 = string.Empty, answer3 = string.Empty;
                    if (readQuestion.Equals(number)) { }
                    number = random.Next(0, totalItems);
                    readQuestion = number;
                    it = names[number];
                    names = it.Split('#');
                    answer1 = names[1];
                    answer2 = names[2];
                    answer3 = names[3];
                    pass_question = it.Substring(0, it.IndexOf("#"));
                    myQuestion = pass_question;
                    lblQuestion.Text = countButton + "." + it.Substring(0, it.IndexOf("#"));
                    accounting = subject.getAccountingCorrectAnswer(pass_question);
                    if (subject.verifyAccountingExist(pass_question, answer1))
                    {
                        string[] answers_array = { answer1, answer2, answer3 };
                        Random ran = new Random();
                        int num = 0;
                        num = ran.Next(0, 2);
                        int num1 = ran.Next(0, 2);
                        int num2 = ran.Next(0, 2);
                        if (num == num1)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[1];
                            radAnswer3.Content = answers_array[0];
                        }
                        else if (num == num2)
                        {
                            radAnswer1.Content = answers_array[0];
                            radAnswer2.Content = answers_array[1];
                            radAnswer3.Content = answers_array[2];
                        }
                        else if (num1 == num2)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[0];
                            radAnswer3.Content = answers_array[1];
                        }
                        else if (num == num1 && num == num2)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[0];
                            radAnswer3.Content = answers_array[1];
                        }
                        else
                        {
                            radAnswer1.Content = answers_array[num];
                            radAnswer2.Content = answers_array[num1];
                            radAnswer3.Content = answers_array[num2];
                        }
                    }

                }
                else if (table.Equals("Geography"))
                {
                    subjects = subjectModel.getGeographyQuestions1(grade);
                    int totalItems = subjects.Count();
                    int count = 0;
                    names = new string[subjects.Count()];
                    foreach (var i in subjects)
                    {
                        names[count] = i.QUESTION + "#" + i.ANSWER + "#" + i.ANSWER1 + "#" + i.ANSWER2;
                        count++;
                    }
                    combo.SelectedIndex.ToString();
                    string answer1 = string.Empty, answer2 = string.Empty, answer3 = string.Empty;
                    if (readQuestion.Equals(number)) { }
                    number = random.Next(0, totalItems);
                    readQuestion = number;
                    it = names[number];
                    names = it.Split('#');
                    answer1 = names[1];
                    answer2 = names[2];
                    answer3 = names[3];
                    pass_question = it.Substring(0, it.IndexOf("#"));
                    myQuestion = pass_question;
                    lblQuestion.Text = countButton + "." + it.Substring(0, it.IndexOf("#"));
                    geography = subject.getGeographyCorrectAnswer(pass_question);
                    if (subject.verifyGeographyExist(pass_question, answer1))
                    {
                        string[] answers_array = { answer1, answer2, answer3 };
                        Random ran = new Random();
                        int num = 0;
                        num = ran.Next(0, 2);
                        int num1 = ran.Next(0, 2);
                        int num2 = ran.Next(0, 2);
                        if (num == num1)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[1];
                            radAnswer3.Content = answers_array[0];
                        }
                        else if (num == num2)
                        {
                            radAnswer1.Content = answers_array[0];
                            radAnswer2.Content = answers_array[1];
                            radAnswer3.Content = answers_array[2];
                        }
                        else if (num1 == num2)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[0];
                            radAnswer3.Content = answers_array[1];
                        }
                        else if (num == num1 && num == num2)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[0];
                            radAnswer3.Content = answers_array[1];
                        }
                        else
                        {
                            radAnswer1.Content = answers_array[num];
                            radAnswer2.Content = answers_array[num1];
                            radAnswer3.Content = answers_array[num2];
                        }
                    }

                }
                else if (table.Equals("History"))
                {
                    subjects = subjectModel.getHistoryQuestions1(grade);
                    int totalItems = subjects.Count();
                    int count = 0;
                    names = new string[subjects.Count()];
                    foreach (var i in subjects)
                    {
                        names[count] = i.QUESTION + "#" + i.ANSWER + "#" + i.ANSWER1 + "#" + i.ANSWER2;
                        count++;
                    }
                    combo.SelectedIndex.ToString();
                    string answer1 = string.Empty, answer2 = string.Empty, answer3 = string.Empty;
                    if (readQuestion.Equals(number)) { }
                    number = random.Next(0, totalItems);
                    readQuestion = number;
                    it = names[number];
                    names = it.Split('#');
                    answer1 = names[1];
                    answer2 = names[2];
                    answer3 = names[3];
                    pass_question = it.Substring(0, it.IndexOf("#"));
                    myQuestion = pass_question;
                    lblQuestion.Text = countButton + "." + it.Substring(0, it.IndexOf("#"));
                    history = subject.getHistoryCorrectAnswer(pass_question);
                    if (subject.verifyHistoryExist(pass_question, answer1))
                    {
                        string[] answers_array = { answer1, answer2, answer3 };
                        Random ran = new Random();
                        int num = 0;
                        num = ran.Next(0, 2);
                        int num1 = ran.Next(0, 2);
                        int num2 = ran.Next(0, 2);
                        if (num == num1)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[1];
                            radAnswer3.Content = answers_array[0];
                        }
                        else if (num == num2)
                        {
                            radAnswer1.Content = answers_array[0];
                            radAnswer2.Content = answers_array[1];
                            radAnswer3.Content = answers_array[2];
                        }
                        else if (num1 == num2)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[0];
                            radAnswer3.Content = answers_array[1];
                        }
                        else if (num == num1 && num == num2)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[0];
                            radAnswer3.Content = answers_array[1];
                        }
                        else
                        {
                            radAnswer1.Content = answers_array[num];
                            radAnswer2.Content = answers_array[num1];
                            radAnswer3.Content = answers_array[num2];
                        }
                    }

                }
                else if (table.Equals("Life"))
                {
                    subjects = subjectModel.getLifeOrientationQuestions1(grade);
                    int totalItems = subjects.Count();
                    int count = 0;
                    names = new string[subjects.Count()];
                    foreach (var i in subjects)
                    {
                        names[count] = i.QUESTION + "#" + i.ANSWER + "#" + i.ANSWER1 + "#" + i.ANSWER2;
                        count++;
                    }
                    combo.SelectedIndex.ToString();
                    string answer1 = string.Empty, answer2 = string.Empty, answer3 = string.Empty;
                    if (readQuestion.Equals(number)) { }
                    number = random.Next(0, totalItems);
                    readQuestion = number;
                    it = names[number];
                    names = it.Split('#');
                    answer1 = names[1];
                    answer2 = names[2];
                    answer3 = names[3];
                    pass_question = it.Substring(0, it.IndexOf("#"));
                    myQuestion = pass_question;
                    lblQuestion.Text = countButton + "." + it.Substring(0, it.IndexOf("#"));
                    life = subject.getLifeCorrectAnswer(pass_question);
                    if (subject.verifyLifeOriontationExist(pass_question, answer1))
                    {
                        string[] answers_array = { answer1, answer2, answer3 };
                        Random ran = new Random();
                        int num = 0;
                        num = ran.Next(0, 2);
                        int num1 = ran.Next(0, 2);
                        int num2 = ran.Next(0, 2);
                        if (num == num1)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[1];
                            radAnswer3.Content = answers_array[0];
                        }
                        else if (num == num2)
                        {
                            radAnswer1.Content = answers_array[0];
                            radAnswer2.Content = answers_array[1];
                            radAnswer3.Content = answers_array[2];
                        }
                        else if (num1 == num2)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[0];
                            radAnswer3.Content = answers_array[1];
                        }
                        else if (num == num1 && num == num2)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[0];
                            radAnswer3.Content = answers_array[1];
                        }
                        else
                        {
                            radAnswer1.Content = answers_array[num];
                            radAnswer2.Content = answers_array[num1];
                            radAnswer3.Content = answers_array[num2];
                        }
                    }

                }
                else if (table.Equals("Physics"))
                {
                    subjects = subjectModel.getPhysicsQuestions1(grade);
                    int totalItems = subjects.Count();
                    int count = 0;
                    names = new string[subjects.Count()];
                    foreach (var i in subjects)
                    {
                        names[count] = i.QUESTION + "#" + i.ANSWER + "#" + i.ANSWER1 + "#" + i.ANSWER2;
                        count++;
                    }
                    combo.SelectedIndex.ToString();
                    string answer1 = string.Empty, answer2 = string.Empty, answer3 = string.Empty;
                    if (readQuestion.Equals(number)) { }
                    number = random.Next(0, totalItems);
                    readQuestion = number;
                    it = names[number];
                    names = it.Split('#');
                    answer1 = names[1];
                    answer2 = names[2];
                    answer3 = names[3];
                    pass_question = it.Substring(0, it.IndexOf("#"));
                    myQuestion = pass_question;
                    lblQuestion.Text = countButton + ".  " + it.Substring(0, it.IndexOf("#"));
                    physics = subject.getPhysicsCorrectAnswer(pass_question);
                    if (subject.verifyPhysicsExist(pass_question, answer1))
                    {
                        string[] answers_array = { answer1, answer2, answer3 };
                        Random ran = new Random();
                        int num = 0;
                        num = ran.Next(0, 2);
                        int num1 = ran.Next(0, 2);
                        int num2 = ran.Next(0, 2);
                        if (num == num1)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[1];
                            radAnswer3.Content = answers_array[0];
                        }
                        else if (num == num2)
                        {
                            radAnswer1.Content = answers_array[0];
                            radAnswer2.Content = answers_array[1];
                            radAnswer3.Content = answers_array[2];
                        }
                        else if (num1 == num2)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[0];
                            radAnswer3.Content = answers_array[1];
                        }
                        else if (num == num1 && num == num2)
                        {
                            radAnswer1.Content = answers_array[2];
                            radAnswer2.Content = answers_array[0];
                            radAnswer3.Content = answers_array[1];
                        }
                        else
                        {
                            radAnswer1.Content = answers_array[num];
                            radAnswer2.Content = answers_array[num1];
                            radAnswer3.Content = answers_array[num2];
                        }
                    }

                }
            }
            catch
            {

            }

            radAnswer1.IsChecked = false;
            radAnswer2.IsChecked = false;
            radAnswer3.IsChecked = false;

            radAnswer1.IsEnabled = true;
            radAnswer2.IsEnabled = true;
            radAnswer3.IsEnabled = true;
            // time.Interval = new TimeSpan(0, 0, 0, 1);
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (combo.SelectedItem != null)
            {
                selItem = int.Parse(combo.SelectedItem.ToString());
                //messageBox("Selected is " + selItem);
                if (countButton > selItem)
                {
                    btnNext.Content = "Finish";
                    if (marks > 0)
                    {
                        if (selItem == 10)
                        {

                            marks = (marks / 10) * 100;
                        }
                        if (selItem == 20)
                        {
                            marks = (marks / 20) * 100;
                        }
                        if (selItem == 30)
                        {
                            marks = (marks / 30) * 100;
                        }
                        if (selItem == 50)
                        {
                            marks = (marks / 50) * 100;
                        }
                    }
                    time.Stop();
                    ////////////////////////////////////////////////////////////////////////////////////////

                    string message = "";
                    if (marks < 50)
                    {
                        // message = "Sorry You failed the test";
                        lblTotalMarks.Text = "Complete!!!";
                        //lblTotalMarks.Text = message;
                    }
                    else if (marks >= 50 && marks < 75)
                    {
                        message = "You passed the test with an avarage score";
                        lblTotalMarks.Text = "Complete!!!";
                    }
                    else if (marks >= 75)
                    {
                        message = "Passed with Distinction";
                        lblTotalMarks.Text = "Complete!!!";

                    }
                    lblNumberOfQuestions.Visibility = Windows.UI.Xaml.Visibility.Collapsed;//lblTotalMarks.Text = message;
                    //messageBox("Complete!!! :Total marks " + marks + "% " + message);
                    //lblTotalMarks.Text = "Complete!!! :Total marks " + marks + "% " + message;
                    if (table.Equals("Accounting"))
                    {
                        subject.removeAllAccountingQuestions(); module.pupulateAccountingTable();
                    }
                    else if (table.Equals("Business"))
                    {
                        subject.removeAllBusinessQuestions(); module.pupulateBusinessTable();
                    }
                    else if (table.Equals("English"))
                    {
                        subject.removeAll(); module.populateEnglishTables();
                    }
                    else if (table.Equals("Geography"))
                    {
                        subject.removeAllGeographyQuestions(); module.pupulateGeographyTable();
                    }
                    else if (table.Equals("History"))
                    {
                        subject.removeAllHistoryQuestions(); module.pupulateHistoryTable();
                    }
                    else if (table.Equals("Life"))
                    {
                        subject.removeAllLifeQuestions(); module.pupulateLifeOrientationTable();
                    }
                    else if (table.Equals("Maths"))
                    {
                        subject.removeAllMathsQuestions(); module.pupulateMathsTable();
                    }
                    else if (table.Equals("Physics"))
                    {
                        subject.removeAllPhysicsQuestions(); module.pupulatePhysicsTable();
                    }
                    btnNext.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    lblQuestion.Text = "";
                    btnFinish.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    radAnswer1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    radAnswer2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    radAnswer3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }

            }
            else
            {
                lblNumberOfQuestions.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                if (countButton > 10)
                {
                    time.Stop();
                    btnNext.Content = "Finish";
                    if (marks > 0)
                    {
                        if (selItem == 10)
                        {
                            marks = (marks / 10) * 100;

                        }
                    }
                    string message = "";
                    if (marks < 50)
                    {
                        message = "Sorry You failed the test";
                        lblTotalMarks.Text = "Complete!!!";

                    }
                    else if (marks >= 50 && marks < 75)
                    {
                        message = "You passed the test with an avarage mark";
                        lblTotalMarks.Text = "Complete!!!";
                    }
                    else if (marks >= 75)
                    {
                        message = "Passed with Distinction";
                        lblTotalMarks.Text = "Complete!!!";
                    }
                    double store = marks = (marks / 10) * 100;
                    //messageBox("Complete!!! :Total marks " + store + "% ");
                    //lblTotalMarks.Text = "Complete!!! :Total marks " + store + "% "+message;
                    lblNumberOfQuestions.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    btnNext.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    lblQuestion.Text = "";
                    btnFinish.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    radAnswer1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    radAnswer2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    radAnswer3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    if (table.Equals("Accounting"))
                    {
                        subject.removeAllAccountingQuestions(); module.pupulateAccountingTable();
                    }
                    else if (table.Equals("Business"))
                    {
                        subject.removeAllBusinessQuestions(); module.pupulateBusinessTable();
                    }
                    else if (table.Equals("English"))
                    {
                        subject.removeAll(); module.populateEnglishTables();
                    }
                    else if (table.Equals("Geography"))
                    {
                        subject.removeAllGeographyQuestions(); module.pupulateGeographyTable();
                    }
                    else if (table.Equals("History"))
                    {
                        subject.removeAllHistoryQuestions(); module.pupulateHistoryTable();
                    }
                    else if (table.Equals("Life"))
                    {
                        subject.removeAllLifeQuestions(); module.pupulateLifeOrientationTable();
                    }
                    else if (table.Equals("Maths"))
                    {
                        subject.removeAllMathsQuestions(); module.pupulateMathsTable();
                    }
                    else if (table.Equals("Physics"))
                    {
                        subject.removeAllPhysicsQuestions(); module.pupulatePhysicsTable();
                    }
                }
            }
            /*if (!(radAnswer1.IsChecked == true) || !(radAnswer2.IsChecked == true) || !(radAnswer3.IsChecked == true))
            {
                messageBox("You have to select at least one of the answers");
            }*/
            if (countTimer == 0 || countTimer20 == 0 || countTimer30 == 0 || countTimer50 == 0)
            {
                lblQuestion.Text = "";
                lblTop.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                lblTop2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                radAnswer1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                radAnswer2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                radAnswer3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                lblTimeRunning.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                btnNext.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                time.Stop();
            }
            countButton++;
            subject.remove(pass_question);
            subject.removeMaths(pass_question);
            subject.removeBusiness(pass_question);
            subject.removeAccounting(pass_question);
            subject.removeGeography(pass_question);
            subject.removeHistory(pass_question);
            subject.removeLifeOrientation(pass_question);
            subject.removePhysics(pass_question);
            lblWrong.Text = "";



        }

        private void radAnswer2_Checked(object sender, RoutedEventArgs e)
        {
            radAnswer1.IsEnabled = false;
            radAnswer3.IsEnabled = false;
            if (radAnswer2.IsChecked == true)
            {
                if (table.Equals("English"))
                {
                    subject.remove(pass_question);
                    if (radAnswer2.Content.Equals(correct_answer.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("Maths"))
                {
                    subject.removeMaths(pass_question);
                    if (radAnswer2.Content.Equals(maths.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("Accounting"))
                {
                    subject.removeAccounting(pass_question);
                    if (radAnswer2.Content.Equals(accounting.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("Business"))
                {
                    subject.removeBusiness(pass_question);
                    if (radAnswer2.Content.Equals(business.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("Geography"))
                {
                    subject.removeGeography(pass_question);
                    if (radAnswer2.Content.Equals(geography.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("History"))
                {
                    subject.removeHistory(pass_question);
                    if (radAnswer2.Content.Equals(history.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("Life"))
                {
                    subject.removeLifeOrientation(pass_question);
                    if (radAnswer2.Content.Equals(life.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("Physics"))
                {
                    subject.removePhysics(pass_question);
                    if (radAnswer2.Content.Equals(physics.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }

            }
            lblMarks.Text = "Mark: " + marks + "";
        }

        private void radAnswer3_Checked(object sender, RoutedEventArgs e)
        {
            radAnswer2.IsEnabled = false;
            radAnswer1.IsEnabled = false;
            if (radAnswer3.IsChecked == true)
            {
                if (table.Equals("English"))
                {
                    subject.remove(pass_question);
                    if (radAnswer3.Content.Equals(correct_answer.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("Maths"))
                {
                    subject.removeMaths(pass_question);
                    if (radAnswer3.Content.Equals(maths.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }

                }
                else if (table.Equals("Accounting"))
                {
                    subject.removeAccounting(pass_question);
                    if (radAnswer3.Content.Equals(accounting.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("Business"))
                {
                    subject.removeBusiness(pass_question);
                    if (radAnswer3.Content.Equals(business.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("Geography"))
                {
                    subject.removeGeography(pass_question);
                    if (radAnswer3.Content.Equals(geography.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("History"))
                {
                    subject.removeHistory(pass_question);
                    if (radAnswer3.Content.Equals(history.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("Life"))
                {
                    subject.removeGeography(pass_question);
                    if (radAnswer3.Content.Equals(life.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }
                else if (table.Equals("Physics"))
                {
                    subject.removePhysics(pass_question);
                    if (radAnswer3.Content.Equals(physics.answer))
                    {
                        marks = marks + 1;
                        lblWrong.Text = "";
                    }
                    else
                    {
                        lblWrong.Text = "Wrong Answer";
                    }
                }

                lblMarks.Text = "Mark: " + marks + "";
            }
        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblNumberOfQuestions.Text = "Tap on start link to start test of " + combo.SelectedItem.ToString() + " questions";
            combo.IsEnabled = false;
            lblnumber.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            lblDisplayNumberOfQuestions.Text = combo.SelectedItem.ToString() + " questions will be generated";
        }
        public void OpenpopUp()
        {

        }
        private void btnStartSession_Click(object sender, RoutedEventArgs e)
        {
            lblPopup.Visibility = Windows.UI.Xaml.Visibility.Visible;
            //messageBox("Click on questions button to start generating the questions");
            btnStartSession.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            //btnNext.Visibility = Windows.UI.Xaml.Visibility.Visible;
            btnNext.IsEnabled = true;
            combo.IsEnabled = false;
            lblDisplayNumberOfQuestions.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            if (combo.SelectedItem != null)
            {
                selItem = int.Parse(combo.SelectedItem.ToString());


                if (selItem == 10)
                {
                    time.Tick += time_tick;
                    time.Interval = new TimeSpan(0, 0, 0, 1);
                }
                else if (selItem == 20)
                {
                    time.Tick += time_tick20;
                    time.Interval = new TimeSpan(0, 0, 0, 1);
                }
                else if (selItem == 30)
                {
                    time.Tick += time_tick30;
                    time.Interval = new TimeSpan(0, 0, 0, 1);
                }
                else if (selItem == 50)
                {
                    time.Tick += time_tick50;
                    time.Interval = new TimeSpan(0, 0, 0, 1);
                }
            }
            else
            {
                time.Tick += time_tick;
                time.Interval = new TimeSpan(0, 0, 0, 1);
            }
        }


    }
}
