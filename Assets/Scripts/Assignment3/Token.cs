using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    public enum TokenType { noPlayer, playerOne, playerTwo}
    public TokenType tokenValue = TokenType.noPlayer;

    public Material whiteMaterial;
    public Material redMaterial;
    public Material blueMaterial;

    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (tokenValue)
        {
            case TokenType.noPlayer:
                renderer.material = whiteMaterial;
                break;
            case TokenType.playerOne:
                renderer.material = redMaterial;
                break;
            case TokenType.playerTwo:
                renderer.material = blueMaterial;
                break;
        }
    }
}
