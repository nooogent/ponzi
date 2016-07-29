//// Learn more about F# at http://fsharp.org. See the 'F# Tutorial' project
//// for more guidance on F# programming.
//
//#load "Library1.fs"
//open WB
//
//// Define your library scripting code here
//
//#r "packages/FSharp.Data.2.3.0/lib/net40/FSharp.Data.dll"
//#load "packages\FSharp.Charting.0.90.14/FSharp.Charting.fsx"
//
//open FSharp.Data

//let data = WorldBankData.GetDataContext()
//
//data
//  .Countries.``United Kingdom``
//  .Indicators.``Gross enrolment ratio, tertiary, both sexes (%)``
//|> Seq.maxBy fst
#load "Types.fs"
#load "Data.fs"
#load "Functions.fs"
open Ponzi.Functions

let teams = getTeams
let questions = getQuestions
let predictions = getPredictions

testFixtureResult 3 2

