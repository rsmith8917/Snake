using System;
using System.Collections.Generic;

namespace SnakeGame
{
    static public class ClonableList
    {
        static public List<T> CloneList<T>(List<T> listToClone) where T : ICloneable
        {
            List<T> clone = new List<T>();

            foreach (T elem in listToClone)
            {
                clone.Add((T)elem.Clone());
            }

            return clone;
        }

    }
}
