﻿namespace uSurvival
{
    public interface Interactable
    {
        string InteractionText();
        void OnInteractClient(Player player);
        void OnInteractServer(Player player);
    }
}