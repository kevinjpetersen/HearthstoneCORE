using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using HearthstoneCORE.Services;

namespace HearthstoneCORE.Services
{
    public class MusicService : IMusicService
    {
        public void PlaySongByPath(string path)
        {
            try
            {
                Play(path);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private Process Play(string path)
        {
            return Process.Start(new ProcessStartInfo
            {
                FileName = "mplayer",
                Arguments = $@"""{path}""",
                UseShellExecute = false,
                RedirectStandardOutput = true
            });
        }
    }
}
