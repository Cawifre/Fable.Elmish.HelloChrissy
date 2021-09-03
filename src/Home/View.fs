module Home.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Fable.React.Props
open Types

let maybeDecoration (model: string) =
  let preciousNames = ["chrissy"; "christina"]
  if Seq.exists (fun s -> s = model.ToLower()) preciousNames
    then "♥"
    else ""

let responseMessage (model: string) =
  if String.length model > 0
    then (sprintf "Hello %s %s" model (maybeDecoration model))
    else ""

let root model dispatch =
  div
    [ ]
    [ p
        [ ClassName "control" ]
        [ input
            [ ClassName "input"
              Type "text"
              Placeholder "Type your name"
              DefaultValue model
              AutoFocus true
              OnChange (fun ev -> !!ev.target?value |> ChangeStr |> dispatch ) ] ]
      br [ ]
      span
        [ ]
        [ str <| responseMessage model ] ]
