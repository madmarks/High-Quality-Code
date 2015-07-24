namespace Methods
{
    using System;

    internal class Student
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string otherInfo;

        public Student(string firstName, string lastName, DateTime dateOfBirth, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.OtherInfo = otherInfo;
        }

        public Student(string firstName, string lastName, DateTime dateOfBirth) :
            this(firstName, lastName, dateOfBirth, string.Empty)
        {
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("'FirstName' property cannot be null, empty or consist of white-space characters only.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("'LastName' property cannot be null, empty or consist of white-space characters only.");
                }

                this.lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("'DateOfBirth' property cannot be null.");
                }

                this.dateOfBirth = value;
            }
        }

        public string OtherInfo
        {
            get
            {
                return this.otherInfo;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("'OtherInfo' property cannot be null.");
                }

                this.otherInfo = value;
            }
        }

        public bool IsOlderThan(Student secondStudent)
        {
            if (secondStudent == null)
            {
                throw new ArgumentNullException("'secondStudent' object cannot be null.");
            }

            DateTime firstStudentDateOfBirth = this.DateOfBirth;

            DateTime secondStudentDateOfBirth = secondStudent.DateOfBirth;

            return firstStudentDateOfBirth < secondStudentDateOfBirth;
        }
    }
}
