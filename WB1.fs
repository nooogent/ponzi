module WB1

open FSharp.Data

let data = FSharp.Data.WorldBankData.GetDataContext()

let myD = 
 data.Countries.``United Kingdom``.Indicators.``Gross enrolment ratio, tertiary, both sexes (%)``
|> Seq.maxBy fst

    //Chart.Line(data.Countries.China.Indicators.``Population, total``);
    //Chart.Line(data.Countries.India.Indicators.``Population, total``);

open FSharp.Charting

Chart.Combine [ //Chart.Line(data.Countries.``United States``.Indicators.``Population, total``, Name="US")
                Chart.Line(data.Countries.Japan.Indicators.``Population, total``, Name="Japan")
                Chart.Line(data.Countries.Germany.Indicators.``Population, total``, Name="Germany") ]
    |> Chart.WithLegend(InsideArea=false)
    |> Chart.WithYAxis(Title="Pop", Min=60000000.0)
    |> ignore


//let testA = float 2 // val testA : 2.0:float
//let testB x = float 2 // val testB : float = 2.0
//let testC x = float 2 + x // val testC : int -> float
//let testD x = x.ToString().Length // val testD : x:'a -> string
//let testE (x:float) = x.ToString().Length // val testE : x:float -> int
//let testF x = printfn "%s" x // val testF : x:string -> unit
//let testG x = printfn "%f" x // val testG : x:float -> unit
//let testH = 2 * 2 |> ignore // val testH : int = 4  val testH : unit = ()
//let testI x = 2 * 2 |> ignore // val testH : x:'a -> int val testI : x:'a -> unit
//let testJ (x:int) = 2 * 2 |> ignore //val testJ : x:int -> unit
//let testK   = "hello" // val testK : string = "hello"
//let testL() = "hello" // val testL : x:unit -> string
//let testM x = x = x //val testM : x:'a -> bool
//let testN x = x 1   //val testN : x:(int -> int) -> 'a
//let testO x:string = x 1 // val testO : (int -> string) -> string
//
//let F x y z = x (y z) // val F : (x:'a -> y:'b) -> z:'c
//let F1 x y z = y z |> x    // using forward pipe  // val F1 : y:('a -> 'b) -> z:'c
//let F2 x y z = x <| y z    // using backward pipe
//
//let f (x,y,z) = x + y * z
//// type is int * int * int -> int
//
//// test
//f (1,2,3)
//
//let Q x y z = y (x z)      // the Queer bird (also familiar!)
//let S x y z = x z (y z)    // The Starling

let testA x = x + 1
testA 4

let testB x y = x + y
testB 4 1

let testC (x:(int->int)) (y:int) = x y

testC (fun x -> x + 1) 4

let testD (x:int) = 
    let subFunc y = x + y
    subFunc

testD 4 3
