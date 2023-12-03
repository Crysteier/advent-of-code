using System.Net;
using System.Text.RegularExpressions;

namespace AdventOfCode.Shared
{
    public class ProblemSolver
    {
        public readonly List<string> input = new List<string>();
        public readonly List<string> test = new List<string>();

        private readonly string _day;
        private readonly string _year;
        private readonly string _folderPath;

        public ProblemSolver(string year, string day)
        {
            _year = year;
            _day = day;
            _folderPath = year + "/" + day;
        }

        public void ReadAllInputs()
        {
            ReadTests();
            ReadInput();
        }

        /// <summary>
        /// Reads the whole input into a single string. Sometimes this is needed.
        /// </summary>
        /// <returns></returns>
        public string ReadPlainInput(bool test = false)
        {
            var file = "//input.txt";
            if (test)
            {
                file = "//test.txt";
            }
            var fullPath = _folderPath + $"{file}";

            try
            {
                var sr = new StreamReader(fullPath);
                var result = sr.ReadToEnd();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void ReadTests()
        {
            var fullPath = _folderPath + $"//test.txt";
            try
            {
                var sr = new StreamReader(fullPath);
                var line = sr.ReadLine();
                while (line is not null)
                {
                    test.Add(line);
                    line = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void ReadInput()
        {
            var fullPath = _folderPath + $"//input.txt";
            try
            {
                var sr = new StreamReader(fullPath);
                var line = sr.ReadLine();
                while (line is not null)
                {
                    input.Add(line);
                    line = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private string GetSession()
        {
            if (!Environment.GetEnvironmentVariables().Contains("SESSION"))
            {
                throw new ArgumentException("Specify SESSION environment variable");
            }
            return Environment.GetEnvironmentVariable("SESSION");
        }

        public async Task DownloadInput()
        {
            string outputFile = _year + "/" + _day + "/input.txt";
            string projectOutputFile = "C:\\repos\\advent-of-code\\AdventOfCode\\" + _year + "\\" + _day + "\\input.txt";
            if (File.Exists(outputFile) && File.Exists(projectOutputFile))
            {
                return;
            }

            string dayNum = Regex.Match(_day, @"\d+", RegexOptions.RightToLeft).Value;
            string yearNum = Regex.Match(_year, @"\d+", RegexOptions.RightToLeft).Value;
            string url = $"https://adventofcode.com/{yearNum}/day/{dayNum}/input";

            string cookieValue = GetSession();
            using (var handler = new HttpClientHandler())
            {
                handler.CookieContainer = new CookieContainer();

                handler.CookieContainer.Add(new Uri(url), new Cookie("session", cookieValue));

                using (var client = new HttpClient(handler))
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();

                        EnsureDirectoryExists(outputFile);

                        using (StreamWriter writer = new StreamWriter(outputFile, true))
                        {
                            writer.WriteLine(content);
                        }
                        using (StreamWriter writer = new StreamWriter(projectOutputFile, true))
                        {
                            writer.WriteLine(content);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
        }

        private static void EnsureDirectoryExists(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            if (!fi.Directory.Exists)
            {
                System.IO.Directory.CreateDirectory(fi.DirectoryName);
            }
        }
    }
}
