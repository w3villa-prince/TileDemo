using UnityEngine;
using UnityEngine.UI;
using System.IO;
using SFB; // Standalone File Browser

public class ImageSelector : MonoBehaviour
{
  [HideInInspector]  public   Texture2D selectedTexture;
    [SerializeField]private  Button selectImageButton;
    [SerializeField]private  Material brickMaterial;
    [SerializeField] private RawImage _importImageView;
    [SerializeField] private GameUIHandler _gameUIHandler;// Assign in Inspector

    void Start()
    {
        selectImageButton.onClick.AddListener(OpenFileBrowser);
        _importImageView.gameObject.SetActive(false);
    }

    void OpenFileBrowser()
    {
        string[] filePaths = StandaloneFileBrowser.OpenFilePanel("Select Image", "", "png,jpg,jpeg", false);

        if (filePaths.Length > 0 && !string.IsNullOrEmpty(filePaths[0]))
        {
            LoadTexture(filePaths[0]);
        }
    }

    void LoadTexture(string path)
    {
        byte[] imageBytes = File.ReadAllBytes(path);
        selectedTexture = new Texture2D(2, 2);
        selectedTexture.LoadImage(imageBytes);
        brickMaterial.mainTexture = selectedTexture;
        _importImageView.texture = selectedTexture;
        _importImageView.gameObject.SetActive(true);
        _gameUIHandler.HideImportPanel();
        // Assign texture to the material
    }
}
