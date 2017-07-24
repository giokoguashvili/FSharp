module NewLineFeature

type C(num) =
    member this.Add(x) = 
        num + x 
  
type B(c:C) =
    member this.Add(x) = c.Add(x)

type A(b:B) =
    member this.Add(x) = b.Add(x)

let add1 = (+) 1
let prod2 = (*) 2
let div3 = (/) 3



let result x = (add1 >> prod2 >> div3) x
let result1 x = (add1 << prod2 << div3) x
let result2 x = add1  (prod2  (div3 x))
//let result3 x = 
//        add1
//            prod2
//                div3 x

let dec x = 
        A(
            B(
                C(1)
            )
        ).Add(x)

//let result =
//        ParsedXML
//            XMLFile "path"


//let dec1 x = 
//        A
//            B
//                C 1    
//        Add(x)

printf "%A" <| dec 5                    

printfn "%A" <| result 3
printfn "%A" <| result1 3
printfn "%A" <| result2 3