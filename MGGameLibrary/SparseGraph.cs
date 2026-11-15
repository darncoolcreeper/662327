using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGameLibrary
{
    public class SparseGraph<TNode, TEdge>
    {
        
        private Dictionary<TNode, List<(TEdge edge, TNode node)>> _adjacency = new();
        public SparseGraph()
        {
            
        }
        public void AddNode(TNode node)
        {
            if (!_adjacency.ContainsKey(node))
                _adjacency[node] = new List<(TEdge, TNode)>();
        }
        public void AddEdge(TNode from, TEdge edge, TNode to)
        {
            AddNode(from);
            AddNode(to);
            _adjacency[from].Add((edge, to));
        }

        public List<(TEdge, TNode)> GetEdges(TNode node)
        {
            if (_adjacency.ContainsKey(node))
                return _adjacency[node];
            else
                return new List<(TEdge, TNode)>();
        }





    }
}
