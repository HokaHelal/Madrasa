using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madrasa.Dto
{
    public class NewPostDto
    {
        public int topicId { get; set; }
        public string content { get; set; }
        public int authorId { get; set; }
    }
}
