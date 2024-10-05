namespace HeroFactoryASB
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero elf = new Hero(new ElfFactory());
            elf.Hit();
            elf.Run();

            Hero voin = new Hero(new WariorFactory());
            voin.Hit();
            voin.Run();

            Console.ReadLine();
        }
    }
    //абстрактный класс - оружие
   public interface Weapon
    {
        public void Hit();
    }
    // абстрактный класс движение
    public interface Movement
    {
        public void Move();
    }

    // класс арбалет
    class Arbalet : Weapon
    {
        public void Hit()
        {
            Console.WriteLine("Стреляем из арбалета");
        }
    }
    // класс меч
    class Sword : Weapon
    {
        public void Hit()
        {
            Console.WriteLine("Бьем мечом");
        }
    }
    // движение полета
    class FlyMovement : Movement
    {
        public void Move()
        {
            Console.WriteLine("Летим");
        }
    }
    // движение - бег
    class RunMovement : Movement
    {
        public void Move()
        {
            Console.WriteLine("Бежим");
        }
    }
    // класс абстрактной фабрики
    abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }
    // Фабрика создания летящего героя с арбалетом
    class ElfFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }
    }
    // Фабрика создания бегущего героя с мечом
    class WariorFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }
    // клиент - сам супергерой
    class Hero
    {
        private Weapon weapon;
        private Movement movement;
        public Hero(HeroFactory factory)
        {
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
        }
        public void Run()
        {
            movement.Move();
        }
        public void Hit()
        {
            weapon.Hit();
        }
    }
}
