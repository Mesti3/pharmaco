namespace pharmaco.model
{
    //dbclass only
    public partial class orderItem
    {
        public medicine med;
        public decimal quantity;
        public string name;
        public decimal? price;
        public order_item_source source;
    }
}
