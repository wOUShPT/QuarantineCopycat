using UnityEngine.Rendering;

public interface IInteractable
{
    float InteractionDistance();
    
    void Interact();

    void ExitInteract();
}
