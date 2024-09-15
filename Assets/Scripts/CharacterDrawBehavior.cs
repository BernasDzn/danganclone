using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDrawbehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Character character;
    private Emotion emotion;

    void Start()
    {
        character = GetComponentInParent<CharacterResources>().character;
        emotion = GetComponentInParent<CharacterResources>().emotion;
    }

    // Update is called once per frame
    void Update()
    {
        var changed = false;
        if(emotion != GetComponentInParent<CharacterResources>().emotion)
        {
            emotion = GetComponentInParent<CharacterResources>().emotion;
            changed = true;
        }
        if(character != GetComponentInParent<CharacterResources>().character)
        {
            character = GetComponentInParent<CharacterResources>().character;
            changed = true;
        }
        if(changed)
        {
            ChangeSprite(character.ToString(), emotion.ToString());
        }
    }

    void ChangeSprite(string c, string e){
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/"+ c + "/" + e);
    }
}
