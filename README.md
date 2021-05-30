# Graph Theory Abstractions

[![NuGet version (SCGraphTheory.Abstractions)](https://img.shields.io/nuget/v/SCGraphTheory.Abstractions.svg?style=flat-square)](https://www.nuget.org/packages/SCGraphTheory.Abstractions/)

[Graph theory](https://en.wikipedia.org/wiki/Graph_theory) interfaces - [IGraph<TNode,TEdge>](/src/Abstractions/IGraph{TNode,TEdge}.cs), [INode<TNode,TEdge>](/src/Abstractions/INode{TNode,TEdge}.cs) and [IEdge<TNode,TEdge>](/src/Abstractions/IEdge{TNode,TEdge}.cs) - to allow for graph algorithms that do not depend on a particular graph representation.

Example implementation and usage can be found in the separate [SCGraphTheory.AdjacencyList](https://github.com/sdcondon/SCGraphTheory.AdjacencyList) and [SCGraphTheory.Search](https://github.com/sdcondon/SCGraphTheory.Search) repositories, respectively. Additional (test-focused) implementation examples can be found in the [TestGraphs library](https://github.com/sdcondon/SCGraphTheory.Search/blob/master/src/Search.TestGraphs) in SCGraphTheory.Search. Notably:
- A super-simple (though rather inefficient) [LINQ-powered immutable implementation](https://github.com/sdcondon/SCGraphTheory.Search/blob/master/src/Search.TestGraphs/LinqGraph.cs). Used for tests in the search algorithm package.
- A [square grid implementation using structs](https://github.com/sdcondon/SCGraphTheory.Search/blob/master/src/Search.TestGraphs/ValGridGraph{T}.cs). Involves no up front heap allocations other than a 2D array of node values, but performs relatively poorly under search because lots of data gets moved around compared to a class-based implementation. Included in search benchmarks project because I was interested in the performance impact.
- A bare-bones [adjacency matrix implementation](https://github.com/sdcondon/SCGraphTheory.Search/blob/master/src/Search.TestGraphs/AdjacencyMatrixGraph.cs). Doesn't actually feature in any tests - I was just curious to know what this'd look like using these interfaces.
