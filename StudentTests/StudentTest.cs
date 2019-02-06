using System;
using System.Runtime.Serialization;

namespace StudentTests
{
    [DataContract]
    public class StudentTest : IComparable<StudentTest>, IComparable
    {
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string TestName { get; set; }
        /*public int Rating {
            set
            {
                if (value >= 0 && value <= 5)
                    Rating = value;
                else
                    throw new Exception("Rating can only be between 0 and 5");
            }
            get
            {
                return Rating;
            }
        }*/
        [DataMember]
        public int Rating { get; set; }
        [DataMember]
        public DateTime TestDate { get; set; }

        public StudentTest(string studentName, string testName, int rating, DateTime testTime)
        {
            this.StudentName = studentName;
            this.TestName = testName;
            this.Rating = rating;
            this.TestDate = DateTime.Now;
        }

        #region CompareTo
        public int CompareTo(object obj)
        {
            StudentTest st = obj as StudentTest;
            if (st != null)
                return CompareTo(obj);
            else
                throw new InvalidCastException("Objest is not StudentTest");
        }

        public int CompareTo(StudentTest other)
        {
            if (other == null)
                return 1;
            return this.Rating.CompareTo(other.Rating);
        }
        #endregion

        public override string ToString()
        {
            string result = $"Student Name: {StudentName}\nTest Name: {TestName}\nRating: {Rating}\nTestDate: {TestDate}\n";
            return result;
        }
    }
}
