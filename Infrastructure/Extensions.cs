
namespace Data.Infrastructure
{
    public static class Extensions
    {
        //public static PagedResult<TSource> ToPagedResult<TSource>(this IQueryable<TSource> source, int pageNumber, int pageSize, List<string> sortBy, List<string> sortDirection)
        //{
        //    PagedResult<TSource> pagedList = new PagedResult<TSource>();
        //    pagedList.TotalRecords = source.Count();

        //    for (int i = 0; i < sortBy.Count; i++)
        //    {
        //        if (i == 0)
        //        {
        //            source = source.OrderBy(sortBy[i], sortDirection[i]);
        //        }
        //        else
        //        {
        //            source = ((IOrderedQueryable<TSource>)source).ThenBy(sortBy[i], sortDirection[i]);
        //        }
        //    }
        //    source = source.Skip((pageNumber - 1) * pageSize);
        //    pagedList.Results = source.Take(pageSize).ToList();
        //    return pagedList;
        //}

        //public static PagedResult<TSource> ToPagedResult<TSource>(this IQueryable<TSource> source, int pageNumber, int pageSize, string sortBy, string sortDirection)
        //{
        //    List<string> sortByList = new List<string>();
        //    List<string> sortByDirectionList = new List<string>();
        //    if (!string.IsNullOrEmpty(sortBy))
        //    {
        //        sortByList.Add(sortBy);
        //    }

        //    if (!string.IsNullOrEmpty(sortDirection))
        //    {
        //        sortByDirectionList.Add(sortDirection);
        //    }
        //    PagedResult<TSource> pagedList = source.ToPagedResult(pageNumber, pageSize, sortByList, sortByDirectionList);
        //    return pagedList;
        //}
    }
}
