namespace WebDecor.Models
{
    public class ProductDetailsModel
    {
        public string productID { get; set; }
        public string productName { get; set; }
        public string made { get; set; }
        public string info { get; set; }
        public string des { get; set; }
        public decimal price { get; set; }
        public long size { get; set; }
        public decimal sale { get; set; }
        public bool freeShip { get; set; }
        public string imageURL { get; set; }
        public int sL { get; set; }
        public bool stt { get; set; }
        public string category { get; set; }
    }
}