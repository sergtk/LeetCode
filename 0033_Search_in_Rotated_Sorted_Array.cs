public class Solution {
    
    int[] nums_;
    int n_;
    
    int maxIndex_;
    
    void FindMaxIndex()
    {
        int mn = 0, mx = n_-1;
        while (mn < mx) {
            int md = (mn+mx) / 2;
            if (nums_[md] > nums_[0])
            {
                mn = md+1;
            } else
            {
                mx = md;
            }
        }
        if (mn == 0 || nums_[mn] > nums_[mn-1])
            maxIndex_ = mn;
        else
            maxIndex_ = mn-1;
    }
    
    public int Search(int[] nums, int target) {
        n_ = nums.Length;
        nums_ = nums;
        FindMaxIndex();
        //Console.WriteLine($"Max value: nums[{maxIndex_}] = {nums[maxIndex_]}");
        
        int index = Array.BinarySearch(nums, 0, maxIndex_ + 1, target);
        if (index >= 0)
        {
            //Console.WriteLine($"Res 1: index = {index}");
            return index;
        }
        if (maxIndex_ < n_ - 1)
        {
            index = Array.BinarySearch(nums, maxIndex_ + 1, n_ - maxIndex_ - 1, target);
            if (index >= 0)
            {
                //Console.WriteLine($"Res 2: index = {index}");
                return index;
            }
        }
        return -1;
    }
}
