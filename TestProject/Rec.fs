module Rec

type Person = {
    Name: string
    Age: int
    }

type Sum (a, b) =
    member this.Result() =
        a + b

let printList aAction aList =
    for i in aList do
        aAction i

let rec y f x = f (y f) x

[<Measure>]
type cm

let x = 1<cm>
let A n = [1..n]
let B n = [|1;n|]
let C n = (..) 1 n
let D n = [n]
let E n = (..) n

let char = 'a'B

printfn "%A" <| [|1;5|]
printfn "%A" <| { Name = "gio"; Age = 19}
printfn "%A" <| new Sum(2,3)