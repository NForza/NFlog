using System;
using NFlog.Core;

namespace NFlog.Viewer
{
    public static class NFlogMessageExtensions
    {
        public static bool MatchesSearchString(this NFlogMessage message, string searchString)
        {
            return ContainsSearchString(message.AppName, searchString) || ContainsSearchString(message.Message, searchString);
        }

        private static bool ContainsSearchString(string p, string searchString)
        {
            if (String.IsNullOrEmpty(searchString))
                return true;
            return p.Contains(searchString);
        }        
    }
}
