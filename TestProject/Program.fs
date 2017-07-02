// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open Math_
open Domain.Model
open LINQ
open Gio.CommandLine

let matcher x =
    let typ = typeof<int>
    let less x b = x < b
    match x with
    | typ when less x 2 -> printfn "int"
    | _ -> printfn "unknow"

let matcher1 = function 
               |  1 as x -> x.ToString()
let matcher2 = function
               | "1" as x -> printfn "%A" x

let mm = matcher1 >> matcher2
    

[<EntryPoint>]
let main argv = 
    printfn "%A" <| (sum 2 3)
    let empl = Employee.create "gio" 25
    printfn "%A" <| empl
    Employee.sayName printfn empl 
    printfn "%A" <| (Employee.create "gioo" 28).FullName
    [1..100] 
    |> where (fun x -> x > 2) 
    |> select (fun x -> x * 2) 
    |> printfn "%A"
    mm 1
    printfn "%A" <| parseCommandLine ["/v"]
    printfn "%A" <| parseCommandLine ["/v"; "/s"]
    printfn "%A" <| parseCommandLine ["/v"; "/o"; "S"]
    0 // return an integer exit code