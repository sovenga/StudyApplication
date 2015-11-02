using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyApplication.model
{
    class Accounting
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public string answer2 { get; set; }
        public string answer3 { get; set; }
        public string GRADE { get; set; }
        public string read { get; set; }
    }
}
