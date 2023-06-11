using System.Collections.Generic;

namespace API.Sistema.Site.Models
{
    public class RespostaSingle<T> where T : class
    {
        public bool success { get; set; }
        public T data { get; set; }
        public string[] errors { get; set; }
    }
}
