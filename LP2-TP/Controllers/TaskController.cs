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
using System.IO;
using Newtonsoft.Json;
using LP2_TP.Models;

namespace LP2_TP.Controllers
{
    public class TaskController
    {
        public static List<Models.Task> TaskList = new List<Models.Task>();

        /// <summary>
        /// Método que cria tarefa
        /// </summary>
        /// <param name="title">Título da tarefa</param>
        /// <param name="description">Descrição da tarefa</param>
        /// <param name="owner">Utilizador ao qual a tarefa foi associada</param>
        /// <param name="origin">Projeto do qual origina a tarefa</param>
        /// <returns></returns>
        public bool NewTask(string title, string description, User owner, Project origin)
        {
            TaskList.Add(new Models.Task(TaskList.Count, title, description, owner, origin, DateTime.Now, true));
            //origin.TaskList.Add(new Models.Task(TaskList.Count, title, description, owner, origin, DateTime.Now, true));
            Serialize();
            return true;
        }

        /// <summary>
        /// Procura tarefas que pertencam ao projeto
        /// </summary>
        /// <param name="p">Projeto do qual pretendemos conhecer as tarefas</param>
        /// <returns>Lista das tarefas que pertencem ao projeto</returns>
        public List<Models.Task> GetTaskList(Project p)
        {
            List<Models.Task> pTasks = new List<Models.Task>();

            for (int i = 0; i < TaskList.Count; i++)
            {
                if(TaskList[i].Origin.ID == p.ID)
                {
                    pTasks.Add(TaskList[i]);
                }
            }
            return pTasks;
        }

        /// <summary>
        /// Desativa a tarefa
        /// </summary>
        /// <param name="t">Tarefa a desativar</param>
        /// <returns></returns>
        public bool CloseTask(Models.Task t)
        {
            if(t.Active == true)
            {
                t.Active = false;
                return true;
            }
            return false;
        }


        public List<string> ShowTasks(Project p)
        {
            List<string> showTasks = new List<string>();

            for (int i = 0; i < p.TaskList.Count; i++)
            {
                if (p.TaskList[i].Active == true)
                {
                    showTasks.Add(string.Format("{0} - {1}", p.TaskList[i].ID, p.TaskList[i].Title));
                }
            }
            return showTasks;
        }

        /// <summary>
        /// Serializa a Lista de Tarefas em Json
        /// </summary>
        /// <returns></returns>
        public static bool Serialize()
        {
            string tasksJson = JsonConvert.SerializeObject(TaskList);
            File.WriteAllText("Tasks.json", tasksJson);
            return true;
        }

        /// <summary>
        /// Deserializa o ficheiro Tasks.Json
        /// Cria TaskList
        /// </summary>
        /// <returns></returns>
        public static bool Deserialize()
        {
            string jsonFile = File.ReadAllText("Tasks.json");
            if (jsonFile != "")
            {
                TaskList = JsonConvert.DeserializeObject<List<Models.Task>>(jsonFile);
            }
            return true;
        }
    }
}
