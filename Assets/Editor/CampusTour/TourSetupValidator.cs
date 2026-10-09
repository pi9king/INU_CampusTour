using System.Collections.Generic;
using System.Reflection;
using CampusTour.Tour;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CampusTour.EditorTools
{
    /// <summary>
    /// 투어 씬 구성 검증. 코스 데이터(TourDefinition)와 씬/지도 프리팹이 서로 맞는지 확인한다.
    /// - 투어 씬: TourController/TourView 연결, 정보 패널 수 = 경유지 수, 버튼 이벤트 대상 메서드 존재
    /// - 지도 프리팹: OnlineMapsTourMap 존재, 경로 마커 수 = 경유지 수 × 3
    /// 메뉴: CampusTour/Validate Tours, 배치 모드: -executeMethod CampusTour.EditorTools.TourSetupValidator.RunBatch
    /// </summary>
    public static class TourSetupValidator
    {
        [MenuItem("CampusTour/Validate Tours")]
        public static void ValidateFromMenu()
        {
            List<string> errors = Validate();
            if (errors.Count == 0)
            {
                EditorUtility.DisplayDialog("Validate Tours", "문제가 없습니다.", "OK");
            }
        }

        public static void RunBatch()
        {
            List<string> errors = Validate();
            EditorApplication.Exit(errors.Count == 0 ? 0 : 1);
        }

        private static List<string> Validate()
        {
            List<string> errors = new List<string>();
            foreach (string guid in AssetDatabase.FindAssets("t:TourDefinition"))
            {
                TourDefinition definition = AssetDatabase.LoadAssetAtPath<TourDefinition>(AssetDatabase.GUIDToAssetPath(guid));
                ValidateMapPrefab(definition, errors);
                ValidateScene(definition, errors);
            }

            foreach (string error in errors)
            {
                Debug.LogError("[TourSetupValidator] " + error);
            }
            Debug.Log("[TourSetupValidator] 검증 완료, 오류 " + errors.Count + "건");
            return errors;
        }

        private static void ValidateMapPrefab(TourDefinition definition, List<string> errors)
        {
            string prefix = definition.name + ": ";
            if (definition.mapPrefab == null)
            {
                errors.Add(prefix + "mapPrefab이 비어 있음");
                return;
            }
            if (definition.mapPrefab.GetComponent<OnlineMapsTourMap>() == null)
            {
                errors.Add(prefix + "mapPrefab에 OnlineMapsTourMap이 없음");
            }

            OnlineMaps map = definition.mapPrefab.GetComponent<OnlineMaps>();
            HashSet<string> labels = new HashSet<string>();
            foreach (OnlineMapsMarker marker in map.markers)
            {
                labels.Add(marker.label);
            }
            int markerCount = definition.route.StopCount * TourRoute.MarkersPerStop;
            for (int number = 1; number <= markerCount; number++)
            {
                if (!labels.Contains(number.ToString()))
                {
                    errors.Add(prefix + "경로 마커 " + number + "번이 지도 프리팹에 없음");
                }
            }
            foreach (QuadrantStart start in definition.route.quadrantStarts)
            {
                if (start.stopIndex < 0 || start.stopIndex >= definition.route.StopCount)
                {
                    errors.Add(prefix + "시작 경유지 인덱스 범위 초과: " + start.stopIndex);
                }
            }
        }

        private static void ValidateScene(TourDefinition definition, List<string> errors)
        {
            string prefix = definition.name + " (" + definition.sceneName + "): ";
            string[] scenePaths = AssetDatabase.FindAssets(definition.sceneName + " t:Scene");
            if (scenePaths.Length == 0)
            {
                errors.Add(prefix + "씬을 찾을 수 없음");
                return;
            }

            Scene scene = EditorSceneManager.OpenScene(AssetDatabase.GUIDToAssetPath(scenePaths[0]), OpenSceneMode.Single);
            TourController controller = Object.FindObjectOfType<TourController>();
            TourView view = Object.FindObjectOfType<TourView>();
            if (controller == null || view == null)
            {
                errors.Add(prefix + "TourController 또는 TourView가 없음");
                return;
            }

            SerializedObject serializedController = new SerializedObject(controller);
            if (serializedController.FindProperty("definition").objectReferenceValue != definition)
            {
                errors.Add(prefix + "TourController.definition이 이 코스를 가리키지 않음");
            }

            CheckObjectReferences(view, prefix, errors);
            SerializedProperty panels = new SerializedObject(view).FindProperty("infoPanels");
            if (panels.arraySize != definition.route.StopCount)
            {
                errors.Add(prefix + "정보 패널 수(" + panels.arraySize + ")와 경유지 수(" + definition.route.StopCount + ")가 다름");
            }

            GameObject arrivalPopup = (GameObject)new SerializedObject(view).FindProperty("arrivalPopup").objectReferenceValue;
            if (arrivalPopup != null && arrivalPopup.GetComponent<TourArrivalPopup>() == null)
            {
                errors.Add(prefix + "arrivalPopup에 TourArrivalPopup이 없음");
            }

            foreach (GameObject root in scene.GetRootGameObjects())
            {
                foreach (Button button in root.GetComponentsInChildren<Button>(true))
                {
                    CheckPersistentCalls(button.onClick, prefix + GetPath(button.transform), errors);
                }
            }
        }

        private static void CheckObjectReferences(Object target, string prefix, List<string> errors)
        {
            SerializedProperty property = new SerializedObject(target).GetIterator();
            while (property.NextVisible(true))
            {
                if (property.propertyType == SerializedPropertyType.ObjectReference && property.objectReferenceValue == null)
                {
                    errors.Add(prefix + target.GetType().Name + "." + property.propertyPath + " 연결이 비어 있음");
                }
            }
        }

        // 메서드 이름 문자열로 저장된 버튼 이벤트가 실제 메서드를 가리키는지 확인한다. 대상이 비어 있는 호출은 검사하지 않는다.
        private static void CheckPersistentCalls(UnityEventBase unityEvent, string location, List<string> errors)
        {
            for (int i = 0; i < unityEvent.GetPersistentEventCount(); i++)
            {
                Object target = unityEvent.GetPersistentTarget(i);
                string method = unityEvent.GetPersistentMethodName(i);
                if (target == null || string.IsNullOrEmpty(method))
                {
                    continue;
                }
                MethodInfo info = target.GetType().GetMethod(method, BindingFlags.Instance | BindingFlags.Public);
                if (info == null)
                {
                    errors.Add(location + " 버튼이 없는 메서드를 호출함: " + target.GetType().Name + "." + method);
                }
            }
        }

        private static string GetPath(Transform transform)
        {
            return transform.parent == null ? transform.name : GetPath(transform.parent) + "/" + transform.name;
        }
    }
}
