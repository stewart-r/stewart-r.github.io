(*** hide ***)
#load "../code/types.fsx"
#load "../packages/FsLab/FsLab.fsx"
open Blog
let frontmatter ={
    Title = "D3 Network (Force Layout) Diagrams in F#"
    Layout = "post"
}
frontmatter
(*** include-value:frontmatter ***)

(**
Some Markdown
-------------
If you prefer to use F# Formatting tools via the command line, you can use the `FSharp.Formatting.CommandTool` package, which includes an executable `fsformatting.exe` 
that gives you access to the most important functionality via a simple command line interface. This might be a good idea if you prefer to run F# Formatting as a 
separate process, e.g. for resource management reasons.
*)

