// This is an example of the Algebraic Type System. Think of it as a data structure.
type Customer = {
    Id: string
    IsEligible: bool
    IsRegistered: bool
}

// We can use the following tpe definition to create an instance of Customer.
let zach = { Id = "Zach"; IsEligible = true; IsRegistered = true; }

// Here we create a function to calculate the total.
// We used let again to define the function, and inside the function to define discount and total.
// There is no container as functions are first-class citizens.
// The return type is to the right of the input arguments.
// No return keyword. The last line is returned.
// Significant whitespace (Tabs are not allowd).
//  - Note that VSCode translates tabs to spaces.
// The function signature is Customer -> decimal -> decimal. The item at the
//  end of the signature (after the last arrow) is the return type of the function.
let calculateTotal (customer:Customer) (spend:decimal) : decimal =
    let discount = if customer.IsRegistered && customer.IsEligible && spend >= 100.0M then (spend * 0.1M) else 0.0M
    let total = spend - discount
    total

// The F# Compiler uses a feature called Type Inference which means that most of the time it can
//  determine types through usage without you needing to explicitly define them. As
//  a consequence, we could rewrite the function like so:
let betterCalculateTotal customer spend =
    let discount = if customer.IsRegistered && customer.IsEligible && spend >= 100.0M then (spend * 0.1M) else 0.0M
    // We also removed the total binding because it doesn't add anything to
    //  the readability of te function.
    spend - discount