using tren_rezervasyon.Modeller;

namespace tren_rezervasyon.Servisler
{
    public class RezervasyonServisi : IRezervasyonServisi
    {
        public RezervasyonCevabi RezervasyonKontrolEt(RezervasyonIstegi istek)
        {
            var cevap = new RezervasyonCevabi
            {
                RezervasyonYapilabilir = false,
                YerlesimAyrinti = new List<YerlesimAyrinti>()
            };

            if (istek == null ||
                istek.Tren == null ||
                istek.Tren.Vagonlar == null ||
                istek.RezervasyonYapilacakKisiSayisi <= 0)
            {
                return cevap;
            }

            int rezervasyonKisiSayisi =
                istek.RezervasyonYapilacakKisiSayisi;

            if (!istek.KisilerFarkliVagonlaraYerlestirilebilir)
            {
                foreach (var vagon in istek.Tren.Vagonlar)
                {
                    int maksimumDoluKoltuk =
                        (int)Math.Floor(vagon.Kapasite * 0.70);

                    int kullanilabilirKoltuk =
                        maksimumDoluKoltuk - vagon.DoluKoltukAdet;

                    if (kullanilabilirKoltuk >= rezervasyonKisiSayisi)
                    {
                        cevap.RezervasyonYapilabilir = true;

                        cevap.YerlesimAyrinti.Add(
                            new YerlesimAyrinti
                            {
                                VagonAdi = vagon.Ad,
                                KisiSayisi = rezervasyonKisiSayisi
                            });

                        return cevap;
                    }
                }

                return cevap;
            }

            int kalanKisiSayisi = rezervasyonKisiSayisi;

            foreach (var vagon in istek.Tren.Vagonlar)
            {
                int maksimumDoluKoltuk =
                    (int)Math.Floor(vagon.Kapasite * 0.70);

                int kullanilabilirKoltuk =
                    maksimumDoluKoltuk - vagon.DoluKoltukAdet;

                if (kullanilabilirKoltuk <= 0)
                {
                    continue;
                }

                int vagonaYerlestirilecekKisiSayisi =
                    Math.Min(kullanilabilirKoltuk, kalanKisiSayisi);

                cevap.YerlesimAyrinti.Add(
                    new YerlesimAyrinti
                    {
                        VagonAdi = vagon.Ad,
                        KisiSayisi = vagonaYerlestirilecekKisiSayisi
                    });

                kalanKisiSayisi -= vagonaYerlestirilecekKisiSayisi;

                if (kalanKisiSayisi == 0)
                {
                    cevap.RezervasyonYapilabilir = true;
                    return cevap;
                }
            }

            cevap.YerlesimAyrinti.Clear();

            return cevap;
        }
    }
}