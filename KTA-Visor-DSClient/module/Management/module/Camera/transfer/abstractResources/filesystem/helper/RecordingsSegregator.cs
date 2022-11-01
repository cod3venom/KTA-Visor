using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Threading.Tasks;
using VisioForge.Core.MediaInfo;

namespace KTA_Visor_DSClient.module.Management.module.Camera.transfer.abstractResources.filesystem.helper
{
    public class RecordingsSegregator
    {
        private List<FileInfo> _files;
        public RecordingsSegregator()
        {

        }

        public void Segregate(string targetDir)
        {
            DirectoryInfo filesDir = new DirectoryInfo(targetDir);
            FileInfo[] videos = filesDir.GetFiles("*.mp4");

            foreach (FileInfo video in videos)
            {
                var infoReader = new MediaInfoReader();
                infoReader.Filename = video.Name;
                infoReader.ReadFileInfo(true);

                string mmInfo = "";
                for (int i = 0; i < infoReader.VideoStreams.Count; i++)
                {
                    var stream = infoReader.VideoStreams[i];

                    mmInfo += string.Empty + Environment.NewLine;
                    mmInfo += "Video #" + Convert.ToString(i + 1) + Environment.NewLine;
                    mmInfo += "Codec: " + stream.Codec + Environment.NewLine;
                    mmInfo += "Duration: " + stream.Duration.ToString() + Environment.NewLine;
                    mmInfo += "Width: " + stream.Width + Environment.NewLine;
                    mmInfo += "Height: " + stream.Height + Environment.NewLine;
                    mmInfo += "FOURCC: " + stream.FourCC + Environment.NewLine;
                    mmInfo += "Aspect Ratio: " + $"{stream.AspectRatio.Item1}:{stream.AspectRatio.Item2}" + Environment.NewLine;
                    mmInfo += "Frame rate: " + stream.FrameRate + Environment.NewLine;
                    mmInfo += "Bitrate: " + stream.Bitrate + Environment.NewLine;
                    mmInfo += "Frames count: " + stream.FramesCount + Environment.NewLine;
                }

                Console.WriteLine(mmInfo + Environment.NewLine);
            }
        }
    }
}
