using System.Collections;

namespace Interfaces
{
    public class FlyableThings : IEnumerable, IEnumerator
    {
        public FlyableThings(params IFlyable[] flyables)
        {
            things = flyables;
        }

        private readonly IFlyable[] things;
        private int currentIndex = -1;

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (currentIndex + 1 == things.Length) return false;

            currentIndex++;
            return true;
        }

        public void Reset()
        {
            currentIndex = -1;
        }

        public object Current
        {
            get { return things[currentIndex]; }
        }
    }
}