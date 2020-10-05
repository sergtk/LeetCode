using System.Diagnostics;

public class Solution {
    public bool IsTransformable(string s, string t) {
        int n = s.Length;
        int[] digCountS = new int[10];
        int[] digCountT = new int[10];
        for (int i = 0; i < n; i++) {
            digCountS[s[i] - '0']++;
            digCountT[t[i] - '0']++;
        }
        //Console.WriteLine("111");
        for (int i = 0; i < 10; i++) {
            if (digCountS[i] != digCountT[i]) {
                return false;
            }
        }
        //Console.WriteLine("222");
        
        List<int> digS = new List<int>(n);
        List<int> digT = new List<int>(n);
        for (int i = 0; i < n; i++) {
            digS.Add(s[i] - '0');
            digT.Add(t[i] - '0');
        }
        
        //Console.WriteLine("333");

        for (int dig = 0; dig < 10; dig++) {
            //Console.WriteLine($"dig = {dig}");
            int posS = 0, posT = 0;
            while (posS < digS.Count) {
                while (posS < digS.Count && digS[posS] != dig) posS++;
                while (posT < digT.Count && digT[posT] != dig) posT++;
                if (posS < posT) {
                    return false;
                }
                posS++;
                posT++;
            }
            Debug.Assert(posS == digS.Count + 1 && posT == digT.Count + 1);
            Debug.Assert(digS.Count == digT.Count);
            digS.RemoveAll(v => v == dig);
            digT.RemoveAll(v => v == dig);
        }
        return true;
    }
}