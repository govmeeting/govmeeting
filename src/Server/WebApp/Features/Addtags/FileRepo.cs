using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    class FileRepo
    {
        public string GetLatest(string dirPath)
        {
            DirectoryInfo dir = new DirectoryInfo(@"..\..\..\testdata");
            //FileInfo[] imageFiles = dir.GetFiles("*.jpg");
            FileInfo[] imageFiles = dir.GetFiles("Step 2*.json");
            return "x";
        }
    }
}
