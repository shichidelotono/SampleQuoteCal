namespace SampleApi1.Representation
{
    public class Quote
    {
        public string Url { get; }

        public Quote(string url)
        {
            Url = url;
        }
    }
}
