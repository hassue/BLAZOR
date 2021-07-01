namespace SamuraiApp.Domain
{
    public class Quote : BaseModel,IActive
    {
       
        public string Text { get; set; }
        public Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }
        public bool Active { get; set; }
    }
}
