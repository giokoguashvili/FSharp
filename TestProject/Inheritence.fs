namespace Interface

type IWord =
    abstract member Content : unit -> string

type Word() =
    interface IWord with
        member this.Content() = "Hello interface"

module Inter =
    let word = new Word()
    printfn "%A" <| (word :> IWord).Content()

    let show (word:IWord) =
        word.Content()
    
    let answ = 
        show {new IWord with
                 member this.Content() = 
                    "asd"}
    printfn "%A" answ