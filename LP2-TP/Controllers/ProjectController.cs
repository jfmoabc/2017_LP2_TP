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
    class ProjectController
    {
        /// <summary>
        /// Cria novo projeto
        /// </summary>
        /// <param name="title">Título do projeto</param>
        /// <param name="description">Descrição do projeto</param>
        /// <param name="admin">Administrador do projeto</param>
        /// <returns></returns>
        public bool NewProject(string title, string description, User admin)
        {
            List<User> userList = new List<User>();
            userList.Add(admin);
            Project.ProjectList.Add(new Project(Project.ProjectList.Count, title, description, admin, DateTime.Now, true, userList));
            Serialize();
            return true;
        }

        /// <summary>
        /// Procura projetos aos quais o utilizador pertence
        /// </summary>
        /// <param name="u">Utilizador a procurar</param>
        /// <returns>Lista dos projetos nos quais o utilizador participa</returns>
        public List<Project> GetProjectList(User u)
        {
            List<Project> userProjects = new List<Project>();

            //Itera a lista de projetos
            for (int i = 0; i < Project.ProjectList.Count; i++)
            {
                //Se o utilizador estiver na lista de Users do projeto
                if (Project.ProjectList[i].UserList.Contains(u))
                {
                    //Adiciona o projeto onde o utilizador foi encontrado à nova lista
                    userProjects.Add(Project.ProjectList[i]);
                }
            }
            return userProjects;
        }

        /// <summary>
        /// Adiciona utilizador ao projeto
        /// </summary>
        /// <param name="u">Utilizador a adicionar ao projeto</param>
        /// <param name="p">Projeto ao qual se adiciona um utilizador</param>
        /// <returns></returns>
        public void AddUser(User u, Project p)
        {
            p.UserList.Add(u);
            Serialize();
        }

        /// <summary>
        /// Altera a descrição do projeto
        /// </summary>
        /// <param name="p">Projeto para alterar a descrição</param>
        /// <param name="newDescription">Nova descrição</param>
        /// <returns></returns>
        public void ChangeDescription(Project p, string newDescription)
        {
            p.Description = newDescription;
        }

        /// <summary>
        /// Altera o admin do projeto
        /// Apenas o admin atual do projeto pode fazer isto
        /// </summary>
        /// <param name="online">Admin atual</param>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool ChangeAdmin(User online, User u, Project p)
        {
            if(online == p.Admin)
            {
                p.Admin = u;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Desativa o projeto, tornando-o só de leitura, apenas se for o admin
        /// </summary>
        /// <param name="online">Verifca se o user é admin</param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool CloseProject(User online, Project p)
        {
            if (online == p.Admin)
            {
                if (p.Active == true)
                {
                    p.Active = false;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Devolve lista de projetos nos quais o utilizador está incluido
        /// </summary>
        /// <param name="online">Utilizador online</param>
        /// <returns>Lista de projetos do Utilizador</returns>
        public List<string> ShowProjects(User online)
        {
            List<string> showProjects = new List<string>();
            for (int i = 0; i < Project.ProjectList.Count; i++)
            {
                if (Project.ProjectList[i].Active == true)
                {
                    for (int j = 0; j < Project.ProjectList[i].UserList.Count; j++)
                    {
                        if (online.ID == Project.ProjectList[i].UserList[j].ID)
                        {
                            showProjects.Add(String.Format("{0} - {1}", Project.ProjectList[i].ID, Project.ProjectList[i].Title));
                        }
                    }
                }
            }
            return showProjects;
        }

        /// <summary>
        /// Método que cria uma lista dos utilizadores no projeto
        /// </summary>
        /// <param name="p">Projeto onde desejamos ver utilizadores</param>
        /// <returns>Lista dos utilizadores no projeto</returns>
        public List<string> ShowUsers(Project p)
        {
            List<string> showUsers = new List<string>();
            for (int i = 0; i < p.UserList.Count; i++)
            {
                showUsers.Add(string.Format("{0} - {1} ({2} {3})", p.UserList[i].ID.ToString(), p.UserList[i].Username, p.UserList[i].Name, p.UserList[i].Surname));
            }
            return showUsers;
        }


        /// <summary>
        /// Método que cria uma lista com utilizadores que não fazem parte do projeto
        /// </summary>
        /// <param name="p">Projeto a adicionar utilizadores</param>
        /// <param name="userList"></param>
        /// <returns></returns>
        public List<string> UsersToAdd(Project p)
        {
            List<string> showUsers = new List<string>();
            for (int i = 0; i < User.UserList.Count; i++)
            {
                if (!(p.UserList.Contains(User.UserList[i])))
                {
                    showUsers.Add(String.Format("{0}. {1}, {2} ({3}) - {4}", User.UserList[i].ID.ToString(), User.UserList[i].Surname, User.UserList[i].Name, User.UserList[i].Username, User.UserList[i].Email));
                }
            }
            return showUsers;
        }

        /// <summary>
        /// Método que procura o projeto através da string obtida pela listbox
        /// </summary>
        /// <param name="info">String da informaçao do projeto a procurar</param>
        /// <returns>Projeto desejado</returns>
        public Project FindProjectListBox(string info)
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
            return Project.ProjectList[position];
        }
        
        /// <summary>
        /// Serializa a Lista de Projetos em Json
        /// </summary>
        /// <returns></returns>
        public static bool Serialize()
        {
            string projectsJson = JsonConvert.SerializeObject(Project.ProjectList, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd HH:mm:ss" });
            File.WriteAllText("Projects.json", projectsJson);
            return true;
        }

        /// <summary>
        /// Deserializa o ficheiro Projects.Json
        /// Cria ProjetList
        /// </summary>
        /// <returns></returns>
        public static bool Deserialize()
        {
            string jsonFile = File.ReadAllText("Projects.json");
            if (jsonFile != "")
            {
                Project.ProjectList = JsonConvert.DeserializeObject<List<Project>>(jsonFile);
            }
            return true;
        }
    }
}
