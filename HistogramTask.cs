namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var days = InitializeDaysArray();
            var birthsCounts = new double[31];
            for (int i = 0; i < birthsCounts.Length; i++)
            {
                birthsCounts[i] = 0;
            }

            foreach (var nameData in names)
            {
                if (nameData.Name == name && nameData.BirthDate.Day != 1)
                {
                    birthsCounts[nameData.BirthDate.Day - 1]++;
                }
            }

            return new HistogramData(
                $"Рождаемость людей с именем '{name}'",
                days,
                birthsCounts);
        }

        private static string[] InitializeDaysArray()
        {
            var days = new string[31];
            for (int i = 0; i < days.Length; i++)
            {
                days[i] = (i + 1).ToString();
            }
            return days;
        }
    }
}
