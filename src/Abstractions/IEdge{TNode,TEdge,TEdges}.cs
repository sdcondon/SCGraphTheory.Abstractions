using System.Collections.Generic;

namespace SCGraphTheory
{
    /// <summary>
    /// Interface for types representing an edge in a <see cref="IGraph{TNode, TEdge, TEdges}"/>.
    /// </summary>
    /// <typeparam name="TNode">The type of each node of the graph.</typeparam>
    /// <typeparam name="TEdge">The type of each edge of the graph.</typeparam>
    /// <typeparam name="TEdges">The type of the outbound edges collection of each node of the graph.</typeparam>
    /// <remarks>
    /// The vast majority of edge implementations should implement the simpler-looking <see cref="IEdge{TNode, TEdge}"/> instead of this.
    /// This interface exists only to facilitate avoidance of boxing by consumers when <typeparamref name="TEdges"/> is a value type.
    /// While the resulting performance boost won't be massive, it may be desirable in some cases.
    /// </remarks>
    public interface IEdge<out TNode, out TEdge, out TEdges>
        where TNode : INode<TNode, TEdge, TEdges>
        where TEdge : IEdge<TNode, TEdge, TEdges>
        where TEdges : IReadOnlyCollection<TEdge>
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
}
