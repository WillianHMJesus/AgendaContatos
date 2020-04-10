using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrabalhoUWP.Abstract;

namespace TrabalhoUWP.Model
{
    public class Contato : NotifyableClass
    {
        private string _id;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { Set(ref _nome, value); }
        }

        private string _telefone;
        public string Telefone
        {
            get { return _telefone; }
            set { Set(ref _telefone, value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { Set(ref _email, value); }
        }

        private bool? _favorito;
        public bool? Favorito
        {
            get { return _favorito ?? false; }
            set { Set(ref _favorito, value); }
        }

        private byte[] _picture;

        public byte[] Picture
        {
            get { return _picture; }
            set { Set(ref _picture, value); }
        }
    }
}
