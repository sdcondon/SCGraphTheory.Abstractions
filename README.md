# Graph Theory Abstractions

[![NuGet version (SCGraphTheory.Abstractions)](https://img.shields.io/nuget/v/SCGraphTheory.Abstractions.svg?style=flat-square)](https://www.nuget.org/packages/SCGraphTheory.Abstractions/)

[Graph theory](https://en.wikipedia.org/wiki/Graph_theory) interfaces - [IGraph<TNode,TEdge>](/src/Abstractions/IGraph{TNode,TEdge}.cs), [INode<TNode,TEdge>](/src/Abstractions/INode{TNode,TEdge}.cs) and [IEdge<TNode,TEdge>](/src/Abstractions/IEdge{TNode,TEdge}.cs) - to allow for graph algorithms that do not depend on a particular graph representation.

Example implementation and usage can be found in the separate [SCGraphTheory.AdjacencyList](https://github.com/sdcondon/SCGraphTheory.AdjacencyList) and [SCGraphTheory.Search](https://github.com/sdcondon/SCGraphTheory.Search) repositories, respectively. Additional (test-focused) implementation examples can be found in the [TestGraphs library](https://github.com/sdcondon/SCGraphTheory.Search/blob/master/src/Search.TestGraphs) in SCGraphTheory.Search. Notably:
- A super-simple (though rather inefficient) [LINQ-powered immutable implementation](https://github.com/sdcondon/SCGraphTheory.Search/blob/master/src/Search.TestGraphs/LinqGraph.cs). Used for tests in the search algorithm package.
- A [square grid implementation using structs](https://github.com/sdcondon/SCGraphTheory.Search/blob/master/src/Search.TestGraphs/ValGridGraph{T}.cs). Involves no up-front heap allocations other than a 2D array of node values, but performs a little worse under search because lots of data gets moved around compared to a class-based implementation (including a little boxing - see notes, below). Included in search benchmarks project because I was interested in the performance impact.
- A bare-bones [adjacency matrix implementation](https://github.com/sdcondon/SCGraphTheory.Search/blob/master/src/Search.TestGraphs/AdjacencyMatrixGraph.cs). Doesn't actually feature in any tests - I was just curious to know what an adjacency matrix implementation of these interfaces could look like.

Notes:
* The fact that the IEdge abstraction has a "From" and a "To" doesn't make this abstraction unsuitable for undirected graphs. Graph algorithms will generally traverse edges in a particular direction, making this a useful interface, and while the AdjacencyList implementation doesn't do this (thus favouring low latency over low memory usage), there's nothing stopping an implementation (with reference type edges) from making the IEdge implementation a value type created from the ref type edge, depending on the current node - thus avoiding "duplicated" undirected edges on the heap.  
  
  ..The elephant in the room of course is the Edges property of IGraph, which, given that it returns IEdges, necessarily should include both directions of an undirected edge - which could cause confusion. However, it should be noted that this is also justified by what it facilitates for algorithms using the abstraction. Consider Bellman-Ford, for example - which (iterates graph edges and) operates specifically on directed graphs. By including both directions of an undirected edge, we allow algorithms such as these to be used against this abstraction. In this way, treating the two directions of undirected edges separately is a form of normalisation.
* The declaration of the edges collection of each node as an `IReadOnlyCollection<TEdge>` necessitates boxing by consumers of these interfaces when this collection is a value type. See [an alternative formulation in the benchmarks project of the SCGraphTheory.Search](https://github.com/sdcondon/SCGraphTheory.Search/tree/master/src/Search.Benchmarks/Alternatives/TEdges) for more on this.
