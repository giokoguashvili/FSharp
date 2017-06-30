// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
module Program
open Calc
open Primitives.Types
open Temp

[<EntryPoint>]
let main argv =
    //printfn "%A" <| abs -3
    //let stack = StackContent [1..10]
    //printfn "%A" <| push 11 stack
    //let stack1 = ONE EMPTY
    //let stack2 = TWO stack1
    //let stack3 = THREE stack2
    //printfn "%A" <| stack3

    //let result321 = EMPTY |> ONE |> TWO |> THREE
    //printfn "%A" result321
    //let (top, result21) = pop result321
    //printfn "Top:%A Rest:%A" top result21

    printfn "%A" <| (EMPTY |> ONE |> TWO |> ADD |> THREE |> MUL)
    printfn "%A" <| (EMPTY |> ONE |> TWO |> ADD |> THREE |> MUL |> NEG)
    EMPTY |> ONE |> TWO |> ADD |> THREE |> MUL |> NEG |> SHOW |> ignore

    out <| sum 2 5


    0 // return an integer exit code
