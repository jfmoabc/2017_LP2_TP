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
using LP2_TP.Models;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LP2_TP.Controllers
{
    public class UserController
    {

        /// <summary>
        /// Cria novo utilizador
        /// </summary>
        /// <param name="name">Nome do utlizador</param>
        /// <param name="surname">Apelido do utilizador</param>
        /// <param name="gender">Género do utilizador</param>
        /// <param name="username">Username do utilizador</param>
        /// <param name="password">Password do utilizador</param>
        /// <param name="email">Email do utilizador</param>
        /// <param name="phoneNo">Número Telefónico do Utilizador</param>
        /// <param name="country">País do Utilizador</param>
        /// <param name="city">Cidade do Utilizador</param>
        /// <returns></returns>
        public bool NewUser(string name, string surname, char gender, string birthDate, string username, string password, string email, string phoneNo, string country, string city, string description)
        {
            User.UserList.Add(new User(User.UserList.Count, name, surname, gender, birthDate, username, password, email, phoneNo, true, DateTime.Now, country, city, description));
            Serialize();
            return true;
        }

        /// <summary>
        /// Procura o utilizador que está a fazer login
        /// </summary>
        /// <param name="username">Username a procurar</param>
        /// <returns>Utilizador que fez login</returns>
        public User GetUser(string username)
        {
            User online = null;

            for (int i = 0; i < User.UserList.Count; i++)
            {
                if (username == User.UserList[i].Username)
                {
                    online = User.UserList[i];
                }
            }
            return online;
        }

        /// <summary>
        /// Procura utilizador pelo ID
        /// </summary>
        /// <param name="info">String com informação sobre o utilizador a procurar</param>
        /// <returns></returns>
        public User GetUser2(string info)
        {
            string aux = string.Empty;
            int position;
            for (int i = 0; i < info.Length; i++)
            {
                if (Char.IsDigit(info[i]))
                {
                    aux += info[i];
                }
                else
                {
                    break;
                }
            }
            position = int.Parse(aux);
            return User.UserList[position];
        }

        /// <summary>
        /// Procura por nome e apelido
        /// </summary>
        /// <param name="s">String a procurar</param>
        /// <param name="searchUser">Lista de users encontrados</param>
        public void SearchNameSurname(string s, out List<User> searchUser)
        {
            searchUser = new List<User>();
            for (int i = 0; i < User.UserList.Count; i++)
            {
                if(User.UserList[i].Name.Contains(s) || User.UserList[i].Surname.Contains(s))
                {
                    searchUser.Add(User.UserList[i]);
                }
            }
        }

        /// <summary>
        /// Verifica se o username existe na plataforma
        /// </summary>
        /// <param name="username">Username a procurar na lista</param>
        /// <returns></returns>
        public bool SearchUsername(string username)
        {
            for (int i = 0; i < User.UserList.Count; i++)
            {
                if(username == User.UserList[i].Username)
                {
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// Edita um utilizador
        /// </summary>
        /// <param name="now">Antes de ser editado</param>
        /// <param name="edited">Após edição</param>
        /// <returns></returns>
        public bool EditUser(User before, User after)
        {
            for (int i = 0; i < User.UserList.Count; i++)
            {
                if(before == User.UserList[i])
                {
                    User.UserList[i] = after;
                    Serialize();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica se a password contém pelo menos uma maiúscula e um número
        /// </summary>
        /// <param name="password">Password a verificar</param>
        /// <returns></returns>
        public bool CheckPassword(string password)
        {
            bool upper = false;
            bool digit = false;

            if (password.Length > 5)
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if (Char.IsUpper(password[i]))
                    {
                        upper = true;
                    }
                    if (Char.IsDigit(password[i]))
                    {
                        digit = true;
                    }
                }
                if ((upper && digit) == true)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica se as passwords são iguais
        /// </summary>
        /// <param name="pw1">password a verificar</param>
        /// <param name="pw2">password a verificar</param>
        /// <returns></returns>
        public bool ComparePassword(string pw1, string pw2)
        {
            if(pw1 == pw2)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Procura email na plataforma
        /// </summary>
        /// <param name="email">Email a procurar</param>
        /// <returns></returns>
        public bool SearchEmail(string email)
        {
            for (int i = 0; i < User.UserList.Count; i++)
            {
                if (email == User.UserList[i].Email)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica se o email é válido
        /// </summary>
        /// <param name="email">Email a verifacar</param>
        /// <returns></returns>
        public bool CheckEmail(string email)
        {
            string[] dots = new string[] { ".com", ".net", ".pt", ".gov", ".es", ".io", ".fr", ".uk" };

            if (email.Contains("@"))
            {
                for (int i = 0; i < dots.Length; i++)
                {
                    if (email.Contains(dots[i]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Verifica o número de contacto
        /// </summary>
        /// <param name="phoneNo">string a verificar</param>
        /// <returns></returns>
        public bool CheckPhoneNo(string phoneNo)
        {
            if (phoneNo.Length != 9)
            {
                for (int i = 0; i < phoneNo.Length; i++)
                {
                    if (!Char.IsDigit(phoneNo[i]))
                    {
                        return false;
                    }
                }
                for (int i = 0; i < User.UserList.Count; i++)
                {
                    if (phoneNo == User.UserList[i].PhoneNo)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Altera a password do utilizador
        /// </summary>
        /// <param name="online">Utilizador que quer alterar a password</param>
        /// <param name="pw1">Password a verificar</param>
        /// <param name="pw2">Password a verificar</param>
        /// <returns></returns>
        public bool ChangePassword(User online, string pw1, string pw2)
        {
            if (pw1 != online.Password)
            {
                if (ComparePassword(pw1, pw2) == true && CheckPassword(pw1) == true)
                {
                    online.Password = pw1;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Altera o Email do utilizador
        /// </summary>
        /// <param name="online">Utilizador que quer alterar o email</param>
        /// <param name="newEmail">Novo email a verificar</param>
        /// <returns></returns>
        public bool ChangeEmail(User online, string newEmail)
        {
            if (newEmail != online.Email)
            {
                if (SearchEmail(newEmail) == false && CheckEmail(newEmail) == true)
                {
                    online.Email = newEmail;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Altera a cidade do utilizador
        /// </summary>
        /// <param name="online">Utilizador que quer alterar a cidade</param>
        /// <param name="newCity">Nova cidade</param>
        /// <returns></returns>
        public bool ChangeCity(User online, string newCity)
        {
            if(newCity != online.City)
            {
                online.City = newCity;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Altera o país do utilizador
        /// </summary>
        /// <param name="online">Utilizador que quer alterar o país</param>
        /// <param name="newCountry">Novo país</param>
        /// <returns></returns>
        public bool ChangeCountry(User online, string newCountry)
        {
            if (newCountry != online.Country)
            {
                online.City = newCountry;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Altera a descrição do utilizador
        /// </summary>
        /// <param name="online">Utilizador que quer alterar a descrição</param>
        /// <param name="newDescription">Nova descrição</param>
        /// <returns></returns>
        public bool ChangeDescription(User online, string newDescription)
        {
            online.Description = newDescription;
            return true;
        }

        /// <summary>
        /// /Verifica se existe um utilizador com este username e password
        /// </summary>
        /// <param name="username">Username a procurar</param>
        /// <param name="password">Password a verificar</param>
        /// <returns></returns>
        public bool LogIn(string username, string password)
        {
            for (int i = 0; i < User.UserList.Count; i++)
            {
                if(User.UserList[i].Username == username && User.UserList[i].Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public List<string> ShowUsersToPick(User admin, Project p, List<User> PUserList)
        {
            List<string> showUsers = new List<string>();
            for (int i = 0; i < User.UserList.Count; i++)
            {
                if (admin != User.UserList[i])
                {
                    showUsers.Add(String.Format("{0}. {1}, {2} ({3}) - {4}", User.UserList[i].ID.ToString(), User.UserList[i].Surname, User.UserList[i].Name, User.UserList[i].Username, User.UserList[i].Email));
                }
            }
            return showUsers;
        }
        /// <summary>
        /// Serializa a Lista de Users em Json
        /// </summary>
        /// <returns></returns>
        public static bool Serialize()
        {
            string usersJson = JsonConvert.SerializeObject(User.UserList, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd HH:mm:ss" });
            File.WriteAllText("Users.json", usersJson);
            return true;
        }

        /// <summary>
        /// Deserializa o ficheiro Users.Json
        /// Cria userList
        /// </summary>
        /// <returns></returns>
        public static bool Deserialize()
        {
            string jsonFile = File.ReadAllText("Users.json");
            if (jsonFile != "")
            {
                User.UserList = JsonConvert.DeserializeObject<List<User>>(jsonFile);
            }
            return true;
        }
    }
}
