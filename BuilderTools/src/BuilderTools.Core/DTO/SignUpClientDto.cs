
namespace BuilderTools.Core.DTO
{
    public class SignUpClientDto
    {
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
            var UserDto = new UserDto(
                Guid.NewGuid(), Imie, Nazwisko, Uprawnienia, Adres, Email, Telefon, "Admin", Haslo);

            return UserDto;
        }
    }
}
