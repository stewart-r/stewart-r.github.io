(*** hide ***)
#load "../code/types.fsx"
#load "../packages/FsLab/FsLab.fsx"
#I "../../XPlot/bin"
#r "XPlot.D3.dll"

open XPlot.D3

open Blog
let frontmatter ={
    Title = "D3 Network Graphs in F#"
    Layout = "post"
}
frontmatter
(*** include-value:frontmatter ***)

(**
##D3
Network chart example:
*)
(*** define-output:netchart ***)
let edges = 
    [   "blog1", "content2"
        "content2", "content1"
        "content1", "blog1"]
edges
|> Chart.ForceLayout
|> Chart.WithHeight 300
|> Chart.WithWidth 400
|> Chart.WithGravity 2.5
|> Chart.WithEdgeOptions (fun e ->
{
    Stroke = {Red = 20uy; Blue = 20uy; Green = 20uy;}
    StrokeWidth = 2.0
    Distance = 250.0
})
(*** include-it:netchart ***)




