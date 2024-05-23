﻿using System.IO;
using System.IO.Compression;

namespace IGtoOBJGen
{
    class Unzip
    {
        private string directoryName { get; set; }
        public string currentFile;
        private string tempStorageDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/Temp/IGtoOBJGenExtraction";
        private string tempTransmitDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/Temp/IGtoOBJGenTransmission";
        public Unzip(string filename)
        {
            if(Directory.Exists(tempStorageDirectory)) 
            { 
                Directory.Delete(tempStorageDirectory, true);
                Directory.CreateDirectory(tempStorageDirectory);
            }
            else
            {
                Directory.CreateDirectory(tempStorageDirectory);
            }
            string extractPath = tempDirectoryPath();
            ZipFile.ExtractToDirectory(filename, tempStorageDirectory);
            directoryName = tempStorageDirectory;
            
        }
        public void Run()
        {
            string runFolder = selectFolderFromFolder(directoryName + "\\Events");
            string file = selectFileFromFolder(runFolder);
            currentFile = file;
        }
        public void destroyStorage()
        {
            Directory.Delete(directoryName,true);
            Console.WriteLine("Temp storage cleared!");
        }
        private static string tempDirectoryPath()
        {
            string tempFolder = Path.GetTempFileName();
            File.Delete(tempFolder);
            Directory.CreateDirectory(tempFolder);
            return tempFolder;
        }
        public static string selectFolderFromFolder(string path)
        {
            string[] folders = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
            foreach (string folder in folders)
            {
                int index = Array.IndexOf(folders, folder);
                Console.WriteLine($"{index}) {folder}");
            }
            Console.WriteLine("Enter ID # of desired path:");
            int selection = int.Parse(Console.ReadLine());
            return folders[selection];
        }
        public static string selectFileFromFolder(string path)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                int index = Array.IndexOf(files, file);
                Console.WriteLine($"{index}) {file}");
            }
            Console.WriteLine("Enter ID # of desired event file:");

            int selection = int.Parse(Console.ReadLine());

            Console.WriteLine(files[selection]);

            return files[selection];
        }
    }
}
