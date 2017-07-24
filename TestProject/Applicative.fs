module Applicative

let ( <*> ) f v =
    match v with
    | Some v' -> 
        match f with 
        | Some f' -> Some (f' v')
        | _ -> None
    | _ -> None

//let (<*>) f g = fun x -> f x (g x)
let cnst a _ = a
let cnst' a = fun b -> Some a
//let id x = cnst <*> cnst
let id' x = (Some (cnst x)) <*> (Some(cnst x x)) 
let id'' x = (Some (cnst x)) <*> (cnst x x)
printfn "%A" <| id' 3



let s = Some((+)3)
printfn "%A" <| s.Value 2

let Apply funInContext valInContext =
    match funInContext with
    | Some f -> 
        match valInContext with
        | Some v -> Some(f v)
        | _ -> None
    | _ -> None 