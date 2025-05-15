
namespace BuilderTools.Core.DTO
{
    public class SignUpClientDto
    {
        public Guid Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public bool Uprawnienia { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Rola { get; set; }
        public string Haslo { get; set; }

        public UserDto ToModel()
        {
            if(Id == null || Guid.Empty == Id)
            {
                Id = Guid.NewGuid();
            }

            var UserDto = new UserDto(
                Id, Imie, Nazwisko, Uprawnienia, Adres, Email, Telefon, Rola, Haslo);

            return UserDto;
        }
    }
}
