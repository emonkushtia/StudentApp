namespace StudentApp.Core.Infastucture
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class PagedListResult<T>
        where T : class
    {
        public PagedListResult() 
        {
        }

        public PagedListResult(
            IEnumerable<T> list,
            int count)
        {
            this.List = list;
            this.Count = count;
        }

        public IEnumerable<T> List { get; set; }

        public int Count { get; set; }
    }
}