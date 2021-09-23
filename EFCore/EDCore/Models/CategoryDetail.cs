using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace EFCore.Models
{
    public class CategoryDetail
    {
        public int CategoryDetailId { get; set; }
        public int UserId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Update { get; set; }
        public int Count { get; set; }
        public Category category {get; set;}

    }
}