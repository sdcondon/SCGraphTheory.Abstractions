#if NET6_0_OR_GREATER
namespace SCGraphTheory;

/// <summary>
/// Interface for types representing an edge in a <see cref="IAsyncGraph{TNode, TEdge}"/>.
/// </summary>
/// <typeparam name="TNode">The type of each node of the graph.</typeparam>
/// <typeparam name="TEdge">The type of each edge of the graph.</typeparam>
public interface IAsyncEdge<out TNode, out TEdge>
    where TNode : IAsyncNode<TNode, TEdge>
    where TEdge : IAsyncEdge<TNode, TEdge>
{
    /// <summary>
    /// Gets the node that the edge connects from.
    /// </summary>
    TNode From { get; }

    /// <summary>
    /// Gets the node that the edge connects to.
    /// </summary>
    TNode To { get; }
}
#endif
