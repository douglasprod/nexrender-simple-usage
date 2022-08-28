using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexrender_tutorial.Models
{
    public class NexrenderDataModel
    {
        public Template template { get; set; }
        public List<Assets> assets { get; set; }
        public Actions actions { get; set; }
    }

    public class Actions
    {
        public List<PostRender> postrender { get; set; }
    }

    public class PostRender
    {
        public string module { get; set; }
        public string preset { get; set; }
        public string output { get; set; }
        public string input { get; set; }
    }

    public class Assets
    {
        public string src { get; set; }
        public string type { get; set; }
        public string property { get; set; }
        public string value { get; set; }
        public string layerName { get; set; }
    }

    public class Template
    {
        public string src { get; set; }
        public string composition { get; set; }
    }
}
