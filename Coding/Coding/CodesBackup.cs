﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using Coding.Array;
using Coding.Tree;
namespace Coding
{

    public class Solution
    {
        public bool IsPowerOfThree(int n)
        {
            int maxP3 = 1162261467;
            if (n > maxP3 || n <= 0 || n > int.MaxValue)
                return false;
            return maxP3 % n == 0;
        }


        public bool CanWinNim(int n)
        {
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = 0;
            }

            return !CanWinHelper(n - 1, ref array) || !CanWinHelper(n - 2, ref array) || !CanWinHelper(n - 3, ref array);
        }

        private bool CanWinHelper(int n, ref int[] array)
        {
            if (n <= 0)
                return false;
            if (array[n - 1] != 0)
                return array[n - 1] > 0;
            if (!CanWinHelper(n - 1, ref array) || !CanWinHelper(n - 2, ref array) || !CanWinHelper(n - 3, ref array))
            {
                array[n - 1] = 1;
                return true;
            }

            array[n - 1] = -1;
            return false;
        }


        public bool CanWinNim2(int n)
        {
            bool[] cache = new bool[4];
            if (n < 3) return true;
            for (int i = 0; i < 3; i++)
            {
                cache[i] = true;
            }

            for (int i = 3; i < n; i++)
            {
                if (cache[0] && cache[1] && cache[2])
                {
                    cache[3] = false;
                }
                else
                {
                    cache[3] = true;
                }

                cache[0] = cache[1];
                cache[1] = cache[2];
                cache[2] = cache[3];
            }

            return cache[3];
        }


        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */

        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return root;

            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;
            InvertTree(root.left);
            InvertTree(root.right);
            return root;
        }



        // Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements. 

        // For example, given nums = [0, 1, 0, 3, 12], after calling your function, nums should be [1, 3, 12, 0, 0]. 

        // Note:

        // 1.You must do this in-place without making a copy of the array.
        // 2.Minimize the total number of operations.



        public void MoveZeroes(int[] nums)
        {
            int countOfZeros = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i - countOfZeros] = nums[i];
                if (nums[i] == 0) countOfZeros++;
            }
            for (; countOfZeros > 0; countOfZeros--)
            {
                nums[nums.Length - countOfZeros] = 0;
            }
        }


        // Given two binary trees, write a function to check if they are equal or not. 

        // Two binary trees are considered equal if they are structurally identical and the nodes have the same value. 

        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;
            if (p.val == q.val)
            {
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }
            else
            {
                return false;
            }
        }


        // Given two strings s and t, write a function to determine if t is an anagram of s.

        // For example,
        // s = "anagram", t = "nagaram", return true.
        // s = "rat", t = "car", return false. 

        // Note:
        //  You may assume the string contains only lowercase alphabets.

        // Follow up:
        //  What if the inputs contain unicode characters? How would you adapt your solution to such case?

        public bool IsAnagram(string s, string t)
        {
            int[] index = new int[26];
            for (int i = 0; i < 26; i++) index[i] = 0;
            foreach (char a in s)
            {
                index[a - 'a']++;
            }
            foreach (char c in t)
            {
                index[c - 'a']--;
            }
            foreach (int i in index)
            {
                if (i != 0) return false;
            }
            return true;
        }



        // Related to question Excel Sheet Column Title

        // Given a column title as appear in an Excel sheet, return its corresponding column number.

        // For example:
        //     A -> 1
        //     B -> 2
        //     C -> 3
        //     ...
        //     Z -> 26
        //     AA -> 27
        //     AB -> 28 



        public int TitleToNumber(string s)
        {
            int ret = 0;
            foreach (char c in s)
            {
                ret *= 26;
                ret += (c - 'A' + 1);
            }
            return ret;
        }



        // Given an array of integers, find if the array contains any duplicates. 
        // Your function should return true if any value appears at least twice in the array, and it should return false if every element is distinct. 



        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> dict = new HashSet<int>();
            foreach (int i in nums)
            {
                if (!dict.Add(i)) return true;
            }
            return false;
        }



        // Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊ n/2 ⌋ times.

        // You may assume that the array is non-empty and the majority element always exist in the array.

        // Credits:
        // Special thanks to @ts for adding this problem and creating all test cases.


        public int MajorityElement(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int maxCount = 0;
            int num = 0;
            foreach (int i in nums)
            {
                if (map.ContainsKey(i)) map[i]++;
                else map.Add(i, 1);

                if (map[i] > maxCount)
                {
                    maxCount = map[i];
                    num = i;
                }
            }

            return num;
        }


        // Reverse a singly linked list.

        // click to show more hints.


        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int x) { val = x; }
         * }
         */
        public ListNode ReverseList(ListNode head)
        {
            if (head == null) return null;
            ListNode tHead = head;
            ListNode last = null;
            while (tHead.next != null)
            {
                ListNode temp = tHead.next;
                tHead.next = last;
                last = tHead;
                tHead = temp;
            }
            tHead.next = last;
            return tHead;
        }



        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int x) { val = x; }
         * }
         */
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode head;
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.val > l2.val)
            {
                head = l2;
                l2 = l2.next;
            }
            else
            {
                head = l1;
                l1 = l1.next;
            }
            ListNode tP = head;

            while (l1 != null && l2 != null)
            {
                if (l1.val > l2.val)
                {
                    tP.next = l2;
                    l2 = l2.next;
                    tP = tP.next;
                }
                else
                {
                    tP.next = l1;
                    l1 = l1.next;
                    tP = tP.next;
                }
            }

            if (l2 == null)
            {
                tP.next = l1;
            }
            else
            {
                tP.next = l2;
            }
            return head;
        }



        // Implement the following operations of a queue using stacks. 
        // • push(x) -- Push element x to the back of queue. 
        // • pop() -- Removes the element from in front of queue. 
        // • peek() -- Get the front element. 
        // • empty() -- Return whether the queue is empty. 
        // Notes:
        // •You must use only standard operations of a stack -- which means only push to top, peek/pop from top, size, and is empty operations are valid.
        // •Depending on your language, stack may not be supported natively. You may simulate a stack by using a list or deque (double-ended queue), as long as you use only standard operations of a stack.
        // •You may assume that all operations are valid (for example, no pop or peek operations will be called on an empty queue).



        // You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

        // Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.

        // Credits:
        // Special thanks to @ifanchu for adding this problem and creating all test cases. Also thanks to @ts for adding additional test cases.




        public int Rob(int[] nums)
        {
            int[] ret = new int[nums.Length];
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return Math.Max(nums[0], nums[1]);
            ret[0] = nums[0];
            ret[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < nums.Length; i++)
            {
                ret[i] = Math.Max(ret[i - 2] + nums[i], ret[i - 1]);
            }
            return ret[nums.Length - 1];
        }




        // Given a binary tree, determine if it is height-balanced. 

        // For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1. 





        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */
        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;
            bool isB = true;
            FromRoot(root, 0, ref isB);
            return isB;
        }

        private int FromRoot(TreeNode root, int dep, ref bool isBalanced)
        {
            if (root == null) return dep - 1;
            if (!isBalanced) return 0;

            int left = FromRoot(root.left, dep + 1, ref isBalanced);
            int right = FromRoot(root.right, dep + 1, ref isBalanced);

            if (isBalanced && (left - right > 1 || left - right < -1)) isBalanced = false;
            return Math.Max(left, right);
        }



        // Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).

        // For example, this binary tree is symmetric: 
        //     1
        //    / \
        //   2   2
        //  / \ / \
        // 3  4 4  3



        // But the following is not:

        //     1
        //    / \
        //   2   2
        //    \   \
        //    3    3



        // Note:
        //  Bonus points if you could solve it both recursively and iteratively. 

        // confused what "{1,#,2,3}" means? > read more on how binary tree is serialized on OJ.



        // Subscribe to see which companies asked this question
        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */

        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            return IsMirror(root.left, root.right);

        }

        private bool IsMirror(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            if (left == null && right != null) return false;
            if (left != null && right == null) return false;
            if (left.val == right.val)
            {
                return IsMirror(left.left, right.right) && IsMirror(left.right, right.left);
            }
            return false;
        }

        //Given a binary tree, return the bottom-up level order traversal of its nodes' values. (ie, from left to right, level by level from leaf to root).

        // For example:
        //  Given binary tree {3,9,20,#,#,15,7},

        //     3
        //    / \
        //   9  20
        //     /  \
        //    15   7



        // return its bottom-up level order traversal as:

        // [
        //   [15,7],
        //   [9,20],
        //   [3]
        // ]



        // confused what "{1,#,2,3}" means? > read more on how binary tree is serialized on OJ.



        // Subscribe to see which companies asked this question


        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> ret = new List<IList<int>>(0);

            LevelOrderHelper(root, 0, ret);
            IList<IList<int>> finalRet = new List<IList<int>>(0);
            for (int i = ret.Count() - 1; i >= 0; i--)
            {
                finalRet.Add(ret[i]);
            }

            return finalRet;
        }

        private void LevelOrderHelper(TreeNode root, int dep, IList<IList<int>> cache)
        {
            if (root == null) return;
            if (cache.Count < dep + 1) cache.Add(new List<int>());
            cache[dep].Add(root.val);
            LevelOrderHelper(root.left, dep + 1, cache);
            LevelOrderHelper(root.right, dep + 1, cache);
            return;
        }


        // Given a sorted linked list, delete all duplicates such that each element appear only once. 

        // For example,
        //  Given 1->1->2, return 1->2.
        //  Given 1->1->2->3->3, return 1->2->3. 




        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int x) { val = x; }
         * }
         */
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return null;

            ListNode t = head;
            while (t.next != null)
            {
                if (t.val == t.next.val) t.next = t.next.next;
                else t = t.next;
            }

            return head;
        }


        // Write a function that takes an unsigned integer and returns the number of ’1' bits it has (also known as the Hamming weight).

        // For example, the 32-bit integer ’11' has binary representation 00000000000000000000000000001011, so the function should return 3.

        public int HammingWeight(uint n)
        {
            int ret = 0;
            uint one = 1;
            while (n > 0)
            {
                if ((n & one) == 1) ret++;
                n = n >> 1;
            }
            return ret;
        }



        // Given a singly linked list, group all odd nodes together followed by the even nodes. Please note here we are talking about the node number and not the value in the nodes.

        // You should try to do it in place. The program should run in O(1) space complexity and O(nodes) time complexity.



        // Example:
        //  Given 1->2->3->4->5->NULL,
        //  return 1->3->5->2->4->NULL. 

        // Note:
        //  The relative order inside both the even and odd groups should remain as it was in the input. 
        //  The first node is considered odd, the second node even and so on ... 

        // Credits:
        // Special thanks to @DjangoUnchained for adding this problem and creating all test cases.


        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int x) { val = x; }
         * }
         */
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null) return head;
            if (head.next.next == null) return head;
            ListNode oddH = head;
            ListNode evenH = head.next;
            ListNode evenHOri = head.next;
            ListNode temp = oddH;
            int i = 0;
            while (oddH != null && evenH != null)
            {
                if (i % 2 == 0)
                {
                    oddH.next = evenH.next;
                    temp = oddH;
                    oddH = oddH.next;

                }
                else
                {
                    evenH.next = oddH.next;
                    evenH = evenH.next;
                }
                i++;
            }

            if (oddH == null) temp.next = evenHOri;
            if (evenH == null) oddH.next = evenHOri;
            return head;
        }



        // You are climbing a stair case. It takes n steps to reach to the top.

        // Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top? 

        public int ClimbStairs(int n)
        {
            if (n < 1) return 0;
            if (n == 1) return 1;
            if (n == 2) return 2;
            int[] ret = new int[n];
            ret[0] = 1;
            ret[1] = 2;
            for (int i = 2; i < n; i++)
            {
                ret[i] = ret[i - 2] + ret[i - 1];
            }
            return ret[n - 1];
        }

        // Write a program to check whether a given number is an ugly number. 

        // Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. For example, 6, 8 are ugly while 14 is not ugly since it includes another prime factor 7. 

        // Note that 1 is typically treated as an ugly number. 

        public bool IsUgly(int num)
        {
            if (num <= 0) return false;
            if (num == 1) return true;
            if (num % 2 == 0) return IsUgly(num / 2);
            if (num % 3 == 0) return IsUgly(num / 3);
            if (num % 5 == 0) return IsUgly(num / 5);
            if (num % 6 == 0 || num % 10 == 0 || num % 15 == 0) return true;
            return false;
        }

        // Given an array and a value, remove all instances of that value in place and return the new length. 

        // Do not allocate extra space for another array, you must do this in place with constant memory.

        // The order of elements can be changed. It doesn't matter what you leave beyond the new length.

        // Example:
        //  Given input array nums = [3,2,2,3], val = 3 

        // Your function should return length = 2, with the first two elements of nums being 2.


        public int RemoveElement(int[] nums, int val)
        {
            int cntOfV = 0;
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                nums[i - cntOfV] = nums[i];
                if (nums[i] == val) cntOfV++;
            }

            return n - cntOfV;
        }



        // Given a sorted array, remove the duplicates in place such that each element appear only once and return the new length.

        // Do not allocate extra space for another array, you must do this in place with constant memory. 

        // For example,
        //  Given input array nums = [1,1,2], 

        // Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively. It doesn't matter what you leave beyond the new length

        public int RemoveDuplicates(int[] nums)
        {

            int cntOfDup = 0;
            int n = nums.Length;
            if (n == 1 || n == 0) return n;

            for (int i = 1; i < n; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    cntOfDup++;
                }
                else
                {
                    nums[i - cntOfDup] = nums[i];
                }
            }

            return n - cntOfDup;
        }



        // Given a non-negative number represented as an array of digits, plus one to the number.

        // The digits are stored such that the most significant digit is at the head of the list.

        public int[] PlusOne(int[] digits)
        {
            int n = digits.Length;
            int[] ret = new int[digits.Length];
            bool isUp = true;
            for (int i = n - 1; i >= 0; i--)
            {
                if (isUp)
                {
                    digits[i] = digits[i] + 1;
                    i++;
                    isUp = false;
                }
                else if (digits[i] >= 10)
                {
                    ret[i] = digits[i] % 10;
                    isUp = true;
                }
                else
                {
                    ret[i] = digits[i];
                }
            }

            if (isUp)
            {
                int[] newRet = new int[n + 1];
                for (int i = ret.Length - 1; i > 0; i--) newRet[i] = ret[i - 1];
                newRet[0] = 1;
                return newRet;
            }

            return ret;
        }

        // Given numRows, generate the first numRows of Pascal's triangle.

        // For example, given numRows = 5,
        //  Return 
        // [
        //      [1],
        //     [1,1],
        //    [1,2,1],
        //   [1,3,3,1],
        //  [1,4,6,4,1]
        // ]


        public IList<IList<int>> Generate(int numRows)
        {
            if (numRows < 1) return new List<IList<int>>();
            IList<IList<int>> ret = new List<IList<int>>();
            ret.Add(new List<int>());
            ret[0].Add(1);
            for (int i = 1; i < numRows; i++)
            {
                ret.Add(new List<int>());
                ret[i].Add(1);
                for (int j = 1; j < i; j++)
                {
                    ret[i].Add(ret[i - 1][j - 1] + ret[i - 1][j]);
                }
                ret[i].Add(1);
            }

            return ret;
        }


        // Given an array of integers, every element appears twice except for one. Find that single one.

        // Note:
        //  Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?

        public int SingleNumber(int[] nums)
        {
            int a = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                a ^= nums[i];
            }
            return a;
        }



        // Given an array of numbers nums, in which exactly two elements appear only once and all the other elements appear exactly twice. Find the two elements that appear only once. 

        // For example: 

        // Given nums = [1, 2, 1, 3, 2, 5], return [3, 5]. 

        // Note:

        // 1.The order of the result is not important. So in the above example, [5, 3] is also correct.
        // 2.Your algorithm should run in linear runtime complexity. Could you implement it using only constant space complexity?

        public int[] SingleNumber2(int[] nums)
        {

            int aXb = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                aXb ^= nums[i];
            }

            int ub = aXb & (~aXb + 1);
            int[] ret = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                if ((nums[i] & ub) > 0) ret[0] ^= nums[i];
                else ret[1] ^= nums[i];
            }

            return ret;
        }

        public IList<int> GetRow(int rowIndex)
        {
            IList<int> ret = new List<int>();
            IList<int> temp = new List<int>();
            ret.Add(1);
            for (int i = 1; i < rowIndex + 1; i++)
            {
                temp.Clear();
                temp.Add(1);
                for (int j = 1; j < i; j++)
                {
                    temp.Add(ret[j - 1] + ret[j]);
                }
                temp.Add(1);

                IList<int> tt = ret;
                ret = temp;
                temp = tt;
            }

            return ret;
        }



        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> ret = new List<IList<int>>();
            LevelOrderHelper(root, 0, ref ret);
            return ret;
        }

        private void LevelOrderHelper(TreeNode root, int level, ref IList<IList<int>> ret)
        {
            if (root == null) return;
            if (ret.Count < level + 1) ret.Add(new List<int>());
            ret[level].Add(root.val);
            LevelOrderHelper(root.left, level + 1, ref ret);
            LevelOrderHelper(root.right, level + 1, ref ret);
            return;
        }




        // Given an array of n integers where n > 1, nums, return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].

        // Solve it without division and in O(n).

        // For example, given [1,2,3,4], return [24,12,8,6]. 



        public int[] ProductExceptSelf(int[] nums)
        {

            int n = nums.Length;
            if (n <= 1) return nums;
            if (n == 2) return new int[] { nums[1], nums[0] };

            int[] left = new int[n];
            left[0] = 1;
            int l = nums[0]; int r = nums[n - 1];

            for (int i = 1; i < n; i++)
            {
                left[i] = l;
                l *= nums[i];
            }

            for (int i = n - 2; i > 0; i--)
            {
                left[i] *= r;
                r *= nums[i];
            }

            left[0] = r;
            return left;
        }




        // Given a string array words, find the maximum value of length(word[i]) * length(word[j]) where the two words do not share common letters. You may assume that each word will contain only lower case letters. If no such two words exist, return 0. 

        // Example 1:


        // Given ["abcw", "baz", "foo", "bar", "xtfn", "abcdef"]
        //  Return 16
        //  The two words can be "abcw", "xtfn". 

        // Example 2:


        // Given ["a", "ab", "abc", "d", "cd", "bcd", "abcd"]
        //  Return 4
        //  The two words can be "ab", "cd". 

        // Example 3:


        // Given ["a", "aa", "aaa", "aaaa"]
        //  Return 0
        //  No such pair of words. 





        public int MaxProduct(string[] words)
        {
            int[] bits = new int[words.Length];
            int[] bitMap = new int[26];

            for (int i = 0; i < 26; i++)
            {
                bitMap[i] = 1 << 26 - i;
            }

            for (int w = 0; w < words.Length; w++)
            {
                bits[w] = 0;
                for (int i = 0; i < 26; i++)
                {
                    if (words[w].IndexOf((char)('a' + i)) >= 0)
                    {
                        bits[w] = bits[w] | bitMap[i];
                    }
                }
            }

            int max = 0;
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    if ((i != j))
                    {
                        if ((bits[i] & bits[j]) == 0)
                        {
                            max = Math.Max(max, words[i].Length * words[j].Length);
                        }
                    }
                }
            }

            return max;
        }



        // Determine whether an integer is a palindrome. Do this without extra space.

        public bool IsPalindrome(int x)
        {
            int t = x;
            int k = 0;
            while (t > 0)
            {
                k = k * 10 + t % 10;
                t = t / 10;
            }

            return k == x;
        }



        // Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum. 
        // For example:
        //  Given the below binary tree and sum = 22,               5
        //              / \
        //             4   8
        //            /   / \
        //           11  13  4
        //          /  \      \
        //         7    2      1


        // return true, as there exist a root-to-leaf path 5->4->11->2 which sum is 22.


        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null) return false;
            int ret = 0;
            return SumHelper(root, sum, ref ret);
        }

        private bool SumHelper(TreeNode root, int sum, ref int ret)
        {
            ret += root.val;
            if (root.left == null && root.right == null && sum == ret) return true;


            if (root.left != null)
            {
                if (SumHelper(root.left, sum, ref ret)) return true;
            }
            if (root.right != null)
            {
                if (SumHelper(root.right, sum, ref ret)) return true;
            }

            ret -= root.val;
            return false;
        }



        public int MinDepth(TreeNode root)
        {
            int level = 1;
            int min = int.MaxValue;
            if (root == null) return 0;
            MDHelper(root, ref level, ref min);

            return min;
        }

        private void MDHelper(TreeNode root, ref int level, ref int min)
        {
            if (root.left == null && root.right == null)
            {
                min = Math.Min(min, level);
                return;
            }

            level++;
            if (root.left != null) MDHelper(root.left, ref level, ref min);
            if (root.right != null) MDHelper(root.right, ref level, ref min);

            level--;
            return;
        }



        public int MissingNumber(int[] nums)
        {

            int n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                if (i != nums[i])
                {
                    int temp = nums[i];
                    if (nums[i] == n)
                    {
                        continue;
                    }
                    else
                    {
                        nums[i] = nums[nums[i]];
                        nums[temp] = temp;
                    }
                    i--;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (i != nums[i]) return i;
            }

            return n;
        }




        public int[] CountBits(int num)
        {

            int[] ret = new int[num + 1];
            if (num == 0)
            {
                ret[0] = 0;
                return ret;
            }

            int level = 1;
            for (; level <= num;)
            {
                level = level * 2;
                int j = 0;
                for (int i = level / 2; i < level && i <= num; i++, j++)
                {
                    ret[i] = 1 + ret[j];
                }

            }

            return ret;
        }




        //Given an array of integers, every element appears three times except for one. Find that single one. 

        // Note:
        //  Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory? 


        public int SingleNumber3(int[] nums)
        {
            int mask = 1 << 30;
            int ret = 0;
            int count;
            for (int i = 0; i < 31; i++)
            {
                count = 0;
                int k = mask >> i;
                for (int j = 0; j < nums.Length; j++)
                {
                    if ((nums[j] & k) > 0)
                    {
                        count++;
                    }
                }

                if (count % 3 != 0) ret |= k;
            }

            mask = 1 << 31;
            count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if ((nums[i] & mask) != 0) count++;
            }

            if (count % 3 != 0) ret |= mask;

            return ret;
        }

        // Given n, how many structurally unique BST's (binary search trees) that store values 1...n?

        // For example,
        //  Given n = 3, there are a total of 5 unique BST's. 
        //    1         3     3      2      1
        //     \       /     /      / \      \
        //      3     2     1      1   3      2
        //     /     /       \                 \
        //    2     1         2                 3

        public int NumTrees(int n)
        {

            if (n == 0) return 0;
            if (n == 1) return 1;
            int[] cache = new int[n + 1];
            cache[0] = 1;
            cache[1] = 1;
            cache[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                cache[i] = 0;
                for (int j = 0; j < i; j++)
                {
                    cache[i] += cache[j] * cache[i - j - 1];
                }
            }

            return cache[n];
        }


        // Given a sorted array and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

        // You may assume no duplicates in the array.

        // Here are few examples.
        // [1,3,5,6], 5 → 2
        // [1,3,5,6], 2 → 1
        // [1,3,5,6], 7 → 4
        // [1,3,5,6], 0 → 0 



        public int SearchInsert(int[] nums, int target)
        {
            int index = QuickFind(nums, 0, nums.Length - 1, target);
            return index;
        }

        private int QuickFind(int[] nums, int start, int end, int target)
        {
            if (start >= end)
            {
                if (nums[start] < target) return start + 1;
                else if (nums[start] >= target) return start;
            }
            int middle = start + (end - start) / 2;
            if (nums[middle] == target) return middle;
            //if(nums[middle] > target && middle == 0) return 0;
            //if(nums[middle] < target && middle == nums.Length-1) return nums.Length;
            //if(nums[middle] < target && nums[middle] > target) return middle+1;
            if (nums[middle] < target) return QuickFind(nums, middle + 1, end, target);
            else return QuickFind(nums, start, middle - 1, target);
        }



        // Given an array where elements are sorted in ascending order, convert it to a height balanced BST.

        public TreeNode SortedArrayToBST(int[] nums)
        {

            TreeNode root = GetRoot(nums, 0, nums.Length - 1);
            return root;
        }

        private TreeNode GetRoot(int[] nums, int start, int end)
        {
            if (start > end) return null;
            int middle = start + (end - start) / 2;
            TreeNode root = new TreeNode(nums[middle]);
            root.left = GetRoot(nums, start, middle - 1);
            root.right = GetRoot(nums, middle + 1, end);
            return root;

        }




        // Given a linked list, determine if it has a cycle in it. 

        // Follow up:
        //  Can you solve it without using extra space? 


        public bool HasCycle(ListNode head)
        {
            ListNode p = head;
            ListNode pp = head;

            while (p != null && pp != null)
            {
                p = p.next;
                if (pp.next == null) return false;
                pp = pp.next.next;

                if (p == pp) return true;
            }

            return false;
        }



        public int KthSmallest(TreeNode root, int k)
        {

            bool isB = false;
            int ret = 0;
            KHelper(root, ref k, ref isB, ref ret);
            return ret;
        }

        private void KHelper(TreeNode root, ref int k, ref bool isBottom, ref int ret)
        {

            if (!isBottom && root == null) isBottom = true;
            if (root == null) return;

            KHelper(root.left, ref k, ref isBottom, ref ret);
            if (k == 0) return;


            k--;
            if (k == 0 && isBottom)
            {
                ret = root.val;
                return;
            }

            KHelper(root.right, ref k, ref isBottom, ref ret);
            if (k == 0) return;

        }




        public IList<string> GenerateParenthesis(int n)
        {

            List<string> ret = new List<string>();
            char[] str = new char[n + n]; ;
            int open = 0;
            int close = 0;

            int i = 0;

            helper(ret, str, i, open, close, n);

            return ret;

        }

        private void helper(List<string> ret, char[] str, int i, int open, int close, int n)
        {
            if (open < close || open > n || close > n) return;
            if (open == n && close == n)
            {
                ret.Add(new string(str));
                return;
            }

            if (open < n)
            {
                str[i++] = '(';
                helper(ret, str, i, open + 1, close, n);
                i--;
            }

            str[i++] = ')';
            helper(ret, str, i, open, close + 1, n);

        }


        // Suppose a sorted array is rotated at some pivot unknown to you beforehand.

        // (i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).

        // Find the minimum element.

        // You may assume no duplicate exists in the array.


        public int FindMin(int[] nums)
        {
            if (nums == null) return 0;
            return FHelper(nums, 0, nums.Length - 1);
        }

        private int FHelper(int[] nums, int start, int end)
        {
            if (start + 1 == end)
            {
                if (nums[end] < nums[start]) return nums[end];
                return nums[start];
            }

            if (start >= end)
            {
                if (nums[start] > nums[end]) return nums[end];
                else return nums[start];
            }

            int middle = start + (end - start) / 2;

            if (nums[middle] > nums[start] && nums[middle] > nums[end])
            {
                return FHelper(nums, middle, end);
            }

            return FHelper(nums, start, middle);

        }



        // The gray code is a binary numeral system where two successive values differ in only one bit.

        // Given a non-negative integer n representing the total number of bits in the code, print the sequence of gray code. A gray code sequence must begin with 0.

        // For example, given n = 2, return [0,1,3,2]. Its gray code sequence is:
        // 00 - 0
        // 01 - 1
        // 11 - 3
        // 10 - 2


        // Note:
        //  For a given n, a gray code sequence is not uniquely defined. 

        // For example, [0,2,3,1] is also a valid gray code sequence according to the above definition.

        // For now, the judge is able to judge based on one instance of gray code sequence. Sorry about that.


        public IList<int> GrayCode(int n)
        {
            HashSet<int> dic = new HashSet<int>();
            Backtrack(dic, n, (int)Math.Pow(2, n), 0);
            return dic.ToList<int>();
        }

        private void Backtrack(HashSet<int> dic, int n, int sum, int last)
        {
            if (dic.Count == sum) return;

            dic.Add(last);
            for (int i = 0; i < n; i++)
            {
                int nVal = last ^ 1 << i;
                if (!dic.Contains(nVal))
                {
                    Backtrack(dic, n, sum, nVal);
                }
            }

            return;
        }




        // Given a collection of distinct numbers, return all possible permutations. 

        // For example,
        // [1,2,3] have the following permutations:
        // [1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,1,2], and [3,2,1]. 


        public IList<IList<int>> Permute(int[] nums)
        {

            IList<IList<int>> ret = new List<IList<int>>();

            Backtrack(ret, nums, 0);
            return ret;

        }

        private void Backtrack(IList<IList<int>> ret, int[] nums, int step)
        {
            if (step == nums.Length)
            {
                ret.Add(nums.ToList<int>());
                return;
            }

            for (int i = step; i < nums.Length; i++)
            {
                int temp = nums[step];
                nums[step] = nums[i];
                nums[i] = temp;
                Backtrack(ret, nums, step + 1);
                temp = nums[step];
                nums[step] = nums[i];
                nums[i] = temp;
            }

            return;
        }




        // Given a collection of numbers that might contain duplicates, return all possible unique permutations. 

        // For example,
        // [1,1,2] have the following unique permutations:
        // [1,1,2], [1,2,1], and [2,1,1]. 



        public IList<IList<int>> PermuteUnique(int[] nums)
        {


            IList<IList<int>> ret = new List<IList<int>>();

            BacktrackPermutation(ret, nums, 0);
            return ret;
        }

        private void BacktrackPermutation(IList<IList<int>> ret, int[] nums, int step)
        {
            if (step == nums.Length)
            {
                ret.Add(nums.ToList<int>());
                return;
            }

            HashSet<int> cache = new HashSet<int>();
            for (int i = step; i < nums.Length; i++)
            {
                if (!cache.Add(nums[i])) continue;
                int temp = nums[step];
                nums[step] = nums[i];
                nums[i] = temp;
                Backtrack(ret, nums, step + 1);
                temp = nums[step];
                nums[step] = nums[i];
                nums[i] = temp;
            }

            return;
        }


        // Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.

        // If such arrangement is not possible, it must rearrange it as the lowest possible order(ie, sorted in ascending order). 

        // The replacement must be in-place, do not allocate extra memory.

        // Here are some examples.Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.
        // 1,2,3 → 1,3,2
        // 3,2,1 → 1,2,3
        // 1,1,5 → 1,5,1


        private List<int> _Min = new List<int>();

        public void NextPermutation(int[] nums)
        {

            int n = nums.Length;

            for (int end = n - 1; end >= 0; end--)
            {
                for (int i = n - 1; i >= end; i--)
                {
                    if (nums[i] > nums[end])
                    {
                        int temp = nums[i];
                        nums[i] = nums[end];
                        nums[end] = temp;

                        for (int f = end + 1; f < n; f++)
                        {
                            _Min.Add(nums[f]);
                        }

                        _Min.Sort();

                        //NextPH(nums, i+1, i+1,  min);
                        for (int f = 0; f + end + 1 < n; f++)
                        {
                            nums[f + end + 1] = _Min[f];
                        }
                        return;
                    }
                }
            }

            System.Array.Sort(nums);
            return;
        }



        // Given a set of candidate numbers(C) and a target number(T), find all unique combinations in C where the candidate numbers sums to T.

        // The same repeated number may be chosen from C unlimited number of times. 


        // Note:

        // •All numbers (including target) will be positive integers.
        // •Elements in a combination (a1, a2, … , ak) must be in non-descending order. (ie, a1 ≤ a2 ≤ … ≤ ak).
        // •The solution set must not contain duplicate combinations.


        // For example, given candidate set 2,3,6,7 and target 7,
        //  A solution set is: 
        // [7]
        // [2, 2, 3]


        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {

            IList<IList<int>> fret = new List<IList<int>>();
            List<int> ret = new List<int>();
            System.Array.Sort(candidates);
            BT(candidates, ret, fret, target, 0);

            return fret;
        }

        private void BT(int[] can, List<int> ret, IList<IList<int>> fret, int target, int step)
        {

            if (target == 0)
            {
                List<int> t = ret.ToList<int>();
                fret.Add(t);
                return;
            }

            if (target < 0 || step >= can.Length) return;

            int i = target / can[step];
            for (int j = 0; j < i; j++) ret.Add(can[step]);
            for (; i > 0; i--)
            {

                BT(can, ret, fret, target - i * can[step], step + 1);
                ret.RemoveAt(ret.Count - 1);
            }

            BT(can, ret, fret, target, step + 1);

            return;
        }




        // ind all possible combinations of k numbers that add up to a number n, given that only numbers from 1 to 9 can be used and each combination should be a unique set of numbers.

        // Ensure that numbers within the set are sorted in ascending order.



        // Example 1:

        // Input: k = 3, n = 7

        // Output: 

        // [[1,2,4]]




        // Example 2:

        // Input: k = 3, n = 9

        // Output: 

        // [[1,2,6], [1,3,5], [2,3,4]]

        public IList<IList<int>> CombinationSum3(int k, int n)
        {

            IList<IList<int>> fret = new List<IList<int>>();
            List<int> ret = new List<int>();
            int[] can = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            BT(can, ret, fret, n, k, 0);

            return fret;
        }

        private void BT(int[] can, List<int> ret, IList<IList<int>> fret, int target, int count, int step)
        {

            if (target == 0 && count == 0)
            {
                List<int> t = ret.ToList<int>();
                fret.Add(t);
                return;
            }

            if (target < 0 || step >= can.Length || count < 0) return;

            count -= 1;
            ret.Add(can[step]);

            BT(can, ret, fret, target - can[step], count, step + 1);
            ret.RemoveAt(ret.Count - 1);
            count++;


            BT(can, ret, fret, target, count, step + 1);

            return;
        }




        // Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.

        // Note: You can only move either down or right at any point in time.


        public int MinPathSum(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    int left = j > 0 ? grid[i, j - 1] + grid[i, j] : grid[i, j];
                    int top = i > 0 ? grid[i - 1, j] + grid[i, j] : grid[i, j];

                    if (j == 0) grid[i, j] = top;
                    else if (i == 0) grid[i, j] = left;
                    else grid[i, j] = Math.Min(left, top);
                }
            }

            return grid[grid.GetLength(0) - 1, grid.GetLength(1) - 1];
        }


        // Given a linked list, swap every two adjacent nodes and return its head.

        // For example,
        //  Given 1->2->3->4, you should return the list as 2->1->4->3. 

        // Your algorithm should use only constant space.You may not modify the values in the list, only nodes itself can be changed. 

        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null) return head;


            ListNode hN = head.next;
            ListNode t = head.next.next;
            head.next = head.next.next;
            hN.next = head;
            ListNode nH = hN;
            ListNode pH = hN.next;

            while (t != null && t.next != null)
            {
                hN = t.next;
                t.next = t.next.next;
                pH.next = hN;
                hN.next = t;
                pH = t;
                t = t.next;
            }

            return nH;
        }



        public Vertex CloneGraph(Vertex a)
        {
            Queue<Vertex> q = new Queue<Vertex>();
            q.Enqueue(a);

            Vertex a1 = new Vertex(a.value);

            Dictionary<int, Vertex> map = new Dictionary<int, Vertex>();
            map.Add(a1.value, a1);

            //{a}, {aV, a1};
            //{b}, {[av, a1], [bv, b1]}
            //{c, d}, {[av, a1], [bv, b1], [cv, c1]. [dv. d1]}
            //{d}, {[av, a1], [bv, b1], [cv, c1], [dv. d1]}
            //{}, {[av, a1], [bv, b1], [cv, c1], [dv. d1]}
            while (q.Any())
            {
                Vertex current = q.Dequeue();
                Vertex cur2;
                map.TryGetValue(current.value, out cur2);

                foreach (Vertex nb in current.neighbours)
                {
                    if (!map.ContainsKey(nb.value))
                    {
                        Vertex clone = new Vertex(nb.value);
                        cur2.neighbours.Add(clone);
                        q.Enqueue(nb);
                        map.Add(clone.value, clone);
                    }
                    else
                    {
                        Vertex clone;
                        if (map.TryGetValue(nb.value, out clone))
                        {
                            cur2.neighbours.Add(clone);
                        }
                    }
                }
            }

            return a1;
        }



        // Implement an iterator over a binary search tree(BST). Your iterator will be initialized with the root node of a BST.

        // Calling next() will return the next smallest number in the BST.

        // Note: next() and hasNext() should run in average O(1) time and uses O(h) memory, where h is the height of the tree


        /**
         * Definition for binary tree
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!This is a very bad solution for the problem.
        /**
         * Your BSTIterator will be called like this:
         * BSTIterator i = new BSTIterator(root);
         * while (i.HasNext()) v[f()] = i.Next();
         */

        public bool SearchMatrix(int[,] matrix, int target)
        {

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int j = BinarySearch(matrix, false, target, 0, m - 1, 0);
            int i = 0;

            if (j < 0) return false;

            if (j >= m) j = m - 1;
            if (matrix[0, j] == target) return true;

            i = BinarySearch(matrix, true, target, 0, n - 1, j);

            if (i > 0 && i < n && matrix[i, j] == target) return true;


            i = BinarySearch(matrix, true, target, 0, n - 1, 0);

            if (i < 0) return false;
            if (i >= n) i = n - 1;

            if (matrix[i, 0] == target) return true;

            j = BinarySearch(matrix, false, target, 0, m - 1, i);

            if (j < m && matrix[i, j] == target) return true;

            while (--i > 0)
            {
                j = BinarySearch(matrix, false, target, 0, m - 1, i);
                if (j < m && matrix[i, j] == target) return true;
            }

            return false;

        }

        private int BinarySearch(int[,] m, bool v, int target, int start, int end, int i)
        {

            if (start + 1 == end)
            {
                if (v)
                {
                    if (m[start, i] < target && target < m[end, i]) return start;
                    if (m[start, i] > target) return start - 1 > 0 ? start - 1 : 0;
                    if (m[end, i] < target) return end;
                }
                else
                {
                    if (m[i, start] < target && target < m[i, end]) return start;
                    if (m[i, start] > target) return start - 1 > 0 ? start - 1 : 0;
                    if (m[i, end] < target) return end;
                }
            }

            if (start == end) return start;

            int middle = start + (end - start) / 2;

            if (v)
            {
                if (m[middle, i] < target) return BinarySearch(m, v, target, middle + 1, end, i);
                else if (m[middle, i] > target) return BinarySearch(m, v, target, start, middle - 1, i);
                return middle;
            }
            else
            {
                if (m[i, middle] < target) return BinarySearch(m, v, target, middle + 1, end, i);
                else if (m[i, middle] > target) return BinarySearch(m, v, target, start, middle - 1, i);
                return middle;
            }
        }


        public bool SearchMatrix2(int[,] matrix, int target)
        {

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int i = 0;
            for (; i < m; i++)
            {
                if (matrix[0, i] > target) break;
            }

            if (i == 0) return false;

            while (--i >= 0)
            {
                int j = BinarySearch(matrix, target, 0, n - 1, i);
                if (j < n && j >= 0 && matrix[j, i] == target) return true;
            }

            return false;
        }

        private int BinarySearch(int[,] m, int target, int start, int end, int i)
        {

            if (start > end) return start - 1;

            int middle = start + (end - start) / 2;

            if (m[middle, i] < target) return BinarySearch(m, target, middle + 1, end, i);
            else if (m[middle, i] > target) return BinarySearch(m, target, start, middle - 1, i);
            return middle;

        }


        // Given an integer n, generate a square matrix filled with elements from 1 to n2 in spiral order.

        // For example,
        //  Given n = 3,
        // You should return the following matrix: [
        //  [ 1, 2, 3 ],
        //  [ 8, 9, 4 ],
        //  [ 7, 6, 5 ]
        // ]



        public int[,] GenerateMatrix(int n)
        {

            int[,] ret = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    ret[i, j] = 0;
                }
            }

            int sq = n * n;
            bool v = false;
            bool r = false;
            int ii = 0;
            int jj = 0;
            for (int i = 0; i < sq;)
            {
                if (!v)
                {
                    if (!r)
                    {
                        while (jj < n && ret[ii, jj] == 0)
                        {
                            ret[ii, jj++] = i + 1;
                            i++;
                        }

                        jj = jj - 1;
                        ii++;
                        v = !v;
                        continue;
                    }
                    if (r)
                    {
                        while (jj > -1 && ret[ii, jj] == 0)
                        {
                            ret[ii, jj--] = i + 1;
                            i++;
                        }

                        jj = jj + 1;
                        ii--;
                        v = !v;
                        continue;
                    }

                }
                else
                {
                    if (!r)
                    {
                        while (ii < n && ret[ii, jj] == 0)
                        {
                            ret[ii++, jj] = i + 1;
                            i++;
                        }
                        ii = ii - 1;
                        jj--;
                        r = !r;
                        v = !v;
                        continue;
                    }
                    if (r)
                    {
                        while (ii > -1 && ret[ii, jj] == 0)
                        {
                            ret[ii--, jj] = i + 1;
                            i++;
                        }

                        ii = ii + 1;
                        jj++;
                        r = !r;
                        v = !v;
                        continue;
                    }
                }

                if (i == sq - 1) break;
            }

            return ret;
        }


        // You are given an n x n 2D matrix representing an image.

        // Rotate the image by 90 degrees (clockwise).

        // Follow up:
        //  Could you do this in-place?

        public void Rotate(int[,] matrix)
        {

            int n = matrix.GetLength(0);

            for (int i = 0; i < (n + 1) / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[n - j - 1, i];
                    matrix[n - j - 1, i] = matrix[n - 1 - i, n - 1 - j];
                    matrix[n - 1 - i, n - 1 - j] = matrix[j, n - 1 - i];
                    matrix[j, n - 1 - i] = temp;
                }
            }

            return;
        }



        // Given two integers n and k, return all possible combinations of k numbers out of 1 ... n.

        // For example,
        //  If n = 4 and k = 2, a solution is: 
        // [
        //   [2,4],
        //   [3,4],
        //   [2,3],
        //   [1,2],
        //   [1,3],
        //   [1,4],
        // ]

        public IList<IList<int>> Combine(int n, int k)
        {
            if (k > n) return null;

            IList<IList<int>> ret = new List<IList<int>>();
            IList<IList<int>> final = new List<IList<int>>();

            List<int> t = new List<int>();
            ret.Add(t);

            for (int i = 1; i <= n; i++)
            {
                int len = ret.Count;
                for (int j = 0; j < len; j++)
                {
                    t = ret[j].ToList<int>();
                    t.Add(i);

                    if (t.Count == k)
                    {
                        final.Add(t);
                    }
                    else
                    {
                        ret.Add(t);
                    }
                }
            }
            return final;
        }




        // Given a string of numbers and operators, return all possible results from computing all the different possible ways to group numbers and operators.The valid operators are +, - and*.

        // Example 1 
        // Input: "2-1-1".
        // ((2-1)-1) = 0
        // (2-(1-1)) = 2
        // Output: [0, 2]

        // Example 2 
        // Input: "2*3-4*5"
        // (2*(3-(4*5))) = -34
        // ((2*3)-(4*5)) = -14
        // ((2*(3-4))*5) = -10
        // (2*((3-4)*5)) = -10
        // (((2*3)-4)*5) = 10
        // Output: [-34, -14, -10, -10, 10]


        public IList<int> DiffWaysToCompute(string input)
        {
            if (input == null) return null;
            List<int> nums = new List<int>();
            List<char> op = new List<char>();
            Parse(input, nums, op);

            List<int>[,] cache = new List<int>[nums.Count, nums.Count];
            return Dp(nums, op, 0, nums.Count - 1, cache);
        }


        private void Parse(string input, List<int> nums, List<char> op)
        {

            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
            {
                if (c == '-' || c == '+' || c == '*')
                {
                    op.Add(c);
                    nums.Add(int.Parse(sb.ToString()));
                    sb.Clear();
                }
                else
                {
                    sb.Append(c);
                }
            }

            nums.Add(int.Parse(sb.ToString()));
            return;
        }

        private List<int> Dp(List<int> nums, List<char> op, int start, int end, List<int>[,] cache)
        {
            if (cache[start, end] != null) return cache[start, end];
            List<int> cur = new List<int>();
            if (start == end)
            {
                cur.Add(nums[start]);
                cache[start, end] = cur;
                return cache[start, end];
            }
            else
            {
                for (int i = start; i < end; i++)
                {
                    List<int> left = Dp(nums, op, start, i, cache);
                    List<int> right = Dp(nums, op, i + 1, end, cache);

                    foreach (int l in left)
                    {
                        foreach (int r in right)
                        {
                            if (op[i] == '-')
                            {
                                cur.Add(l - r);

                            }
                            else if (op[i] == '+')
                            {
                                cur.Add(l + r);

                            }
                            else if (op[i] == '*')
                            {
                                cur.Add(l * r);
                            }
                        }
                    }
                }

                cache[start, end] = cur;
            }

            return cache[start, end];
        }



        // Given a 2D board containing 'X' and 'O', capture all regions surrounded by 'X'.

        // A region is captured by flipping all 'O's into 'X's in that surrounded region.

        // For example,

        // X X X X
        // X O O X
        // X X O X
        // X O X X



        // After running your function, the board should be: 
        // X X X X
        // X X X X
        // X X X X
        // X O X X


        public void Solve(char[,] board)
        {

            int n = board.GetLength(0);
            int m = board.GetLength(1);


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (board[i, j] == 'O')
                    {
                        Search(board, i, j, n, m);
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (board[i, j] == 'L')
                    {
                        board[i, j] = 'O';
                    }
                }
            }
            return;
        }

        private bool Search(char[,] board, int i, int j, int n, int m)
        {

            Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>();
            Queue<KeyValuePair<int, int>> visited = new Queue<KeyValuePair<int, int>>();
            q.Enqueue(new KeyValuePair<int, int>(i, j));
            bool isDead = true;
            while (q.Any())
            {
                KeyValuePair<int, int> p = q.Dequeue();
                i = p.Key;
                j = p.Value;
                if (board[i, j] == 'O')
                {
                    board[i, j] = '!';
                    if (i == 0 || i == n - 1 || j == 0 || j == m - 1)
                    {
                        isDead = false;
                    }
                    else
                    {
                        if (i > 0 && board[i - 1, j] == 'O') q.Enqueue(new KeyValuePair<int, int>(i - 1, j));
                        else if (i > 0 && board[i - 1, j] == 'L') { board[i, j] = 'L'; isDead = false; }
                        if (j > 0 && board[i, j - 1] == 'O') q.Enqueue(new KeyValuePair<int, int>(i, j - 1));
                        else if (j > 0 && board[i, j - 1] == 'L') { board[i, j] = 'L'; isDead = false; }
                        if (i + 1 < n && board[i + 1, j] == 'O') q.Enqueue(new KeyValuePair<int, int>(i + 1, j));
                        else if (i + 1 < n && board[i + 1, j] == 'L') { board[i, j] = 'L'; isDead = false; }
                        if (j + 1 < m && board[i, j + 1] == 'O') q.Enqueue(new KeyValuePair<int, int>(i, j + 1));
                        else if (j + 1 < m && board[i, j + 1] == 'L') { board[i, j] = 'L'; isDead = false; }
                    }
                }

                visited.Enqueue(p);
            }

            if (isDead)
            {
                while (visited.Any())
                {
                    KeyValuePair<int, int> p = visited.Dequeue();
                    board[p.Key, p.Value] = 'X';
                }
            }
            else
            {
                while (visited.Any())
                {
                    KeyValuePair<int, int> p = visited.Dequeue();
                    board[p.Key, p.Value] = 'L';
                }
            }

            return isDead;
        }



        // Given an unsorted array return whether an increasing subsequence of length 3 exists or not in the array. 

        // Formally the function should:


        // Return true if there exists i, j, k  
        //  such that arr[i] < arr[j] < arr[k] given 0 ≤ i < j < k ≤ n-1 else return false. 


        // Your algorithm should run in O(n) time complexity and O(1) space complexity. 

        // Examples:
        //  Given [1, 2, 3, 4, 5],
        //  return true. 

        // Given [5, 4, 3, 2, 1],
        //  return false. 



        public bool IncreasingTriplet(int[] nums)
        {
            if (nums.Length < 3) return false;

            //int left = 0;
            //int right = nums.Length-1;
            //bool[] biggerLeft = new bool[nums.Length];

            //for(int i = 1; i < nums.Length; i++){
            //    if(nums[i] < nums[left])  left = i;
            //    if(nums[i]>nums[left]) biggerLeft[i] = true;
            //}

            //for(int i = nums.Length-2; i > 0; i--){
            //    if(nums[i] > nums[right]){
            //      right = i;
            //    }

            //    if(nums[i] < nums[right] && biggerLeft[i]) return true;
            //}


            int min = nums[0]; int mid = int.MaxValue;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < min) min = nums[i];

                if (nums[i] > min && nums[i] < mid)
                {
                    mid = nums[i];
                }

                if (nums[i] > mid) return true;
            }
            return false;
        }



        // Given a m x n matrix, if an element is 0, set its entire row and column to 0. Do it in place. 

        // click to show follow up.

        // Follow up: 
        // Did you use extra space?
        //  A straight forward solution using O(mn) space is probably a bad idea.
        //  A simple improvement uses O(m + n) space, but still not the best solution.
        //  Could you devise a constant space solution? 


        public void SetZeroes(int[,] matrix)
        {

            HashSet<int> rows = new HashSet<int>();
            HashSet<int> cols = new HashSet<int>();

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }
                }
            }

            foreach (int r in rows)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[r, j] = 0;
                }
            }

            foreach (int c in cols)
            {
                for (int i = 0; i < n; i++)
                {
                    matrix[i, c] = 0;
                }
            }
            return;
        }



        // Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

        // Example 1:
        // 11110
        // 11010
        // 11000
        // 00000

        // Answer: 1

        // Example 2:
        // 11000
        // 11000
        // 00100
        // 00011

        // Answer: 3



        public int NumIslands(char[,] grid)
        {

            int n = grid.GetLength(0);
            int m = grid.GetLength(1);
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i, j] == '1')
                    {
                        sum += BFS(grid, i, j, n, m);
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i, j] == '2')
                    {
                        grid[i, j] = '1';
                    }
                }
            }

            return sum;
        }

        private int BFS(char[,] grid, int i, int j, int n, int m)
        {

            Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>();
            q.Enqueue(new KeyValuePair<int, int>(i, j));
            while (q.Any())
            {
                KeyValuePair<int, int> top = q.Dequeue();
                int x = top.Key;
                int y = top.Value;
                if (grid[x, y] != '1') continue;

                if (x > 0 && grid[x - 1, y] == '1') q.Enqueue(new KeyValuePair<int, int>(x - 1, y));
                if (y > 0 && grid[x, y - 1] == '1') q.Enqueue(new KeyValuePair<int, int>(x, y - 1));
                if (x < n - 1 && grid[x + 1, y] == '1') q.Enqueue(new KeyValuePair<int, int>(x + 1, y));
                if (y < m - 1 && grid[x, y + 1] == '1') q.Enqueue(new KeyValuePair<int, int>(x, y + 1));

                grid[x, y] = '2';
            }

            return 1;
        }




        // Find the kth largest element in an unsorted array. Note that it is the kth largest element in the sorted order, not the kth distinct element. 

        // For example,
        //  Given [3,2,1,5,6,4] and k = 2, return 5. 

        // Note: 
        //  You may assume k is always valid, 1 ≤ k ≤ array's length.



        public int FindKthLargest(int[] nums, int k)
        {
            List<int> kL = new List<int>(k);

            for (int i = 0; i < k; i++)
            {
                kL.Add(nums[i]);
            }

            kL.Sort();

            for (int j = k; j < nums.Length; j++)
            {
                if (nums[j] > kL[0])
                {
                    QuickAdjust(kL, 0, k - 1, nums[j]);
                }
            }

            return kL[0];
        }


        private void QuickAdjust(List<int> kL, int start, int end, int target)
        {
            if (start >= end)
            {
                if (start > 0 && start < kL.Count)
                {
                    for (int i = 0; i < start; i++)
                    {
                        kL[i] = kL[i + 1];
                    }
                }
                if (kL[start] < target) kL[start] = target;
                if (kL[start] > target && start > 0) kL[start - 1] = target;
                return;
            }

            int middle = start + (end - start) / 2;

            if (target < kL[middle])
            {
                QuickAdjust(kL, start, middle - 1, target);
            }
            else
            {
                QuickAdjust(kL, middle + 1, end, target);
            }
        }



        // Write a program to find the nth super ugly number.

        // Super ugly numbers are positive numbers whose all prime factors are in the given prime list primes of size k. For example, [1, 2, 4, 7, 8, 13, 14, 16, 19, 26, 28, 32]  is the sequence of the first 12 super ugly numbers given primes = [2, 7, 13, 19] of size 4. 

        // Note:
        //  (1) 1 is a super ugly number for any given primes.
        //  (2) The given numbers in primes are in ascending order.
        //  (3) 0 < k ≤ 100, 0 < n ≤ 106, 0 < primes[i] < 1000. 


        public int NthSuperUglyNumber(int n, int[] primes)
        {
            int k = primes.Length;
            int[] ret = new int[n];

            int[] index = new int[k];
            int[] factor = new int[k];

            for (int i = 0; i < k; i++)
            {
                index[i] = 0;
                factor[i] = primes[i];
            }

            ret[0] = 1;

            for (int i = 1; i < n; i++)
            {
                int min = int.MaxValue;

                for (int j = 0; j < k; j++)
                {
                    if (min > factor[j]) min = factor[j];
                }

                ret[i] = min;

                for (int j = 0; j < k; j++)
                {
                    if (factor[j] == min) factor[j] = primes[j] * ret[++index[j]];
                }
            }

            return ret[n - 1];
        }


        // Write a program to find the n-th ugly number.

        // Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. For example, 1, 2, 3, 4, 5, 6, 8, 9, 10, 12 is the sequence of the first 10 ugly numbers.

        // Note that 1 is typically treated as an ugly number.



        public int NthUglyNumber(int n)
        {
            int[] ret = new int[n];

            ret[0] = 1;

            int i2 = 0; int i3 = 0; int i5 = 0;

            int f1 = 2; int f2 = 3; int f3 = 5;

            for (int i = 1; i < n; i++)
            {

                int min = int.MaxValue;

                if (min > f1) min = f1;
                if (min > f2) min = f2;
                if (min > f3) min = f3;

                ret[i] = min;

                if (min == f1) f1 = 2 * ret[++i2];
                if (min == f2) f2 = 3 * ret[++i3];
                if (min == f3) f3 = 5 * ret[++i5];
            }

            return ret[n - 1];
        }


        public int Search(int[] nums, int target)
        {
            if (nums.Length == 1) return nums[0] == target ? 0 : -1;
            return bs(nums, target, 0, nums.Length - 1);
        }

        private int bs(int[] nums, int target, int start, int end)
        {
            if (start > end) return -1;
            int middle = start + (end - start) / 2;
            int ret = -1;
            if (nums[middle] >= nums[start] && nums[middle] <= nums[end])
            {
                if (nums[middle] > target)
                {
                    ret = bs(nums, target, start, middle - 1);
                }
                else if (nums[middle] < target)
                {
                    ret = bs(nums, target, middle + 1, end);
                }
                else if (nums[middle] == target) return middle;
            }
            else
            {
                ret = bs(nums, target, middle + 1, end);
                if (ret != -1) return ret;
                ret = bs(nums, target, start, middle);
            }

            return ret;
        }



        public int NumSquares(int n)
        {

            if (n == 1) return 1;
            int[] dp = new int[n + 1];
            for (int i = 0; i <= n; i++)
            {
                dp[i] = 0;
            }

            dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                int min = int.MaxValue;
                for (int k = 1; k * k <= i; k++)
                {
                    min = Math.Min(1 + dp[i - k * k], min);
                }

                dp[i] = min;
            }

            return dp[n];
        }



        public ListNode DetectCycle(ListNode head)
        {
            ListNode p = head;
            ListNode pp = head;
            int hh = 0;

            while (p != null && pp != null)
            {
                p = p.next; hh++;
                if (pp.next == null) return null;
                pp = pp.next.next;

                if (p == pp) break;
            }

            if (pp == null) return null;

            int ah = hh / 2;
            pp = head;
            while (ah > 0)
            {
                pp = pp.next.next;
                ah--;
            }

            if (hh % 2 != 0) pp = pp.next;
            p = head;

            while (hh >= 0)
            {
                if (p == pp) return p;
                p = p.next;
                pp = pp.next;
                hh--;
            }

            return null;
        }



        // Given an array of citations (each citation is a non-negative integer) of a researcher, write a function to compute the researcher's h-index. 

        // According to the definition of h-index on Wikipedia: "A scientist has index h if h of his/her N papers have at least h citations each, and the other N − h papers have no more than h citations each." 

        // For example, given citations = [3, 0, 6, 1, 5], which means the researcher has 5 papers in total and each of them had received 3, 0, 6, 1, 5 citations respectively. Since the researcher has 3 papers with at least 3 citations each and the remaining two with no more than 3 citations each, his h-index is 3. 

        // Note: If there are several possible values for h, the maximum one is taken as the h-index. 


        public int HIndex(int[] citations)
        {
            int n = citations.Length;
            return bs(citations, 0, n - 1);
        }

        private int bs(int[] c, int start, int end)
        {
            if (start > end) return 0;
            int middle = start + (end - start) / 2;

            int h = c.Length - middle;
            int max = 0;
            if (h <= c[middle])
            {
                max = Math.Max(bs(c, start, middle - 1), h);
            }
            else
            {
                max = bs(c, middle + 1, end);
            }

            return max;
        }


        // Follow up for "Search in Rotated Sorted Array":
        //  What if duplicates are allowed?

        // Would this affect the run-time complexity? How and why?

        // Write a function to determine if a given target is in the array.



        public bool SearchRotated(int[] nums, int target)
        {
            return bsRotated(nums, target, 0, nums.Length - 1) == -1 ? false : true;
        }

        private int bsRotated(int[] nums, int target, int start, int end)
        {
            if (start > end) return -1;
            while (start < end && nums[start] == nums[end]) start++;
            int middle = start + (end - start) / 2;
            int ret = -1;
            int lM = middle;
            int rM = middle;

            while (lM > start && nums[lM] == nums[lM - 1]) lM--;
            while (rM < end && nums[rM] == nums[rM + 1]) rM++;

            if (nums[middle] >= nums[start] && nums[middle] <= nums[end])
            {
                if (nums[middle] > target)
                {
                    ret = bs(nums, target, start, lM - 1);
                }
                else if (nums[middle] < target)
                {
                    ret = bs(nums, target, rM + 1, end);
                }
                else if (nums[middle] == target) return lM;
            }
            else
            {
                ret = bs(nums, target, rM + 1, end);
                if (ret != -1) return ret;
                ret = bs(nums, target, start, lM);
            }
            return ret;
        }




        public ListNode MergeKLists(ListNode[] lists)
        {
            return MergeK(lists, 0, lists.Length - 1);
        }

        private ListNode MergeK(ListNode[] lists, int start, int end)
        {

            if (start > end) return null;
            if (start == end) return lists[start];
            if (start + 1 == end) return Merge(lists[start], lists[end]);

            int middle = start + (end - start) / 2;

            ListNode a = MergeK(lists, start, middle);
            ListNode b = MergeK(lists, middle + 1, end);
            return Merge(a, b);
        }

        private ListNode Merge(ListNode a, ListNode b)
        {
            ListNode head = new ListNode(-1);

            ListNode ret = head;
            while (a != null && b != null)
            {
                if (a.val < b.val)
                {
                    head.next = a;
                    a = a.next;
                }
                else
                {
                    head.next = b;
                    b = b.next;
                }

                head = head.next;
            }

            if (a == null) head.next = b;
            else head.next = a;
            return ret.next;
        }




        // Given a collection of integers that might contain duplicates, nums, return all possible subsets.

        // Note:

        // •Elements in a subset must be in non-descending order.
        // •The solution set must not contain duplicate subsets.


        // For example,
        //  If nums = [1, 2, 2], a solution is: 
        // [
        //   [2],
        //   [1],
        //   [1,2,2],
        //   [2,2],
        //   [1,2],
        //   []
        // ]

        public IList<IList<int>> Subsets(int[] nums)
        {
            List<int> last = new List<int>();
            System.Array.Sort(nums);
            IList<IList<int>> ret = new List<IList<int>>();
            ret.Add(last);
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                int len = ret.Count;
                for (int j = 0; j < len; j++)
                {
                    last = ret[j].ToList<int>();
                    last.Add(nums[i]);
                    ret.Add(last);
                }
            }

            return ret;
        }


        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            List<int> last = new List<int>();
            System.Array.Sort(nums);
            IList<IList<int>> ret = new List<IList<int>>();
            ret.Add(last);
            int len = ret.Count;
            int n = nums.Length;
            int j = 0;
            for (int i = 0; i < n; i++)
            {

                if (i > 0 && nums[i] == nums[i - 1])
                {
                    j = len;
                }
                else
                {
                    j = 0;
                }

                len = ret.Count;
                for (; j < len; j++)
                {
                    last = ret[j].ToList<int>();
                    last.Add(nums[i]);
                    ret.Add(last);
                }
            }

            return ret;
        }

        // Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.
        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int x) { val = x; }
         * }
         */
        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */

        public TreeNode SortedListToBST(ListNode head)
        {
            ListNode t = head;
            int count = 0;
            if (head == null) return null;

            while (t != null)
            {
                t = t.next;
                count++;
            }

            List<TreeNode> ltr = new List<TreeNode>(count);
            for (int i = 0; i < count; i++)
            {
                ltr.Add(new TreeNode(int.MinValue));
            }

            TreeNode root = ConstructTree(ltr, 0, count - 1);
            DFS(root, ref head);
            return root;
        }

        private TreeNode ConstructTree(List<TreeNode> ltr, int start, int end)
        {
            if (start > end) return null;

            int middle = start + (end - start) / 2;
            TreeNode root = ltr[middle];
            root.left = ConstructTree(ltr, start, middle - 1);
            root.right = ConstructTree(ltr, middle + 1, end);

            return root;
        }

        private void DFS(TreeNode root, ref ListNode head)
        {
            if (root == null) return;

            DFS(root.left, ref head);
            root.val = head.val;
            head = head.next;
            DFS(root.right, ref head);
        }




        // Given a range[m, n] where 0 <= m <= n <= 2147483647, return the bitwise AND of all numbers in this range, inclusive.

        // For example, given the range[5, 7], you should return 4. 


        public int RangeBitwiseAnd(int m, int n)
        {
            int sum = m;
            int lgM = (int)Math.Log(m, 2);
            int lgN = (int)Math.Log(n, 2);
            if (lgM == lgN)
            {
                for (int i = m; i <= n; i++)
                {
                    sum = sum & i;
                    if (i == n) break;
                }
                return sum;
            }

            sum = RangeBitwiseAnd(0, n - (int)Math.Pow(2, lgN)) & (int)Math.Pow(2, lgN);
            return sum;
        }



        // A message containing letters from A-Z is being encoded to numbers using the following mapping: 
        // 'A' -> 1
        // 'B' -> 2
        // ...
        // 'Z' -> 26


        // Given an encoded message containing digits, determine the total number of ways to decode it. 

        // For example,
        //  Given encoded message "12", it could be decoded as "AB" (1 2) or "L" (12). 



        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            if (s[0] == '0') return 0;
            int[] ret = new int[s.Length + 1];
            int n = s.Length;
            for (int i = 0; i <= n; i++)
            {
                ret[i] = 0;
            }

            ret[0] = 1;
            ret[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                if (s[i - 1] == '0' && s[i - 2] != '1' && s[i - 2] != '2') return 0;
                if (s[i - 1] != '0') ret[i] += ret[i - 1];
                if ((s[i - 2] == '1' || s[i - 2] == '2' && s[i - 1] <= '6'))
                {
                    ret[i] += ret[i - 2];
                }
            }

            return ret[n];
        }



        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */


        public IList<TreeNode> GenerateTrees(int n)
        {
            List<TreeNode>[,] cache = new List<TreeNode>[n + 2, n + 2];
            if (n == 0) return new List<TreeNode>();
            for (int len = 1; len <= n; len++)
            {
                for (int i = 1; i <= n - len + 1; i++)
                {
                    for (int j = i; j < i + len; j++)
                    {
                        List<TreeNode> left = cache[i, j - 1];
                        List<TreeNode> right = cache[j + 1, i + len - 1];
                        if (left == null) { left = new List<TreeNode>(); left.Add(null); }
                        if (right == null) { right = new List<TreeNode>(); right.Add(null); }
                        if (cache[i, i + len - 1] == null) cache[i, i + len - 1] = new List<TreeNode>();
                        for (int lni = 0; lni < left.Count; lni++)
                        {
                            for (int rni = 0; rni < right.Count; rni++)
                            {
                                TreeNode l = null;
                                l = CopyTree(left[lni], ref l);
                                TreeNode r = null;
                                r = CopyTree(right[rni], ref r);
                                TreeNode root = new TreeNode(j);
                                root.left = l;
                                root.right = r;
                                cache[i, i + len - 1].Add(root);
                            }
                        }
                    }
                }
            }
            return cache[1, n];
        }

        private TreeNode CopyTree(TreeNode root, ref TreeNode copy)
        {
            if (root == null) { copy = null; return copy; }

            copy = new TreeNode(root.val);
            copy.left = null;
            copy.right = null;
            CopyTree(root.left, ref copy.left);
            CopyTree(root.right, ref copy.right);

            return copy;
        }




        // Given a triangle, find the minimum path sum from top to bottom. Each step you may move to adjacent numbers on the row below.
        // For example, given the following triangle
        // [
        //      [2],
        //    [3,4],
        //    [6,5,7],
        //   [4,1,8,3]
        // ]
        // The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11). 

        // 2
        // 3, 4
        // 6, 5, 7
        // 4, 1, 8, 3

        public int MinimumTotal(IList<IList<int>> triangle)
        {
            if (triangle == null || triangle.Count == 0 || triangle[0].Count == 0) return 0;
            int n = triangle.Count;
            int m = triangle[n - 1].Count;
            int[] ret = new int[m];
            int[] previous = new int[m];
            int minPath = int.MaxValue;
            previous[0] = triangle[0][0];

            for (int i = 1; i < n; i++)
            {
                ret[0] = triangle[i][0] + previous[0];
                ret[i] = triangle[i][i] + previous[i - 1];
                for (int j = 1; j < i; j++)
                {
                    ret[j] = Math.Min(triangle[i][j] + previous[j], triangle[i][j] + previous[j - 1]);
                }

                previous = ret;
                ret = new int[m];
            }

            for (int i = 0; i < m; i++)
            {
                minPath = Math.Min(previous[i], minPath);
            }

            return minPath;
        }
        //     public class ListNode {
        //         public int val;
        //         public ListNode next;
        //         public ListNode(int x) { val = x; }
        //     }


        //   Input: [3,4,1]
        // Output: [1,3]
        // Expected: [1,3,4]

        public ListNode SortList(ListNode head)
        {
            if (head == null) return null;
            ListNode end = head;
            int len = 1;
            while (end.next != null) { end = end.next; len++; }
            return Sort(head, end, len);
        }

        private ListNode Sort(ListNode head, ListNode end, int len)
        {
            if (head == null || end == null) return head;
            if (head == end)
            {
                head.next = null;
                return head;
            }

            int m = len / 2;
            ListNode mNode = head;
            while (m > 1) { mNode = mNode.next; m--; }
            ListNode b = Sort(mNode.next, end, len - len / 2);
            ListNode a = Sort(head, mNode, len / 2);
            return Merge(a, b);
        }

        private ListNode MergeSorte(ListNode a, ListNode b)
        {
            ListNode head = new ListNode(-1);
            ListNode hh = head;
            while (a != null && b != null)
            {
                if (a.val < b.val)
                {
                    head.next = a;
                    a = a.next;
                    head = head.next;
                }
                else
                {
                    head.next = b;
                    b = b.next;
                    head = head.next;
                }
            }
            if (a == null) head.next = b;
            else head.next = a;
            return hh.next;
        }



        // Find the contiguous subarray within an array (containing at least one number) which has the largest product. 

        // For example, given the array [2,3,-2,4],
        // the contiguous subarray [2,3] has the largest product = 6. 
        public int MaxProductInt(int[] nums)
        {
            int n = nums.Length;
            List<int> num = new List<int>();
            int ret = nums[0];
            int cnt = 0;
            int cntP = 0;
            for (int i = 0; i < n; i++)
            {
                ret = Math.Max(nums[i], ret);
                if (nums[i] == 1) { cntP++; continue; }
                else if (nums[i] == -1) { cnt++; continue; }
                else
                {
                    if (cnt > 0)
                    {
                        if (cnt % 2 == 0) num.Add(1);
                        else num.Add(-1);
                        cnt = 0;
                    }
                    else if (cntP > 0)
                    {
                        num.Add(1);
                        cntP = 0;
                    }
                    num.Add(nums[i]);
                }
            }

            if (cnt > 0)
            {
                if (cnt % 2 == 0) num.Add(1);
                else num.Add(-1);
                cnt = 0;
            }
            else if (cntP > 0)
            {
                num.Add(1);
                cntP = 0;
            }

            n = num.Count;
            nums = num.ToArray();
            int[,] dp = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dp[i, j] = 1;
                }
                dp[i, i] = nums[i];
                ret = Math.Max(nums[i], ret);
            }

            for (int i = 2; i <= n; i++)
            {
                for (int start = 0; start <= n - i; start++)
                {
                    int end = start + i - 1;
                    dp[start, end] = dp[start, start] * dp[start + 1, end];
                    ret = Math.Max(dp[start, end], ret);
                }
            }
            return ret;
        }

        public int MaxProductIntOn(int[] nums)
        {
            int n = nums.Length;
            int ret = int.MinValue;
            List<int> maxP = new List<int>();
            List<int> minP = new List<int>();

            maxP.Add(nums[0]);
            minP.Add(nums[0]);

            for (int i = 1; i < n; i++)
            {
                maxP.Add(Math.Max(Math.Max(nums[i], nums[i] * maxP[i - 1]), nums[i] * minP[i - 1]));
                minP.Add(Math.Min(Math.Min(nums[i], nums[i] * minP[i - 1]), nums[i] * maxP[i - 1]));
            }

            foreach (int i in maxP)
            {
                ret = Math.Max(i, ret);
            }
            return ret;
        }


        // Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.

        // Example:

        // Given nums = [-2, 0, 3, -5, 2, -1]

        // sumRange(0, 2) -> 1
        // sumRange(2, 5) -> -1
        // sumRange(0, 5) -> -3



        // Note:

        // 1.You may assume that the array does not change.
        // 2.There are many calls to sumRange function.

        //private int[,] rangeSumCache = new int[n, n];
        private int[] rangeCacheRight;
        private int[] rangeCacheLeft;
        private int rangeSumCache = 0;
        private int rangeSumLen;
        public void NumArray(int[] nums)
        {
            int n = nums.Length;
            rangeSumLen = n;
            if (n == 0) return;
            rangeCacheLeft = new int[n];
            rangeCacheRight = new int[n];
            rangeCacheLeft[0] = nums[0];
            rangeCacheRight[n - 1] = nums[n - 1];
            rangeSumCache += nums[0];
            for (int i = 1; i < n; i++)
            {
                rangeSumCache += nums[i];
                rangeCacheLeft[i] = rangeCacheLeft[i - 1] + nums[i];
                rangeCacheRight[n - 1 - i] = rangeCacheRight[n - i] + nums[n - 1 - i];
            }
        }

        public int SumRange(int i, int j)
        {
            if (rangeSumLen == 0) return 0;
            if (i == 0 && j == rangeSumLen - 1) return rangeSumCache;
            else if (i == 0) return rangeSumCache - rangeCacheRight[j + 1];
            else if (j == rangeSumLen - 1) return rangeSumCache - rangeCacheLeft[i - 1];
            else return rangeSumCache - rangeCacheLeft[i - 1] - rangeCacheRight[j + 1];
        }

        //  Given a 2D matrix matrix, find the sum of the elements inside the rectangle defined by its upper left corner (row1, col1) and lower right corner (row2, col2).

        //  Range Sum Query 2D
        //  The above rectangle (with the red border) is defined by (row1, col1) = (2, 1) and (row2, col2) = (4, 3), which contains sum = 8. 

        //  Example:

        //   Given matrix = [
        //   [3, 0, 1, 4, 2],
        //   [5, 6, 3, 2, 1],
        //   [1, 2, 0, 1, 5],
        //   [4, 1, 0, 1, 7],
        //   [1, 0, 3, 0, 5]
        //   ]

        //  sumRegion(2, 1, 4, 3) -> 8
        //  sumRegion(1, 1, 2, 2) -> 11
        //  sumRegion(1, 2, 2, 4) -> 12

        private int[,] rangeCacheRight2D;
        private int[,] rangeCacheLeft2D;
        private int[] rangeSumCache2D;
        private int rangeSum2DLen = 0;
        public void NumMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            rangeSum2DLen = m;
            if (n == 0) return;
            rangeCacheLeft2D = new int[n, m];
            rangeCacheRight2D = new int[n, m];
            rangeSumCache2D = new int[n];
            for (int i = 0; i < n; i++) rangeCacheLeft2D[i, 0] = matrix[i, 0];
            for (int j = 0; j < n; j++) rangeCacheRight2D[j, m - 1] = matrix[j, m - 1];
            for (int i = 0; i < n; i++) rangeSumCache2D[i] += matrix[i, 0];
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    rangeSumCache2D[i] += matrix[i, j];
                    rangeCacheLeft2D[i, j] = rangeCacheLeft2D[i, j - 1] + matrix[i, j];
                    rangeCacheRight2D[i, m - 1 - j] = rangeCacheRight2D[i, m - j] + matrix[i, m - 1 - j];
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            if (rangeSum2DLen == 0) return 0;
            int sum = 0;
            if (col1 == 0 && col2 == rangeSum2DLen - 1 || col2 == 0 && col1 == rangeSum2DLen - 1)
            {
                for (int i = row1; i <= row2; i++) sum += rangeSumCache2D[i];
                return sum;
            }
            else if (col1 == 0)
            {
                for (int i = row1; i <= row2; i++)
                    sum += rangeSumCache2D[i] - rangeCacheRight2D[i, col2 + 1];
                return sum;
            }
            else if (col2 == rangeSum2DLen - 1)
            {
                for (int i = row1; i <= row2; i++) sum += rangeSumCache2D[i] - rangeCacheLeft2D[i, col1 - 1];
                return sum;
            }
            else
            {
                for (int i = row1; i <= row2; i++)
                    sum += rangeSumCache2D[i] - rangeCacheLeft2D[i, col1 - 1] - rangeCacheRight2D[i, col2 + 1];
                return sum;
            }


        }

        // Given a 2D binary matrix filled with 0's and 1's, find the largest square containing all 1's and return its area. 

        // For example, given the following matrix: 
        // 1 0 1 0 0
        // 1 0 1 1 1
        // 1 1 1 1 1
        // 1 0 0 1 0

        // Return 4.

        public int MaximalSquare(char[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] ret = new int[n, m];
            int max = 0;
            if (n == 0 && m == 0) return 0;

            for (int i = 0; i < n; i++)
            {
                ret[i, 0] = matrix[i, 0] == '1' ? 1 : 0;
                max = Math.Max(ret[i, 0], max);
            }

            for (int j = 0; j < m; j++)
            {
                ret[0, j] = matrix[0, j] == '1' ? 1 : 0;
                max = Math.Max(ret[0, j], max);
            }

            if (n == 1 || m == 1) return max;

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] == '0') { ret[i, j] = 0; continue; }
                    else if (matrix[i - 1, j - 1] == '0') { ret[i, j] = 1; continue; }

                    int shortSide = (int)Math.Min(Math.Sqrt(ret[i - 1, j]), Math.Sqrt(ret[i, j - 1]));
                    int min = (int)Math.Sqrt(ret[i - 1, j - 1]);
                    if (min >= shortSide) ret[i, j] = (shortSide + 1) * (shortSide + 1);
                    else ret[i, j] = ret[i - 1, j - 1] + 2 * min + 1;

                    max = Math.Max(ret[i, j], max);
                }
            }

            return max;
        }

        //[
        //    "1010",
        //    "1011",
        //    "1011",
        //    "1111"
        //]
        public int MaximalRectangle(char[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] yCache = new int[n, m];
            int max = 0;
            if (n == 0 && m == 0) return 0;

            for (int j = 0; j < m; j++)
            {
                if (matrix[0, j] == '1') yCache[0, j] = 1;
                else yCache[0, j] = 0;
                for (int i = 1; i < n; i++)
                {
                    if (matrix[i, j] == '1') yCache[i, j] = yCache[i - 1, j] + 1;
                    else yCache[i, j] = 0;
                }
            }

            int h;
            int v;
            for (int i = 0; i < n; i++)
            {
                for (int start = 0; start < m; start++)
                {
                    h = 0;
                    v = int.MaxValue;
                    for (int j = start; j < m; j++)
                    {
                        if (matrix[i, j] == '1')
                        {
                            h++;
                            v = Math.Min(yCache[i, j], v);
                            max = Math.Max(max, v * h);
                        }
                        else
                        {
                            h = 0; v = int.MaxValue;
                        }
                    }
                }
            }
            return max;
        }

        public int MaxRectangle(char[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] left = new int[m];
            int[] right = new int[m];
            int[] h = new int[m];
            if (n == 0 || m == 0) return 0;
            for (int i = 0; i < m; i++) right[i] = m;
            int area = 0;
            for (int i = 0; i < n; i++)
            {
                int l = 0;
                int r = m;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == '1')
                    {
                        h[j]++;
                        left[j] = Math.Max(l, left[j]);
                    }
                    else
                    {
                        l = j + 1;
                        h[j] = 0;
                        left[j] = 0;
                    }
                }

                for (int j = m - 1; j > -1; j--)
                {
                    if (matrix[i, j] == '1')
                    {
                        right[j] = Math.Min(r, right[j]);
                        area = Math.Max(area, h[j] * (right[j] - left[j]));
                    }
                    else
                    {
                        right[j] = m;
                        r = j;
                    }
                }
            }

            return area;
        }

        // Given n non-negative integers representing the histogram's bar height where the width of each bar is 1, find the area of largest rectangle in the histogram. 
        // Above is a histogram where width of each bar is 1, given height = [2,1,5,6,2,3].
        // The largest rectangle is shown in the shaded area, which has area = 10 unit.
        // For example,
        //  Given heights = [2,1,5,6,2,3],
        //                   0, 0, 2, 3, 3, 5
        //  return 10. 

        public int LargestRectangleArea(int[] heights)
        {
            int area = 0;
            int n = heights.Length;
            if (n == 0) return 0;
            int[] left = new int[n];
            int[] right = new int[n];
            left[0] = -1;
            right[n - 1] = n;

            for (int i = 1; i < n; i++)
            {
                if (heights[i] > heights[i - 1])
                {
                    left[i] = i - 1;
                }
                else
                {
                    int j = i - 1;
                    while (j >= 0 && heights[i] <= heights[j]) j = left[j]; // This is the key to the speed of the solution
                    left[i] = j;
                }
            }

            area = Math.Max(area, heights[n - 1] * (right[n - 1] - left[n - 1] - 1));

            for (int i = n - 2; i > -1; i--)
            {
                if (heights[i] > heights[i + 1])
                {
                    right[i] = i + 1;
                }
                else
                {
                    int j = i + 1;
                    while (j < n && heights[i] <= heights[j]) j = right[j];
                    right[i] = j;
                }

                area = Math.Max(area, heights[i] * (right[i] - left[i] - 1));
            }

            return area;
        }


        // // You are given coins of different denominations and a total amount of money amount. Write a function to compute the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1. 

        // // Example 1:
        // //  coins = [1, 2, 5], amount = 11
        // //  return 3 (11 = 5 + 5 + 1) 

        // // Example 2:
        // //  coins = [2], amount = 3
        // //  return -1. 

        public int CoinChange(int[] coins, int amount)
        {
            int n = coins.Length;
            int[] ret = new int[amount + 1];

            for (int i = 0; i <= amount; i++)
            {
                ret[i] = int.MaxValue;
            }

            ret[0] = 0;

            for (int a = 1; a <= amount; a++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (a >= coins[i] && ret[a - coins[i]] != int.MaxValue) ret[a] = Math.Min(ret[a - coins[i]] + 1, ret[a]);
                }
            }

            return ret[amount] == int.MaxValue ? -1 : ret[amount];
        }

        // '?' Matches any single character.
        // '*' Matches any sequence of characters (including the empty sequence).

        // The matching should cover the entire input string (not partial).

        // The function prototype should be:
        // bool isMatch(const char *s, const char *p)

        // Some examples:
        // isMatch("aa","a") → false
        // isMatch("aa","aa") → true
        // isMatch("aaa","aa") → false
        // isMatch("aa", "*") → true
        // isMatch("aa", "a*") → true
        // isMatch("ab", "?*") → true
        // isMatch("aab", "c*a*b") → false

        public bool IsMatch(string s, string p)
        {
            int n = s.Length;
            int m = p.Length;
            int[,] match = new int[n, m];
            if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(p)) return true;
            if (string.IsNullOrEmpty(s))
            {
                foreach (char c in p)
                {
                    if (c != '*') return false;
                }
                return true;
            }
            if (string.IsNullOrEmpty(p)) return false;

            if (s[0] != p[0] && p[0] != '?' && p[0] != '*') return false;
            if (s[0] == p[0] || p[0] == '?') match[0, 0] = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (s[i] == p[j] || p[j] == '?')
                    {
                        match[i, j] = 1;
                    }
                    else if (p[j] == '*')
                    {
                        if (i > 0 && j > 0)
                        {
                            match[i, j] = 1;
                            for (int k = i; k < n; k++) match[k, j] = 1;
                        }
                    }
                    else match[i, j] = 0;
                }
            }

            if (SearchMatch(s, p, n - 1, m - 1, match) > 0) return true;
            return false;
        }

        private int SearchMatch(string s, string p, int i, int j, int[,] match)
        {
            if (i < 0 && j < 0) return 1;
            if (i < 0 || j < 0 || match[i, j] == 0) return 0;
            if (i >= s.Length) i = s.Length - 1;

            if (s[i] == p[j] || p[j] == '?') return SearchMatch(s, p, i - 1, j - 1, match);
            else if (p[j] == '*')
            {
                int k = i;
                while (k >= j - 1)
                {
                    if (SearchMatch(s, p, k--, j - 1, match) > 0) return 1;
                }
            }


            return 0;
        }

        public bool IsMatch2(string s, string p)
        {
            int n = s.Length;
            int m = p.Length;
            int[,] match = new int[n, m];
            if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(p)) return true;
            if (string.IsNullOrEmpty(s))
            {
                foreach (char c in p)
                {
                    if (c != '*') return false;
                }
                return true;
            }
            if (string.IsNullOrEmpty(p)) return false;

            if (s[0] != p[0] && p[0] != '?' && p[0] != '*') return false;
            if (s[0] == p[0] || p[0] == '?' || p[0] == '*') match[0, 0] = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (s[i] == p[j] || p[j] == '?')
                    {
                        if (i > 0 && j > 0) match[i, j] = match[i - 1, j - 1];
                        else if (i == 0 && j > 0)
                        {
                            match[i, j] = 1;
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (p[k] != '*') { match[i, j] = 0; break; }
                            }
                        }
                        else if (i > 0 && j == 0) match[i, j] = 0;
                        else match[i, j] = 1;
                    }
                    else if (p[j] == '*')
                    {
                        if (i > 0 && j > 0)
                        {
                            int k = i;
                            match[i, j] = 0;
                            while (k >= 0)
                            {
                                if (match[k--, j - 1] > 0) { match[i, j] = 1; break; }
                            }
                        }
                        else if (i == 0 && j > 0) match[i, j] = match[i, j - 1];
                        else if (i > 0 && j == 0) match[i, j] = 1;
                        else match[i, j] = 1;

                    }
                    else match[i, j] = 0;
                }
            }

            return match[n - 1, m - 1] == 1 ? true : false;
        }

        public bool IsMatchMostShortAndQuick(string s, string p)
        {
            int n = s.Length;
            int m = p.Length;
            bool[,] match = new bool[n + 1, m + 1];

            match[0, 0] = true;
            for (int j = 1; j < m + 1; j++)
            {
                match[0, j] = match[0, j - 1] & p[j - 1] == '*';
            }

            for (int i = 1; i < n + 1; i++)
            {
                match[i, 0] = false;
            }

            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < m + 1; j++)
                {
                    if (s[i - 1] == p[j - 1] || p[j - 1] == '?')
                    {
                        match[i, j] = match[i - 1, j - 1];
                    }
                    else if (p[j - 1] == '*')
                    {
                        match[i, j] = match[i - 1, j] | match[i, j - 1];
                    }
                }
            }

            return match[n, m];
        }


        // Implement regular expression matching with support for '.' and '*'.
        // '.' Matches any single character.
        // '*' Matches zero or more of the preceding element.

        // The matching should cover the entire input string (not partial).

        // The function prototype should be:
        // bool isMatch(const char *s, const char *p)

        // Some examples:
        // isMatch("aa","a") → false
        // isMatch("aa","aa") → true
        // isMatch("aaa","aa") → false
        // isMatch("aa", "a*") → true
        // isMatch("aa", ".*") → true
        // isMatch("ab", ".*") → true
        // isMatch("aab", "c*a*b") → true

        public bool IsMatchRegex(string s, string p)
        {
            int n = s.Length;
            int m = p.Length;
            bool[,] match = new bool[n + 1, m + 1];
            match[0, 0] = true;
            if (m != 0)
                match[0, 1] = false;
            for (int j = 2; j < m + 1; j++)
            {
                match[0, j] = match[0, j - 2] & p[j - 1] == '*';
            }

            for (int i = 1; i < n + 1; i++)
            {
                match[i, 0] = false;
            }

            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < m + 1; j++)
                {
                    if (s[i - 1] == p[j - 1] || p[j - 1] == '.')
                    {
                        match[i, j] = match[i - 1, j - 1];
                    }
                    else if (p[j - 1] == '*')
                    {
                        if (s[i - 1] == p[j - 2] || p[j - 2] == '.') match[i, j] |= match[i - 1, j];
                        match[i, j] |= match[i, j - 2];
                    }
                }
            }

            return match[n, m];
        }

        //Sort a linked list using insertion sort.
        public ListNode InsertionSortList(ListNode head)
        {
            ListNode min = head;
            ListNode w = head;
            ListNode newTail = new ListNode(0);
            newTail.next = head;
            ListNode minP = newTail;
            ListNode ret = null;
            while (w != null)
            {
                while (w.next != null)
                {
                    if (min.val > w.next.val)
                    {
                        min = w.next;
                        minP = w;
                    }
                    w = w.next;
                }
                if (ret == null) ret = min;
                minP.next = min.next;
                min.next = newTail.next;
                newTail.next = min;
                newTail = newTail.next;
                minP = min;
                min = min.next;
                w = min;
            }

            return ret;
        }

        public ListNode InsertionSortListFaster(ListNode head)
        {
            ListNode pre = head;
            ListNode next = head;
            ListNode w = head;
            ListNode newTail = new ListNode(int.MinValue);
            newTail.next = null;
            while (w != null)
            {
                next = w.next;
                w.next = null;
                if (pre.val < w.val) InsertLinkList(pre, w);
                else InsertLinkList(newTail, w);
                pre = w;
                w = next;
            }
            return newTail.next;
        }

        private ListNode InsertLinkList(ListNode head, ListNode insert)
        {
            ListNode p = head;
            while (p != null)
            {
                if (p.val <= insert.val && (p.next == null || p.next.val > insert.val))
                {
                    insert.next = p.next;
                    p.next = insert;
                    break;
                }
                p = p.next;
            }
            return head;
        }


        // Given an array of non-negative integers, you are initially positioned at the first index of the array. 

        // Each element in the array represents your maximum jump length at that position. 

        // Determine if you are able to reach the last index. 

        // For example:
        //  A = [2,3,1,1,4], return true. 

        // A = [3,2,1,0,4], return false. 

        public bool CanJump(int[] nums)
        {
            bool[] cache = new bool[nums.Length];
            for (int i = 0; i < nums.Length; i++) cache[i] = true;
            return JumpToEnd(nums, 0, cache);
        }

        private bool JumpToEnd(int[] nums, int i, bool[] cache)
        {
            if (i >= nums.Length) return true;
            if (nums[i] == 0) return false;
            if (!cache[i]) return false;

            int k = nums[i];
            while (k > 0)
            {
                if (JumpToEnd(nums, i + (k--), cache)) return true;
            }

            cache[i] = false;
            return false;
        }

        public bool CanJumpSuperFast(int[] nums)
        {
            int max = nums[0];
            int maxi = 0;
            int n = nums.Length;
            int i = 0;
            for (; i < n; i++)
            {
                if (i > maxi + max) return false;
                if (nums[i] + i >= n - 1) return true;
                if (nums[i] >= max - (i - maxi)) { max = nums[i]; maxi = i; }
            }
            return false;
        }

        //        Given a sorted array of integers, find the starting and ending position of a given target value.
        //        Your algorithm's runtime complexity must be in the order of O(log n).
        //If the target is not found in the array, return [-1, -1].
        //For example,
        //        Given[5, 7, 7, 8, 8, 10] and target value 8,
        //        return [3, 4]. 

        public int[] SearchRange(int[] nums, int target)
        {
            int n = nums.Length;
            int[] ret = new int[2];
            ret[0] = BSRangeLeft(nums, target, 0, n - 1);
            ret[1] = BSRangeRight(nums, target, 0, n - 1);
            return ret;
        }
        private int BSRangeLeft(int[] nums, int target, int start, int end)
        {
            if (start > end) return -1;
            int middle = start + (end - start) / 2;
            if (nums[middle] == target && (middle == 0 || nums[middle - 1] < target)) return middle;
            else if (nums[middle] >= target)
            {
                return BSRangeLeft(nums, target, start, middle - 1);
            }
            return BSRangeLeft(nums, target, middle + 1, end);
        }

        private int BSRangeRight(int[] nums, int target, int start, int end)
        {
            if (start > end) return -1;
            int middle = start + (end - start) / 2;
            if (nums[middle] == target && (middle == nums.Length - 1 || nums[middle + 1] > target)) return middle;
            else if (nums[middle] > target)
            {
                return BSRangeRight(nums, target, start, middle - 1);
            }
            return BSRangeRight(nums, target, middle + 1, end);
        }


        //  Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target.Return the sum of the three integers.You may assume that each input would have exactly one solution.
        //  For example, given array S = { -1 2 1 - 4 }, and target = 1.

        //  The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).


        public int ThreeSumClosest(int[] nums, int target)
        {
            int n = nums.Length;
            System.Array.Sort(nums);
            int sum3 = 0;
            int sum2 = 0;
            int ret = 0;
            int minDiff = int.MaxValue;

            for (int i = 0; i < n - 2; i++)
            {

                sum3 = nums[i] + nums[i + 1] + nums[i + 2];
                if (3 * nums[i] > target)
                {
                    if (Math.Abs(target - sum3) < minDiff)
                    {
                        minDiff = Math.Abs(target - sum3);
                        ret = sum3;
                    }
                    return ret;
                }

                int left = i + 1;
                int right = n - 1;

                if (3 * nums[right] < target) return nums[right] + nums[right - 1] + nums[right - 2];
                while (left < right)
                {
                    sum2 = nums[left] + nums[right];
                    sum3 = nums[i] + sum2;


                    if (Math.Abs(target - sum3) < minDiff)
                    {
                        minDiff = Math.Abs(target - sum3);
                        ret = sum3;
                    }

                    if (nums[left] + nums[left] > sum2)
                    {
                        break;
                    }
                    if (sum3 < target) left++;
                    else right--;
                }
            }
            return ret;
        }

        //There are two sorted arrays nums1 and nums2 of size m and n respectively.Find the median of the two sorted arrays.The overall run time complexity should be O(log (m+n)).

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int m = nums2.Length;
            int l = (n + m + 1) / 2;
            int r = (n + m + 2) / 2;
            return (MedianBinarySearchFindMth(nums1, 0, nums2, 0, l) + MedianBinarySearchFindMth(nums1, 0, nums2, 0, r)) / 2.0;
        }

        private int MedianBinarySearchFindMth(int[] a, int ai, int[] b, int bi, int m)
        {
            if (ai > a.Length - 1) return b[bi + m - 1];
            if (bi > b.Length - 1) return a[ai + m - 1];
            int aM = int.MaxValue;
            int bM = int.MaxValue;
            if (m == 1) return Math.Min(a[ai], b[bi]);
            if (ai + m / 2 - 1 < a.Length) aM = a[ai + m / 2 - 1];
            if (bi + m / 2 - 1 < b.Length) bM = b[bi + m / 2 - 1];

            if (aM < bM) return MedianBinarySearchFindMth(a, ai + m / 2, b, bi, m - m / 2);
            else return MedianBinarySearchFindMth(a, ai, b, bi + m / 2, m - m / 2);
        }

        //Given a digit string, return all possible letter combinations that the number could represent.

        //A mapping of digit to letters(just like on the telephone buttons) is given below.

        public IList<string> LetterCombinations(string digits)
        {
            List<string> ret = new List<string>();
            List<char>[] map = new List<char>[10];
            char[] s = new char[digits.Length];
            if (digits.Length == 0) return ret;
            map[1] = new List<char>();
            map[2] = new List<char>() { 'a', 'b', 'c' };
            map[3] = new List<char>() { 'd', 'e', 'f' };
            map[4] = new List<char>() { 'g', 'h', 'i' };
            map[5] = new List<char>() { 'j', 'k', 'l' };
            map[6] = new List<char>() { 'm', 'n', 'o' };
            map[7] = new List<char>() { 'p', 'q', 'r', 's' };
            map[8] = new List<char>() { 't', 'u', 'v' };
            map[9] = new List<char>() { 'w', 'x', 'y', 'z' };
            map[0] = new List<char>() { ' ' };
            for (int i = 0; i < digits.Length; i++)
            {
                s[i] = map[digits[i] - '0'][0];
            }

            BTDigits(digits, 0, s, map, ret);
            return ret;
        }

        private void BTDigits(string digits, int step, char[] s, List<char>[] map, IList<string> ret)
        {
            if (step >= digits.Length)
            {
                ret.Add(new string(s));
                return;
            }

            BTDigits(digits, step + 1, s, map, ret);
            int k = digits[step] - '0';
            for (int i = 1; i < map[k].Count; i++)
            {
                s[step] = map[k][i];
                BTDigits(digits, step + 1, s, map, ret);
            }
            s[step] = map[k][0];
        }

        // Given an array of n positive integers and a positive integer s, find the minimal length of a subarray of which the sum ≥ s.If there isn't one, return 0 instead. 

        // For example, given the array[2, 3, 1, 2, 4, 3] and s = 7,
        // the subarray[4, 3] has the minimal length under the problem constraint.

        public int MinSubArrayLen(int s, int[] nums)
        {
            int left = 0; int right = 0;
            int len = nums.Length;
            int sum = 0;
            int n = nums.Length;

            while (right < n)
            {
                sum += nums[right];
                if (sum < s)
                {
                    right++;
                    continue;
                }
                else
                {
                    while (sum >= s) sum -= nums[left++];
                    left--; sum += nums[left];
                    len = Math.Min(len, right - left + 1);
                }
                right++;
            }

            if (sum < s) return 0;

            return len;
        }

        //        Given a 2D board and a word, find if the word exists in the grid.
        //        The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring.The same letter cell may not be used more than once.
        //        For example,
        //         Given board =
        //        [
        //          ['A', 'B', 'C', 'E'],
        //          ['S','F','C','S'],
        //          ['A','D','E','E']
        //        ]
        //word = "ABCCED", -> returns true,
        //word = "SEE", -> returns true,
        //word = "ABCB", -> returns false.

        public bool Exist(char[,] board, string word)
        {
            int n = board.GetLength(0);
            int m = board.GetLength(1);
            bool[,] visited = new bool[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (Search(board, word, 0, visited, i, j)) return true;
                }
            }

            return false;
        }

        private bool Search(char[,] board, string word, int step, bool[,] visited, int i, int j)
        {
            if (step == word.Length) return true;
            if (i < 0 || i >= board.GetLength(0) || j < 0 || j >= board.GetLength(1)) return false;
            if (board[i, j] != word[step]) return false;
            if (visited[i, j]) return false;
            visited[i, j] = true;
            bool ret = false;
            step++;
            ret = Search(board, word, step, visited, i + 1, j);

            if (ret) { visited[i, j] = false; return true; }
            ret = Search(board, word, step, visited, i - 1, j);
            if (ret) { visited[i, j] = false; return true; }
            ret = Search(board, word, step, visited, i, j + 1);
            if (ret) { visited[i, j] = false; return true; }
            ret = Search(board, word, step, visited, i, j - 1);
            step--;
            visited[i, j] = false;
            return ret;
        }


        //  Given a 2D board and a list of words from the dictionary, find all words in the board.

        //  Each word must be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring.The same letter cell may not be used more than once in a word. 

        //  For example,
        //  Given words = ["oath", "pea", "eat", "rain"] and board =
        //  [
        //      ['o', 'a', 'a', 'n'],
        //      ['e','t','a','e'],
        //      ['i','h','k','r'],
        //      ['i','f','l','v']
        //  ]
        //Return["eat", "oath"]. 
        private List<string> wordsFound = new List<string>();
        //public IList<string> FindWords(char[,] board, string[] words)
        //{
        //    int n = board.GetLength(0);
        //    int m = board.GetLength(1);
        //    bool[,] visited = new bool[n, m];
        //    TrieNode root = new TrieNode();

        //    InitTrieTree(words, root);

        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < m; j++)
        //        {
        //            SearchWordsII(board, root, visited, i, j);
        //        }
        //    }

        //    return wordsFound;
        //}

        //private TrieNode InitTrieTree(string[] words, TrieNode root)
        //{
        //    TrieNode cur;
        //    for (int i = 0; i < words.Length; i++)
        //    {
        //        if (root.next[words[i][0] - 'a'] == null)
        //        {
        //            root.next[words[i][0] - 'a'] = new TrieNode();
        //            root.next[words[i][0] - 'a'].word = words[i].Substring(0, 1);
        //        }

        //        cur = root.next[words[i][0] - 'a'];
        //        for (int j = 1; j < words[i].Length; j++)
        //        {
        //            if (cur.next[words[i][j] - 'a'] == null) cur.next[words[i][j] - 'a'] = new TrieNode();
        //            cur = cur.next[words[i][j] - 'a'];
        //            cur.word = words[i].Substring(0, j + 1);
        //        }

        //        cur.found = true;
        //    }

        //    return root;
        //}

        //private bool SearchWordsII(char[,] board, TrieNode root, bool[,] visited, int i, int j)
        //{
        //    if (root == null) return false;

        //    if (root.found)
        //    {
        //        wordsFound.Add(root.word);
        //        root.found = false;
        //    }

        //    if (i < 0 || i >= board.GetLength(0) || j < 0 || j >= board.GetLength(1)) return false;
        //    if (visited[i, j]) return false;
        //    if (root.next[board[i, j] - 'a'] == null) return false;

        //    visited[i, j] = true;
        //    bool ret = false;
        //    ret = SearchWordsII(board, root.next[board[i, j] - 'a'], visited, i + 1, j);
        //    ret = SearchWordsII(board, root.next[board[i, j] - 'a'], visited, i - 1, j);
        //    ret = SearchWordsII(board, root.next[board[i, j] - 'a'], visited, i, j + 1);
        //    ret = SearchWordsII(board, root.next[board[i, j] - 'a'], visited, i, j - 1);
        //    visited[i, j] = false;
        //    return ret;
        //}

        // Given a string s and a dictionary of words dict, determine if s can be segmented into a space-separated sequence of one or more dictionary words.

        // For example, given
        // s = "leetcode",
        // dict = ["leet", "code"].

        // Return true because "leetcode" can be segmented as "leet code". 

        public bool WordBreak(string s, ISet<string> wordDict)
        {
            int n = s.Length;
            bool[,] dp = new bool[s.Length + 1, s.Length + 1];
            if (wordDict.Contains(s)) return true;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    if (dp[1, j] && dp[j + 1, i])
                    {
                        dp[1, i] = true;
                        break;
                    }
                    else
                    {
                        if (wordDict.Contains(s.Substring(0, j))) dp[1, j] = true;
                        if (wordDict.Contains(s.Substring(j, i - j))) dp[j + 1, i] = true;
                    }

                    dp[1, i] = dp[1, j] & dp[j + 1, i];
                    if (dp[1, i]) break;
                }
            }

            return dp[1, s.Length];
        }

        public bool WordBreakFasterWithOnSpace(string s, ISet<string> wordDict)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            int n = s.Length;
            bool[] breakable = new bool[n + 1];
            breakable[0] = true;
            for (int i = 1; i <= n; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (breakable[j] && wordDict.Contains(s.Substring(j, i - j)))
                    {
                        breakable[i] = true;
                        break;
                    }
                }
            }

            return breakable[n];
        }



        // Given a set of non-overlapping intervals, insert a new interval into the intervals(merge if necessary).

        // You may assume that the intervals were initially sorted according to their start times.

        // Example 1:
        //  Given intervals [1,3], [6,9], insert and merge[2, 5] in as [1,5], [6,9]. 

        // Example 2:
        //  Given[1, 2], [3,5], [6,7], [8,10], [12,16], insert and merge[4, 9] in as [1,2], [3,10], [12,16]. 

        // This is because the new interval[4, 9] overlaps with[3, 5],[6,7],[8,10]. 
        //public class Interval
        //{
        //    public int start;
        //    public int end;
        //    public Interval() { start = 0; end = 0; }
        //    public Interval(int s, int e) { start = s; end = e; }
        //}

        public IList<Interval> InsertInterval(IList<Interval> intervals, Interval newInterval)
        {
            int i = 0;
            int n = intervals.Count;
            List<Interval> ret = new List<Interval>();
            if (intervals.Count == 0)
            {
                ret.Add(newInterval);
                return ret;
            }

            if (newInterval.end < intervals[0].start)
                ret.Add(newInterval);

            while (i < n)
            {
                if (intervals[i].end < newInterval.start || intervals[i].start > newInterval.end || intervals[i].start <= newInterval.start && intervals[i].end >= newInterval.end)
                {
                    ret.Add(intervals[i]);
                    //this is the insert scenario.
                    if (i < n - 1 && intervals[i].end < newInterval.start && intervals[i + 1].start > newInterval.end)
                        ret.Add(newInterval);
                }
                else
                {
                    //This is the merge scenario
                    newInterval.start = Math.Min(intervals[i].start, newInterval.start);
                    while (i < intervals.Count && intervals[i].start <= newInterval.end) i++;
                    --i;
                    newInterval.end = Math.Max(intervals[i].end, newInterval.end);
                    ret.Add(newInterval);
                    ++i;
                    while (i < n)
                    {
                        ret.Add(intervals[i++]);
                    }
                    break;
                }

                i++;
            }

            if (newInterval.start > intervals[intervals.Count - 1].end)
                ret.Add(newInterval);
            return ret;
        }

        public IList<Interval> InsertIntervalLogN(IList<Interval> intervals, Interval newInterval)
        {
            int n = intervals.Count;
            List<Interval> ret = new List<Interval>();
            if (intervals.Count == 0)
            {
                ret.Add(newInterval);
                return ret;
            }

            if (newInterval.end < intervals[0].start)
            {
                ret = new List<Interval>(intervals);
                ret.Insert(0, newInterval);
                return ret;
            }

            if (newInterval.start > intervals[intervals.Count - 1].end)
            {
                ret = new List<Interval>(intervals);
                ret.Add(newInterval);
                return ret;
            }

            int toInsertStart = InsertIntervalBS(intervals, 0, n - 1, newInterval.start, true);
            int toInsertend = InsertIntervalBS(intervals, 0, n - 1, newInterval.end, false);
            if (toInsertStart < 0) { intervals[0].start = newInterval.start; toInsertStart = 0; }
            else if (toInsertStart > n - 1) { toInsertStart = n - 1; }
            if (toInsertend > n - 1) { intervals[n - 1].end = newInterval.end; toInsertend = n - 1; }
            else if (toInsertend < 0) { toInsertend = 0; }

            if (toInsertStart == toInsertend - 1 && newInterval.start > intervals[toInsertStart].end && newInterval.end < intervals[toInsertend].start)
            {
                //insert inbetween
                ret = new List<Interval>(intervals);
                ret.Insert(toInsertStart + 1, newInterval);
                return ret;
            }

            if (newInterval.start >= intervals[toInsertStart].start && newInterval.end <= intervals[toInsertend].end)
            {
                if (newInterval.end < intervals[toInsertend].start) toInsertend--;
                if (newInterval.start > intervals[toInsertStart].end) toInsertStart++;
                intervals[toInsertStart].start = Math.Min(newInterval.start, intervals[toInsertStart].start);
                intervals[toInsertStart].end = Math.Max(newInterval.end, intervals[toInsertend].end);
                toInsertend++;
            }

            for (int i = 0; i <= toInsertStart; i++)
            {
                ret.Add(intervals[i]);
            }

            for (int i = toInsertend; i < n; i++)
            {
                ret.Add(intervals[i]);
            }
            return ret;
        }

        public int InsertIntervalBS(IList<Interval> intervals, int start, int end, int target, bool isStart)
        {
            if (start > end)
            {
                if (isStart) return end;
                else return start;
            }
            int m = start + (end - start) / 2;
            if (isStart)
            {
                if (intervals[m].start > target) return InsertIntervalBS(intervals, start, m - 1, target, isStart);
                else return InsertIntervalBS(intervals, m + 1, end, target, isStart);
            }
            else
            {
                if (intervals[m].end > target) return InsertIntervalBS(intervals, start, m - 1, target, isStart);
                else return InsertIntervalBS(intervals, m + 1, end, target, isStart);
            }
        }

        public IList<Interval> Merge(IList<Interval> intervals)
        {
            List<Interval> ret = new List<Interval>();
            int n = intervals.Count;
            if (n == 0 || n == 1) return intervals;
            MergeIntervalSort(intervals, 0, intervals.Count - 1);

            for (int i = 0; i < n; i++)
            {
                int end = MergeIntervalBS(intervals, i, n - 1, intervals[i].end);
                if (end >= n - 1)
                {   // reach the end, merge and return
                    end = n - 1;
                    for (int j = i; j <= end; j++)
                        intervals[i].end = Math.Max(intervals[j].end, intervals[i].end);
                    ret.Add(intervals[i]);
                    break;
                }

                if (end == i) { ret.Add(intervals[i]); continue; } // nothing to merge, 

                intervals[end].start = intervals[i].start;
                for (int j = i; j <= end; j++)
                    intervals[end].end = Math.Max(intervals[j].end, intervals[end].end);
                i = end;
                i--;
            }

            return ret;
        }

        public int MergeIntervalBS(IList<Interval> intervals, int start, int end, int target)
        {
            if (start > end) return end;
            int m = start + (end - start) / 2;
            if (intervals[m].start == target) return MergeIntervalBS(intervals, m + 1, end, target);
            if (intervals[m].start > target) return MergeIntervalBS(intervals, start, m - 1, target);
            else return MergeIntervalBS(intervals, m + 1, end, target);
        }

        public void MergeIntervalSort(IList<Interval> intervals, int start, int end)
        {
            if (start >= end) return;

            int pivot = end;
            int left = start;
            int right = end - 1;
            while (left < right)
            {
                if (intervals[left].start > intervals[pivot].start)
                {
                    SwapIntervals(intervals[left], intervals[right]);
                    right--;
                    continue;
                }

                left++;
            }

            if (intervals[left].start < intervals[pivot].start) right++;
            SwapIntervals(intervals[right], intervals[pivot]);

            MergeIntervalSort(intervals, start, left);
            MergeIntervalSort(intervals, left + 1, end);
        }

        private void SwapIntervals(Interval a, Interval b)
        {
            int st = a.start;
            int et = a.end;
            a.start = b.start;
            a.end = b.end;
            b.start = st;
            b.end = et;
        }

        public int CountPrimes(int n)
        {
            bool[] visited = new bool[n];
            int sum = 0;
            for (int i = 2; i * i <= n; i++)
            {
                if (visited[i]) //By default, every element is false, if it's true, that means we have marked if off 
                {
                    continue;
                }
                if (!visited[i])
                {
                    for (int k = i; k * i < n; k++)
                    {
                        visited[i * k] = true;
                    }
                }

            }

            for (int i = 2; i < n; i++)
            {

                if (!visited[i]) { sum++; }

            }

            return sum;
        }

        public bool isPrimes(int n)
        {
            if (n < 2) return false;
            int k = (int)Math.Sqrt(n);
            while (k > 1)
            {
                if (n % k == 0) return false;
                k--;
            }

            return true;
        }

        //        For example, given input 43261596 (represented in binary as 00000010100101000001111010011100), return 964176192 (represented in binary as 00111001011110000010100101000000).

        //Follow up:
        // If this function is called many times, how would you optimize it?

        public uint reverseBits(uint n)
        {
            bool bit;
            uint f = 1;
            uint ret = 0;
            for (int i = 0; i < 32; i++)
            {
                if ((n & f) == 1) bit = true;
                else bit = false;
                n = n >> 1;
                if (bit) ret++;
                if (i == 31) break;
                ret = ret << 1;
            }

            return ret;
        }

        // Given two strings s and t, determine if they are isomorphic.

        // Two strings are isomorphic if the characters in s can be replaced to get t.

        // All occurrences of a character must be replaced with another character while preserving
        // the order of characters.No two characters may map to the same character but a character may map to itself.

        // For example,
        // Given "egg", "add", return true.

        // Given "foo", "bar", return false.

        // Given "paper", "title", return true.

        public bool IsIsomorphic(string s, string t)
        {
            if (s == null && t == null) return true;
            if (s == "" && t == "") return true;
            Dictionary<char, char> map = new Dictionary<char, char>();
            HashSet<char> visited = new HashSet<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!map.ContainsKey(s[i]))
                {
                    map.Add(s[i], t[i]);
                    if (!visited.Add(t[i])) return false;
                }
                else
                {
                    if (t[i] != map[s[i]]) return false;
                }
            }

            return true;
        }

        public void Rotate(int[] nums, int k)
        {
            Queue<int> q = new Queue<int>();
            int n = nums.Length;
            k = k % n;
            if (n <= 1 || k == 0) return;
            int s = n - k;
            while (s < n) { q.Enqueue(nums[s++]); }
            for (int i = 0; i < n; i++)
            {
                q.Enqueue(nums[i]);
                nums[i] = q.Dequeue();
            }

            return;
        }


        public void RotateReverse(int[] nums, int k)
        {
            int n = nums.Length;
            if (n <= 1 || k == 0) return;
            k = k % n;

            ReverseElements(nums, n - k, n - 1);
            ReverseElements(nums, 0, n - k - 1);
            ReverseElements(nums, 0, n - 1);
            return;
        }

        private void ReverseElements(int[] nums, int left, int right)
        {
            if (left >= right) return;

            while (left < right)
            {
                int temp = nums[left];
                nums[left++] = nums[right];
                nums[right--] = temp;
            }
        }

        //Given a binary tree, return all root-to-leaf paths. 

        //        For example, given the following binary tree: 


        //   1
        // /   \
        //2     3
        // \
        //  5



        //All root-to-leaf paths are: 
        //["1->2->5", "1->3"]

        public IList<string> BinaryTreePaths(TreeNode root)
        {
            List<int> a = new List<int>();
            List<string> ret = new List<string>();
            if (root == null) return ret;
            BackTrackBTP(root, a, ret);
            return ret;
        }

        private void BackTrackBTP(TreeNode root, List<int> a, IList<string> ret)
        {
            if (root.left == null && root.right == null)
            {
                StringBuilder sb = new StringBuilder();

                int i = 0;
                for (; i < a.Count; i++)
                {
                    sb.Append(a[i]);
                    sb.Append("->");
                }

                sb.Append(root.val);
                ret.Add(sb.ToString());

                return;
            }

            a.Add(root.val);
            if (root.left != null) BackTrackBTP(root.left, a, ret);
            if (root.right != null) BackTrackBTP(root.right, a, ret);

            a.RemoveAt(a.Count - 1);
            return;
        }


        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode header = new ListNode(-1);
            header.next = head;
            ListNode cur = header;
            ListNode p = cur.next;
            while (p != null)
            {
                while (p != null && p.val == val)
                {
                    p = p.next;
                }

                cur.next = p;
                cur = cur.next;
                p = cur.next;
            }

            return header.next;
        }


        // Given a linked list, remove the nth node from the end of list and return its head.

        // For example,
        //    Given linked list: 1->2->3->4->5, and n = 2.

        //    After removing the second node from the end, the linked list becomes 1->2->3->5.


        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null) return null;
            ListNode pp = head;
            while (n > 0)
            {
                pp = pp.next;
                n--;
            }

            ListNode pre = new ListNode(-1);
            ListNode p = head;
            pre.next = p;
            while (pp != null)
            {
                pre = pre.next;
                p = p.next;
                pp = pp.next;
            }

            pre.next = p.next;
            return head;
        }

        // Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

        // The brackets must close in the correct order, "()" and "()[]{}" are all valid but "(]" and "([)]" are not.
        //([)]
        public bool IsValid(string s)
        {
            Dictionary<char, char> map = new Dictionary<char, char>();
            map.Add('(', ')');
            map.Add('{', '}');
            map.Add('[', ']');
            if (s.Length % 2 == 1 || string.IsNullOrEmpty(s)) return false;
            Stack<char> open = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (map.ContainsKey(s[i])) open.Push(s[i]);
                else
                {
                    if (open.Count == 0) return false;
                    if (map[open.Pop()] != s[i]) return false;
                }

            }

            return !open.Any();
        }

        //        Given a pattern and a string str, find if str follows the same pattern.

        // Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in str.

        // Examples:

        // 1.pattern = "abba", str = "dog cat cat dog" should return true.
        // 2.pattern = "abba", str = "dog cat cat fish" should return false.
        // 3.pattern = "aaaa", str = "dog cat cat dog" should return false.
        // 4.pattern = "abba", str = "dog dog dog dog" should return false.


        //Notes:
        // You may assume pattern contains only lowercase letters, and str contains lowercase letters separated by a single space.


        public bool WordPattern(string pattern, string str)
        {
            Dictionary<string, char> map = new Dictionary<string, char>();
            string[] ss = str.Split(' ');
            if (pattern.Length != ss.Length) return false;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (!map.ContainsKey(ss[i]))
                {
                    if (map.ContainsValue(pattern[i])) return false;
                    map.Add(ss[i], pattern[i]);
                }
                else
                {
                    if (map[ss[i]] != pattern[i]) return false;
                }
            }

            return true;
        }

        // Given a string containing just the characters '(' and ')', find the length of the longest valid(well-formed) parentheses substring.

        //For "(()", the longest valid parentheses substring is "()", which has length = 2.

        //Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4.
        // ()(()

        public int LongestValidParentheses(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            int max = 0;
            int[] dp = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                dp[i] = i;
            }

            if (s[0] == ')') dp[0] = -1;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == ')')
                {
                    if (s[i - 1] == '(')
                    {
                        dp[i] = i - 1;
                    }
                    else
                    {
                        int jump = dp[i - 1];
                        while (jump > 0 && s[jump - 1] == ')')
                        {
                            jump = dp[jump - 1];
                        }

                        dp[i] = jump - 1;
                    }
                }
            }

            int len = 0;
            for (int i = s.Length - 1; i > 0; i--)
            {

                if (s[i] == ')')
                {
                    if (dp[i] >= 0)
                    {
                        len += i - dp[i] + 1;
                        i = dp[i];
                    }
                    else
                    {
                        max = Math.Max(max, len);
                        len = 0;
                    }
                }
                else
                {
                    max = Math.Max(max, len);
                    len = 0;
                }
            }

            return Math.Max(max, len);
        }

        //        Write an algorithm to determine if a number is "happy".

        // A happy number is a number defined by the following process: Starting with any positive integer,
        // replace the number by the sum of the squares of its digits, and repeat the process until the number equals 1 (where it will stay), 
        // or it loops endlessly in a cycle which does not include 1. Those numbers for which this process ends in 1 are happy numbers.

        // Example: 19 is a happy number

        //12 + 92 = 82
        //82 + 22 = 68
        //62 + 82 = 100
        //12 + 02 + 02 = 1
        public bool IsHappy(int n)
        {
            HashSet<int> map = new HashSet<int>();
            
            while(!map.Contains(n))
            {
                map.Add(n);
                n = SquarePlus(n);
                if (n == 1) return true;
            }

            return false;
        }

        //2, 4, 16, 37, 9+49 = 58, 25 + 64 = 89, 64+81 = 145, 1+16+25 = 42, 16+4 = 20, 4, 16, 
        private int SquarePlus(int n)
        {
            int k = 0;
            while( n > 0)
            {
                k += (n % 10) * (n % 10);
                n /= 10;
            }

            return k;
        }
    }



    public class Queue
    {
        private Stack<int> _front = new Stack<int>();
        private Stack<int> _rear = new Stack<int>();
        // Push element x to the back of queue.
        public void Push(int x)
        {
            _rear.Push(x);
        }

        // Removes the element from front of queue.
        public void Pop()
        {
            if (_front.Count > 0) _front.Pop();
            else
            {
                while (_rear.Count > 0)
                {
                    int val = _rear.Pop();
                    _front.Push(val);
                }
                _front.Pop();
            }
        }

        // Get the front element.
        public int Peek()
        {
            if (_front.Count > 0) return _front.Peek();
            else if (_rear.Count > 0)
            {
                while (_rear.Count > 0)
                {
                    int val = _rear.Pop();
                    _front.Push(val);
                }
                return _front.Peek();
            }

            return 0;
        }

        // Return whether the queue is empty.
        public bool Empty()
        {
            return _front.Count == 0 && _rear.Count == 0;
        }
    }


    public class BSTIterator
    {

        private Stack<TreeNode> _stack = new Stack<TreeNode>();

        public BSTIterator(TreeNode root)
        {

            TreeNode it = root;
            while (it != null)
            {
                _stack.Push(it);
                it = it.left;
            }
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            if (_stack.Count > 0) return true;
            return false;

        }

        /** @return the next smallest number */
        public int Next()
        {
            if (_stack.Count > 0)
            {
                TreeNode f = _stack.Pop();
                TreeNode it = f.right;
                while (it != null)
                {
                    _stack.Push(it);
                    it = it.left;
                }
                return f.val;
            }

            return -1;
        }
    }
}
