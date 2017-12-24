using HK.FAlpha.CourseSystems;
using HK.FAlpha.Extensions;
using UnityEditor;
using UnityEngine;

namespace HK.FAlpha.Editor
{
    [CustomEditor(typeof(CoursePoints))]
    public sealed class CoursePointsEditor : UnityEditor.Editor
    {
        void OnSceneGUI()
        {
            Tools.current = Tool.None;
            var target = (CoursePoints)this.target;
            
            target.Courses.ForEach(c =>
            {
                for (var i = 0; i < c.List.Count; i++)
                {
                    var p = c.List[i];
                    var n = (i + 1) >= c.List.Count ? null : c.List[i + 1];
                    
                    // Positionの代入処理
                    using (var check = new EditorGUI.ChangeCheckScope())
                    {
                        var newPosition = Handles.PositionHandle(p.Position, p.Rotation.ToQuaternion());
                        if (check.changed)
                        {
                            Undo.RecordObject(target, "Point Position");
                            p.Position = newPosition;
                        }
                    }
                    
                    // Rotationの代入処理
                    using (var check = new EditorGUI.ChangeCheckScope())
                    {
                        var newRotation = Handles.RotationHandle(p.Rotation.ToQuaternion(), p.Position).eulerAngles;
                        if (check.changed)
                        {
                            Undo.RecordObject(target, "Point Rotation");
                            p.Rotation = newRotation;
                        }
                    }
                    
                    // Widthの代入処理
                    using (var check = new EditorGUI.ChangeCheckScope())
                    {
                        var newWidth = Handles.ScaleSlider(p.Width, p.Position, p.Rotation.ToQuaternion() * Vector3.left, p.Rotation.ToQuaternion(), 1.0f, 0.5f);
                        if (check.changed)
                        {
                            Undo.RecordObject(target, "Point Width");
                            p.Width = newWidth;
                        }
                    }
                }
            });
        }
    }
}
