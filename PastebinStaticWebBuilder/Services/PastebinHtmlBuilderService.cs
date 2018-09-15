using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDBService.Interfaces;
using PastebinStaticWebBuilder.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PastebinStaticWebBuilder.Services
{
    public class PastebinHtmlBuilderService : IPatebinHtmlBuilderService
    {
        private readonly ILogger<PastebinHtmlBuilderService> _log;
        private readonly HtmlBuilderSettings _config;
        private readonly ITemplatingService _templateEngine;
        private readonly IMongoDBService _mongo; 


        public PastebinHtmlBuilderService(ILogger<PastebinHtmlBuilderService> log, IOptions<HtmlBuilderSettings> config,
            ITemplatingService templateEngine)
        {
            _log = log;
            _config = config.Value;
            _templateEngine = templateEngine;   
        }

        public async Task Initialize()
        {
            try
            {

                await Task.Run(() =>
                {
                    _templateEngine.SetDirectory(_config.Path);
                    _templateEngine.SetReplacementValues(new Dictionary<string, string>()
                    {
                        { "@nav", File.ReadAllText($"{Directory.GetCurrentDirectory()}/Templates/Components/Nav/nav.txt") }
                    });

                });
            }
            catch (Exception ex)
            {
                _log.LogCritical($"Could not initialize PastebinHtmlBuilder Service{Environment.NewLine}{ex.Message}");
            }
        }

        public async Task BuildIndex()
        {
            StringBuilder sb = new StringBuilder(); 
        }

    }

    public interface IPatebinHtmlBuilderService
    {
        Task Initialize();
    }
}
