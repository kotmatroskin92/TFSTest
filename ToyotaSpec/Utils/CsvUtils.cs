using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;

namespace ToyotaSpec.Utils
{
    public class CsvUtils
    {
        private readonly CsvReader _csv;

        public CsvUtils(string path)
        {
            var steam = File.OpenText(path);
            var config = new CsvHelper.Configuration.Configuration
            {
                HasHeaderRecord = true,
                PrepareHeaderForMatch = (header, index) => header.Replace(" ", string.Empty).Replace(".", string.Empty)
            };
            _csv = new CsvReader(steam, config);
        }

        public List<T> GetListOf<T>()
        {
            return _csv.GetRecords<T>().ToList();
        }
    }
}
