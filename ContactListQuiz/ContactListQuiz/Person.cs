using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListQuiz
{
    public class Person
    {
        private int id;
        private String firstName;
        private String lastName;
        private String email;

        public Person()
        {
            this.id = 0;
            this.firstName = null;
            this.lastName = null;
            this.email = null;
        }

        public Person(int id, String firstName, String lastName, String email)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }

        public int Id
        {
            get { return this.id;}
            set { this.id = value; }
        }

        public String FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public String LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public String Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public String toString() {
            return "ID: " + this.id + "\nVorname: " + this.firstName + "\nNachname" + this.lastName + "\nEmail: " + this.email;
        }
    }
}
