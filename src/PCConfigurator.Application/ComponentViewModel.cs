﻿namespace PCConfigurator.Application
{
    public class ComponentViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public ComponentTypeViewModel ComponentType { get; set; }

        public decimal Price { get; set; }
    }
}