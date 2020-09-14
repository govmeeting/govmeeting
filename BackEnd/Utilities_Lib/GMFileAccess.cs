using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GM.Utilities
{
    public static partial class GMFileAccess
    {
        public static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
            foreach (FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine(target.FullName, file.Name));
        }
        public static string Readfile(string path)
        {
            try
            {
                string text = System.IO.File.ReadAllText(path);
                return text;
            }
            catch (Exception e)
            {
                Console.WriteLine("Common.cs - The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }

        // Example: CopyDirectory(@"C:\tmp\X", @"D\tmp"); will copy X to D:\tmp\X.
        public static void CopyDirectory(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            string destination = Path.Combine(targetDirectory, diSource.Name);
            Directory.CreateDirectory(destination);
            CopyContents(sourceDirectory, destination);
        }

        // Example: CopyContents(@"C:\tmp\X", @"D\tmp"); will copy the contents of X to D:\tmp.
        public static void CopyContents(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyContentsRecursively(diSource, diTarget);
        }

        public static void CopyContentsRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Directories.cs - Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyContentsRecursively(diSourceSubDir, nextTargetSubDir);
            }
        }

        public static bool CreateDirectory(string folder, bool deleteOldFolder = false)
        {
            if (deleteOldFolder)
            {
                DeleteDirectoryAndContents(folder);
            }
            if (Directory.Exists(folder))
            {
                return false;
            }
            else
            {
                Directory.CreateDirectory(folder);
                return true;
            }
        }

        //public static bool DeleteDirectoryAndContents(string folder)
        //{
        //    if (Directory.Exists(folder))
        //    {
        //        DirectoryInfo di = new DirectoryInfo(folder);

        //        di.Delete(true);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        public static bool DeleteDirectoryAndContents(string folderName)
        {
            return (DeleteDirectoryContents(folderName, true));
        }


        public static bool DeleteDirectoryContents(string folderName, bool deleteSelf = false)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(folderName);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                string dirPath = dir.FullName;
                if (!IsDirectoryEmpty(dirPath))
                {
                    DeleteDirectoryContents(dirPath);
                }

                if (!DeleteAndMaybeSleep(dir))
                {
                    return false;
                }
            }
            if (deleteSelf)
            {
                return DeleteAndMaybeSleep(di);
            }
            return true;
        }

        public static bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        // When Windows deletes folder recursively, it does so asynchronously.
        // We may try to delete a containing folder before one of it's contents finishes being deleted.
        // This routine does up to a few millisecond pauses if there we get an exception.
        private static bool DeleteAndMaybeSleep(DirectoryInfo dir)
        {
            int maxTries = 3;
            while (maxTries-- > 0)
            {
                try
                {
                    dir.Delete(true);
                    break;
                }
                catch
                {
                    Thread.Sleep(1);
                    continue;
                }
            }
            return (maxTries > 0);
        }

        //public static bool DeleteDirectoryContents(string folderName, bool deleteSelf = false)
        //{
        //    if (!Directory.Exists(folderName)) { return false; }

        //    DeleteAllFilesInDirectory(folderName);
        //    DeleteAllFoldersInDirectory(folderName, deleteSelf);
        //    return true;
        //}

        public static bool DeleteAllFilesInDirectory(string folderName)
        {
            if (!Directory.Exists(folderName)) { return false; }

            DirectoryInfo directory = new DirectoryInfo(folderName);
            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                DeleteAllFilesInDirectory(dir.FullName);
            }
            return true;
        }

        public static bool DeleteAllFoldersInDirectory(string folderName, bool deleteSelf)
        {
            if (!Directory.Exists(folderName)) { return false; }

            DirectoryInfo directory = new DirectoryInfo(folderName);

            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                DeleteAllFoldersInDirectory(dir.FullName, true);
            }
            if (deleteSelf)
            {
                Directory.Delete(folderName);
            }
            return true;
        }

        public static void DeleteAndCreateDirectory(string folder)
        {
            if (Directory.Exists(folder))
            {
                Directory.Delete(folder, true);
            }
            Directory.CreateDirectory(folder);
        }

        // Modify the path to be the full path, if it is a relative path.
        public static string GetFullPath(string path)
        {
            if (!Path.IsPathRooted(path))
            {
                //string cd = Directory.GetCurrentDirectory();
                path = Path.Combine(Directory.GetCurrentDirectory(), path);
            }
            return Path.GetFullPath(path);
        }


        public static string FindParentFolderContaining(string file)
        {
            string current = Directory.GetCurrentDirectory();

            do
            {
                string filePath = Path.Combine(current, file);
                if (File.Exists(filePath))
                {
                    return current;
                }
                current = Path.GetDirectoryName(current);
               //Write - Host("filePath=" + $filePath + " directory=" + $directory)

            }
            while (current != null);

        return null;
        }

        public static string FindParentFolderWithName(string folder)
        {
            string current = Directory.GetCurrentDirectory();
            current = Path.GetDirectoryName(current); // start with parent of current folder
            string test;

            while (current != null)
            {              
                test = Path.Combine(current, folder);
                if (Directory.Exists(test))
                {
                    return test;
                }
                current = Path.GetDirectoryName(current);
            }

            return null;
        }

    }
}
