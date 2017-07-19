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
    public interface IUser
    {
        int ID { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        char Gender { get; set; }
        string BirthDate { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Email { get; set; }
        string PhoneNo { get; set; }
        bool Active { get; set; }
        DateTime Creation { get; set; }
        string Country { get; set; }
        string City { get; set; }
        string Description { get; set; }
    }
}
