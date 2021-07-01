using System.Collections.Generic;

namespace SamuraiApp.Domain
{
    public class Samurai : BaseModel, IActive
    {
        public string Name { get; set; }
        public List<Quote> Quotes { get; set; } = new List<Quote>();
        public bool Active { get; set; }
    }
}
