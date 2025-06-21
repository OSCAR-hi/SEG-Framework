namespace SEGFramework
{
    /// <summary>
    /// 不继承MonoBehaviour的单例类
    /// </summary>
    public class Singleton<T> where T : class, new()
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
                return _instance;
            }
        }

        protected Singleton()
        {
            // 避免外部直接实例化
        }
    }
}