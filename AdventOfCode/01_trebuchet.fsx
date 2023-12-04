open System

let charToInt = int >> (+) (- int '0')

let getTheNumber (line: string) =
    let digits = Seq.filter Char.IsDigit line |> Seq.map charToInt
    match digits with
    | d when Seq.isEmpty d -> 0
    | _ -> Seq.head digits * 10 + Seq.last digits
    
let trebuchet filePath =
    if System.IO.File.Exists filePath then 
        filePath
        |> System.IO.File.ReadLines
        |> Seq.fold (fun acc line -> acc + getTheNumber line) 0
    else
        -1
    
    
trebuchet "./Input/trebuchet.txt"