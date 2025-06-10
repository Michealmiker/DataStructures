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
