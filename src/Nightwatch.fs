module Nightwatch

open Elmish
open Elmish.React
open Elmish.ReactNative
open Elmish.HMR
open Fable.Helpers.ReactNative
open Fable.Helpers.ReactNative.Props

type Msg =
| Noop

type Model =
| BlankModel

let update (_:Msg) model : Model*Cmd<Msg> = 
  model, Cmd.none

let init() =
  BlankModel, Cmd.none

let view (model:Model) (dispatch: Msg -> unit) =
  match model with
  | BlankModel -> 
    text [
      TextProperties.Style [
        FontSize 20.
        FontWeight FontWeight.Bold
        Margin 20.
      ]
    ] "Hello World"


Program.mkProgram init update view
#if RELEASE
#else
|> Program.withConsoleTrace
|> Program.withHMR
#endif
|> Program.withReactNative "nightwatch"
|> Program.run