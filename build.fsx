
#I "packages/FAKE/tools"
#r "packages/FAKE/tools/FakeLib.dll"
#load "packages/FSharp.Formatting/FSharp.Formatting.fsx"

open Fake
open FSharp.Literate
open System.IO


let siteDir = "_site"
let entriesDir = "FsEntries"
let postsDir = "_posts"

Target "Clean" (fun _ ->
    CleanDir siteDir
)

let generateHtml path (doc:LiterateDocument)= 
    let html = sprintf "%s %s" (Literate.WriteHtml(doc)) doc.FormattedTips
    File.WriteAllText(path, html)

let getNewFname oldFname = 
    Path.GetFileName oldFname
    |> (fun s -> s.Replace(".fsx",".html"))
    |> (fun s -> Path.Combine(postsDir,s))

let myFsi = new FsiEvaluator()

Target "BuildPosts" (fun _ ->
    
    Directory.GetFiles(entriesDir) 
    |> Seq.iter (fun x -> Literate.ProcessScriptFile(x, output = (getNewFname x), fsiEvaluator = myFsi))
)



RunTargetOrDefault "BuildSite"