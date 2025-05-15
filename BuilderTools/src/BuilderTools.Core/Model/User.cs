
namespace BuilderTools.Core.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public bool Uprawnienia { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string? NIP { get; set; }
        public string? KRS { get; set; }
        public string? NazwaFirmy { get; set; }
        public string Rola { get; set; }
        public string Haslo { get; set; }

        public User(Guid id, string imie, string nazwisko, bool uprawnienia, string adres,
            string email, string telefon, string? nIP, string? kRS, string? nazwaFirmy, string rola, string haslo)
        {
            Id = id;
            Imie = imie;
            Nazwisko = nazwisko;
            Uprawnienia = uprawnienia;
            Adres = adres;
            Email = email;
            Telefon = telefon;
            NIP = nIP;
            KRS = kRS;
            NazwaFirmy = nazwaFirmy;
            Rola = rola;
            Haslo = haslo;
        }

    }
}
