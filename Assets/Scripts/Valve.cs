using System;
using UnityEngine;

public class Valve : MonoBehaviour
{
   private bool _isOpen;
   public event Action OnOpen;
   public event Action OnClose;

   public void Open()
   {
      if (_isOpen) return;
      _isOpen = true;
      OnOpen?.Invoke();
   }

   public void Close()
   {
      if (!_isOpen) return;
      _isOpen = false;
      OnClose?.Invoke();
   }
}
