using System.Collections.Generic;

namespace SCGraphTheory
{
    /// <summary>
    /// Interface for types representing an edge in a <see cref="IGraph{TNode, TEdge}"/>.
    /// </summary>
    /// <typeparam name="TNode">The type of each node of the graph.</typeparam>
    /// <typeparam name="TEdge">The type of each edge of the graph.</typeparam>
    public interface IEdge<out TNode, out TEdge> : IEdge<TNode, TEdge, IReadOnlyCollection<TEdge>>
        where TNode : INode<TNode, TEdge>
        where TEdge : IEdge<TNode, TEdge>
    {
    }
}
