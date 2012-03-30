using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnOOInterface.SimpleObject;
using LearnOOInterface.SimpleFactory;
using LearnOOInterface.Factory;
using LearnOOInterface.AbstractFactory;
using LearnOOInterface.AbstractFactoryEx;
using LearnOOInterface.Observer;
using LearnOOInterface.ObserverEx;

namespace LearnOOInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            UseSimpleObjectVivienne();
            UseSimpleFactoryVivienne();
            UseFactoryVivienne();
            UseÁbastractFatcory();
            UseÁbastractFatcoryEx();

            SimpleObserverPattern();
            AdvancedObserverPatternWithRoute();
        }

        private static void AdvancedObserverPatternWithRoute()
        {
            PushsubWithDispatcher<NotificationManager> newSimulatoer = 
                            new PushsubWithDispatcher<NotificationManager>();

            newSimulatoer.SimulateObserverRegisterSubject();
        }

        private static void SimpleObserverPattern()
        {
            PushsubContext newSimulatoer = new PushsubContext();
            newSimulatoer.SimulateObserverRegisterSubject();
        }

        private static void UseÁbastractFatcoryEx()
        {
            AbstractFactoryExClient<VivienneBrandEx> currentClient = new AbstractFactoryExClient<VivienneBrandEx>();
            currentClient.CreateProductLine();
            currentClient.DiplayAllItems();
            Console.WriteLine();

            AbstractFactoryExClient<GucciBrandEx> newGucciClient = new AbstractFactoryExClient<GucciBrandEx>();
            newGucciClient.CreateProductLine();
            newGucciClient.DiplayAllItems();
            Console.WriteLine();
        }

        private static void UseÁbastractFatcory()
        {
            AbstractFactoryClient<VivienneBrand> currentClient = new AbstractFactoryClient<VivienneBrand>();
            currentClient.CreateProductLine();
            currentClient.DiplayAllItems();
            Console.WriteLine();

            AbstractFactoryClient<GucciBrand> newGucciClient = new AbstractFactoryClient<GucciBrand>();
            newGucciClient.CreateProductLine();
            newGucciClient.DiplayAllItems();
            Console.WriteLine();
        }

        private static void UseFactoryVivienne()
        {
            FactoryVivienneClient newFactoryVivienne = new FactoryVivienneClient();
            newFactoryVivienne.CreateProductLine();
            newFactoryVivienne.DiplayAllItems();
            Console.WriteLine();
        }

        private static void UseSimpleFactoryVivienne()
        {
            SimpleFactoryVivienneClient newSimpleFactoryVivienne = new SimpleFactoryVivienneClient();
            newSimpleFactoryVivienne.CreateProductLine();
            newSimpleFactoryVivienne.DiplayAllItems();
            Console.WriteLine();

        }

        private static void UseSimpleObjectVivienne()
        {
            SimpleObjectVivienneClient newSimpleObjectVivienne = new SimpleObjectVivienneClient();
            newSimpleObjectVivienne.CreateProductLine();
            newSimpleObjectVivienne.DiplayAllItems();
            Console.WriteLine();
        }
    }
}
