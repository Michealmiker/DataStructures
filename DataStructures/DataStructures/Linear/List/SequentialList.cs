namespace DataStructures.Linear.List;

/// <summary>
/// 顺序表
/// </summary>
/// <param name="capacity">初始容量</param>
/// <typeparam name="T"></typeparam>
public class SequentialList<T>(int capacity)
{
    /// <summary>
    /// 表长度
    /// </summary>
    public int Count { get; private set; } = 0;
    
    /// <summary>
    /// 表容量
    /// </summary>
    public int Capacity { get; private set; } = capacity;

    private T[] _elements = new T[capacity];

    /// <summary>
    /// 默认容量
    /// </summary>
    private const int DefaultCapacity = 4;

    /// <summary>
    /// 增量倍数
    /// </summary>
    private const int IncrementCapacity = 2;

    public SequentialList() : this(DefaultCapacity)
    {
    }

    /// <summary>
    /// 将新元素插入表尾
    /// </summary>
    /// <param name="item"></param>
    public void Add(T item)
    {
        // 1. 检查表容量是否足够
        CheckCapacity();

        // 2. 将新元素插入表尾
        _elements[Count] = item;

        // 3. 表长度加1
        Count++;
    }

    /// <summary>
    /// 向表头插入新元素
    /// </summary>
    /// <param name="item"></param>
    public void AddFirst(T item)
    {
        // 1. 检查表容量是否足够
        CheckCapacity();
        
        // 2. 如果是第一个元素，则直接插入
        if (Count == 0)
        {
            _elements[0] = item;

            Count++;

            return;
        }
        
        // 3. 如果不是第一个元素，则将表中的所有元素向后移动一位
        var span = new Span<T>(_elements, 0, Count + 1);
        for (var i = Count; i > 0; i--)
        {
            span[i] = span[i - 1];
        }

        // 4. 将新元素插入下标为1的单元中
        span[0] = item;

        // 5. 表长度加1
        Count++;
    }

    /// <summary>
    /// 向表的指定位置插入新元素 (index基于0)
    /// </summary>
    /// <param name="item"></param>
    public void Insert(int index, T item)
    {
        // 1. 检查index是否超出Count的范围
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException("指定的下标超界");
        }
        
        // 2. 检查表容量是否足够
        CheckCapacity();
        
        // 3. index指向表尾，则直接插入
        if (index == Count)
        {
            _elements[index] = item;

            Count++;

            return;
        }
        
        // 4. 如果index未指向表尾，则从index位置开始，将其后的全部元素向后移动一位
        var length = Count + 1 - index;
        var span = new Span<T>(_elements, index, length);
        for (var i = length - 1; i > 0; i--)
        {
            span[i] = span[i - 1];
        }

        // 5. 将新元素插入index所指向的单元
        span[0] = item;

        // 6. 表长度加1
        Count++;
    }

    /// <summary>
    /// 获取指定元素在表中的位置 (位置基于0)
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int IndexOf(T item)
    {
        var span = new Span<T>(_elements, 0, Count);
        for (var i = 0; i < Count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(span[i], item))
            {
                return i;
            }
        }

        return -1;
    }
    
    public override string ToString() => string.Join(", ", _elements.Take(Count));

    /// <summary>
    /// 检查表容量
    /// </summary>
    private void CheckCapacity()
    {
        if (Count < Capacity)
        {
            return;
        }
        
        // 如果表已满，则扩充表容量
        Capacity *= IncrementCapacity;
        
        Array.Resize(ref _elements, Capacity);
    }
}
