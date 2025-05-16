
namespace BuilderTools.Core.DTO
{
    public class SignUpCompanyDto
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string NIP { get; set; }
        public string KRS { get; set; }
        public string NazwaFirmy { get; set; }
        public string Rola { get; set; }
        public string Haslo { get; set; }

        public UserDto ToModel()
        {
            var UserDto = new UserDto(
                Guid.NewGuid(), Imie, Nazwisko, Adres, Email, Telefon, NIP, KRS, NazwaFirmy, "Admin", Haslo);

            return UserDto;
        }
    }
}
