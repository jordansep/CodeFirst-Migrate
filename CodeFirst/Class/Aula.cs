using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Class
{
    public class Aula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(3)]
        public int Numero { get; set; }
        public int Piso { get; set; }
        public int Capacidad { get; set; }
       // List<Materia> materias {  get; set; }
       public List<Cursado> CursadoAulas { get; set; }
        public Aula() { }
        public Aula (int piso, int capacidad)
        {
            Piso = piso;
            Capacidad = capacidad;
            Numero = GenerarNumero(piso);
        }
        private int GenerarNumero(int piso) { 
            Random random = new Random();
            int numeroAula = random.Next(1, 20);
            return piso * 100 + numeroAula;
        }
    }
}
