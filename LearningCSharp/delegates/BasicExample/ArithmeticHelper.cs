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

        // Action - void return type
        // Func - 
        public static int OperationWithFunc(Func<int, int, int> operation, int x, int y)
        {
            return operation(x, y); // same as: operation?.Invoke(x, y);
        }
    }
}

