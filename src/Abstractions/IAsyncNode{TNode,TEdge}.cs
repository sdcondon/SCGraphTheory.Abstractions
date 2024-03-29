﻿#if NET6_0_OR_GREATER
using System.Collections.Generic;

namespace SCGraphTheory;

/// <summary>
/// Interface for types representing a node in a <see cref="IAsyncGraph{TNode, TEdge}"/>.
/// </summary>
/// <typeparam name="TNode">The type of each node of the graph.</typeparam>
/// <typeparam name="TEdge">The type of each edge of the graph.</typeparam>
public interface IAsyncNode<out TNode, out TEdge>
    where TNode : IAsyncNode<TNode, TEdge>
    where TEdge : IAsyncEdge<TNode, TEdge>
{
    /// <summary>
    /// Gets the collection of edges that are outbound from this node.
    /// </summary>
    IAsyncEnumerable<TEdge> Edges { get; }
}
#endif
