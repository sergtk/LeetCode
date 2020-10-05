public class ThroneInheritance {
    Dictionary<string, List<string>> tree = new Dictionary<string, List<string>>();
    HashSet<string> deads = new HashSet<string>();
    string kingName;

    public ThroneInheritance(string kingName) {
        this.kingName = kingName;
        tree[kingName] = new List<string>();    
    }
    
    public void Birth(string parentName, string childName) {
        List<string> children;
        if (tree.ContainsKey(parentName))
        {
            children = tree[parentName];
        } else {
            tree[parentName] = children = new List<string>();
        }
        children.Add(childName);
        
        if (!tree.ContainsKey(childName)) {
            tree[childName] = new List<string>();
        }
    }
    
    public void Death(string name) {
        deads.Add(name);
    }
    
    public IList<string> GetInh(string root) {
        List<string> ret = new List<string>();
        if (!deads.Contains(root)) {
            ret.Add(root);
        }
        foreach (var ch in tree[root]) {
            IList<string> cur = GetInh(ch);
            ret.AddRange(cur);
        }
        return ret;
    }
    
    public IList<string> GetInheritanceOrder() {
        IList<string> ret = GetInh(kingName);
        return ret;
    }
}

/**
 * Your ThroneInheritance object will be instantiated and called as such:
 * ThroneInheritance obj = new ThroneInheritance(kingName);
 * obj.Birth(parentName,childName);
 * obj.Death(name);
 * IList<string> param_3 = obj.GetInheritanceOrder();
 */
