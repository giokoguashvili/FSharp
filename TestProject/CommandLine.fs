namespace Gio

module CommandLine =

    let OrderByName = "N"
    let OrderBySize = "S"

    type CommandLineOptions = {
        verbose: bool;
        subdirectoris: bool;
        orderby: string
        }

    let rec parseCommandLineRec args optionsSoFar =
        match args with 
        | [] -> optionsSoFar
        | "/v"::xs ->
            let newOptionsSoFar = { optionsSoFar with verbose = true }
            parseCommandLineRec xs newOptionsSoFar
        | "/s"::xs  ->
            let newOptionsSoFar = { optionsSoFar with subdirectoris = true }
            parseCommandLineRec xs newOptionsSoFar
        | "/o"::xs ->
            match xs with
            | "S"::xss ->
                let newOptionsSoFar = { optionsSoFar with orderby = OrderBySize }
                parseCommandLineRec xss newOptionsSoFar
            | "N"::xss ->
                let newOptionsSoFar = { optionsSoFar with orderby = OrderByName }
                parseCommandLineRec xss newOptionsSoFar
            | _ -> 
                eprintf "OrderBy needs a second argument"
                parseCommandLineRec xs optionsSoFar 
        | x::xs ->
            eprintfn "Option '%s' is unrecognized" x
            parseCommandLineRec xs optionsSoFar


    let parseCommandLine args = 

        let defaultOptions = {
            verbose = true;
            subdirectoris = false;
            orderby = OrderByName
            }
        parseCommandLineRec args defaultOptions
        

    

   