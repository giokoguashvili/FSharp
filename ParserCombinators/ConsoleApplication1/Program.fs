// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
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

[<EntryPoint>]
let main argv = 
    let a = [|1;a|]

    let A n = [1..n]
    let B n = [|1;n|]
    let C n = (..) 1 n
    let D n = [n]
    let E n = (..) n

    let char = 'a'B

    printfn "%A" <| [|1;5|]
    printfn "%A" <| { Name = "gio"; Age = 19}
    printfn "%A" <| new Sum(2,3)
    0 // return an integer exit code
