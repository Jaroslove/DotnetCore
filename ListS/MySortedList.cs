namespace ListS
{
    public class MySortedList
    {
        private int value;

        private MySortedList first;
        private MySortedList next;
        private MySortedList previus;

        public MySortedList(int value)
        {
            this.value = value;
        }

        public MySortedList Insert(MySortedList mySortedList)
        {
            if (first.next == null && first.previus == null)
            {
                if (value < mySortedList.value)
                {
                    mySortedList.previus = this;

                    next = mySortedList;

                    first = this;
                }
                else
                {
                    first = mySortedList;

                    mySortedList.next = this;

                    mySortedList.first = this;

                    first = mySortedList;
                }

                return mySortedList;
            }

            if (first.value > mySortedList.value)
            {
                
            }
            
            var current = first;

            while (current.next != null && current.next.value < mySortedList.value)
            {
                current = current.next;
            }

            mySortedList.previus = this;

            current.next = mySortedList;

            return mySortedList;
        }

        public MySortedList FindFirst(int value)
        {
        }

        public MySortedList DeleteFirst(int value)
        {
        }

        public void Print()
        {
        }
    }
}