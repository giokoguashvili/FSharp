// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System

let A_Parser str =
    if String.IsNullOrEmpty(str) then
        (false,"")
    else if str.[0] = 'A' then
        let remaining = str.[1..]
        (true,remaining)
    else
        (false,str)

type Result<'a> =
    | Success of 'a
    | Failure of string

type Parser<'T> = Parser of (string -> Result<'T * string>)

let pchar charToMatch =
    let innerFn str =
        if String.IsNullOrEmpty(str) then
            Failure "No more input"
        else 
            let first = str.[0]
            if first = charToMatch then
                let remaining = str.[1..]
                let msg = sprintf "Found %c" charToMatch
                Success(charToMatch,remaining)
            else
                let msg = sprintf "Expecting '%c'. Got '%c'" charToMatch first
                Failure msg
    Parser innerFn

let run parser input = 
    let (Parser innerFn) = parser
    innerFn input

let andThen parser1 parser2 =
    let innerFn input =
        let result = run parser1 input
        match result with
        | Failure err -> Failure err
        | Success (value1,remaining1) ->
            let result2 = run parser2 remaining1
            match result2 with
            | Failure err ->  Failure err
            | Success (value2,remaining2) -> 
                let newValue = (value1,value2)
                Success (newValue,remaining2)
    Parser innerFn

let orElse parser1 parser2 =
    let innerFn input =
        let result1 = run parser1 input
        match result1 with
        | Success result -> result1
        | Failure err ->
            let result2 = run parser2 input
            result2
    Parser innerFn

let mapP f parser =
    let innerFn input =
        let result = run parser input
        match result with
        | Success (value,remaining) -> 
            let newValue = f value
            Success (newValue,remaining)
        |Failure err -> 
            Failure err
    Parser innerFn

let ( .>>. ) = andThen
let ( <|> ) = orElse

let ( <!> ) = mapP
let ( |>> ) x f = mapP f x

let choice listOfParsers =
    List.reduce ( <|> ) listOfParsers

let anyOf listOfChars =
    listOfChars
    |> List.map pchar
    |> choice

let parseDigit =
    anyOf ['0'..'9']

let parseDigits =
         parseDigit .>>. parseDigit .>>. parseDigit .>>. parseDigit    


[<EntryPoint>]
let main argv = 
    printfn "%A" <| A_Parser "ABC"
    printfn "%A" <| A_Parser "BBC"

    let parseA = pchar 'A'
    let parseB = pchar 'B'

    printfn "%A" <| run parseA "BBC"
    printfn "%A" <| run parseB "BBC"

    let parseAThenB = parseA .>>. parseB
    printfn "%A" <| run parseAThenB "ABC"
    printfn "%A" <| run parseAThenB "BBC"

    let parseAOrElseB = parseA <|> parseB
    printfn "%A" <| run parseAOrElseB "ABC"
    printfn "%A" <| run parseAOrElseB "BBC"
    printfn "%A" <| run parseAOrElseB "KBC"

    let parserLowercase = anyOf ['a'..'b']
    let parseDigit = anyOf ['0'..'9']

    printfn "%A" <| run parserLowercase "aBC"
    printfn "%A" <| run parserLowercase "BBC"

    printfn "%A" <| run parseDigit "1BC"
    printfn "%A" <| run parseDigit "BBC"

    let parseThreeDigitsAsStr =
        let tupleParser =
            parseDigit .>>. parseDigit .>>. parseDigit
        let transformTuple ((c1,c2),c3) =
            String [|c1;c2;c3|]
        mapP transformTuple tupleParser

    let parseThreeDigitsAsStr2 =
        (parseDigit .>>. parseDigit .>>. parseDigit)
        |>> fun ((c1,c2),c3) -> String [|c1;c2;c3|]

    printfn "%A" <| run parseThreeDigitsAsStr2 "123B"
    printfn "%A" <| run parseThreeDigitsAsStr2 "12AB"
    0 // return an integer exit code
