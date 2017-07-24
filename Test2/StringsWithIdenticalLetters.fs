module StringsWithIdenticalLetters

open System

let strings = ["abc"; "bac"; "abc"; "d"; "et"; "d"; "et"]


let sortedString (str:string) =
    str 
    |> Seq.sort
    |> String.Concat

let stringsWithSortedLetters strs =
    strs |> List.map sortedString

let stringsWithIdenticalLetters strs =
    let startState = (List.head strs, 0)
    strs 
    //|> List.fold(

printfn "%A" <| stringsWithSortedLetters strings

