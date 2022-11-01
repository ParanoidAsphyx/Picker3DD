using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICommand : MonoBehaviour
{
   public interface ICommand
    {
        public void Execute();

        public void Execute(int value);
    }
}
