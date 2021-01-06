using System.Windows.Controls;

namespace pharmaco.components.medicine_components
{
    public partial class medicine_text_section : UserControl
    {
        public medicine_text_section()
        {
            InitializeComponent();
        }

        public medicine_text_section(model.medicine med):this()
        {
            if (!string.IsNullOrWhiteSpace(med.description))
            this.popis.Children.Add(new medicine_text_block("Popis", med.description));
            if (!string.IsNullOrWhiteSpace(med.usage))
                this.sposobPouzitia.Children.Add(new medicine_text_block("Spôsob použitia", med.usage));
            if (!string.IsNullOrWhiteSpace(med.dosage))
                this.davkovanie.Children.Add(new medicine_text_block("Dávkovanie", med.dosage));
            if (!string.IsNullOrWhiteSpace(med.warning))
                this.varovanie.Children.Add(new medicine_text_block("Varovanie", med.warning));
            if (!string.IsNullOrWhiteSpace(med.producer))
                this.vyrobca.Children.Add(new medicine_text_block("Výrobca", med.producer));

        }
    }
}

