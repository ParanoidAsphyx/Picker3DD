using System.Collections.Generic;
using System.Linq;
using Enums;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class UIPanelController : MonoBehaviour
    {
        #region Self Variables
    
        #region Serialized Variables
    
        [SerializeField] private List<Transform> layers = new List<Transform>();
    
        #endregion
    
        #endregion
    
        private void OnEnable()
        {
            SubscribeEvents();
        }
    
        private void SubscribeEvents()
        {
            CoureUISignals.Instance.onOpenPanel += OnOpenPanel;
            CoureUISignals.Instance.onClosePanel += OnClosePanel;
            CoureUISignals.Instance.onCloseAllPanels += OnCloseAllPanels;
        }
    
        private void UnSubscribeEvents()
        {
            CoureUISignals.Instance.onOpenPanel -= OnOpenPanel;
            CoureUISignals.Instance.onClosePanel -= OnClosePanel;
            CoureUISignals.Instance.onCloseAllPanels -= OnCloseAllPanels;
        }
    
        private void OnDisable()
        {
            UnSubscribeEvents();
        }
    
        private void OnOpenPanel(UIPanelTypes type, int layerValue)
        {
            OnClosePanel(layerValue);
            Instantiate(Resources.Load<GameObject>($"Screens/{type}Panel"), layers[layerValue]);
        }
    
        private void OnClosePanel(int layerValue)
        {
            if(layers[layerValue].childCount > 0)
            {
                Destroy(layers[layerValue].GetChild(0).gameObject);
            }
        }
    
        private void OnCloseAllPanels()
        {
            foreach (var t in layers.Where(t => t.childCount > 0))
            {
                {
                    Destroy(t.GetChild(0).gameObject);
                }
            }
        }
    }
}

