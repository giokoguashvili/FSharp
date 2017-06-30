module Temp

let out a = printfn "%A" a

let rec sum a b = 
    if a > b then 0
    else a + sum (a + 1) b

let rec iter a b fn i =
    if a > b then i
    else fn a (iter(a + 1) b fn i)

let _sum a b = iter a b (+) 0

let f x = x*2+1
let f1 = fun x -> x*2+1
let f2 = (*)2 >> (+)1 

f2 4