﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace WUG.BehaviorTreeDebugger
{
    public enum NavigationActivity
    {
        Waypoint, 
        PickupItem
    }

    public class NonPlayerCharacter : MonoBehaviour, IBehaviorTree
    {
        public NavMeshAgent MyNavMesh { get; private set; }
        public NodeBase BehaviorTree { get; set; }
        public NavigationActivity MyActivity { get; set; }

        private Coroutine m_BehaviorTreeRoutine;
        private YieldInstruction m_WaitTime = new WaitForSeconds(.1f);


        private void Start()
        {
            MyNavMesh = GetComponent<NavMeshAgent>();
            MyActivity = NavigationActivity.Waypoint;
            GenerateBehaviorTree();
            
            if (m_BehaviorTreeRoutine == null && BehaviorTree != null)
            {
                m_BehaviorTreeRoutine = StartCoroutine(RunBehaviorTree());
            }
        }

        private void OnDestroy()
        {
            if (m_BehaviorTreeRoutine != null)
            {
                StopCoroutine(m_BehaviorTreeRoutine);
            }
        }

        private IEnumerator RunBehaviorTree()
        {
            while (enabled)
            {
                if (BehaviorTree == null)
                {
                    $"{this.GetType().Name} is missing Behavior Tree. Did you set the BehaviorTree property?".BTDebugLog();
                    continue;
                }

                (BehaviorTree as Node).Run();

                yield return m_WaitTime;
            }
        }

        private void GenerateBehaviorTree()
        {
            BehaviorTree = new Selector("Control NPC",
                                new Sequence("Pickup Item",
                                    new IsNavigationActivityTypeOf(NavigationActivity.PickupItem),
                                    new Selector("Look for or move to items",
                                        new Sequence("Look for items",
                                            new Inverter("Inverter",
                                                new AreItemsNearBy(5f)),
                                            new SetNavigationActivityTo(NavigationActivity.Waypoint)),
                                        new Sequence("Navigate to Item",
                                            new NavigateToDestination()))),
                                new Sequence("Move to Waypoint",
                                    new IsNavigationActivityTypeOf(NavigationActivity.Waypoint),
                                    new NavigateToDestination(),
                                    new Timer(2f,
                                        new Idle()),
                                    new SetNavigationActivityTo(NavigationActivity.PickupItem)));
        }
    }
}