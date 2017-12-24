using UnityEngine;

namespace HK.FAlpha.Extensions
{
    public static class Extensions
    {
        public static Quaternion ToQuaternion(this Vector3 self)
        {
            return Quaternion.Euler(self);
        }
    }
}
