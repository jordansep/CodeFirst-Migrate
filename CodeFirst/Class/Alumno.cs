using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Class
{
    public class Alumno
    {
        // Columnas | Propiedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        
        public string Apellido { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        public List<Materia> Materias { get; set; } = new List<Materia>();

        // Constructores.
        public Alumno() { 
        }
        public Alumno(string nombre, string apellido) {
            Nombre = nombre;
            Apellido = apellido;
            
        }
        public Alumno(string nombre, string apellido, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;

        }
        
    }
}
