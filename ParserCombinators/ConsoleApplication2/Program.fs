// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System.IO
open System.Text
open Newtonsoft.Json
open System.Xml.Serialization
open System

type User() =
    member val Name = String.Empty with get,set
    member val Age = 0 with get,set
    member val Salary  = 0m with get,set

type UsersModel() =
    [<XmlElement("User")>]
    member val Users = Array.empty<User> with get,set
    

let readFile encoding path = 
    File.ReadAllText(path, encoding)

let readFileAsUTF8 = readFile Encoding.UTF8

let parseJSON<'a> str =
    try
        let json = JsonConvert.DeserializeObject<'a>(str);
        Some json
    with
    | x -> None
 
let castAs<'T> (o:obj) =
    match o with
    | :? 'T as res -> res

let parseXML<'a> str =
    try
        let result =  XmlSerializer(typeof<'a>)
                            .Deserialize(new StringReader(str))
        Some (result :?> 'a)
    with 
    | x -> None

let parsers = [parseJSON<UsersModel>;parseXML<UsersModel>]

let tryParse (parsers: (string -> UsersModel option) list) str =
    parsers
    |> List.pick (fun p -> p str) 



[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    let users = List.empty<User>
    let vax = new User() :: users
    let readedFile = readFileAsUTF8 @"D:\4.txt"
    let json = (parseJSON<UsersModel> readedFile)
    let xml = (parseXML<UsersModel> readedFile)
    //printf "%A" json
    //printf "%A" xml
    printfn "%A" <| tryParse parsers readedFile

    let str = "\t|\tName\t|\tAge\t|\tSalary\t|"
    let rowView (user:User) = 
        sprintf  "%d\t|\t%s\t|\t%d\t|\t%M\t|" 1 user.Name user.Age user.Salary
    let render users = 
        users
        |> List.fold (fun acc next -> acc + "\n" + rowView next ) str
            
    printfn "%s" <| render ((tryParse parsers readedFile).Users |> Array.toList)
    let line = Console.ReadLine()
    0 // return an integer exit code
