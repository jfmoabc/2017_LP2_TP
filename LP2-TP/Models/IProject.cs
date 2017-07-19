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
    public interface IProject
    {
        int ID { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        User Admin { get; set; }
        DateTime Creation { get; set; }
        bool Active { get; set; }
    }
}
