using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazbek.CommonToolkit.Extensions;

public static class ListExtensions
{
    public static void SynchronizeWith<TSource,TTarget>(this List<TSource> source, IList<TTarget> target, Func<TSource, TTarget,bool> compareFunction, Func<TTarget, TSource> converter)
    {
        source.RemoveAll(s => !target.Any(t => compareFunction(s, t)));
        source.AddRange(target.Where(t => source.All(s => !compareFunction(s, t))).Select(converter).ToList());
    }

}
