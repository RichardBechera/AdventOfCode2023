open System
open Microsoft.FSharp.Core

let charToInt = int >> (+) (- int '0')

let validDigits = [("one", "1"); ("two", "2o"); ("three", "t3"); ("four", "4"); ("five", "5"); ("six", "6"); ("seven", "7"); ("eight", "e8t"); ("nine", "n9e")]

let replace (oldValue: string, newValue: string) (str: string) = str.Replace(oldValue, newValue)

let rec toDigits (line: string) = function
    | i when i > 8 -> line
    | i when i >= 0 -> toDigits line (i + 1) |> replace validDigits[i]
    | _ -> failwith "Index out of range."

let getTheNumber (line: string) =
    printf $"line: {line}"
    let digits = toDigits line 0 |> Seq.filter Char.IsDigit |> Seq.map charToInt
    let result = match digits with | d when Seq.isEmpty d -> 0 | _ -> Seq.head digits * 10 + Seq.last digits
    printfn $", digits: {result}"
    result
    
let trebuchet filePath =
    if System.IO.File.Exists filePath then 
        filePath
        |> System.IO.File.ReadLines
        |> Seq.fold (fun acc line -> acc + getTheNumber line) 0
    else
        -1
    
    
trebuchet "./Input/trebuchet.txt"