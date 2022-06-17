using Items;
using Character;

namespace Customization
{
    public interface IItemButtonAction
    {
        void Execute(Item item, CharacterModel characterModel);
    }
}