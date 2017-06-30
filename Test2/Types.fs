namespace Gio

module Types =
    let abs x = -x
    type IntOrBool =
        | I of int
        | B of bool
        | C of float

    let II = IntOrBool.I 3
    let BB = IntOrBool.B false
    

    let func x =
        match x with
        | I x -> printfn "%A" x
        | B x -> printfn "%A" x
        | C x -> printfn "%A" x

    let (tup:int*int) = (1, 2)