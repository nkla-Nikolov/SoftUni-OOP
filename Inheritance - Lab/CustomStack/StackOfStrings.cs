using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        private Stack<string> stack;

        public StackOfStrings()
        {
            stack = new Stack<string>();
        }

        public bool IsEmpty()
        {
            return stack.Count == 0;
        }

        public void AddRange(IEnumerable<string> items)
        {
            foreach (var item in items)
            {
                stack.Push(item);
            }
        }
    }
}
