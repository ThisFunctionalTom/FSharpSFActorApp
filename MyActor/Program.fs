// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System
open System.Threading
open System.Fabric
open Microsoft.ServiceFabric.Actors.Runtime

open Logging

[<EntryPoint>]
let main argv = 
    try
      let task = ActorRuntime.RegisterActorAsync<MyActor.MyActor>(fun context actorType -> 
        new ActorService(context, actorType))
      let awaiter = task.GetAwaiter()
      let result = awaiter.GetResult()
      Thread.Sleep Timeout.Infinite
      0
    with
    | exn -> 
      log.Write(exn |> string)
      -1
