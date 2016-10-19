
#I "packages/FAKE/tools"
#r "packages/FAKE/tools/FakeLib.dll"
#load "packages/FSharp.Formatting/FSharp.Formatting.fsx"
#load "code/types.fsx"

open Fake
open FSharp.Literate
open System.IO
open System

open FSharp.Markdown


let siteDir = "_site"
let entriesDir = "FsEntries"
let postsDir = "_posts"

Target "Clean" (fun _ ->
    CleanDir siteDir
)

let generateHtml path (doc:LiterateDocument)= 
    let html = sprintf "%s %s" (Literate.WriteHtml(doc,lineNumbers=true)) doc.FormattedTips
    File.WriteAllText(path, html)

let getNewFname oldFname = 
    Path.GetFileName oldFname
    |> (fun s -> s.Replace(".fsx",".html"))
    |> (fun s -> Path.Combine(postsDir,s))

let fsi = 
    let ret = new FsiEvaluator()
    ret.RegisterTransformation(fun (o,ty) ->
        if (ty.ToString().Contains("FrontMatter"))
        then
            let layout = ty.GetProperty("Layout").GetValue(o) :?> string
            let title = ty.GetProperty("Title").GetValue(o) :?> string
            let raw =  (sprintf 
"""---
title: %s
layout: %s
---"""                  title layout)
            Some [InlineBlock(raw)]

        else 
            let genMethod = ty.GetMethod("GetHtml")
            match genMethod with
            | null -> None
            | _ -> 
                let raw = genMethod.Invoke(o,[||]) :?> string
                Some[InlineBlock(raw)]
    )
    ret

Target "BuildPosts" (fun _ ->
    
    Directory.GetFiles(entriesDir) 
    |> Seq.iter (fun x -> Literate.ProcessScriptFile(x, output = (getNewFname x), fsiEvaluator = fsi))
)



RunTargetOrDefault "BuildSite"