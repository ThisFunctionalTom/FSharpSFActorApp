[<AutoOpen>]
module Logging

open System.Diagnostics.Tracing

let log = new EventSource("MyActorFun")

