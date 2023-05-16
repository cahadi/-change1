using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media.Imaging;

namespace ООО__Товары_для_животных_.Models;

public partial class Product
{
    [NotMapped]
    public BitmapImage Image { get; set; }
}