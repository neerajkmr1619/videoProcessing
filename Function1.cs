using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace VideoProcessor
{
    public static class ActivityFunctions
    {
        
        [FunctionName("TranscodeVideo")]
        public static async Task<string> TranscodeVideo([ActivityTrigger] string inputVideo, ILogger log)
        {
            log.LogInformation($"Transcode video {inputVideo}.");

            await Task.Delay(5000);
            return $"{Path.GetFileNameWithoutExtension(inputVideo)}-transcoded.mp4";
        }

        [FunctionName("ExtractThumbnail")]
        public static async Task<string> ExtractThumbnail([ActivityTrigger] string inputVideo, ILogger log)
        {
            log.LogInformation($"Extract thumbnail {inputVideo}.");

            await Task.Delay(5000);
            return $"{Path.GetFileNameWithoutExtension(inputVideo)}-thumbnail.png";
        }
        [FunctionName("PrependIntro")]
        public static async Task<string> PrependIntro([ActivityTrigger] string inputVideo, ILogger log)
        {
            var introLocation = Environment.GetEnvironmentVariable("Introduction");
            log.LogInformation($"Pretending intro {inputVideo}.");

            await Task.Delay(5000);
            return $"{Path.GetFileNameWithoutExtension(inputVideo)}-withintro.mp4";
        }

    }
}