namespace MyActor

open System
open System.Diagnostics.Tracing
open System.Threading.Tasks
open Microsoft.ServiceFabric.Actors.Runtime
open MyActor.Interfaces

[<StatePersistence(StatePersistence.Persisted)>]
type public MyActor(actorService, actorId) =
  inherit Actor(actorService, actorId)

  override a.OnActivateAsync() =
    log.Write("Actor activated.")
    a.StateManager.TryAddStateAsync ("count", 0) :> Task

  interface IMyActor with
    member a.GetCountAsync () =
      a.StateManager.GetStateAsync "count"
    member a.SetCountAsync count =
      let update = Func<string, int, int>(fun key value -> if count > value then count else value)
      a.StateManager.AddOrUpdateStateAsync ("count", count, update) :> Task
