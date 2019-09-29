namespace PCConfigurator.Application
{
    using System.Collections.Generic;

    public class Page<T>
    {
        public IEnumerable<T> Items { get; set; }

        public int TotalItems { get; set; }
    }
}
