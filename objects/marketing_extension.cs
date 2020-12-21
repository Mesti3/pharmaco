using pharmaco.model;
using System;
using System.Windows.Media.Imaging;

namespace pharmaco.objects
{
    public  class marketing_with_image
    {
        public marketing marketing;
        public BitmapImage horizontal_image_source;
        public BitmapImage vertical_image_source;

        public marketing_with_image(marketing marketing)
        {
            this.marketing = marketing;
            horizontal_image_source = load_image(marketing.horizontal_banner_path);
            vertical_image_source = load_image(marketing.vertical_banner_path);
        }

        private BitmapImage load_image(string path)
        {
            if (!string.IsNullOrWhiteSpace(path) )
            {

                try
                {
                    //if (!File.Exists(path))
                    //{
                    //    path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, path);
                    //}
                    return new BitmapImage(new Uri(path, UriKind.Absolute));
                }
                catch (Exception ex)
                {
                    ex.Data.Add("function", "load_image");
                    ex.Data.Add("input path", path);
                    ex.Data.Add("datetime", DateTime.Now);
                    return null;
                }
            }
            else
                return null;
        }
    }
}
