using System;

namespace Nails.Models
{
    public class ContentBlock
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string HtmlId { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}