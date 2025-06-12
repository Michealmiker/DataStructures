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

    /// <summary>
    /// 向表指定位置插入新元素（index基于0）
    /// </summary>
    /// <param name="index"></param>
    /// <param name="item"></param>
    public void Insert(int index, T item)
    {
        // 1. 检查index是否超过Count的界限
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException("指定的位置超过表长度");
        }
        
        // 2. 如果没有超界，则创建新节点
        var newNode = new ListNode
        {
            data = item,
            next = null
        };

        // 3. 如果index为0，则将其直接插在头结点处
        if (index == 0)
        {
            newNode.next = _head;
            _head = newNode;

            Count++;

            return;
        }

        // 4. 如果index不为0
        //    创建临时引用，并将其移动至index的前一位处
        var ptr = _head;
        var length = index - 1;

        for (var i = 0; i < length; i++)
        {
            ptr = ptr!.next;
        }

        // 5. 将新节点的下一节点赋值为临时引用所指向的下一个节点
        newNode.next = ptr.next;

        // 6. 将临时引用所指向的下一个节点修改为新节点
        ptr.next = newNode;

        // 7. 表长度加1
        Count++;
    }

    /// <summary>
    /// 获取元素在表中的位置
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int IndexOf(T item)
    {
        // 1. 检查表是否为空，如果为空则直接抛出异常
        if (_head is null)
        {
            throw new NullReferenceException("链表为空");
        }
        
        // 2 如果指定的元素就是表头所指向的节点所保存的元素，则直接返回坐标0
        if (EqualityComparer<T>.Default.Equals(_head!.data, item))
        {
            return 0;
        }
        
        // 3. 如果不是表头，则创建一个临时引用，
        //    并通过临时引用遍历整个链表，一个元素一个元素的对比，
        //    直到找到指定的元素后，返回记录的index的值
        var ptr = _head.next;
        var index = 1;

        while (ptr is not null)
        {
            if (EqualityComparer<T>.Default.Equals(ptr.data, item))
            {
                return index;
            }
            
            ptr = ptr.next;
            index++;
        }

        // 4. 如果上面的循环结束退出，则表示没有找到元素，直接返回-1
        return -1;
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