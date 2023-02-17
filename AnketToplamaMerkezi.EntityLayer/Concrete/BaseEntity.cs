using AnketToplamaMerkezi.EntityLayer.Abstract;
using System.ComponentModel.DataAnnotations;

namespace AnketToplamaMerkezi.EntityLayer.Concrete
{
    public class BaseEntity : IBaseTable
    {
        [Key]
        public int Id { get; set; }
    }
}

