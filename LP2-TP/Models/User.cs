/* Trabalho Prático, Turno 1, 08/06/2017
 * Plataforma de Gestão de Projetos de Software
 * 
 * LP2 - LESI - EST - IPCA
 * 2016/2017, 2º Semestre
 * 
 * a10944 - João Oliviera
 * a11595 - Daniel Amorim
 */
using System;
using System.Collections.Generic;

namespace LP2_TP.Models
{
    public class User : IUser
    {
        #region ATRIBUTES
        int id;
        string name;
        string surname;
        char gender;
        string birthDate;
        string username;
        string password;
        string email;
        string phoneNo;
        bool active;
        DateTime creation;
        string country;
        string city;
        string description;
        #endregion ATRIBUTES
           
        public static List<User> UserList = new List<User>();

        #region CONSTRUCTORS
        public User(int id, string name, string surname, char gender, string birthDate, string username, string password, string email, string phoneNo, bool active, DateTime creation, string country, string city, string description)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.gender = gender;
            this.birthDate = birthDate;
            this.username = username;
            this.password = password;
            this.email = email;
            this.phoneNo = phoneNo;
            this.active = active;
            this.creation = creation;
            this.country = country;
            this.city = city;
            this.description = description;

        }
        #endregion CONSTRUCTORS

        #region PROPERTIES
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public char Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public string BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        public DateTime Creation
        {
            get { return creation; }
            set { creation = value; }
        }
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
#endregion
    }
}
