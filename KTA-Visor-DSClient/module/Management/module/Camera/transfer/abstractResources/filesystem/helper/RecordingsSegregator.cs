using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Threading.Tasks;
using NReco.VideoInfo;

namespace KTA_Visor_DSClient.module.Management.module.Camera.transfer.abstractResources.filesystem.helper
{
    public class RecordingsSegregator
    {
        private const int ONE_FULL_RECORD_DURATION = 2; //2hours
        private List<FileInfo> _files;

        public RecordingsSegregator()
        {

        }

        public void Segregate(DirectoryInfo gallery)
        {
            List<FileInfo> videos = new List<FileInfo>(gallery.GetFiles("*.mp4"));
            List<FileInfo> fullRecords = new List<FileInfo>();
            List<FileInfo> singleRecord = new List<FileInfo>();
            var ffProbe = new FFProbe();
            for (int i = 0; i < videos.Count - 1; i++)
            {
                if (videos.Count <= (i+i)){
                    continue;
                }

                FileInfo current = videos[i];
                FileInfo next = videos[i + 1];

                if (current.Exists && next.Exists)
                {
                    var currentVideoInfo = ffProbe.GetMediaInfo(current.FullName);

                    Console.WriteLine("Media information for: {0}", current.FullName);
                    Console.WriteLine("File format: {0}", currentVideoInfo.FormatName);
                    Console.WriteLine("Duration: {0}", currentVideoInfo.Duration);


                    var nextVideoInfo = ffProbe.GetMediaInfo(next.FullName);


                    Console.WriteLine("Media information for: {0}", next.FullName);
                    Console.WriteLine("File format: {0}", nextVideoInfo.FormatName);
                    Console.WriteLine("Duration: {0}", nextVideoInfo.Duration);

                    if ((currentVideoInfo.Duration.Hours == ONE_FULL_RECORD_DURATION) && (nextVideoInfo.Duration.Hours == ONE_FULL_RECORD_DURATION))
                    {
                        fullRecords.Add(current);
                    }
                }

                else if (next.Exists)
                {
                    singleRecord.Add(next);
                }

                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(fullRecords));
            }
        }

    }
}
