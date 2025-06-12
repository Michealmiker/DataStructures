namespace DataStructures.Linear.List;

/// <summary>
/// 链表
/// </summary>
/// <typeparam name="T"></typeparam>
public class LinkedList<T>
{
    /// <summary>
    /// 表长度
    /// </summary>
    public int Count { get; private set; } = 0;

    /// <summary>
    /// 链表头节点引用
    /// </summary>
    private ListNode? _head = null;

    /// <summary>
    /// 将新元素插入表尾
    /// </summary>
    /// <param name="item"></param>
    public void Add(T item)
    {
        // 1. 创建新节点
        var newNode = new ListNode
        {
            data = item,
            next = null
        };

        // 2. 如果表头为空，则将新节点放在表头后，返回
        if (_head is null)
        {
            _head = newNode;

            Count++;

            return;
        }
        
        // 3. 如果表头不为空
        //    创建临时引用，并将其移动至表尾
        var ptr = _head;

        while (ptr.next is not null)
        {
            ptr = ptr.next;
        }

        // 4. 将新元素插在表尾的下一个节点处
        ptr.next = newNode;

        // 5. 表长度加1
        Count++;
    }

    /// <summary>
    /// 向表头插入新元素
    /// </summary>
    /// <param name="item"></param>
    public void AddFirst(T item)
    {
        // 1. 新建节点
        var newNode = new ListNode
        {
            data = item,
            next = null
        };
        
        // 2. 如果表头为空，则将新节点放在表头后，返回
        if (_head is null)
        {
            _head = newNode;

            Count++;

            return;
        }
        
        // 3. 将新节点的下一节点赋值为表头所指向的节点
        newNode.next = _head;

        // 4. 将表头所指向的节点修改为新节点
        _head = newNode;

        // 5. 表长度加1
        Count++;
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        var ptr = _head;

        for (var i = 0; i < Count; i++)
        {
            stringBuilder.Append($"{ptr.data}");

            if (i < Count - 1)
            {
                stringBuilder.Append(", ");
            }
            
            ptr = ptr.next;
        }
        
        return stringBuilder.ToString();
    }

    /// <summary>
    /// 链表节点
    /// </summary>
    private class ListNode
    {
        public T data;
        public ListNode? next;
    }
}