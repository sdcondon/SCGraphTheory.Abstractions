namespace GraphTheory
{
    /// <summary>
    /// Interface for types representing an edge in a <see cref="IGraph{TNode, TEdge}"/>.
    /// </summary>
    /// <typeparam name="TNode">The type of each node of the graph.</typeparam>
    /// <typeparam name="TEdge">The type of each edge of the graph.</typeparam>
    public interface IEdge<out TNode, out TEdge>
        where TNode : INode<TNode, TEdge>
        where TEdge : IEdge<TNode, TEdge>
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
