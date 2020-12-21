namespace pharmaco.model
{
    public class activity_log
    {
        public activity_log(activity_log_type type,string referenced_object_id = "",  string additional_data = "")
        {
            this.type = type;
            this.additional_data = additional_data;
            this.referenced_object_id = referenced_object_id;
        }

        public  activity_log_type type { get; set; }
        public string referenced_object_id { get; set; }
        public string additional_data { get; set; }
    }
}
