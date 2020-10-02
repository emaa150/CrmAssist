using System.ComponentModel.DataAnnotations.Schema;

namespace CMRmvc.Interface
{
    interface ICheckedProperty
    {
        [NotMapped]
        public bool IsChecked { get; set; }
    }
}
