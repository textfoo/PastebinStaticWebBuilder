using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PastebinStaticWebBuilder.Services
{
    public class TemplatingService : ITemplatingService
    {
        private string _dir; 
        private Dictionary<string, string> _replacementValues { get; set; } = new Dictionary<string, string>();
        private Dictionary<string, string> _pages { get; set; } = new Dictionary<string, string>(); 

        private readonly ILogger<TemplatingService> _log; 

        public TemplatingService(ILogger<TemplatingService> log)
        {
            _log = log; 
        }

        public void SetDirectory(string dir)
        {
            _dir = dir; 
        }

        public void SetReplacementValues(Dictionary<string, string> replacementValues)
        {
            _replacementValues = replacementValues;
        }
    }

    public interface ITemplatingService
    {
        void SetReplacementValues(Dictionary<string, string> replacementValues);
        void SetDirectory(string dir);
    }
}
