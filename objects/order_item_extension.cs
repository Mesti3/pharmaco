using System.Windows.Media.Imaging;

namespace pharmaco.model
{
    public partial class  orderItem_with_image
    {
        public orderItem order_item { get { return new orderItem() { quantity = this.quantity, med = this.med , source = this.source, price = this.med.price}; } }
        public int quantity;
        public medicine med;
        public order_item_source source;
        public decimal price;
        public BitmapImage image_source;
    }
}
