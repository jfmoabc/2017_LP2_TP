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
    public class Project : IProject
    {
        #region ATRIBUTES
        int id;
        string title;
        string description;
        User admin;
        DateTime creation;
        bool active;
        #endregion ATRIBUTES

        public static List<Project> ProjectList = new List<Project>();
        public List<User> UserList = new List<User>();
        public List<Task> TaskList = new List<Task>();

        #region CONSTRUCTORS
        /// <summary>
        /// Construtor Project
        /// </summary>
        /// <param name="id">ID do projeto</param>
        /// <param name="title">Título do projeto</param>
        /// <param name="description">Descrição do projeto</param>
        /// <param name="admin">Utilizador administrador do projeto</param>
        /// <param name="creation">Data de criação do projeto</param>
        /// <param name="active">Se o projeto está aberto ou fechado</param>
        /// <param name="userList">Lista de utilizadores do projeto</param>
        public Project(int id, string title, string description, User admin, DateTime creation, bool active, List<User> userList)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.admin = admin;
            this.creation = creation;
            this.active = active;
            UserList = userList;
        }
        #endregion CONSTRUCTORS

        #region PROPERTIES
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public User Admin
        {
            get { return admin; }
            set { admin = value; }
        }
        public DateTime Creation
        {
            get { return creation; }
            set { creation = value; }
        }
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        #endregion PROPERTIES
    }
}
