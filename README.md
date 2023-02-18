![SCGraphTheory Icon](src/Abstractions/SCGraphTheoryIcon.png)

# Graph Theory Abstractions

[![NuGet version (SCGraphTheory.Abstractions)](https://img.shields.io/nuget/v/SCGraphTheory.Abstractions.svg?style=flat-square)](https://www.nuget.org/packages/SCGraphTheory.Abstractions/) [![NuGet downloads (SCGraphTheory.Abstractions)](https://img.shields.io/nuget/dt/SCGraphTheory.Abstractions.svg?style=flat-square)](https://www.nuget.org/packages/SCGraphTheory.Abstractions/)

[Graph theory](https://en.wikipedia.org/wiki/Graph_theory) interfaces - [IGraph<TNode,TEdge>](/src/Abstractions/IGraph{TNode,TEdge}.cs), [INode<TNode,TEdge>](/src/Abstractions/INode{TNode,TEdge}.cs) and [IEdge<TNode,TEdge>](/src/Abstractions/IEdge{TNode,TEdge}.cs) - to allow for graph algorithms that do not depend on a particular graph representation.

Example implementation and usage can be found in the separate [SCGraphTheory.AdjacencyList](https://github.com/sdcondon/SCGraphTheory.AdjacencyList) and [SCGraphTheory.Search](https://github.com/sdcondon/SCGraphTheory.Search) repositories, respectively. Additional (test-focused) implementation examples can be found in the [TestGraphs library](https://github.com/sdcondon/SCGraphTheory.Search/tree/main/src/Search.TestGraphs) in SCGraphTheory.Search. Notably:
- A very simple (though rather inefficient) [LINQ-powered immutable implementation](https://github.com/sdcondon/SCGraphTheory.Search/blob/main/src/Search.TestGraphs/LinqGraph.cs). Used for tests in the search algorithm package.
- A [square grid implementation using structs](https://github.com/sdcondon/SCGraphTheory.Search/blob/main/src/Search.TestGraphs/ValGridGraph%7BT%7D.cs). Involves no up-front heap allocations other than a 2D array of node values, but performs a little worse under search because lots of data gets moved around compared to a class-based implementation (including a little boxing - see notes, below). Included in search benchmarks project because I was interested in the performance impact.
- A bare-bones [adjacency matrix implementation](https://github.com/sdcondon/SCGraphTheory.Search/blob/main/src/Search.TestGraphs/AdjacencyMatrixGraph.cs). Doesn't actually feature in any tests - I was just curious to know what an adjacency matrix implementation of these interfaces could look like.
- Some [and-or graph implementations](https://github.com/sdcondon/SCGraphTheory.Search/tree/main/src/Search.TestGraphs/Specialized/AndOr) that also serve as general examples of graphs with more than one edge and node type, and of graphs with reference type nodes/edges that are lazily initialised as the graph is explored.

Notes:
* The fact that the IEdge abstraction has a "From" and a "To" doesn't make this abstraction unsuitable for undirected graphs.
Graph algorithms will generally traverse edges in a particular direction, making this a useful interface,
and while the AdjacencyList implementation doesn't do this (thus favouring low latency over low memory usage),
there's nothing stopping an implementation (with class-valued edges) from making the IEdge implementation a struct created from the "actual" edge,
depending on the current node - thus avoiding "duplicated" undirected edges on the heap.  
  
  Of course, the Edges property of IGraph returns IEdges, so necessarily should include both directions of an undirected edge - which could cause confusion.
However, it should be noted that this is also justified by what it facilitates for algorithms using the abstraction.
Consider Bellman-Ford, for example - which (iterates graph edges and) operates specifically on directed graphs.
By including both directions of an undirected edge, we allow algorithms such as these to be used against all graphs that implement this abstraction correctly.
In this way, treating the two directions of undirected edges separately is a form of normalisation.  
  
  ..I should however probably expand a little on the "confusion" mentioned above, and in general the downside of this simplicity. Consider the act of building a
spanning tree. Which direction of an undirected edge is included would depend on where you start, which might not be ideal. There are of course ways to deal with
this. The addition of an edge-valued `Reverse` property, the addition of a property to indicate the "actual" underlying edge (which is the same for reverse edges),
careful `Equals` implementation, or a combination of these. One way of thinking about this abstraction (though we are perhaps straying into semantics here) is
that it deals with edge traversals (which are inherently directed) rather than edges - and it is down to the consumer to decide how they want the two concepts to be
related. This might result in a little extra work in certain cases, but does keep the abstraction very simple.
* The declaration of the edges collection of each node as an `IReadOnlyCollection<TEdge>` necessitates boxing by consumers of these interfaces when this collection is a value type. See [an alternative formulation in the benchmarks project of the SCGraphTheory.Search](https://github.com/sdcondon/SCGraphTheory.Search/tree/main/src/Search.Benchmarks/AlternativeAbstractions/TEdges) for more on this.
* Naming is hard:
  * Why `INode` and not `IVertex`? Simply because its shorter. I must confess that I am slightly regretting this one though..
  * Why call it "SCGraphTheory"? SC are my initials. I do worry that using my initials comes off as a little arrogant - but I'd argue that just calling it "GraphTheory.." would be more arrogant. And inventing a brand name would be tedious - and no doubt longer than SC.. 
