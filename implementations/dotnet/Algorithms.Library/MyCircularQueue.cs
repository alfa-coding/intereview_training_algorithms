namespace Algorithms.Library
{


    public class DoubleLinkedNode
    {
        public int val;
        public DoubleLinkedNode next;
        public DoubleLinkedNode prev;

        public DoubleLinkedNode(int val, DoubleLinkedNode next, DoubleLinkedNode prev)
        {
            this.val = val;
            this.next = next;
            this.prev = prev;
        }
        public DoubleLinkedNode(int val)
        {
            this.val = val;
        }

    }
    public class MyCircularQueue
    {
        private DoubleLinkedNode last;
        private DoubleLinkedNode front;

        private int currentCapacity;
        private int maxCapacity;

        public MyCircularQueue(int k)
        {
            this.maxCapacity = k;
            this.currentCapacity = 0;
        }

        public bool EnQueue(int value)
        {
            if (currentCapacity < maxCapacity)
            {
                if (this.currentCapacity == 0)
                {
                    this.front = new DoubleLinkedNode(value);
                    this.last = this.front;
                    this.last.prev = front;
                }
                else
                {
                    DoubleLinkedNode nuevo = new DoubleLinkedNode(value);
                    nuevo.prev = last;
                    last.next = nuevo;
                    last = last.next;
                }
                this.currentCapacity++;
                return true;
            }
            return false;

        }

        public bool DeQueue()
        {
            if (currentCapacity > 0)
            {
                this.front = this.front.next;
                this.currentCapacity--;
                return true;
            }
            return false;
        }

        public int Front()
        {
            if (currentCapacity == 0) return -1;
            return front.val;
        }

        public int Rear()
        {
            if (currentCapacity == 0) return -1;
            return last.val;
        }

        public bool IsEmpty()
        {
            return currentCapacity == 0;
        }

        public bool IsFull()
        {
            return currentCapacity == maxCapacity;

        }
    }
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */