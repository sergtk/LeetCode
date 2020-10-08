public class PriorityQueue<T>
{
    private IComparer<T> comparer_;
    
    public PriorityQueue(IComparer<T> cmp = null)
    {
        if (cmp == null) {
            cmp = Comparer<T>.Default;
        }
        this.comparer_ = cmp;
        this.data_ = new List<T>();
    }


    List<T> data_;
    
    int Count {get => data_.Count; }
    
    // Peek min element
    public T Peek()
    {
        if (this.Count == 0) {
            throw new Exception("Trying to access min element from empty priority queue");
        }
        T ret = data_[0];
        return ret;
    }

    // Pop min element
    public T Pop()
    {
        T ret = Peek();
        data_[0] = data_[Count - 1];
        data_.RemoveAt(Count - 1);
        MoveDown(0);
        return ret;
    }
    
    private void MoveDown(int i)
    {
        while (true)
        {
            int opt = i;
            int i1 = i*2 + 1;
            if (i1 < Count && comparer_.Compare(data_[i1], data_[opt]) < 0) {
                opt = i1;
            }
            int i2 = i1+1;
            if (i2 < Count && comparer_.Compare(data_[i2], data_[opt]) < 0) {
                opt = i2;
            }
            if (opt == i)
            {
                break;
            }
            (data_[i], data_[opt]) = (data_[opt], data_[i]);
            i = opt;
        }
    }
    
    public void Push(T t) {
        data_.Add(t);
        MoveUp(this.Count - 1);
    }
    
    private void MoveUp(int i)
    {
        while (i > 0) {
            int j = (i - 1) / 2;
            if (comparer_.Compare(data_[j], data_[i]) < 0) {
                break;
            }
            (data_[j], data_[i]) = (data_[i], data_[j]);
            i = j;
        }
    }
    
    public bool IsEmpty()
    {
        return this.Count == 0;
    }
}
