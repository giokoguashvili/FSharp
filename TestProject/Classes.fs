namespace Test

type Customer(Name, Age) =
    let mutable x = 1
    let sum a b = a + b

    new() = Customer("Gio", 10)
    new(age) =
        printf "%A" "vax"
        Customer("Gio", age)


    member this.Name() = Name 
    member this.Sum a b = sum a b
    member this.Sum1(a,b) = sum a b
    member this.MyProp 
        with get() = x
        and set(value) = x <- value
    member val AutoProp = x
    member val MutableAutoProp = x with get,set
    member val MutableAutoProp2 = 0 with get,set

module Classes =
    let add2 = Customer(1).Sum1
    let add3 = new Customer(2)