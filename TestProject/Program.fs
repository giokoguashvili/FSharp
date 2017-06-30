// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open Math_
open Domain.Model



[<EntryPoint>]
let main argv = 
    printfn "%A" <| (sum 2 3)
    let empl = Employee.create "gio" 25
    printfn "%A" <| empl
    Employee.sayName printfn empl
    printfn "%A" <| (Employee.create "gioo" 28).FullName
    0 // return an integer exit code

