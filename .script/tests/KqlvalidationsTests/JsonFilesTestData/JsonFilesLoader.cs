﻿using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kqlvalidations.Tests
{
    public abstract class JsonFilesLoader
    {
        protected const int TestFolderDepth = 6;

        protected abstract List<string> GetDirectoryPaths();

        public virtual List<string> GetFilesNames()
        {
            var directoryPaths = GetDirectoryPaths();
            return directoryPaths.Aggregate(new List<string>(), (accumulator, directoryPath) =>
            {
                var files = Directory.GetFiles(directoryPath, "*.json", SearchOption.AllDirectories).ToList();
                return accumulator.Concat(files).ToList();
            });
        }
    }
}