namespace CommonLib.Basic
{
    public sealed class Singleton<T> where T: new()
    {
        public T Model { get; set; }

        private Singleton()
        {
            this.Model = new T();
        }

        public static Singleton<T> GetObj => Nested.Obj;
        
        private class Nested
        {
            
            static Nested()
            {
            }

            internal static readonly Singleton<T> Obj = new Singleton<T>();
        }
    }
}