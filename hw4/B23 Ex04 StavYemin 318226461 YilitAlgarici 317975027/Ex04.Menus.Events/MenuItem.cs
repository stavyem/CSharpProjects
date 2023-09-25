namespace Ex04.Menus.Events
{
    public class MenuItem : Item
    {
        private readonly SubMenu r_SubMenu;

        public SubMenu SubMenu
        {
            get
            {
                return r_SubMenu;
            }
        }

        public MenuItem(int i_Choice, string i_Title) : base(i_Choice, i_Title)
        {
            r_SubMenu = new SubMenu(i_Title);
        }

        internal void ShowMenu()
        {
            r_SubMenu.Show();
        }
    }
}
