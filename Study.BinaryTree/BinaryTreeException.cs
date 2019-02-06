

namespace Study.BinaryTree
{
    public class BinaryTreeException : System.Exception
    {
        public BinaryTreeException() : base() { }
        public BinaryTreeException(string message) : base(message) { }
        public BinaryTreeException(string message, System.Exception inner) : base(message, inner) { }

        protected BinaryTreeException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public override string ToString()
        {
            string result = "Study.BinaryTreeException class: " + base.ToString();
            return result;
        }
    }
}
