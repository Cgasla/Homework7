
using System;
using System.Text;

namespace DecoratorTree
{
    abstract class Tree
    {
        public abstract string GetDescription();
        public abstract void Light();
    }

    class ChristmasTree : Tree
    {
        public override string GetDescription()
        {
            return "Ялинка";
        }

        public override void Light()
        {
            Console.WriteLine("Ялинка не світиться (гірлянди немає)");
        }
    }

    abstract class TreeDecorator : Tree
    {
        protected Tree tree;

        public TreeDecorator(Tree tree)
        {
            this.tree = tree;
        }

        public override string GetDescription()
        {
            return tree.GetDescription();
        }

        public override void Light()
        {
            tree.Light();
        }
    }

    class OrnamentsDecorator : TreeDecorator
    {
        private string color;
        private int count;

        public OrnamentsDecorator(Tree tree, string color, int count)
            : base(tree)
        {
            this.color = color;
            this.count = count;
        }

        public override string GetDescription()
        {
            return tree.GetDescription() +
                " + іграшки (" + count + " шт., " + color + ")";
        }
    }

    class GarlandDecorator : TreeDecorator
    {
        private string color;
        private int lamps;

        public GarlandDecorator(Tree tree, string color, int lamps)
            : base(tree)
        {
            this.color = color;
            this.lamps = lamps;
        }

        public override string GetDescription()
        {
            return tree.GetDescription() +
                " + гірлянда (" + lamps + " лампочок, " + color + ")";
        }

        public override void Light()
        {
            Console.WriteLine("Гірлянда світиться: " +
                lamps + " лампочок, колір - " + color);
        }
    }

    // Декоратор сніжинок
    class SnowflakesDecorator : TreeDecorator
    {
        private int count;

        public SnowflakesDecorator(Tree tree, int count)
            : base(tree)
        {
            this.count = count;
        }

        public override string GetDescription()
        {
            return tree.GetDescription() +
                " + сніжинки (" + count + " шт.)";
        }
    }

    // Декоратор кульок
    class BallsDecorator : TreeDecorator
    {
        private int count;
        private string color;

        public BallsDecorator(Tree tree, int count, string color)
            : base(tree)
        {
            this.count = count;
            this.color = color;
        }

        public override string GetDescription()
        {
            return tree.GetDescription() +
                " + кульки (" + count + " шт., " + color + ")";
        }
    }

    class Program
    {
        static Random random = new Random();

        static void Show(Tree tree)
        {
            Console.WriteLine("Опис: " + tree.GetDescription());
            tree.Light();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Tree tree = new ChristmasTree();

            // Випадковий вибір декоратора
            int choice = random.Next(2);

            if (choice == 0)
            {
                tree = new SnowflakesDecorator(
                    tree, random.Next(5, 21));
            }
            else
            {
                string[] colors = { "червоні", "золоті", "срібні" };

                tree = new BallsDecorator(
                    tree,
                    random.Next(5, 21),
                    colors[random.Next(colors.Length)]);
            }

            // Випадкова гірлянда
            if (random.Next(2) == 1)
            {
                string[] garlandColors = {
                    "біла", "різнокольорова", "синя"
                };

                tree = new GarlandDecorator(
                    tree,
                    garlandColors[random.Next(garlandColors.Length)],
                    random.Next(20, 101));
            }

            Show(tree);

            Console.ReadKey();
        }
    }
}
