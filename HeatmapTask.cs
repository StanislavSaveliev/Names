using System.Linq;

namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var daysInMonth = 31;
            var monthsInYear = 12;
            var birthsPerDate = InitializeBirthsPerDate(daysInMonth - 1, monthsInYear);
            var dayLabels = GenerateLabels(2, daysInMonth - 1);
            var monthLabels = GenerateLabels(1, monthsInYear);

            foreach (var name in names)
            {
                if (name.BirthDate.Day != 1)
                {
                    birthsPerDate[name.BirthDate.Day - 2, name.BirthDate.Month - 1]++;
                }
            }

            return new HeatmapData(
                "Тепловая карта рождаемости по дням и месяцам",
                birthsPerDate,
                dayLabels,
                monthLabels);
        }

        private static double[,] InitializeBirthsPerDate(int days, int months)
        {
            return new double[days, months];
        }

        private static string[] GenerateLabels(int start, int count)
        {
            return Enumerable.Range(start, count).Select(number => number.ToString()).ToArray();
        }
    }
}
