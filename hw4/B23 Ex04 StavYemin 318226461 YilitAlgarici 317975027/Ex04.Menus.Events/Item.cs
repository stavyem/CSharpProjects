namespace Ex04.Menus.Events
{
    public abstract class Item
    {
        private readonly int r_Choice;
        private readonly string r_Title;

        protected Item(int i_Choice, string i_Title)
        {
            r_Choice = i_Choice;
            r_Title = i_Title;
        }

        public override string ToString()
        {
            return $"{r_Choice}. {r_Title}";
        }
    }
}
