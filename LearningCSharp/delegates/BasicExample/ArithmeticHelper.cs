using System;

namespace LearningCSharp.delegates.BasicExample
{
    public class ArithmeticHelper
    {
        public delegate int ArithmeticOperation(int x, int y);

        public static int Operation(ArithmeticOperation operation, int x, int y)
        {
            return operation(x, y); // same as: operation?.Invoke(x, y);
        }

        // 2 main delegates
        // Action - void return type. They are predefined and can be directly used...:)
        // Func - have a return type. They are predefined and can be directly used...:)
        public static int OperationWithFunc(Func<int, int, int> operation, int x, int y)
        {
            return operation(x, y); // same as: operation?.Invoke(x, y);
        }
    }
}

