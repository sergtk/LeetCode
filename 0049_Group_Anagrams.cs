// Problem statement: https://leetcode.com/problems/group-anagrams/

public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var dict = new Dictionary<string, IList<string>>();
        foreach (string s in strs) {
            char[] ar = s.ToCharArray();
            Array.Sort(ar);
            string key = new string(ar);
            if (dict.ContainsKey(key)) {
                dict[key].Add(s);
            } else {
                dict[key] = (IList<string>) new List<string> {s};
            }
        }
        var ret = dict.Select(entry => entry.Value).ToList();
        return ret;
    }
}
