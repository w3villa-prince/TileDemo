using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class BrickGeneratorHandler : MonoBehaviour
{
    [SerializeField] private ImageSelector _imageSelector;

    [SerializeField] private  BrickPatternGenerator _brickPatternGenerator;
    [SerializeField]private Button _generateButton;
    // Start is called before the first frame update
    void Start()
    {
        _generateButton.onClick.AddListener(OnClickGenerateBrick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClickGenerateBrick()
    {
        _brickPatternGenerator.GeneratePattern(_imageSelector.selectedTexture);
    }
}
