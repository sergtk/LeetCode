public class Solution {
    public bool IsValid(string s) {
        Stack<char> st = new Stack<char>();
        for (int i = 0; i < s.Length; i++) {
            char c = s[i];
            if (c == '{' || c == '(' || c == '[') {
                st.Push(c);
            } else {
                if (st.Count == 0) {
                    //Console.WriteLine($"Pos {i}: Empty stack on bracket '{c}'");
                    return false;
                }
                char c1 = st.Pop();
                if (c1 == '{' && c != '}' || c1 == '(' && c != ')' || c1 == '[' && c != ']') {
                    //Console.WriteLine($"Pos {i}: Wrong bracket '{c}'");
                    return false;
                }
                    
            }
        }
        if (st.Count != 0) {
            //Console.WriteLine($"Pos at the end: Non-empty stack at the end");
            return false;
        }
        return true;
    }
}
