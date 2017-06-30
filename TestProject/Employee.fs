namespace Domain.Model

type EmployeeType = {Name:string; Age:int;} with
    member this.FullName = 
        this.Name + " kogoia" 
                
type EmployeeType with 
    member this.A a = a

module Employee =

    let create name age = {Name=name; Age=age}
    let sayName (printer:Printf.TextWriterFormat<'T>-> 'T) (empl:EmployeeType) = printer "%s" empl.Name