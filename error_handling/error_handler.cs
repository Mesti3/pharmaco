using pharmaco.log;
using pharmaco.pages.message_box;
using System;

namespace pharmaco.error_handling
{
    public class error_handler
    {
        public static void handle_ex(Exception ex, string text_to_display,  string email_subject = "error")
        {
            message_box.show_dialog(text_to_display, System.Windows.MessageBoxButton.OK);
            logger.send_email(ex,   System.Configuration.ConfigurationManager.AppSettings["ClientID"], email_subject);
        }
        public static void send_email(Exception ex, string email_subject = "error")
        {
            logger.send_email(ex,  System.Configuration.ConfigurationManager.AppSettings["ClientID"],email_subject);
        }

    }
}
