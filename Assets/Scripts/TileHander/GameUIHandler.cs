using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.UI;

public class GameUIHandler : MonoBehaviour
{
    
    [SerializeField] private GameObject _importPanel;
    [SerializeField]private Button _importButton;
    // Start is called before the first frame update
    void Start()
    {
        _importButton.onClick.AddListener(ShowImportPanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowImportPanel()
    {
        _importPanel.SetActive(true);
    }

    public void HideImportPanel()
    {
        _importPanel.SetActive(false);
    }
}
