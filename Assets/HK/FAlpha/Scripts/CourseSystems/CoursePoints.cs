using System;
using System.Collections.Generic;
using HK.FAlpha.Extensions;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.FAlpha.CourseSystems
{
    /// <summary>
    /// コースポイント.
    /// </summary>
    public class CoursePoints : MonoBehaviour
    {
        public List<Points> Courses;
        
        [Serializable]
        public class Points
        {
            public List<Point> List;
        }
        
        [Serializable]
        public class Point
        {
            public Vector3 Position;

            public Vector3 Rotation;

            public float Width;

            public AnimationCurve Ease;
        }
    }
}
