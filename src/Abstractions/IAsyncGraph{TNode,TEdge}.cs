#if NET6_0_OR_GREATER
using System.Collections.Generic;

namespace SCGraphTheory;

/// <summary>
/// <para>
/// Interface for types representing a graph for which navigation can be asynchronous.
/// </para>
/// <para>
/// It differs from <see cref="IGraph{TNode, TEdge}"/> in that the outbound edges of a node,
/// as well as the nodes and edges of an entire graph, are <see cref="IAsyncEnumerable{T}"/>.
/// </para>
/// </summary>
/// <typeparam name="TNode">The type of each node of the graph.</typeparam>
/// <typeparam name="TEdge">The type of each edge of the graph.</typeparam>
public interface IAsyncGraph<out TNode, out TEdge>
    where TNode : INode<TNode, TEdge>
    where TEdge : IEdge<TNode, TEdge>
{
    /// <summary>
    /// Gets the set of nodes of the graph.
    /// </summary>
    IAsyncEnumerable<TNode> Nodes { get; }

    /// <summary>
    /// Gets the set of edges of the graph.
    /// </summary>
    IAsyncEnumerable<TEdge> Edges { get; }
}
#endif
