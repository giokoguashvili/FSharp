module PipetInto

let x = 1
let y = 2
let z = x + y

//let x' = 1 in
//    let y' = 2 in
//        let z' = x' + y' in 
//            z'  |> ignore
   
let pipe = 
    1 |> fun x ->
    2 |> fun y ->
    x + y |> fun z ->
    z

printfn "%A" pipe

let pipeInto (someExpression, lambda) =
    printfn "expression is %A" someExpression
    someExpression |> lambda

let pipeInto' (someExpression, lambda) =
    printfn "expression is %A" someExpression
    match someExpression with
    | None -> None
    | Some s -> lambda s

let pipe' =
    pipeInto (1, fun x ->
    pipeInto (22, fun y ->
    pipeInto (x + y, fun z ->
    z)))

printfn "%A" pipe'

let dividedBy x y = 
    printfn "x: %A y: %A" x y
    if y = 0 
    then None
    else Some (x/y)

let dividedByWorkflow x y z = 
        pipeInto' (y |> dividedBy x, fun a ->
        pipeInto' (a |> dividedBy z, fun b ->
        Some b))
        
let result = dividedByWorkflow 109 2 3
printfn "%A" result

type Logger() =
    member this.Bind(expression, fn) = 
        match expression with
        | None -> None
        | Some s -> fn s
    member this.Return(x) = Some x

let logger = new Logger()
let loggedDividedByWorkflow a b c = 
    logger 
        {
        let! x = b |> dividedBy a
        let! y = c |> dividedBy x
        return y
        }

let result' = loggedDividedByWorkflow 109 2 3
printfn "%A" result'