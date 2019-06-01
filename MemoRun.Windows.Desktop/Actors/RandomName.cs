using System;
using System.Text.RegularExpressions;


namespace MemoRun.Windows.Desktop.Actors
{

    public class RandomName
    {

        public string StartWith(string prefix)
        {
            return Normalize(prefix + new Guid().ToString("N"));
        }


        private string Normalize(string actorName)
        {
            var alphaNumerics = new Regex(@"^[^\w*\d*]$");
            return alphaNumerics.Replace(actorName, string.Empty);
        }
    }
}
