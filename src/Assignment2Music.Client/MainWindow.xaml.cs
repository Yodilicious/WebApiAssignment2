namespace Assignment2Music.Client
{
    using System;
    using System.Windows;
    using System.Windows.Documents;
    using ViewModels;
    using Helper;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CmdArtistGetAll_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.GetRequest("v1/artists");

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdArtistGetOne_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.GetRequest("v1/artist/1");

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdArtistInsert_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.PostRequest("v1/artist", new ArtistViewModel
            {
                RecordId = 0,
                ArtistName = "Test Artist",
                FirstName = "Jonny",
                LastName = "Five",
                Username = "jonny.five@gmail.com",
                Password = "Secure"
            });

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdArtistUpdate_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.PutRequest("v1/artist/1", new ArtistViewModel
            {
                RecordId = 1,
                ArtistName = "Test Artist",
                FirstName = "Jonny",
                LastName = "Six",
                Username = "jonny.six@gmail.com",
                Password = "Secure"
            });

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdArtistDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.DeleteRequest("v1/artist/1");

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdTrackGetAll_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.GetRequest("v1/tracks");

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdTrackGetOne_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.GetRequest("v1/track/1");

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdTrackInsert_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.PostRequest("v1/track", new TrackViewModel
            {
                RecordId = 0,
                ArtistName = "Test Artist",
                ArtistId = 2,
                GenreId = 2,
                GenreName = "Pop",
                PostedOn = DateTime.Now,
                TrackLength = 201,
                TrackName = "Test Track"
            });

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdTrackUpdate_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.PutRequest("v1/track/1", new TrackViewModel
            {
                RecordId = 1,
                ArtistName = "",
                ArtistId = 2,
                GenreId = 2,
                GenreName = "",
                PostedOn = DateTime.Now,
                TrackLength = 201,
                TrackName = "Test Track Update"
            });

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdTrackDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.DeleteRequest("v1/track/1");

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdGenreGetAll_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.GetRequest("v1/genres");

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdGenreGetOne_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.GetRequest("v1/genre/1");

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdGenreInsert_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.PostRequest("v1/genre", new GenreViewModel
            {
                RecordId = 0,
                Name = "Cool Track Insert",
                Description = "Cool Track Insert Description"
            });

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdGenreUpdate_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.PutRequest("v1/genre/1", new GenreViewModel
            {
                RecordId = 1,
                Name = "Cool Track Update",
                Description = "Cool Track Update Description"
            });

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdGenreDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.DeleteRequest("v1/genre/1");

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdReviewGetAll_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.GetRequest("v1/reviews");

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdReviewGetAllForTrack_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.GetRequest("v1/reviews/track/2");

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdReviewGetOne_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.GetRequest("v1/review/1");

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdReviewInsert_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.PostRequest("v1/review", new ReviewViewModel
            {
                RecordId = 0,
                ArtistId = 2,
                ArtistName = "",
                ReviewedOn = DateTime.Now,
                ReviewText = "Insert Review Text",
                TrackId = 2,
                TrackName = ""
            });

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdReviewUpdate_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.PutRequest("v1/review/1", new ReviewViewModel
            {
                RecordId = 1,
                ArtistId = 2,
                ArtistName = "",
                ReviewedOn = DateTime.Now,
                ReviewText = "Update Review Text",
                TrackId = 2,
                TrackName = ""
            });

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }

        private void CmdReviewDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = RestClientHelper.DeleteRequest("v1/review/1");

            this.RtbResult.Document.Blocks.Clear();
            this.RtbResult.Document.Blocks.Add(new Paragraph(new Run(result)));
        }
    }
}
