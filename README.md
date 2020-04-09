# Graph Theory Abstractions

Core [Graph theory](https://en.wikipedia.org/wiki/Graph_theory) interfaces - [IGraph<TNode,TEdge>](/src/Abstractions/IGraph{TNode,TEdge}.cs), [INode<TNode,TEdge>](/src/Abstractions/INode{TNode,TEdge}.cs) and [IEdge<TNode,TEdge>](/src/Abstractions/IEdge{TNode,TEdge}.cs).

Example implementation and usage can be found in [SCGraphTheory.AdjacencyList](https://github.com/sdcondon/SCGraphTheory.AdjacencyList) and [SCGraphTheory.Search](https://github.com/sdcondon/SCGraphTheory.Search) respectively, but here's the simple (though of course rather inefficient) LINQ-powered immutable implementation used for tests in the search algorithm package:

``` 
public class Graph : IGraph<Graph.Node, Graph.Edge>
{
    public Graph(params (int from, int to)[] edges)
        : this(edges.Select(e => (e.from, e.to, 1f)).ToArray())
    {
    }

    public Graph(params (int from, int to, float cost)[] edges)
    {
        Nodes = edges.SelectMany(e => new[] { e.from, e.to }).Distinct().Select(i => new Node(this, i)).ToArray();
        Edges = edges.Select(e => new Edge(this, e.from, e.to, e.cost)).ToArray();
    }

    public IEnumerable<Node> Nodes { get; }

    public IEnumerable<Edge> Edges { get; }

    public class Node : INode<Node, Edge>
    {
        private readonly Graph graph;

        public Node(Graph graph, int id) => (this.graph, Id) = (graph, id);

        public int Id { get; }

        public IReadOnlyCollection<Edge> Edges => graph.Edges.Where(e => e.From.Id == Id).ToArray();
    }

    public class Edge : IEdge<Node, Edge>
    {
        private readonly Graph graph;
        private readonly int fromId;
        private readonly int toId;

        public Edge(Graph graph, int fromId, int toId, float cost) => (this.graph, this.fromId, this.toId, this.Cost) = (graph, fromId, toId, cost);

        public Node From => graph.Nodes.Single(n => n.Id == fromId);

        public Node To => graph.Nodes.Single(n => n.Id == toId);

        public float Cost { get; }
    }
}
```

