# Tren Rezervasyon API

Bu proje, bir tren rezervasyon isteğinin uygun olup olmadığını kontrol eden ASP.NET Core Web API uygulamasıdır.

## Özellikler

- Bir tren içinde birden fazla vagon desteklenir.
- Her vagon farklı kapasiteye sahip olabilir.
- Vagon doluluk oranı %70'i geçemez.
- Birden fazla kişi için rezervasyon yapılabilir.
- Yolcular aynı veya farklı vagonlara yerleştirilebilir.
- Rezervasyon yapılabiliyorsa vagon bazında yerleşim bilgisi döndürülür.

## Teknolojiler

- C#
- ASP.NET Core Web API
- .NET
- Postman

## Endpoint

POST

/api/Rezervasyon

## Örnek Request

```json
{
  "tren": {
    "ad": "Başkent Ekspres",
    "vagonlar": [
      {
        "ad": "Vagon 1",
        "kapasite": 100,
        "doluKoltukAdet": 68
      },
      {
        "ad": "Vagon 2",
        "kapasite": 90,
        "doluKoltukAdet": 50
      }
    ]
  },
  "rezervasyonYapilacakKisiSayisi": 3,
  "kisilerFarkliVagonlaraYerlestirilebilir": true
}
