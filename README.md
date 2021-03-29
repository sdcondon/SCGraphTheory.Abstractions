# Graph Theory Abstractions

Core [Graph theory](https://en.wikipedia.org/wiki/Graph_theory) interfaces - [IGraph<TNode,TEdge>](/src/Abstractions/IGraph{TNode,TEdge}.cs), [INode<TNode,TEdge>](/src/Abstractions/INode{TNode,TEdge}.cs) and [IEdge<TNode,TEdge>](/src/Abstractions/IEdge{TNode,TEdge}.cs).

Example implementation and usage can be found in the separate [SCGraphTheory.AdjacencyList](https://github.com/sdcondon/SCGraphTheory.AdjacencyList) and [SCGraphTheory.Search](https://github.com/sdcondon/SCGraphTheory.Search) repositories, respectively. 

Additional (test-focused) implementation examples can be found among the test and benchmark projects in [SCGraphTheory.Search](https://github.com/sdcondon/SCGraphTheory.Search). Notably:
- A super-simple (though rather inefficient) [LINQ-powered immutable implementation](https://github.com/sdcondon/SCGraphTheory.Search/blob/master/src/Search.Tests/GraphImplementations/LinqGraph.cs). Used for tests in the search algorithm package.
- A [square grid implementation using structs](https://github.com/sdcondon/SCGraphTheory.Search/blob/master/src/Search.Benchmarks/GraphImplementations/ValGridGraph{T}.cs). Involves no up front heap allocations other than a 2D array of node values, but performs relatively poorly under search because lots of data gets moved around compared to a class-based implementation. Included in search benchmarks project because I was interested in the performance impact.


