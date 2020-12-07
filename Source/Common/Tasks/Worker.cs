using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace mbaaz.AdventOfCode2020.Common.Tasks
{
    public abstract class Worker
    {
        private readonly Settings.Settings _settings;
        public abstract int DayNumber { get; }

        private const string INPUT_FILENAME = "input.txt";
        private const string INPUT_FILE_URL_FORMAT = "https://adventofcode.com/{0}/day/{1}/input";

        private string INPUT_FILE_URL => string.Format(INPUT_FILE_URL_FORMAT, _settings.Year, DayNumber);

        public Worker(Settings.Settings settings)
        {
            _settings = settings;
        }

        protected IEnumerable<string> GetTaskInput()
        {
            if (File.Exists(INPUT_FILENAME))
            {
                var input = File.ReadAllLines(@"input.txt");
                return input;
            }

            try
            {
                var input = DownloadInput().ToArray();
                CreateFile(input);
                return input;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private IEnumerable<string> DownloadInput()
        {
            if (string.IsNullOrEmpty(_settings.SessionID))
            {
                throw new ApplicationException("SessionID is not set!");
            }

            var streamTask = GetInputFileStream();

            try
            {
                streamTask.Wait();
            }
            catch (Exception)
            {
                return null;
            }

            //using var inputStream = streamTask.Result;
            var inputStream = streamTask.Result;
            return ReadStream(inputStream);
        }

        private async Task<StreamReader> GetInputFileStream()
        {
            var httpClient = new System.Net.Http.HttpClient();
            httpClient.DefaultRequestHeaders.Add("cookie",  $"session={_settings.SessionID}");
            var stream = await httpClient.GetStreamAsync(INPUT_FILE_URL);
            return new StreamReader(stream);
        }

        private IEnumerable<string> ReadStream(StreamReader inputStream)
        {
            string line;
            while ((line = inputStream.ReadLine()) != null)
            {
                yield return line;
            }
        }

        private void CreateFile(IEnumerable<string> input)
        {
            using var writer = File.CreateText(INPUT_FILENAME);
            foreach (var line in input)
                writer.WriteLine(line);
            writer.Close();
        }
    }
}