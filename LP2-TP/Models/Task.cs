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

namespace LP2_TP.Models
{
    public class Task : ITask
    {
        #region ATTRIBUTES
        int id;
        string title;
        string description;
        User owner;
        Project origin;
        DateTime creation;
        bool active;
        #endregion ATRRIBUTES

        #region CONSTRUCTORS
        public Task(int id, string title, string description, User owner, Project origin, DateTime creation, bool active)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.owner = owner;
            this.origin = origin;
            this.creation = creation;
            this.active = active;
        }
        #endregion

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
        public User Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        public Project Origin
        {
            get { return origin; }
            set { origin = value; }
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
