using TMPro;
using UnityEngine;

namespace _scripts.Generics
{
    public class MessagePanel : MonoBehaviour
    {
        [SerializeField] private GameObject panelMessage;
        [SerializeField] private TextMeshProUGUI messageText;

        public static MessagePanel Instance;
        private bool _isInstantiated;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            panelMessage.SetActive(false);
        }
        
        private void InstantiateFloatingWindow()
        {
            if (!_isInstantiated)
            {
                GameObject prefab = Resources.Load<GameObject>("PanelMessage");
                GameObject instance = Instantiate(prefab);
                
                Canvas canvas = FindFirstObjectByType<Canvas>();
                if (canvas != null)
                {
                    instance.transform.SetParent(canvas.transform, false);
                }
                else
                {
                    Debug.LogWarning("No se encontró un Canvas en la escena. Asegúrate de que haya uno.");
                }

                Instance = instance.GetComponent<MessagePanel>();
                _isInstantiated = true;
            }
        }

        public void ShowMessage(string message)
        {
            if (Instance == null)
            {
                InstantiateFloatingWindow();
            }
            Instance.SetMessage(message);
        }

        private void SetMessage(string message)
        {
            messageText.text = message;
            panelMessage.SetActive(true);
        }

        public void HideMessage()
        {
            panelMessage.SetActive(false);
        }
    }
}