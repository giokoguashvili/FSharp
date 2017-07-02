namespace Gio

module CommandLine =

    type OrderByOption = OrderBySize | OrderByName
    type SubdirectoriesOption = IncludeSubdirectories | ExcludeSubdirectories
    type VerboseOption = VerboseOutput | TerseOutput

    type CommandLineOptions = {
        verbose: VerboseOption;
        subdirectoris: SubdirectoriesOption;
        orderby: OrderByOption
        }

    let rec parseCommandLineRec args optionsSoFar =
        match args with 
        | [] -> optionsSoFar
        | "/v"::xs ->
            let newOptionsSoFar = { optionsSoFar with verbose = VerboseOutput }
            parseCommandLineRec xs newOptionsSoFar
        | "/s"::xs  ->
            let newOptionsSoFar = { optionsSoFar with subdirectoris = IncludeSubdirectories }
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
            verbose = TerseOutput;
            subdirectoris = ExcludeSubdirectories;
            orderby = OrderByName
            }
        parseCommandLineRec args defaultOptions
        

    

   