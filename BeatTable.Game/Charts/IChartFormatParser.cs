using System.Collections.Generic;

namespace BeatTable.Game.Charts
{
    public interface IChartFormatParser
    {
        public Chart Parse(List<string> data); // Add arg for raw chart data to parse

        public int ConvertTo(Chart data); // Change datatype to custom internal object for chart data
    }
}
