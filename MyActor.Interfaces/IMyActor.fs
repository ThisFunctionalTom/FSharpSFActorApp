namespace MyActor.Interfaces

open System.Threading.Tasks
open Microsoft.ServiceFabric.Actors

type IMyActor =
  inherit IActor
  abstract member GetCountAsync : unit -> Task<int>
  abstract member SetCountAsync : int -> Task

