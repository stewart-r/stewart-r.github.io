(**
Some Markdown
-------------

boom de boom
*)

(*** hide ***)
#load "../code/types.fsx"
#load "../packages/FsLab/FsLab.fsx"
open Blog
let frontmatter = { Title = "My Blog"; Layout = "page"} 
let c = 1

(**
Some other stuff
*)
(*** include-value:c ***)
