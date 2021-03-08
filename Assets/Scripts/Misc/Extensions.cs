using UnityEngine;

namespace Examples.Extensions
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
        public static (int height, int width) Size<T>(this T[,] matrix)
        {
            return (matrix.GetLength(0), matrix.GetLength(1));
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