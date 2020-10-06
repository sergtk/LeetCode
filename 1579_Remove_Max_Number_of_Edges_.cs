using System.Diagnostics;

public class Solution {

    struct Node {
        public Node(int root, int rank)
        {
            //Console.WriteLine($"Node::Node(root = {root}, rank = {rank})");
            this.root = root;
            this.rank = rank;
        }
        
        public int root;
        public int rank;
    }
        
    Node[] nodes;
    
    int GetRoot(int v) {
        //Console.Write($"GetRoot({v})");
        //Console.WriteLine($" with root = {nodes[v].root}");
        while (nodes[v].root != -1)
        {
            v = nodes[v].root;
        }
        return v;
    }
    
    bool IsGraphConnected()
    {
        int root = GetRoot(1);
        for (int v = 2; v < nodes.Length; v++) {
            if (GetRoot(v) != root) {
                //Console.WriteLine($"nodes[{v}].root {nodes[v].root} != {root}");
                return false;
            }
        }
        return true;
    }
    
    void Union(int uRoot, int vRoot) {
        /*
        if (nodes[uRoot].root != -1) {
            throw new Exception($"Node {uRoot} is not root");
        }
        if (nodes[vRoot].root != -1) {
            throw new Exception($"Node {vRoot} is not root");
        }
        */
        if (nodes[uRoot].rank < nodes[vRoot].rank) {
            (uRoot, vRoot) = (vRoot, uRoot);
        }
        if (nodes[uRoot].rank == nodes[vRoot].rank) {
            nodes[uRoot].rank++;
        }
        nodes[vRoot].root = uRoot;
        
        /*
        Console.WriteLine("Roots:");
        for (int i = 0; i < nodes.Length; i++) {
            Console.Write($"{i} -> {nodes[i].root}, ");
        }
        Console.WriteLine();
        */
    }
    
    int ne;
    int[][] edges;
    int[] saveEdgeCounts = {0, 0, 0, 0};

    public void HandleEdges(int workType) {
        for (int ei = 0; ei < ne; ei++) {
            (int type, int u, int v) = (edges[ei][0], edges[ei][1], edges[ei][2]);
            if (type != workType) continue;

            int uRoot = GetRoot(u);
            int vRoot = GetRoot(v);
            if (uRoot == vRoot) {
                continue;
            }
            //Console.WriteLine($"Preserve edge: ({type}, {u}, {v})");
            Union(uRoot, vRoot);
            //Console.WriteLine($"type = {type}");
            saveEdgeCounts[type]++;
        }
    }
    
    public int MaxNumEdgesToRemove(int n, int[][] edges)
    {
        //Console.WriteLine($"n = {n}");
        nodes = new Node[n+1];
        Array.Fill(nodes, new Node(-1, 0));
        
        ne = edges.Length;
        this.edges = edges;

        HandleEdges(3);
                
        Node[] backNodes = new Node[n+1];
        Array.Copy(nodes, backNodes, n+1);
        
        HandleEdges(1);
        if (!IsGraphConnected()) {
            //Console.WriteLine("Disconnected for edge type 1");
            return -1;
        }
        
        nodes = backNodes;

        HandleEdges(2);
        if (!IsGraphConnected()) {
            //Console.WriteLine("Disconnected for edge type 2");
            return -1;
        }
        
        int ret = ne - saveEdgeCounts[1] - saveEdgeCounts[2] - saveEdgeCounts[3];

        return ret;
    }
}
