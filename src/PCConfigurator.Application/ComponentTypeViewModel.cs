namespace PCConfigurator.Application
{
    public class ComponentTypeViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is ComponentTypeViewModel)) return false;
            return (obj as ComponentTypeViewModel).GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return (int)Id;
        }
    }
}
