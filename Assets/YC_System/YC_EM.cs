using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace YCEM
{
    public static class YC_EM
    {
        public static void for_each<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
                action(item);
        }

        public static List<T> FindObjectsOfTypeAll<T>()
        {
            return SceneManager.GetActiveScene().GetRootGameObjects()
                .SelectMany(g => g.GetComponentsInChildren<T>(true))
                .ToList();
        }

        public static bool Match(this bool condition, Action act)
        {
            if (condition) act();
            return condition;
        }
    }
}