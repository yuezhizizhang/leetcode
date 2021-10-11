using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Logger
    {
        private const int Intervals = 10;
        private IDictionary<string, int> Messages;

        public Logger()
        {
            this.Messages = new Dictionary<string, int>();
        }

        public bool ShouldPrintMessage(int timestamp, string message)
        {
            if (this.Messages.ContainsKey(message))
            {
                var expectedTime = this.Messages[message];
                if (expectedTime > timestamp) return false;
            }

            this.Messages[message] = timestamp + Intervals;
            return true;
        }
    }

    /**
     * Your Logger object will be instantiated and called as such:
     * Logger obj = new Logger();
     * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
     */
}
