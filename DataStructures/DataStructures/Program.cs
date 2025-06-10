var seqList = new SequentialList<int>();

// for (var i = 0; i < 10; i++)
// {
//     seqList.Add(i + 1);
// }

for (var i = 0; i < 10; i++)
{
    seqList.AddFirst(i + 1);
}

Console.WriteLine("表信息：");
Console.WriteLine($"表容量：{seqList.Capacity}");
Console.WriteLine($"表长度：{seqList.Count}");
Console.WriteLine($"表内容:\n{seqList}");
