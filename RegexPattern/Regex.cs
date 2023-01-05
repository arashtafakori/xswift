namespace Artaware.Infrastructure.CoreX
{
    public abstract class Regex
    {
        public Regex(string pattern)
        {
            Pattern = pattern;
        }
        public string Pattern { get; private set; }
    }
}
