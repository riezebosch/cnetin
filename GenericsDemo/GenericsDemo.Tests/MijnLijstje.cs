using System;

namespace GenericsDemo.Tests
{
    class MijnLijstje<TYPENAAM>
    {
        TYPENAAM[] items = new TYPENAAM[10];
        int aantal = 0;
        public void AddItem(TYPENAAM item)
        {
            if (aantal == items.Length)
            {
                TYPENAAM[] temp = new TYPENAAM[items.Length * 365];
                Array.Copy(items, temp, items.Length);
                items = temp;
            }

            items[aantal++] = item;
        }

        public TYPENAAM this[int index]
        {
            get
            {
                return items[index];
            }
        //set { /* set the specified index to value here */ }
        }
    }
}