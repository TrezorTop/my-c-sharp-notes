// https://youtu.be/jONSIhMST9E

// Every method (as we know Property and Events also compiled into methods) has own stack
// And every value type argument is going to stack

// Value types declared as a variable in a method. ==> STACK
// Value types declared as a parameter in a method. ==> STACK
// Value types declared as a member of a Ref Type. ==> Allocated along with the parent which is ref so stored in HEAP.
// Value types declared as a member of a Struct Type ==> Allocated wherever the Struct is allocated so HEAP or STACK depending on where the parent is
// Value types declared as a member of a *Ref* Struct Type ==> STACK

ValueType();
RefType();

void ValueType()
{
    // This is going into stack as value type
    int number = 42;

    // This is also going into stack because it's struct
    MyStruct myStruct = new MyStruct();
    myStruct.Number = 54;

    // Works as usual for struct (going to stack)
    RefMyStruct refMyStruct = new RefMyStruct();
}

void RefType()
{
    // Class is always placing in heap as ref type 
    MyClass myClass = new MyClass();

    // But this argument (Int32) 15 will be in stack as argument
    // Method has it's own stack and expects a value type to place it into stack
    myClass.MyMethod(15);

    // MyStruct will be in heap because it's field of MyClass
    // And it will be allocated in heap alongside with parent (MyClass)
    // myClass.MyStruct.Number is also going into heap with MyStruct
    int number = myClass.MyStruct.Number;
}

public class MyClass
{
    private int number = 24;

    public void MyMethod(int number)
    {
    }

    public MyStruct MyStruct = new MyStruct() { Number = 5 };

    // ▼ This is not going to be compiled! ▼
    // ▼ ref struck can't be placed in heap ▼
    public RefMyStruct RefMyStruct = new RefMyStruct() { Number = 100 };
}

public struct MyStruct
{
    public int Number { get; set; }
}

// ref keyword will guarantees struck will be always allocated in the stack no matter what
// compiler will limit you when you try to put in into heap
public ref struct RefMyStruct
{
    public int Number { get; set; }
}