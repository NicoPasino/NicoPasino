using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoPasino.Core.DTO.Movies
{
    public class MovieDto
    {
        public string? title { get; set; }
        public int year { get; set; }
        public string? director { get; set; }
        public int duration { get; set; }
        public string? poster { get; set; }
        public IEnumerable<string>? genre { get; set; }
        public float rate { get; set; }
    }
}
