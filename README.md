# Graph Theory Abstractions

Core [Graph theory](https://en.wikipedia.org/wiki/Graph_theory) interfaces - [IGraph<TNode,TEdge>](/src/Abstractions/IGraph{TNode,TEdge}.cs), [INode<TNode,TEdge>](/src/Abstractions/INode{TNode,TEdge}.cs) and [IEdge<TNode,TEdge>](/src/Abstractions/IEdge{TNode,TEdge}.cs).

Example implementation and usage can be found in the spearate [SCGraphTheory.AdjacencyList](https://github.com/sdcondon/SCGraphTheory.AdjacencyList) and [SCGraphTheory.Search](https://github.com/sdcondon/SCGraphTheory.Search) repositories, respectively. 

Additional (test-focused) implementation examples can be found among the test and benchmark projects in [SCGraphTheory.Search](https://github.com/sdcondon/SCGraphTheory.Search). Notably:
- A super-simple (though rather inefficient) [LINQ-powered immutable implementation](https://github.com/sdcondon/SCGraphTheory.Search/blob/master/src/Search._Tests/_TestHelpers/Graph.cs). Used for tests in the search algorithm package:
- A [square grid implementation using structs](https://github.com/sdcondon/SCGraphTheory.Search/blob/master/src/Search._Benchmarks/GraphImplementations/ValSquareGridGraph.cs). Involves no up front heap allocations other than a 2D array of node values, but of course performs relatively poorly under search because lots data gets moved around compared to a class-based implementation. Included in search benchmarks project because I was interested in the performance impact.


