var seqList = new SequentialList<int>();

// for (var i = 0; i < 10; i++)
// {
//     seqList.Add(i + 1);
// }

// for (var i = 0; i < 10; i++)
// {
//     seqList.AddFirst(i + 1);
// }

for (var i = 0; i < 10; i++)
{
    seqList.Add(i + 1);
}

var rand = new Random();
for (var i = 0; i < 10; i++)
{
    var index = rand.Next(0, seqList.Count);
    var number = rand.Next(500, 600);
    
    seqList.Insert(index, number);
    
    Console.WriteLine($"向表第{index + 1}位置插入新元素{number}");
}

var location = seqList.IndexOf(10);
var location2 = seqList.IndexOf(1000);

Console.WriteLine("表信息：");
Console.WriteLine($"表容量：{seqList.Capacity}");
Console.WriteLine($"表长度：{seqList.Count}");
Console.WriteLine($"表内容:\n{seqList}");

Console.WriteLine($"10在表中的位置为{location}");
Console.WriteLine($"1000在表中的位置为{location2}");
