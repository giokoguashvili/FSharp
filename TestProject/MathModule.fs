module Math_

let sum a b = a + b


printfn "%A" <| (sum 2 3)
let testG number producer = producer number

let sumProd = (+) 1 >> (*) 2
printfn "%A" <| sumProd 7

printfn "%A" <| ([1..10] |> List.reduce (*))

let rec fib n =
    match n with
    | 1 -> 1
    | 2 -> 1
    | n -> fib(n-1) + fib(n-2)
printfn "%A" <| fib 40