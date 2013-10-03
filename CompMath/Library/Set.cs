using System;
namespace Library.Set
{
	public class Set<T> : System.Collections.IEnumerable
	{
		private sealed class Node
		{
			public T Data;
			public Node Next;

			public Node(T data, Node next)
			{
				this.Data = data;
				this.Next = next;
			}
		}

		public System.Collections.IEnumerator GetEnumerator()
		{
			for (Node currentNode = head; currentNode != null; currentNode = currentNode.Next)
				yield return currentNode.Data;
		}

		private int count;
		public int Count
		{
			get { return this.count; }
		}

		private Node head = null;
		private Node tail = null;

		public void Insert(int position, T data)
		{
			if (position < 0 || position > this.count)
				throw new ArgumentOutOfRangeException();

			if (position == 0)
				this.AddFront(data);
			else if (position == this.count)
				this.AddBack(data);
			else
			{
				Node curentNode = this.head;
				for (int i = 0; i < this.count; i++)
					curentNode = curentNode.Next;

				Node newNode = new Node(data, curentNode.Next);
				curentNode.Next = newNode;

				this.count++;
			}
		}

		public void AddFront(T data)
		{
			if (this.head == null)
			{
				this.head = new Node(data, null);
				this.tail = this.head;
			}
			else
			{
				Node newHead = new Node(data, this.head);
				this.head = newHead;
			}
			this.count++;
		}

		public void AddBack(T data)
		{
			if (this.head == null)
			{
				this.head = new Node(data, null);
				this.tail = this.head;
			}
			else
			{
				this.tail.Next = new Node(data, null);
				this.tail = this.tail.Next;
			}
			this.count++;
		}

		public void Print()
		{
			System.Console.Write("Set:");
			foreach (var nodeValue in this)
			{
				System.Console.Write(nodeValue + " ");
			}
			System.Console.WriteLine();
		}

		public bool Contains(T data)
		{
			var currentNode = this.head;
			while (currentNode != null)
			{
				if (currentNode.Data.ToString() == data.ToString())
					return true;
				else
					currentNode = currentNode.Next;
			}
			return false;
		}

		public virtual void Operation(Set<T> externalSet) { }

		public virtual void Sort() { }
	}
}