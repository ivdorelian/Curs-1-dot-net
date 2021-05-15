using System;
using System.Collections.Generic;

namespace Curs_1.ViewModels
{
    public class ProductWithCommentsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
