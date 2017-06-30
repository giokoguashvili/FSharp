module Calc
open Primitives.Types

let ONE = push 1
let TWO = push 2
let THREE = push 3
let EMPTY = StackContent []

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

let SHOW stack =
    let top,_ = pop stack
    printfn "The answr is: %A" top
    stack