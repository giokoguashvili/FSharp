namespace Computation
module ExpressionComputation =

    type MaybeBuilder() =
        member this.Bind(x, f) =
            match x with
            | None -> None
            | Some a -> f a
        member this.Return(x) =
            Some x

    let divideBy bottom top =
        if bottom = 0
        then None
        else Some(top/bottom)

    let maybe = new MaybeBuilder()

    let divideByWorkflow init x y z =
        maybe 
            {
            let! a = divideBy x init
            return a
            }
    let workflow = 
        maybe.Bind(
            divideBy 2 3, 
            fun x -> maybe.Bind(
                        divideBy x 4, 
                        fun x -> maybe.Return(x)))
