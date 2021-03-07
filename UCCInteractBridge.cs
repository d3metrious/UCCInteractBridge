using UnityEngine;
using Opsive.UltimateInventorySystem.Interactions;
using Opsive.UltimateCharacterController.Traits;

public class UCCInteractBridge : MonoBehaviour, IInteractableTarget, IInteractableMessage
{
    [SerializeField] protected InventoryInteractor CharacterInventoryInteractor;
    [SerializeField] protected InteractableBehavior m_InteractableBehavior;
    [SerializeField] protected Opsive.UltimateInventorySystem.Interactions.Interactable UISInteractable;
    [SerializeField] protected string DisplayMessage;
    protected bool m_HasInteracted;

    private Animator m_Animator;


    public bool CanInteract(GameObject character)
    {
        return true;
    }

    public void Interact(GameObject character)
    {
        if (CharacterInventoryInteractor == null)
        {
            CharacterInventoryInteractor = character.GetComponent<InventoryInteractor>();
        }
        UISInteractable.Interact(CharacterInventoryInteractor);
        m_HasInteracted = true;

    }
    public void ResetInteract()
    {
        m_HasInteracted = false;
        UISInteractable.Deselect(CharacterInventoryInteractor);
        m_Animator.Rebind();
    }
    public string AbilityMessage()
    {
        return DisplayMessage;
    }
}
