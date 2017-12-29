module Nightwatch

open Elmish
open Elmish.React
open Elmish.ReactNative
open Elmish.HMR
open Fable.Core.JsInterop
open Fable.Helpers.ReactNative
open Fable.Helpers.ReactNative.Props
open Fable.Import.ReactNative

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
    // The prop `initialRoute` is marked as required in `NavigatorIOS`
    let route: Route = createEmpty<Route>
    route.``component`` <- Some (createElement(Fable.Import.ReactNative.Globals.View, [], []))
    let initialRoute = NavigatorIOSProperties.InitialRoute route
    createElement(Fable.Import.ReactNative.Globals.NavigatorIOS, [initialRoute], [])

Program.mkProgram init update view
#if RELEASE
#else
|> Program.withConsoleTrace
|> Program.withHMR
#endif
|> Program.withReactNative "nightwatch"
|> Program.run