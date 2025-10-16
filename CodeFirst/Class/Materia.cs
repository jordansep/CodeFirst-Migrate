using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Class
{
    public class Materia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        [MaxLength(200)]
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int Nivel { get; set; }
        public List<Alumno> Alumnos { get; set; }
        List<Cursado> CursadoMaterias { get; set; }

    }
}
