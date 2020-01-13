using System.Windows;

namespace Metal_Lynch__v2._0_
{
    public abstract class GUIObject
    {
        protected Game game;

        protected UIElement GUIMainElement;

        protected void AddToCanvas()
        {
            game.GetGame_GUICanvas().Children.Add(GUIMainElement);
            //Adds the object's main element to the Canvas of the Game that
            //it belongs to.
        }
    }
}
