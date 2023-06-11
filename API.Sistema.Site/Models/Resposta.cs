using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections;
using System.Collections.Generic;

namespace API.Sistema.Site.Models
{
    public class Resposta<T> where T : class
    {
        public bool success { get; set; }
        public IEnumerable<T> data { get; set; }
    }
}
