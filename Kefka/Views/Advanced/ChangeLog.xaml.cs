using System.Windows;
using Kefka.Utilities.RSS;

namespace Kefka.Views.Advanced
{
    /// <summary>
    /// Interaction logic for ChangeLog.xaml
    /// </summary>
    public partial class ChangeLog
    {
        public ChangeLog()
        {
            InitializeComponent();
            BindLatestFeeds();
        }

        private void BindLatestFeeds()
        {
            string url = "https://github.com/newb23/Omnicode/commits/master.atom";
            var rssService = new RssService(url);

            icFeeds.ItemsSource = rssService.GetLatest();
        }
    }
}