namespace tren_rezervasyon.Modeller
{
    public class Tren
    {
        public string Ad { get; set; } = string.Empty;

        public List<Vagon> Vagonlar { get; set; } = new();
    }
}