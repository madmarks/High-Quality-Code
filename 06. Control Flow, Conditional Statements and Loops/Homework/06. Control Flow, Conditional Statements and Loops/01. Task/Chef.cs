namespace Kitchen
{
    using System;

    internal class Chef
    {
        public void Cook()
        {
            Bowl bowl = this.GetBowl();

            Potato potato = this.GetPotato();
            Vegetable peeledPotato = this.Peel(potato);
            Vegetable cutPotato = this.Cut(peeledPotato);
            bowl.Add(cutPotato);

            Carrot carrot = this.GetCarrot();
            Vegetable peeledCarrot = this.Peel(carrot);
            Vegetable cutCarrot = this.Cut(peeledCarrot);
            bowl.Add(cutCarrot);
        }

        private Bowl GetBowl()
        {
            Bowl bowl = new Bowl();

            return bowl;
        }

        private Potato GetPotato()
        {
            Potato potato = new Potato();

            return potato;
        }

        private Carrot GetCarrot()
        {
            Carrot carrot = new Carrot();

            return carrot;
        }

        private Vegetable Peel(Vegetable vegetable)
        {
            if (vegetable.IsPeeled)
            {
                return vegetable;
            }

            // ... 
            // peel vegetable
            // ...

            return vegetable;
        }

        private Vegetable Cut(Vegetable vegetable)
        {
            if (vegetable.IsCut)
            {
                return vegetable;
            }

            // ... 
            // cut vegetable
            // ... 

            return vegetable;
        }
    }
}