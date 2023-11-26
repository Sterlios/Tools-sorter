using Zenject;

namespace Views.Game.InteractableObjects.Items.Scripts
{
    internal class ItemController
    {
        [Inject]
        private readonly Spawner _spawner;

        private Item _currentItem;

        public ItemController(Spawner spawner) => 
            _spawner = spawner ?? throw new System.ArgumentNullException(nameof(spawner));

        private void Spawn() => 
            _currentItem = _spawner.Create();

    }
}
