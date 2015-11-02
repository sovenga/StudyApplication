using StudyApplication.model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;

namespace StudyApplication.viewModels
{
    class SubjectViewModel
    {
        private App app = (Application.Current as App);
        private int id = 0;
        public int ID
        {
            get { return id; }
            set
            {
                if (id == value)
                {
                    return;
                }
                id = value;
            }
        }

        private string question = string.Empty;
        public string QUESTION
        {
            get { return question; }
            set
            {
                if (question == value)
                {
                    return;
                }
                question = value;
            }
        }
        private string answer = string.Empty;
        public string ANSWER
        {
            get { return answer; }
            set
            {
                if (answer == value)
                {
                    return;
                }
                answer = value;
            }
        }
        private string answer1 = string.Empty;
        public string ANSWER1
        {
            get { return answer1; }
            set
            {
                if (answer1 == value)
                {
                    return;
                }
                answer1 = value;
            }
        }
        private string answer2 = string.Empty;
        public string ANSWER2
        {
            get { return answer2; }
            set
            {
                if (answer2 == value)
                {
                    return;
                }
                answer2 = value;
            }
        }
        private string grade = string.Empty;
        public string GRADE
        {
            get { return grade; }
            set
            {
                if (grade == value)
                {
                    return;
                }
                grade = value;
            }
        }
        private string read = string.Empty;
        public string READ
        {
            get { return read; }
            set
            {
                if (read == value)
                {
                    return;
                }
                read = value;
            }
        }
        public English getEnglish()
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<English>("select * from English").FirstOrDefault();
                return q;
            }
        }
        public Maths getMaths()
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<Maths>("select * from Maths").FirstOrDefault();
                return q;
            }
        }
        public Business getBusiness()
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<Business>("select * from Business").FirstOrDefault();
                return q;
            }
        }
        public Accounting getAccounting()
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<Accounting>("select * from Accounting").FirstOrDefault();
                return q;
            }
        }
        public Physics getPhysics()
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<Physics>("select * from Physics").FirstOrDefault();
                return q;
            }
        }
        public void addAccountingSubject(string question, string answer, string answer1, string answer2, string grade, string read)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    int data = db.Insert(new Accounting()
                    {
                        Id = 0,
                        question = question,
                        answer = answer,
                        answer2 = answer1,
                        answer3 = answer2,
                        GRADE = grade,
                        read = read
                    });
                }
                catch (Exception e)
                {

                }
            }

        }
        public void addBusinessStuddiesSubject(string question, string answer, string answer1, string answer2, string grade, string read)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    int data = db.Insert(new Business()
                    {
                        Id = 0,
                        question = question,
                        answer = answer,
                        answer2 = answer1,
                        answer3 = answer2,
                        GRADE = grade,
                        read = read
                    });
                }
                catch (Exception e)
                {

                }
            }

        }
        public void addEnglishSubject(string question, string answer, string answer1, string answer2, string grade, string read)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    int data = db.Insert(new English()
                    {
                        Id = 0,
                        question = question,
                        answer = answer,
                        answer2 = answer1,
                        answer3 = answer2,
                        GRADE = grade,
                        read = read
                    });
                }
                catch (Exception e)
                {

                }
            }

        }
        public void addGeographySubject(string question, string answer, string answer1, string answer2, string grade, string read)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    int data = db.Insert(new Geography()
                    {
                        Id = 0,
                        question = question,
                        answer = answer,
                        answer2 = answer1,
                        answer3 = answer2,
                        GRADE = grade,
                        read = read
                    });
                }
                catch (Exception e)
                {

                }
            }

        }
        public void addHistorySubject(string question, string answer, string answer1, string answer2, string grade, string read)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    int data = db.Insert(new History()
                    {
                        Id = 0,
                        question = question,
                        answer = answer,
                        answer2 = answer1,
                        answer3 = answer2,
                        GRADE = grade,
                        read = read
                    });
                }
                catch (Exception e)
                {

                }
            }

        }
        public void addLifeOrientationSubject(string question, string answer, string answer1, string answer2, string grade, string read)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    int data = db.Insert(new Life()
                    {
                        Id = 0,
                        question = question,
                        answer = answer,
                        answer2 = answer1,
                        answer3 = answer2,
                        GRADE = grade,
                        read = read
                    });
                }
                catch (Exception e)
                {

                }
            }

        }
        public void addMathsSubject(string question, string answer, string answer1, string answer2, string grade, string read)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    int data = db.Insert(new Maths()
                    {
                        Id = 0,
                        question = question,
                        answer = answer,
                        answer2 = answer1,
                        answer3 = answer2,
                        GRADE = grade,
                        read = read
                    });
                }
                catch (Exception e)
                {

                }
            }

        }
        public void addPhysicsSubject(string question, string answer, string answer1, string answer2, string grade, string read)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    int data = db.Insert(new Physics()
                    {
                        Id = 0,
                        question = question,
                        answer = answer,
                        answer2 = answer1,
                        answer3 = answer2,
                        GRADE = grade,
                        read = read
                    });
                }
                catch (Exception e)
                {

                }
            }

        }
        public Accounting getAccountingCorrectAnswer(string question)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<Accounting>("select * from Accounting where question = '" + question + "'").FirstOrDefault();
                return q;
            }
        }
        public Business getBusinessCorrectAnswer(string question)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<Business>("select * from Business where question = '" + question + "'").FirstOrDefault();
                return q;
            }
        }
        public English getEnglishCorrectAnswer(string question)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<English>("select * from English where question = '" + question + "'").FirstOrDefault();
                return q;
            }
        }
        public Geography getGeographyCorrectAnswer(string question)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<Geography>("select * from Geography where question = '" + question + "'").FirstOrDefault();
                return q;
            }
        }
        public History getHistoryCorrectAnswer(string question)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<History>("select * from History where question = '" + question + "'").FirstOrDefault();
                return q;
            }
        }
        public Life getLifeCorrectAnswer(string question)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<Life>("select * from Life where question = '" + question + "'").FirstOrDefault();
                return q;
            }
        }
        public Maths getMathsCorrectAnswer(string question)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<Maths>("select * from Maths where question = '" + question + "'").FirstOrDefault();
                return q;
            }
        }
        public Physics getPhysicsCorrectAnswer(string question)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<Physics>("select * from Physics where question = '" + question + "'").FirstOrDefault();
                return q;
            }
        }
        public bool verifyAccountingExist(string question, string answer)
        {
            bool found = false;
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<Accounting>("select * from Accounting where question = '" + question + "' and answer ='" + answer + "'").FirstOrDefault();

                if (q != null)
                {
                    found = true;
                }
            }
            return found;
        }
        public bool verifyBusinessExist(string question, string answer)
        {
            bool found = false;
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<Business>("select * from Business where question = '" + question + "' and answer ='" + answer + "'").FirstOrDefault();

                if (q != null)
                {
                    found = true;
                }
            }
            return found;
        }
        public bool verifyExist(string question, string answer)
        {
            bool found = false;
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<English>("select * from English where question = '" + question + "' and answer ='" + answer + "'").FirstOrDefault();

                if (q != null)
                {
                    found = true;
                }
            }
            return found;
        }
        public bool verifyGeographyExist(string question, string answer)
        {
            bool found = false;
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<Geography>("select * from Geography where question = '" + question + "' and answer ='" + answer + "'").FirstOrDefault();

                if (q != null)
                {
                    found = true;
                }
            }
            return found;
        }
        public bool verifyHistoryExist(string question, string answer)
        {
            bool found = false;
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<History>("select * from History where question = '" + question + "' and answer ='" + answer + "'").FirstOrDefault();

                if (q != null)
                {
                    found = true;
                }
            }
            return found;
        }
        public bool verifyLifeOriontationExist(string question, string answer)
        {
            bool found = false;
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<Life>("select * from Life where question = '" + question + "' and answer ='" + answer + "'").FirstOrDefault();

                if (q != null)
                {
                    found = true;
                }
            }
            return found;
        }
        public bool verifyMathsExist(string question, string answer)
        {
            bool found = false;
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<Maths>("select * from Maths where question = '" + question + "' and answer ='" + answer + "'").FirstOrDefault();

                if (q != null)
                {
                    found = true;
                }
            }
            return found;
        }
        public bool verifyPhysicsExist(string question, string answer)
        {
            bool found = false;
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<Physics>("select * from Physics where question = '" + question + "' and answer ='" + answer + "'").FirstOrDefault();

                if (q != null)
                {
                    found = true;
                }
            }
            return found;
        }
        public void updateToRead(string quetion)
        {
            string yes = "yes";
            string no = "no";
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    //var existing = db.Query<English>("update English set read ='" + yes + "' where question ='" + question + "'");
                    var existing = db.Execute("update English set read ='" + yes + "' where answer ='" + question + "'");
                    //var q = db.Execute("update English set read ='" + yes + "'");
                }

                catch (Exception e)
                {

                }
            }
        }
        public string updateToRead2(string quetion)
        {
            string isUpdated = "";
            string yes = "yes";
            string no = "no";
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    var existing = db.Execute("update English set read ='" + yes + "' where question ='" + question + "'");
                    if (existing != null)
                    {
                        isUpdated = "true";
                    }
                    else
                    {
                        isUpdated = "false";
                    }
                }

                catch (Exception e)
                {

                }
            }
            return isUpdated;
        }
        public void updateEnglishToNotRead()
        {
            string yes = "yes";
            string no = "no";
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    var existing = db.Query<English>("update English set read ='" + no + "'");
                }
                catch (Exception e)
                {

                }
            }

        }
        public void removeAccounting(string question)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    var existing = db.Query<Accounting>("delete from Accounting where question ='" + question + "'");
                }
                catch (Exception e)
                {

                }
            }
        }
        public void removeBusiness(string question)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    var existing = db.Query<Business>("delete from Business where question ='" + question + "'");
                }
                catch (Exception e)
                {

                }
            }
        }

        public void remove(string question)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    var existing = db.Query<English>("delete from English where question ='" + question + "'");
                }
                catch (Exception e)
                {

                }
            }
        }
        public void removeGeography(string question)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    var existing = db.Query<Geography>("delete from Geography where question ='" + question + "'");
                }
                catch (Exception e)
                {

                }
            }
        }
        public void removeHistory(string question)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    var existing = db.Query<History>("delete from History where question ='" + question + "'");
                }
                catch (Exception e)
                {

                }
            }
        }
        public void removeLifeOrientation(string question)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    var existing = db.Query<Life>("delete from Life where question ='" + question + "'");
                }
                catch (Exception e)
                {

                }
            }
        }
        public void removeMaths(string question)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    var existing = db.Query<Maths>("delete from Maths where question ='" + question + "'");
                }
                catch (Exception e)
                {

                }
            }
        }
        public void removePhysics(string question)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    var existing = db.Query<Physics>("delete from Physics where question ='" + question + "'");
                }
                catch (Exception e)
                {

                }
            }
        }
        public void removeAll()
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    var existing = db.Query<English>("delete from English");
                }
                catch (Exception e)
                {

                }
            }
        }
        public void removeAllMathsQuestions()
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    var existing = db.Query<Maths>("delete from Maths");
                }
                catch (Exception e)
                {

                }
            }
        }
        public void removeAllAccountingQuestions()
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    var existing = db.Query<Accounting>("delete from Accounting");
                }
                catch (Exception e)
                {

                }
            }
        }
        public void removeAllBusinessQuestions()
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    var existing = db.Query<Business>("delete from Business");
                }
                catch (Exception e)
                {

                }
            }
        }
        public void removeAllGeographyQuestions()
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    var existing = db.Query<Geography>("delete from Geography");
                }
                catch (Exception e)
                {

                }
            }
        }
        public void removeAllHistoryQuestions()
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    var existing = db.Query<Geography>("delete from Geography");
                }
                catch (Exception e)
                {

                }
            }
        }
        public void removeAllLifeQuestions()
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    var existing = db.Query<Life>("delete from Life");
                }
                catch (Exception e)
                {

                }
            }
        }
        public void removeAllPhysicsQuestions()
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                try
                {
                    var existing = db.Query<Physics>("delete from Physics");
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
