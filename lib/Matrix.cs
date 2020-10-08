// This is draft class which was not tested yet.

public class Matrix : ICloneable
{
    const int mod = 1000000000 + 7;

    private int nr_, nc_;
    
    private int[,] data_;
    
    public int Nr 
    {
        get => nr_;
    }
    
    public int Nc
    {
        get => nc_;
    }
    
    public int this[int r, int c]
    {
        get {return data_[r, c]; }
        set {data_[r, c] = value; }
    }
    
    public Matrix(int nr, int nc)
    {
        nr_ = nr;
        nc_ = nc;
        data_ = new int[nr, nc];
    }
    
    // Matrix multiplication
    public static Matrix operator* (Matrix a, Matrix b) {
        Matrix ret = new Matrix(a.Nr, b.Nc);
        Debug.Assert(a.Nc == b.Nr);
        for (int r = 0; r < ret.Nr; r++) {
            for (int c = 0; c < ret.Nc; c++) {
                for (int t = 0; t < a.Nc; t++) {
                    long cur = (long)a[r, t] * b[t, c];
                    ret[r, c] = (ret[r, c] + cur) % mod;
                }
            }
        }
        return ret;
    }
    
    public object Clone()
    {
        Matrix ret = new Matrix(Nr, Nc);
        for (int r = 0; r < Nr; r++) {
            for (int c = 0; c < Nc; c++) {
                ret[r, c] = this[r, c];
            }
        }
        return ret;
    }
    
    public static Identity(int n) {
        Matrix ret = new Matrix(n, n);
        for (int i = 0; i < n; i++) {
            ret[i, i] = 1;
        }
        return ret;
    }
    
    public Matrix Power(int p) {
        Debug.Assert(Nr == Nc);
        Matrix ret = Matrix.Identity(Nr);
        Matrix a = this.Clone();
        while (p > 0) {
            if (p % 2 == 1) {
                p--;
                ret *= a;
            }
            if (p > 0) {
                p /= 2;
                a = a * a;
            }
        }
        return ret;
    }
    
    
}
