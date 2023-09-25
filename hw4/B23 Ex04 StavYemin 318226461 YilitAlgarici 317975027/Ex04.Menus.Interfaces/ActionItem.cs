using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class ActionItem : MenuItem
    {
        private readonly List<ISelectionListener> r_SelectionListeners = new List<ISelectionListener>();

        public ActionItem(string i_MenuTitle, MenuItem i_PreviousMenu)
            : base(i_MenuTitle, i_PreviousMenu)
        {
        }

        public void AddListener(ISelectionListener i_Listener)
        {
            r_SelectionListeners.Add(i_Listener);
        }

        internal void InvokeUserSelection()
        {
            foreach (ISelectionListener listener in this.r_SelectionListeners)
            {
                listener.UserSelectedItem();
            }
        }

        public interface ISelectionListener
        {
            void UserSelectedItem();
        }
    }
}