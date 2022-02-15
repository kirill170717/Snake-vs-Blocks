using TMPro;
using UnityEngine;

[RequireComponent(typeof(Block))]
public class BlockView : MonoBehaviour
{
    public TMP_Text view;

    private Block block;

    private void Awake()
    {
        block = GetComponent<Block>();
    }

    private void OnEnable()
    {
        block.FillingUpdated += OnFillingUpdated;
    }

    private void OnDisable()
    {
        block.FillingUpdated -= OnFillingUpdated;
    }

    private void OnFillingUpdated(int leftToFill)
    {
        view.text = leftToFill.ToString();
    }
}