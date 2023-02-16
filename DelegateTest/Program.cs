
Console.WriteLine("Hello, World!");
DelegateExample delegateExample = new DelegateExample();
delegateExample.Hello();

public class DelegateExample
{

    public DelegateExample()
    {
        // 5 绑定事件和处理流程的实例
        Example += DelegateExample_Example;
    }

    public void Hello()
    {
        // 6 加入执行流程
        OnExample(new ExampleEventArgs() { Value = "Sucess" });
        Console.WriteLine("Hello World!");
    }

    // 0 扩展创建自己的EventArgs
    public class ExampleEventArgs : EventArgs
    {
        public string? Value { get; set; }
    }

    // 1 声明委托，可以在外部类声明
    public delegate void ExampleEventHandler(object sender, ExampleEventArgs e);

    // 2 声明事件，需要在定义事件的类内声明
    public event ExampleEventHandler Example;

    // 3 声明处理过程，需要在定义事件的类内声明
    public virtual void OnExample(ExampleEventArgs e)
    {
        Example?.Invoke(this, e);
    }

    // 4 声明处理过程的实例，需要在定义事件的类内声明
    private void DelegateExample_Example(object sender, ExampleEventArgs e)
    {
        Console.WriteLine(e.Value);
    }
}