using UnityEngine;

public class TextEdit : MonoBehaviour
{
    public TextEditor editor;

    public void Loading(string key)
    {
        if (string.IsNullOrEmpty(key))
            Debug.Log("The 'Key' field is empty");
        else
        {
            if (!editor.txtList.Exists(x => x.key == key))
            {
                editor.txtList.Add(new TextEditor.DictList() { key = key });
                Debug.Log("Added!");
            }
            else
                Debug.Log("The Key already exists");
        }
    }

    public void Deleting(string key)
    {
        if (string.IsNullOrEmpty(key))
            Debug.Log("The 'Key' field is empty");
        else
        {
            if (editor.txtList.Exists(x => x.key == key))
            {
                int keyId = editor.txtList.FindIndex(x => x.key == key);
                editor.txtList.RemoveAt(keyId);
                Debug.Log("Deleted!");
            }
            else
                Debug.Log("The Key doesn't exist!");
        }
    }
}