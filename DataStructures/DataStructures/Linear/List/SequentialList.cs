namespace DataStructures.Linear.List;

/// <summary>
/// 顺序表
/// </summary>
/// <param name="capacity">初始容量</param>
/// <typeparam name="T"></typeparam>
public class SequentialList<T>(int capacity)
{
    /// <summary>
    /// 表容量
    /// </summary>
    public int Capacity { get; private set; } = capacity;

    /// <summary>
    /// 默认容量
    /// </summary>
    private const int DefaultCapacity = 4;

    public SequentialList() : this(DefaultCapacity)
    {
    }
}
