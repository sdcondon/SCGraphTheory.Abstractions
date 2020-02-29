using System.Collections.Generic;

namespace GraphTheory
{
    /// <summary>
    /// Interface for types representing a graph.
    /// </summary>
    /// <typeparam name="TNode">The type of each node of the graph.</typeparam>
    /// <typeparam name="TEdge">The type of each edge of the graph.</typeparam>
    public interface IGraph<out TNode, out TEdge>
        where TNode : INode<TNode, TEdge>
        where TEdge : IEdge<TNode, TEdge>
    {
        /// <summary>
        /// Gets the set of nodes of the graph.
        /// </summary>
        IEnumerable<TNode> Nodes { get; }

        /// <summary>
        /// Gets the set of edges of the graph.
        /// </summary>
        IEnumerable<TEdge> Edges { get; }
    }
}
