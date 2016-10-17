module Blog

#load "packages/FsLab/FsLab.fsx"

type FrontMatter = {
    Title:string
    Layout:string
}

fsi.AddHtmlPrinter(fun (h:FrontMatter) ->
  seq [], (sprintf """
  ---
  title: %s
  layout: %s
  ---
  """ h.Title h.Layout))