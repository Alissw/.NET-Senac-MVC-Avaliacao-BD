using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models{
    public class LocacaoFilmeModels{ 
        [Key]
        public int Id { get; set; }

        [ForeignKey("locacoes")]
        public int IdLocacao { get; set; }

        public virtual LocacaoModels Locacao { get; set; }

        [ForeignKey("filmes")]
        public int IdFilme { get; set; }
        
        public virtual FilmeModels Filme { get; set; }

    }
}