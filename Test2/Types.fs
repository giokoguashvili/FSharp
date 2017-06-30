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

    type Box = {Name:string; Age:int}


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