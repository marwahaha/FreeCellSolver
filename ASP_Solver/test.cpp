#include <iostream>
#include <map>
#include <string>
#include <iterator>
using namespace std;


class Solution {
public:
    int lengthOfLongestSubstring(string s) {
        int n = s.size();
        map <char, int> hashmap;
        int ans = 0;
            
        for(int j = 0, i = 0; j < n; j++){
            if(hashmap.find(s[j]) != hashmap.end()){
                i = max(hashmap[s[j]], i);
            }
            ans = max(ans, j - i + 1);
            hashmap.emplace(s[j],j + 1);
        }
        return ans;
    }
};

int main() {
    Solution solution1;
    int ans = solution1.lengthOfLongestSubstring("abcabcbb");
    cout << ans << endl;
}
