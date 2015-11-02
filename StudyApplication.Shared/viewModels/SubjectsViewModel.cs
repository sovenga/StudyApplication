using StudyApplication.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml;

namespace StudyApplication.viewModels
{
    class SubjectsViewModel
    {
        private App app = (Application.Current as App);
        private ObservableCollection<SubjectViewModel> subject;
        private List<SubjectViewModel> subjects;
        public ObservableCollection<SubjectViewModel> Subject
        {
            get { return subject; }

            set
            {
                if (subject == value)
                {
                    return;
                }
                subject = value;

            }
        }
        public ObservableCollection<SubjectViewModel> getAccountingQuestions1(string gr)
        {
            string no = "no";
            string yes = "yes";
            subject = new ObservableCollection<SubjectViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                //var query = db.Table<English>();
                var query = db.Query<Accounting>("select * from Accounting where GRADE ='" + gr + "' and read ='" + no + "'");
                foreach (var j in query)
                {
                    var sub = new SubjectViewModel()
                    {
                        ID = j.Id,
                        QUESTION = j.question,
                        ANSWER = j.answer,
                        ANSWER1 = j.answer2,
                        ANSWER2 = j.answer3,
                        GRADE = j.GRADE,
                        READ = j.read
                    };
                    subject.Add(sub);
                }
            }
            return subject;
        }
        public ObservableCollection<SubjectViewModel> getBusinessQuestions1(string gr)
        {
            string no = "no";
            string yes = "yes";
            subject = new ObservableCollection<SubjectViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                //var query = db.Table<English>();
                var query = db.Query<Business>("select * from Business where GRADE ='" + gr + "' and read ='" + no + "'");
                foreach (var j in query)
                {
                    var sub = new SubjectViewModel()
                    {
                        ID = j.Id,
                        QUESTION = j.question,
                        ANSWER = j.answer,
                        ANSWER1 = j.answer2,
                        ANSWER2 = j.answer3,
                        GRADE = j.GRADE,
                        READ = j.read
                    };
                    subject.Add(sub);
                }
            }
            return subject;
        }
        public ObservableCollection<SubjectViewModel> getEnglishQuestions1(string gr)
        {
            string no = "no";
            string yes = "yes";
            subject = new ObservableCollection<SubjectViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                //var query = db.Table<English>();
                var query = db.Query<English>("select * from english where GRADE ='" + gr + "' and read ='" + no + "'");
                foreach (var j in query)
                {
                    var sub = new SubjectViewModel()
                    {
                        ID = j.Id,
                        QUESTION = j.question,
                        ANSWER = j.answer,
                        ANSWER1 = j.answer2,
                        ANSWER2 = j.answer3,
                        GRADE = j.GRADE,
                        READ = j.read
                    };
                    subject.Add(sub);
                }
            }
            return subject;
        }
        public ObservableCollection<SubjectViewModel> getGeographyQuestions1(string gr)
        {
            string no = "no";
            string yes = "yes";
            subject = new ObservableCollection<SubjectViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                //var query = db.Table<English>();
                var query = db.Query<Geography>("select * from Geography where GRADE ='" + gr + "' and read ='" + no + "'");
                foreach (var j in query)
                {
                    var sub = new SubjectViewModel()
                    {
                        ID = j.Id,
                        QUESTION = j.question,
                        ANSWER = j.answer,
                        ANSWER1 = j.answer2,
                        ANSWER2 = j.answer3,
                        GRADE = j.GRADE,
                        READ = j.read
                    };
                    subject.Add(sub);
                }
            }
            return subject;
        }
        public ObservableCollection<SubjectViewModel> getHistoryQuestions1(string gr)
        {
            string no = "no";
            string yes = "yes";
            subject = new ObservableCollection<SubjectViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                //var query = db.Table<English>();
                var query = db.Query<History>("select * from History where GRADE ='" + gr + "' and read ='" + no + "'");
                foreach (var j in query)
                {
                    var sub = new SubjectViewModel()
                    {
                        ID = j.Id,
                        QUESTION = j.question,
                        ANSWER = j.answer,
                        ANSWER1 = j.answer2,
                        ANSWER2 = j.answer3,
                        GRADE = j.GRADE,
                        READ = j.read
                    };
                    subject.Add(sub);
                }
            }
            return subject;
        }
        public ObservableCollection<SubjectViewModel> getLifeOrientationQuestions1(string gr)
        {
            string no = "no";
            string yes = "yes";
            subject = new ObservableCollection<SubjectViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                //var query = db.Table<English>();
                var query = db.Query<Life>("select * from Life where GRADE ='" + gr + "' and read ='" + no + "'");
                foreach (var j in query)
                {
                    var sub = new SubjectViewModel()
                    {
                        ID = j.Id,
                        QUESTION = j.question,
                        ANSWER = j.answer,
                        ANSWER1 = j.answer2,
                        ANSWER2 = j.answer3,
                        GRADE = j.GRADE,
                        READ = j.read
                    };
                    subject.Add(sub);
                }
            }
            return subject;
        }
        public ObservableCollection<SubjectViewModel> getMathsQuestions1(string gr)
        {
            string no = "no";
            string yes = "yes";
            subject = new ObservableCollection<SubjectViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                //var query = db.Table<English>();
                var query = db.Query<Maths>("select * from Maths where GRADE ='" + gr + "' and read ='" + no + "'");
                foreach (var j in query)
                {
                    var sub = new SubjectViewModel()
                    {
                        ID = j.Id,
                        QUESTION = j.question,
                        ANSWER = j.answer,
                        ANSWER1 = j.answer2,
                        ANSWER2 = j.answer3,
                        GRADE = j.GRADE,
                        READ = j.read
                    };
                    subject.Add(sub);
                }
            }
            return subject;
        }
        public ObservableCollection<SubjectViewModel> getPhysicsQuestions1(string gr)
        {
            string no = "no";
            string yes = "yes";
            subject = new ObservableCollection<SubjectViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                //var query = db.Table<English>();
                var query = db.Query<Physics>("select * from Physics where GRADE ='" + gr + "' and read ='" + no + "'");
                foreach (var j in query)
                {
                    var sub = new SubjectViewModel()
                    {
                        ID = j.Id,
                        QUESTION = j.question,
                        ANSWER = j.answer,
                        ANSWER1 = j.answer2,
                        ANSWER2 = j.answer3,
                        GRADE = j.GRADE,
                        READ = j.read
                    };
                    subject.Add(sub);
                }
            }
            return subject;
        }
        public List<SubjectViewModel> getEnglishQuestion(string gr)
        {
            //string grade = "Grade 6";
            subjects = new List<SubjectViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                //var query = db.Table<English>();
                var query = db.Query<English>("select * from english where GRADE ='" + gr + "'");
                foreach (var j in query)
                {
                    var sub = new SubjectViewModel()
                    {
                        ID = j.Id,
                        QUESTION = j.question,
                        ANSWER = j.answer,
                        ANSWER1 = j.answer2,
                        ANSWER2 = j.answer3,
                        GRADE = gr
                    };
                    subject.Add(sub);
                }
            }
            return subjects;
        }
    }
}
