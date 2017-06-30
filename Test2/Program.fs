// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
module Program

type Box = {Name:string; Age:int}

open Gio.Types
open Primitives.Types
open Calc

let box = {Name="gio";Age=25}
let sum x y = (+) x y
let prod x y = (*) x y

let compose f g x = f (g x)

let sum2 = sum 2
let prod3 = prod 3
let sum2prod3 = sum2 >> prod3
let _sum2prod3 = compose sum2 prod3
let sum23 = sum 2 3

let sumABC a b c = a + b + c
let sum23c = sumABC 2 3 

[<EntryPoint>]
let main argv =
    printfn "%A" <| abs -3
    let stack = StackContent [1..10]
    printfn "%A" <| push 11 stack
    let stack1 = ONE EMPTY
    let stack2 = TWO stack1
    let stack3 = THREE stack2
    printfn "%A" <| stack3

    let result321 = EMPTY |> ONE |> TWO |> THREE
    printfn "%A" result321
    let (top, result21) = pop result321
    printfn "Top:%A Rest:%A" top result21

    printfn "%A" <| (EMPTY |> ONE |> TWO |> ADD |> THREE |> MUL)
    0 // return an integer exit code
