using Microsoft.Extensions.Logging;
using PastebinStaticWebBuilder.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PastebinStaticWebBuilder
{
    public class App
    {
        private readonly ILogger<App> _log;
        private readonly IPatebinHtmlBuilderService _htmlBuilder; 

        public App(ILogger<App> log, IPatebinHtmlBuilderService htmlBuilder)
        {
            _log = log;
            _htmlBuilder = htmlBuilder; 
        }

        public async Task Run()
        {

        }
    }
}
