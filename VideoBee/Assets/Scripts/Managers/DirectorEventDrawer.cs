using JetBrains.Annotations;
using lvl_0;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace lvl_0
{
    [CustomPropertyDrawer(typeof(DirectorEvent))]
    public class DirectorEventDrawer : PropertyDrawer
    {
        private Rect Position;
        private const int lineHeight = 16;
        private int marginBetweenFields;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Position = position;
            marginBetweenFields = (int)EditorGUIUtility.standardVerticalSpacing;
            Position.height = lineHeight + marginBetweenFields;

            var eventTypeProperty = property.FindPropertyRelative("EventType");
            var eventType = (GameEvent)eventTypeProperty.enumValueIndex;
            SerializedProperty waitProperty = null;

            string foldoutLabel = $"{label.text.Split(' ')[1]}: ";

            switch (eventType)
            {
                case GameEvent.Wait:
                    waitProperty = property.FindPropertyRelative("Wait");
                    foldoutLabel += $"{eventType} - {waitProperty.floatValue}";
                    break;
                case GameEvent.TextWindowEvent:
                    var textsProperty = property.FindPropertyRelative("TextWindowEvent").FindPropertyRelative("texts");
                    string textSample = string.Empty;
                    
                    if (textsProperty != null && textsProperty.arraySize > 0)
                    {
                        var firstTextBoxString = textsProperty.GetArrayElementAtIndex(0).stringValue;
                        textSample = firstTextBoxString.Substring(0, Mathf.Min(firstTextBoxString.Length, 35));
                    }

                    foldoutLabel += $"TEXT - '{textSample}...' - {textsProperty.arraySize} pages - ";
                    break;
                case GameEvent.GameStartEvent:
                    var gameStartEventProperty = property.FindPropertyRelative("GameStartEvent");
                    var game = (Game)gameStartEventProperty.FindPropertyRelative("Game").enumValueIndex;
                    foldoutLabel += $"GAME START: {game}";
                    break;
                default:
                    foldoutLabel += eventType.ToString();                 
                    break;
            }

            property.isExpanded = EditorGUI.Foldout(new Rect(3, 3, position.width, lineHeight), property.isExpanded, foldoutLabel);
            Position.y += lineHeight + marginBetweenFields;

            if (property.isExpanded)
            {
                Position.x = position.x;
                Position.width = position.width;

                DisplayPropertyField(eventTypeProperty);

                switch (eventType)
                {
                    case GameEvent.Wait:
                        DisplayPropertyField(waitProperty);
                        break;
                    default:
                        var selectedProperty = property.FindPropertyRelative(eventType.ToString());
                        if (selectedProperty != null)
                        {
                            var depth = selectedProperty.depth;
                            var ite = selectedProperty.GetEnumerator();
                            while (ite.MoveNext())
                            {
                                SerializedProperty prop = ite.Current as SerializedProperty;
                                if (prop == null || prop.depth > depth + 1) continue;
                                DisplayPropertyField(prop);
                            }
                        }
                        break;
                }
            }
        }

        private void DisplayPropertyField(SerializedProperty property)
        {
            EditorGUI.PropertyField(Position, property);
            Position.y += EditorGUI.GetPropertyHeight(property);
            Position.y += marginBetweenFields;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float totalPropertyHeight = lineHeight + marginBetweenFields;

            if (property.isExpanded)
            {
                totalPropertyHeight += marginBetweenFields;
                var eventTypeProperty = property.FindPropertyRelative("EventType");
                totalPropertyHeight += EditorGUI.GetPropertyHeight(eventTypeProperty);

                var eventType = (GameEvent)eventTypeProperty.enumValueIndex;
                switch (eventType)
                {
                    case GameEvent.Wait:
                        var waitProperty = property.FindPropertyRelative("Wait");
                        totalPropertyHeight += EditorGUI.GetPropertyHeight(waitProperty);
                        break;
                    default:
                        var selectedProperty = property.FindPropertyRelative(eventType.ToString());
                        if (selectedProperty != null)
                        {
                            var depth = selectedProperty.depth;
                            var ite = selectedProperty.GetEnumerator();
                            while (ite.MoveNext())
                            {
                                SerializedProperty prop = ite.Current as SerializedProperty;
                                if (prop == null || prop.depth > depth + 1) continue;
                                totalPropertyHeight += EditorGUI.GetPropertyHeight(prop);
                                totalPropertyHeight += marginBetweenFields;
                            }
                        }
                        break;
                }

            }
            return totalPropertyHeight;
        }
    }
}

