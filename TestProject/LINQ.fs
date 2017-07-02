module LINQ

open System
open System.Linq

let select  f xs = Enumerable.Select(xs, new Func<_,_>(f))
let where   f xs = Enumerable.Where(xs, new Func<_,_>(f))
let orderBy f xs = Enumerable.OrderBy(xs, new Func<_,_>(f))

