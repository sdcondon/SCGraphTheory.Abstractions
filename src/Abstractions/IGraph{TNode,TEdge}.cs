using System.Collections.Generic;

namespace SCGraphTheory
{
    /// <summary>
    /// Interface for types representing a graph.
    /// </summary>
    /// <typeparam name="TNode">The type of each node of the graph.</typeparam>
    /// <typeparam name="TEdge">The type of each edge of the graph.</typeparam>
    public interface IGraph<out TNode, out TEdge> : IGraph<TNode, TEdge, IReadOnlyCollection<TEdge>>
        where TNode : INode<TNode, TEdge>
        where TEdge : IEdge<TNode, TEdge>
    {
    }
}
