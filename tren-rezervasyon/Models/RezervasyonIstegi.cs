namespace tren_rezervasyon.Modeller
{
    public class RezervasyonIstegi
    {
        public Tren Tren { get; set; } = new();

        public int RezervasyonYapilacakKisiSayisi { get; set; }

        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }
}