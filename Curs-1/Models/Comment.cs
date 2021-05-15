using System;
namespace Curs_1.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public int Stars { get; set; }
        public Product Product { get; set; }
    }
}
