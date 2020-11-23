using System.Windows.Media.Imaging;

namespace pharmaco.model
{
    public partial class  orderItem_with_image
    {
        public orderItem order_item { get { return new orderItem() { quantity = this.quantity, med = this.med }; } }
        public int quantity;
        public medicine med;
        public BitmapImage image_source;
    }
}
