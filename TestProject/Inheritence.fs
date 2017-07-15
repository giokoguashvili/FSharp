namespace Interface

type IWord =
    abstract member Content : unit -> string

type Word() =
    interface IWord with
        member this.Content() = "Hello interface"

module Inter =
    let word = new Word()
    printfn "%A" <| (word :> IWord).Content()