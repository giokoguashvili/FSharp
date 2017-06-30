namespace Primitives

module Types =
    type Stack = StackContent of int List

    let push x (StackContent contents) =
        StackContent (x::contents)

    let pop (StackContent contents) =
        match contents with
        | top::rest -> (top,StackContent rest)
        | [] -> failwith "stack is empty"

    