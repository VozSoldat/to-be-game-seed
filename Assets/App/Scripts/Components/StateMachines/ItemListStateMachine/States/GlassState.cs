using StateMachines;
using UnityEngine;
using System.Collections.Generic;

namespace StateMachines.ItemListStateMachine
{
    public class GlassState : ItemListState
    {
        private GlassListUI glassListUI;
        private List<GlassData> defaultGlasses;

        public GlassState() : base(ItemCategory.Glass)
        {
            InitializeDefaultGlasses();
        }

        // These methods should be removed or made private as they conflict with the base class implementation
        private void OnEnter()
        {
            EnterState();
        }

        private void OnExit()
        {
            ExitState();
        }

        // Override the base methods instead
        public override void Enter(MB_ItemListStateContext context)
        {
            base.Enter(context);
            EnterState();
        }

        public override void Exit(MB_ItemListStateContext context)
        {
            base.Exit(context);
            ExitState();
        }

        private void InitializeDefaultGlasses()
        {
            defaultGlasses = new List<GlassData>();

            // Try to get glasses from GlassListUI first
            if (glassListUI == null)
            {
                glassListUI = Object.FindObjectOfType<GlassListUI>();
            }

            if (glassListUI != null && glassListUI.availableGlasses != null && glassListUI.availableGlasses.Count > 0)
            {
                Debug.Log($"Loading {glassListUI.availableGlasses.Count} glasses from GlassListUI");
                defaultGlasses.AddRange(glassListUI.availableGlasses);
            }
            else
            {
                // Fallback to Resources if GlassListUI doesn't have any
                GlassData[] allGlasses = Resources.LoadAll<GlassData>("Glasses");
                Debug.Log($"Found {allGlasses.Length} glasses in Resources/Glasses folder");

                foreach (var glass in allGlasses)
                {
                    if (glass.category == ItemCategory.Glass)
                    {
                        defaultGlasses.Add(glass);
                    }
                }
            }

            Debug.Log($"Total glasses loaded: {defaultGlasses.Count}");
        }

        private void EnterState()
        {
            if (glassListUI == null)
            {
                glassListUI = Object.FindObjectOfType<GlassListUI>();
            }

            if (glassListUI != null)
            {
                // If we don't have default glasses yet, try to initialize from UI
                if (defaultGlasses == null || defaultGlasses.Count == 0)
                {
                    InitializeDefaultGlasses();
                }

                // Only set glasses if we have some to set
                if (defaultGlasses != null && defaultGlasses.Count > 0)
                {
                    Debug.Log($"Setting {defaultGlasses.Count} glasses to UI");
                    glassListUI.SetAvailableGlasses(defaultGlasses);
                }

                glassListUI.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogError("GlassListUI not found!");
            }
        }

        private void ExitState()
        {
           Debug.Log("Exiting Glass State");
        }
    }
}