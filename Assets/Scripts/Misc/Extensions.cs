using System.Linq;
using UnityEngine;

namespace FUGAS.Examples.Misc.Extensions
{
    public static class Extensions
    {
        public static void DestroyChildren(this GameObject obj)
        {
            foreach (Transform t in obj.transform)
            {
                SafeDestroy(t.gameObject);
            }
        }

        public static T SafeDestroy<T>(T obj) where T : Object
        {
            Object.Destroy(obj);

            return null;
        }

        public static T SafeDestroyGameObject<T>(T component) where T : Component
        {
            if (component != null)
                SafeDestroy(component.gameObject);
            return null;
        }

        public static GameObject GetChildWithName(this GameObject obj, string name)
        {
            var res = obj.transform.GetComponentsInChildren<Transform>(true).FirstOrDefault(x => x.gameObject.name == name);
            return res != default ? res.gameObject : default;
        }
        
        public static (int height, int width) Size<T>(this T[,] matrix)
        {
            return (matrix.GetLength(0), matrix.GetLength(1));
        }

        public static void SetAll<T>(this T[,] matrix, T value)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = value;
                }
            }
        }
        public static void FillContour<T>(this T[,] matrix, T value)
        {
            var (mh, mw) = matrix.Size();

            for (var i = 0; i < mw; i++)
                matrix[0, i] = value;

            for (var i = 0; i < mw; i++)
                matrix[mh - 1, i] = value;

            for (var i = 0; i < mh; i++)
                matrix[i, 0] = value;

            for (var i = 0; i < mh; i++)
                matrix[i, mw - 1] = value;
        }

        public static bool Contains<T>(this T[,] matrix, T value)
        {
            var (mh, mw) = matrix.Size();

            for (var i = 0; i < mh; i++)
                for (var j = 0; j < mw; j++)
                    if (Equals(matrix[i, j], value))
                        return true;
            return false;
        }

        public static int Count<T>(this T[,] matrix, T value)
        {
            var (mh, mw) = matrix.Size();

            var v = 0;
            for (var i = 0; i < mh; i++)
                for (var j = 0; j < mw; j++)
                    if (Equals(matrix[i, j], value))
                        v++;
            return v;
        }
    }
}