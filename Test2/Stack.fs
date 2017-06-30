namespace Primitives

module Types =
    type Stack = StackContent of int List

    let push x (StackContent contents) =
        StackContent (x::contents)

    let pop (StackContent contents) =
        match contents with
        | top::rest -> (top,StackContent rest)
        | [] -> failwith "stack is empty"

    let binary fn stack =
        let x,stack' = pop stack
        let y,stack'' = pop stack'
        let result = fn x y
        push result stack''

    let unary fn stack =
        let x,stack' = pop stack
        push (fn x) stack'

    let ADD = binary (+)
    let MUL = binary (*)
    let SUB = binary (-)

    let NEG = unary (fun x -> -x)
    let SQUARE = unary (fun x -> x * x)

    