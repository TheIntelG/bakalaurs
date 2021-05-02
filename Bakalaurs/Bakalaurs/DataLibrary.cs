using System;
using System.Collections.Generic;
using System.Text;

namespace Bakalaurs
{
    public class DataLibrary
    {
        // Design FilePath Storage
        private static string designFilePath;
        public static string DesignFilePath
        {
            get { return designFilePath; }
            set { designFilePath = value; }
        }

        public void setDesignFilePath(string filePath)
        {
            DesignFilePath = filePath;
        }

        public string getDesignFilePath()
        {
            return DesignFilePath;
        }
    }
}
