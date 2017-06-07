using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Visitors.Cst
{
	public class BottomUpHelper<T>
	{
		private IList<T> itemList;
		private Stack<int> sizeStack;

		public int Count
		{
			get
			{
				if (sizeStack.Count == 0)
					return 0;

				return itemList.Count - sizeStack.Peek();
			}
		}

		public T this[int index]
		{
			get { return itemList[sizeStack.Peek() + index]; }
		}

		public void Pre()
		{
			Enter();
		}

		public void Post(T item)
		{
			AddItem(item);
			Exit();
		}

		public void Clear()
		{
			sizeStack.Clear();
			itemList.Clear();
		}

		protected void Enter()
		{
			sizeStack.Push(itemList.Count);
		}

		protected void AddItem(T item)
		{
			itemList.Add(item);
		}

		protected void Exit()
		{
			int n = itemList.Count - 1 - sizeStack.Peek();

			for (int i = 0; i < n; i++)
				itemList.RemoveAt(sizeStack.Peek());

			sizeStack.Pop();
		}

		public BottomUpHelper()
		{
			this.itemList = new List<T>();
			this.sizeStack = new Stack<int>();
		}
	}
}
