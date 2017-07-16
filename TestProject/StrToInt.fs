module StrToInt
open System

let strToInt str = 
    let mutable parsed = 0
    let isParsed = Int32.TryParse(str, &parsed)
    printfn "%A" isParsed
    if isParsed = true
    then Some(parsed)
    else None

type StrParserWorkflow() =
    member this.Bind(x, f) =
        printfn "x: %A" x 
        match x with
        | None -> None
        | Some s ->
            s |> f
    member this.Return(x) = Some x
    member this.ReturnFrom(x) = x

let strParserWorkflow = new StrParserWorkflow()

let stringAddWorkflow x y z =
    strParserWorkflow
        {
        let! a = strToInt x
        let! b = strToInt y
        let! c = strToInt z
        return a + b + c
        }

let good = stringAddWorkflow "1" "2" "3"
let bad = stringAddWorkflow "1" "xyz" "4"

printfn "%A" good
printfn "%A" bad

let strAdd str i =
    strParserWorkflow
        {
            let! c = strToInt str 
            return c + i
        }

let ( >>= ) m f = Option.bind f m

let good' = strToInt "10" >>= strAdd "1" >>= strAdd "3"
let bad' = strToInt "10" >>= strAdd "x1" >>= strAdd "3"
printfn "%A" good'
printfn "%A" bad'

    

