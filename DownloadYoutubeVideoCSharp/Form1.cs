using System.Linq;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using static System.Net.WebRequestMethods;

namespace DownloadYoutubeVideoCSharp
{
    public partial class Form1 : Form
    {

        public const string enter_URL_notice = "Enter youtube URL here...";
        public bool download_result = true;

        public Form1()
        {
            InitializeComponent();
            // Auto input text from Clipboard:
            string clipboard_text_temp = Clipboard.GetText();
            if (clipboard_text_temp.Contains("www.youtube.com") == true)
            {
                textbox_link.ForeColor = Color.Black;
                textbox_link.BackColor = Color.White;
                textbox_link.Text = clipboard_text_temp;
                textbox_link.Select(0, 0);
            }
        }

        private void textbox_link_Enter(object sender, EventArgs e)
        {
            if (textbox_link.Text.Trim() == enter_URL_notice)
            {
                textbox_link.Text = "";
                textbox_link.ForeColor = Color.Black;
                textbox_link.BackColor = Color.White;
            }
        }

        private void textbox_link_Leave(object sender, EventArgs e)
        {
            if (textbox_link.Text.Trim() == "")
            {
                textbox_link.ForeColor = Color.Gray;
                textbox_link.BackColor = Color.White;
                textbox_link.Text = enter_URL_notice;
            }
        }

        private void textbox_link_TextChanged(object sender, EventArgs e)
        {
            // Change selected index to the first of textBox automatically:
            //textbox_link.Select(0, 0);
        }

        private void textbox_link_MouseClick(object sender, MouseEventArgs e)
        {
            // Auto input text from Clipboard:
            string clipboard_text_temp = Clipboard.GetText();
            if (clipboard_text_temp.Contains("www.youtube.com") == true)
            {
                textbox_link.ForeColor = Color.Black;
                textbox_link.BackColor = Color.White;
                textbox_link.Text = clipboard_text_temp;
                textbox_link.Select(0, 0);
            }
            else
            {
                textbox_link.ForeColor = Color.Black;
                textbox_link.BackColor = Color.White;
                textbox_link.Text = "";
            }
        }

        private async void button_download_YT_Click(object sender, EventArgs e)
        {
            if (textbox_link.Text.Trim() != "" && textbox_link.Text.Contains("www.youtube.com") == true)
            {
                await DownloadVideosAsync();
            }
            else
            {
                textbox_link.BackColor = Color.Red;
                textbox_link.Text = enter_URL_notice;
            }
        }

        private async Task DownloadVideosAsync()
        {
            string outputDirectory = Path.Combine(Environment.CurrentDirectory, "Downloads");
            Directory.CreateDirectory(outputDirectory);

            //List<string> videoUrls = new List<string> {
            //    "https://www.youtube.com/watch?v=WPl10ZrhCtk&list=PLvkALxvIltPFtz5z7irzAj1-g5UVw16Xg&index=3"
            //};

            Cursor.Current = Cursors.WaitCursor;
            textbox_link.Enabled = false;
            button_download_YT.Enabled = false;

            try
            {
                //var downloadTasks = videoUrls.Select(videoUrl => DownloadYouTubeVideoAsync(videoUrl, outputDirectory));
                var downloadTasks = DownloadYouTubeVideoAsync(textbox_link.Text, outputDirectory
                    , checkBox_NeedLowQualityWithSound.Checked, checkBox_NeedHighQuality.Checked);
                textbox_link.Text = "Please wait...";
                textbox_link.BackColor = Color.LightGray;
                await Task.WhenAll(downloadTasks);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while downloading the videos: {ex.Message}");
            }

            if (download_result)
            {
                textbox_link.BackColor = Color.Lime;
                textbox_link.Text = "Download Finish!!!";
            }
            //else
            //{
            //    textbox_link.BackColor = Color.Red;
            //    textbox_link.Text = "Download Fail!!!";
            //}

            button_download_YT.Enabled = true;
            textbox_link.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        static async Task DownloadYouTubeVideoAsync(string videoUrl, string outputDirectory, bool NeedLowQualityWithSound, bool NeedHighQualityNoSound)
        {
            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(videoUrl);

            // Sanitize the video title to remove invalid characters from the file name
            string sanitizedTitle = string.Join("_", video.Title.Split(Path.GetInvalidFileNameChars()));

            // Get all available muxed streams
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);
            var muxedStreams = streamManifest.GetMuxedStreams().OrderByDescending(s => s.VideoQuality.MaxHeight).ToList();

            if (muxedStreams.Any())
            {
                if (NeedLowQualityWithSound)
                {
                    /// Download voice:
                    var streamInfo = muxedStreams.First();

                    using var httpClient = new HttpClient();
                    var stream = await httpClient.GetStreamAsync(streamInfo.Url);
                    var datetime = DateTime.Now;

                    string outputFilePath = Path.Combine(outputDirectory, $"{sanitizedTitle}.{streamInfo.Container}");
                    using var outputStream = System.IO.File.Create(outputFilePath);
                    await stream.CopyToAsync(outputStream);
                }

                if (NeedHighQualityNoSound)
                {
                    /// Download videos by high quality:
                    var streamInfo = streamManifest
                            .GetVideoStreams()
                            .Where(s => s.VideoQuality.MaxHeight <= 1080)
                            .MaxBy(s => s.VideoQuality);

                    using var httpClient = new HttpClient();
                    var stream = await httpClient.GetStreamAsync(streamInfo.Url);
                    var datetime = DateTime.Now;

                    string outputFilePath = Path.Combine(outputDirectory, $"{sanitizedTitle}{"_" + streamInfo.VideoQuality}.{streamInfo.Container}");
                    using var outputStream = System.IO.File.Create(outputFilePath);
                    await stream.CopyToAsync(outputStream);
                }

                //Console.WriteLine("Download completed!");
                //Console.WriteLine($"Video saved as: {outputFilePath}{datetime}");
            }
            else
            {
                //Console.WriteLine($"No suitable video stream found for {video.Title}.");
            }
        }

    }
}
