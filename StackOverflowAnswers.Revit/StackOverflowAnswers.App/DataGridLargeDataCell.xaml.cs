using System.Collections.Generic;
using System.Windows;

namespace StackOverflowAnswers.Wpf
{
    public class Data
    {
        public string Description { get; set; }
    }
    /// <summary>
    /// Interaction logic for DataGridLargeDataCell.xaml
    /// </summary>
    public partial class DataGridLargeDataCell : Window
    {
        public List<Data> Datas { get; set; } = new List<Data>
        {
            new Data { Description = "So how did the classical Latin become so incoherent? According to McClintock, a 15th century typesetter likely scrambled part of Cicero's De Finibus in order to provide placeholder text to mockup various fonts for a type specimen book.\r\n\r\nIt's difficult to find examples of lorem ipsum in use before Letraset made it popular as a dummy text in the 1960s, although McClintock says he remembers coming across the lorem ipsum passage in a book of old metal type samples. So far he hasn't relocated where he once saw the passage, but the popularity of Cicero in the 15th century supports the theory that the filler text has been used for centuries." },
            new Data { Description = "A nice short description." },
            new Data {
                Description = "Until recently, the prevailing view assumed lorem ipsum was born as a nonsense text. “It's not Latin, though it looks like it, and it actually says nothing,” Before & After magazine answered a curious reader, “Its ‘words’ loosely approximate the frequency with which letters occur in English, which is why at a glance it looks pretty real.”\r\n\r\nAs Cicero would put it, “Um, not so fast.”\r\n\r\nThe placeholder text, beginning with the line “Lorem ipsum dolor sit amet, consectetur adipiscing elit”, looks like Latin because in its youth, centuries ago, it was Latin.\r\n\r\nRichard McClintock, a Latin scholar from Hampden-Sydney College, is credited with discovering the source behind the ubiquitous filler text. In seeing a sample of lorem ipsum, his interest was piqued by consectetur—a genuine, albeit rare, Latin word. Consulting a Latin dictionary led McClintock to a passage from De Finibus Bonorum et Malorum (“On the Extremes of Good and Evil”), a first-century B.C. text from the Roman philosopher Cicero.\r\n\r\nIn particular, the garbled words of lorem ipsum bear an unmistakable resemblance to sections 1.10.32–33 of Cicero's work, with the most notable passage excerpted below:\r\n\r\n“Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.”\r\nA 1914 English translation by Harris Rackham reads:\r\n\r\n“Nor is there anyone who loves or pursues or desires to obtain pain of itself, because it is pain, but occasionally circumstances occur in which toil and pain can procure him some great pleasure.”\r\nMcClintock's eye for detail certainly helped narrow the whereabouts of lorem ipsum's origin, however, the “how and when” still remain something of a mystery, with competing theories and timelines."
            },
            new Data { Description = "A nice short description." },
            new Data { Description = "A nice short description." },
        };

        public DataGridLargeDataCell()
        {
            DataContext = this;
            InitializeComponent();
        }
    }
}
