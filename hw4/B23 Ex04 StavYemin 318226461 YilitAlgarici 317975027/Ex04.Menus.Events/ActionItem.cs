using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    public class ActionItem : Item
    {
        public event Action Selected;

        public ActionItem(int i_Choice, string i_Title) : base(i_Choice, i_Title)
        {
        }

        internal virtual void OnSelected()
        {
            Selected?.Invoke();
        }
    }

}
