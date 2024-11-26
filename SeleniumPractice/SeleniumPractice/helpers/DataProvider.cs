using SeleniumPractice.models;

namespace SeleniumPractice.Helpers
{
    internal class DataProvider
    {
        public static IEnumerable<SearchCriterion> GetSearchCriteraTestData(string fileName)
        {
            var AssemblyDirectory = TestContext.CurrentContext.TestDirectory;
            var csvPath = Path.Combine(AssemblyDirectory, "data", fileName);

            List<SearchCriterion> searchCriteria = new();

            using (var reader = new StreamReader(csvPath))
            {
                var wasFirstLineRead = false;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (!wasFirstLineRead)
                    {
                        wasFirstLineRead = true;
                        continue;
                    }


                    var values = line.Split(',');
                    var searchCriterion = new SearchCriterion()
                    {
                        City = values[0],
                        StartDate = values[1],
                        EndDate = values[2],
                        Distance = int.Parse(values[3]),
                        Rating = values[4],
                    };

                    searchCriteria.Add(searchCriterion);
                }
            }
            return searchCriteria;
        }
    }
}
