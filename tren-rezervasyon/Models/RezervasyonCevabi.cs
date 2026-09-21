namespace tren_rezervasyon.Modeller
{
    public class RezervasyonCevabi
    {
        public bool RezervasyonYapilabilir { get; set; }

        public List<YerlesimAyrinti> YerlesimAyrinti { get; set; } = new();
    }
}