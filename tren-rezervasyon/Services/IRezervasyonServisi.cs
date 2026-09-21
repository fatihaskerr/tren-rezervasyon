using tren_rezervasyon.Modeller;

namespace tren_rezervasyon.Servisler
{
    public interface IRezervasyonServisi
    {
        RezervasyonCevabi RezervasyonKontrolEt(RezervasyonIstegi istek);
    }
}