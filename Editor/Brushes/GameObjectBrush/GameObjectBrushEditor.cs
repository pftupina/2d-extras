using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UnityEditor.Tilemaps
{
    /// <summary>
    /// The Brush Editor for a GameObject Brush.
    /// </summary>
    [CustomEditor(typeof(GameObjectBrush))]
    public class GameObjectBrushEditor : GridBrushEditorBase
    {
        /// <summary>
        /// The GameObjectBrush for this Editor
        /// </summary>
        public GameObjectBrush brush { get { return target as GameObjectBrush; } }

        /// <summary>
        /// Callback for painting the GUI for the GridBrush in the Scene View.
        /// The GameObjectBrush Editor overrides this to draw the preview of the brush when drawing lines.
        /// </summary>
        /// <param name="gridLayout">Grid that the brush is being used on.</param>
        /// <param name="brushTarget">Target of the GameObjectBrush::ref::Tool operation. By default the currently selected GameObject.</param>
        /// <param name="position">Current selected location of the brush.</param>
        /// <param name="tool">Current GameObjectBrush::ref::Tool selected.</param>
        /// <param name="executing">Whether brush is being used.</param>
        public override void OnPaintSceneGUI(GridLayout gridLayout, GameObject brushTarget, BoundsInt position, GridBrushBase.Tool tool, bool executing)
        {
            BoundsInt gizmoRect = position;

            if (tool == GridBrushBase.Tool.Paint || tool == GridBrushBase.Tool.Erase)
                gizmoRect = new BoundsInt(position.min - brush.pivot, brush.size);

            base.OnPaintSceneGUI(gridLayout, brushTarget, gizmoRect, tool, executing);
        }

        /// <summary>
        /// Callback for painting the inspector GUI for the GameObjectBrush in the tilemap palette.
        /// The GameObjectBrush Editor overrides this to show the usage of this Brush.
        /// </summary>
        public override void OnPaintInspectorGUI()
        {
            GUILayout.Label("Pick, paint and erase GameObject(s) in the scene.");
            GUILayout.Label("Limited to children of the currently selected GameObject.");
        }
    }
}