module StackCalc

type Stack = StackContents of float list

let push x (StackContents contents) = 
    StackContents (x::contents)

let pop (StackContents contents) = 
    match contents with 
    | top::rest -> 
        let newStack = StackContents rest
        (top,newStack)
    | [] -> 
        failwith "Stack underflow"

let EMPTY = StackContents []
let ONE = push 1.0
let TWO = push 2.0
let THREE = push 3.0
let FOUR = push 4.0
let FIVE = push 5.0

let DoMath op stack =
   let x,s = pop stack  //pop the top of the stack
   let y,s2 = pop s     //pop the result stack
   let result = op x y   //do the math
   push result s2       //push back on the doubly-popped stack

let unary f stack = 
    let x,stack' = pop stack  //pop the top of the stack
    push (f x) stack'         //push the function value on the stack

let ADD = DoMath (+)
let MUL = DoMath (*)
let SUB = DoMath (-)
let DIV = DoMath (/)

let NEG = unary (fun x -> -x)

let SHOW stack = 
    let x,_ = pop stack
    printfn "The answer is %f" x
    stack  // keep going with same stack

/// Duplicate the top value on the stack
let DUP stack = 
    // get the top of the stack
    let x,_ = pop stack  
    // push it onto the stack again
    push x stack 
    
/// Swap the top two values
let SWAP stack = 
    let x,s = pop stack  
    let y,s' = pop s
    push y (push x s')   
    
/// Make an obvious starting point
let START  = EMPTY

let ONE_TWO_ADD = 
    ONE >> TWO >> ADD 

// define a new function
let SQUARE = 
    DUP >> MUL 

// define a new function
let CUBE = 
    DUP >> DUP >> MUL >> MUL 

// define a new function
let SUM_NUMBERS_UPTO = 
    DUP                     // n  
    >> ONE >> ADD           // n+1
    >> MUL                  // n(n+1)
    >> TWO >> SWAP >> DIV   // n(n+1) / 2 

let neg3 = EMPTY  |> THREE|> NEG
let square2 = EMPTY  |> TWO |> SQUARE

let add1and2 = EMPTY |> ONE |> TWO |> ADD
let add2and3 = EMPTY |> TWO |> THREE |> ADD
let mult2and3 = EMPTY |> TWO |> THREE |> MUL

let div2by3 = EMPTY |> THREE|> TWO |> DIV
let sub2from5 = EMPTY  |> TWO |> FIVE |> SUB
let add1and2thenSub3 = EMPTY |> ONE |> TWO |> ADD |> THREE |> SUB

EMPTY |> ONE |> THREE |> ADD |> TWO |> MUL |> SHOW |> ignore

//let result123 = EMPTY |> ONE |> TWO |> THREE 
//let result312 = EMPTY |> THREE |> ONE |> TWO
