using System;
using System.IO;

namespace Robber_2D
{
    class ScoreLogger
    {
        public void Save(string score)
        {
            CreateFolder();
            CreateFile(score);
        }

        private void CreateFolder()
        {
            string folderPath = @"c:\Robber2D";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        private void CreateFile(string score)
        {
            DateTime currentTime = DateTime.Now;
            string fileName = "Score " + currentTime.ToString("MM-dd-yyyy_HH-mm-ss");

            string path = $@"c:\Robber2D\{fileName}.txt";

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Robber 2D Score:");
                    sw.WriteLine(score);
                }
            }
        }
    }
}
