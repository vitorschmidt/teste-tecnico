using System.ComponentModel.DataAnnotations;

namespace APIt.Model
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }    

        public string Descricao { get; set; }
    }
}
