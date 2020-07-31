using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab11_5EFCoreDbContextLINQSakilaDB
{
    class FileWriter
    {
        #region Fields and Properties

        // private const string userLogFile = @"C:\weblogs\userlog.txt";

        private string fileNameWithPath;
        private string inputTextData;

        #endregion

        #region Constructors

        public FileWriter()
        {

        }

        public FileWriter(string fileNameWithPath, string inputTextData)
        {
            this.fileNameWithPath = fileNameWithPath;
            this.inputTextData = inputTextData;
        }

        #endregion

        #region Methods

        public void WriteThisFile()
        {
            //string fileName = userLogFile;
            //string data = "Print this info to a log. \n";

            string fileName = fileNameWithPath;
            string data = inputTextData;
            File.AppendAllText(fileName, data);

        }

        #endregion

    }
}
