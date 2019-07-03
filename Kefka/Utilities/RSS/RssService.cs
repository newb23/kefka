using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace Kefka.Utilities.RSS
{
    public class RssService
    {
        private string _feedUrl;

        public string FeedUrl
        {
            get { return _feedUrl; }
            set { _feedUrl = value; }
        }

        public RssService(string feedUrl)
        {
            _feedUrl = feedUrl;
        }

        public List<Feed> GetLatest()
        {
            var rssFeed = XmlReader.Create(_feedUrl);
            SyndicationFeed feed = SyndicationFeed.Load(rssFeed);
            rssFeed.Close();

            var feeds = feed.Items.Select(item => new Feed
            {
                Title = item.Title.Text,
                Content = item.LastUpdatedTime.LocalDateTime + "\n" + UnHtml(((TextSyndicationContent)item.Content).Text)
            }).Take(10).ToList();

            return feeds;
        }

        private static readonly Regex _tags_ = new Regex(@"<[^>]+?>", RegexOptions.Multiline | RegexOptions.Compiled);

        //add characters that are should not be removed to this regex
        private static readonly Regex _notOkCharacter_ = new Regex(@"[^\w;&#@.:/\\?=|%!() -]", RegexOptions.Compiled);

        public static String UnHtml(String html)
        {
            html = HttpUtility.UrlDecode(html);
            html = HttpUtility.HtmlDecode(html);

            html = RemoveTag(html, "<!--", "-->");
            html = RemoveTag(html, "<script", "</script>");
            html = RemoveTag(html, "<style", "</style>");

            //replace matches of these regexes with space
            html = _tags_.Replace(html, " ");
            //html = _notOkCharacter_.Replace(html, " ");
            html = SingleSpacedTrim(html);

            return html;
        }

        private static String RemoveTag(String html, String startTag, String endTag)
        {
            Boolean bAgain;
            do
            {
                bAgain = false;
                Int32 startTagPos = html.IndexOf(startTag, 0, StringComparison.CurrentCultureIgnoreCase);
                if (startTagPos < 0)
                    continue;
                Int32 endTagPos = html.IndexOf(endTag, startTagPos + 1, StringComparison.CurrentCultureIgnoreCase);
                if (endTagPos <= startTagPos)
                    continue;
                html = html.Remove(startTagPos, endTagPos - startTagPos + endTag.Length);
                bAgain = true;
            } while (bAgain);
            return html;
        }

        private static String SingleSpacedTrim(String inString)
        {
            StringBuilder sb = new StringBuilder();
            Boolean inBlanks = false;
            foreach (Char c in inString)
            {
                switch (c)
                {
                    case '\r':
                    //case '\n':
                    case '\t':
                    case ' ':
                        if (!inBlanks)
                        {
                            inBlanks = true;
                            sb.Append(' ');
                        }
                        continue;
                    default:
                        inBlanks = false;
                        sb.Append(c);
                        break;
                }
            }
            return sb.ToString().Trim();
        }
    }
}