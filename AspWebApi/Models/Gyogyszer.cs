namespace AspWebApi.Models
{
    public class Gyogyszer
    {
        public int Id { get; set; }
        public string Nev { get; set; } = "";
        public string Hatoanyag { get; set; } = "";
        public bool Venykoteles { get; set; }
        public string kepnev { get; set; } = string.Empty;
    }
}
