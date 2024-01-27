#if NET6_0_OR_GREATER
using System.Collections.Generic;

namespace SCGraphTheory;

/// <summary>
/// Interface for types representing a graph for which navigation (specifically, enumeration of the outbound edges of a node, or of the nodes or edges of an entire graph) is asynchronous.
/// <para/>
/// Intended to be useful when navigating a graph requires (or may require) IO.
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
