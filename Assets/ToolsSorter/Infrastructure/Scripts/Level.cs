using Codice.Client.BaseCommands.Download;
using System;
using System.Collections;
using ToolsSorter.Service.CollideService;
using ToolsSorter.Service.HoldService;
using ToolsSorter.UI;
using ToolsSorter.UnityObjects;
using UnityEngine;
using Zenject;

namespace ToolsSorter.Infrastructure
{
    public class Level : IDisposable
    {
        [Inject] private readonly WinWindow _winWindow;
        [Inject] private readonly LoseWindow _loseWindow;
        [Inject] private readonly CollideController _collideController;
        [Inject] private readonly Holder _holder;

        public Level(WinWindow winWindow, LoseWindow loseWindow, CollideController collideController, Holder holder)
        {
            _winWindow = winWindow ?? throw new ArgumentNullException(nameof(winWindow));
            _loseWindow = loseWindow ?? throw new ArgumentNullException(nameof(loseWindow));
            _collideController = collideController ?? throw new ArgumentNullException(nameof(collideController));
            _holder = holder ?? throw new ArgumentNullException(nameof(holder));
            _collideController.Losed += End;
            _holder.Completed += Complite;
        }

        private void Complite() => 
            _winWindow.Activate(_collideController.SlowdownSeconds);

        private void End() => 
            _loseWindow.Activate(_collideController.SlowdownSeconds);

        public void Dispose()
        {
            _collideController.Losed -= End;
            _holder.Completed -= Complite;
        }
    }
}
