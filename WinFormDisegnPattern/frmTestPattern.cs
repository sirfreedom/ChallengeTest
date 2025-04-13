using System;
using System.Windows.Forms;
using WinFormDisegnPattern.AbstractFactoryPattern;
using WinFormDisegnPattern.Builder;
using WinFormDisegnPattern.FactoryMethod;
using WinFormDisegnPattern.FactoryMethodPattern;
using WinFormDisegnPattern.Strategy;
using System.Data;
using WinFormDisegnPattern.Decorator;
using WinFormDisegnPattern.StatePattern;
using WinFormDisegnPattern.FlyWeight;
using System.Text;
using WinFormDisegnPattern.Singleton;
using WinFormDisegnPattern.LoadBalancer;
using WinFormDisegnPattern.InyeccionDeDepencias1;
using WinFormDisegnPattern.InyeccionDeDependencias2;
using WinFormDisegnPattern.Observer1;
using WinFormDisegnPattern.Polimorfismo1;
using WinFormDisegnPattern.Polimorfismo2;
using WinFormDisegnPattern.Thread1;
using System.Collections.Generic;
using WinFormDisegnPattern.Thread2;
using System.Threading.Tasks;
using System.Linq;
using WinFormDisegnPattern.OpenClose;
using WinFormDisegnPattern.OpenClose1;
using WinFormDisegnPattern.Liskov;
using WinFormDisegnPattern.SegregacionDeInterfaces;
using WinFormDisegnPattern.ChainOfResponsibility;
using WinFormDisegnPattern.Prototype;
using WinFormDisegnPattern.RepositoryPattern;
using WinFormDisegnPattern.Command;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WinFormDisegnPattern.Iterator1;
using WinFormDisegnPattern.ObjectPooling;

namespace WinFormDisegnPattern
{
    public partial class frmTestPattern : Form
    {

        #region Constructor / Load

        public frmTestPattern()
        {
            InitializeComponent();
        }

        private void frmTestPattern_Load(object sender, EventArgs e)
        {
        }

        #endregion

        #region Patrones

        private void StatePattern()
        {
            txtVisor.Text = string.Empty;
            IState state = new ClickNext();
            ContextState context = new ContextState(state);
            txtVisor.Text = context.Request();
        }

        private void StrategyPattern()
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            SelectStrategy oStrategy;
            oStrategy = new SelectStrategy(new StrategyXml());
            sb.AppendLine(oStrategy.Save(ds));
            oStrategy = new SelectStrategy(new StrategyMemory());
            sb.AppendLine(oStrategy.Save(ds));
            oStrategy = new SelectStrategy(new StrategyFile());
            sb.AppendLine(oStrategy.Save(ds));
            txtVisor.Text = sb.ToString();
        }

        private void FactoryPattern1()
        {
            txtVisor.Text = string.Empty;
            int a = 1;
            int b = 2;
            IOperation o = new OperationFactory("sum").CreateInstance();
            txtVisor.Text = o.Calculate(a, b).ToString();
        }

        private void FactoryPattern2()
        {
            txtVisor.Text = string.Empty;
            var v = new MedioDeTrasporteFactory("avion").Create();
            txtVisor.Text = v.Prender();
        }

        private void Builder()
        {
            txtVisor.Text = string.Empty;
            IHouse h = new House();
            HouseBuilder oHouseBuilder = new HouseBuilder();
            h = oHouseBuilder.BuildFull();
            txtVisor.Text = h.ToString();
        }

        private void AbstractFactory()
        {
            StringBuilder sb = new StringBuilder();
            txtVisor.Text = string.Empty;
            var vButton1 = new ModernFactory().CreateButton();
            var vButton2 = new OlderFactory().CreateTextBox();
            sb.AppendLine(vButton1.PruebaMethodButton());
            sb.AppendLine(vButton2.PruebaMethodTextBox());
            txtVisor.Text = sb.ToString();
        }

        private void Decorator()
        {
            txtVisor.Text = string.Empty;
            StringBuilder sb = new StringBuilder();
            Bebida b = new Cafe(); // Cafe solo
            sb.Append(b.Description);
            sb.Append(b.Price);
            sb.AppendLine();
            b = new Leche(new Chocolate(new Canela(new Cafe()))); // Cafe Decorado
            sb.Append(b.Description);
            sb.Append(b.Price);
            sb.AppendLine();
            b = new Leche(new Te());
            sb.Append(b.Description);
            sb.Append(b.Price);
            sb.AppendLine();
            txtVisor.Text = sb.ToString();
        }

        private void FlyWeight()
        {
            txtVisor.Text = string.Empty;
            StringBuilder sb = new StringBuilder();
            int extrinsicstate = 22;
            FlyweightFactory factory = new FlyweightFactory();
            // Work with different flyweight instances
            Flyweight fx = factory.GetFlyweight("1");
            sb.AppendLine(fx.Operation(--extrinsicstate));
            Flyweight fy = factory.GetFlyweight("2");
            sb.AppendLine(fy.Operation(--extrinsicstate));
            Flyweight fz = factory.GetFlyweight("3");
            sb.AppendLine(fz.Operation(--extrinsicstate));
            UnsharedConcreteFlyweight fu = new UnsharedConcreteFlyweight();
            sb.AppendLine(fu.Operation(--extrinsicstate));
            txtVisor.Text = sb.ToString();
        }

        private void Singleton()
        {
            txtVisor.Text = SingletonPattern.Instance.ReadTextFile();
        }

        private void LoadBalancer()
        {
            StringBuilder sb = new StringBuilder();
            var b1 = LoadBalancerPattern.GetLoadBalancer();
            var b2 = LoadBalancerPattern.GetLoadBalancer();
            var b3 = LoadBalancerPattern.GetLoadBalancer();
            var b4 = LoadBalancerPattern.GetLoadBalancer();

            // Confirm these are the same instance
            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                sb.AppendLine("Same instance");
            }

            // Next, load balance 15 requests for a server
            var balancer = LoadBalancerPattern.GetLoadBalancer();

            for (int i = 0; i < 15; i++)
            {
                sb.Append("Dispatch request to: ");
                sb.Append(balancer.NextServer.Name);
                sb.AppendLine();
            }

            txtVisor.Text = sb.ToString();

        }

        private void InyeccionDeDependencias1()
        {
            StringBuilder sb = new StringBuilder();
            Store store;

            store = new Store(new BankPaymentAdapter());
            sb.AppendLine(store.Purchase());

            store = new Store(new PayPalAdapter());
            sb.AppendLine(store.Purchase());

            store = new Store(new CreditCardAdapter());
            sb.AppendLine(store.Purchase());

            txtVisor.Text = sb.ToString();
        }

        private void InyeccionDeDependencias2()
        {
            StringBuilder sb = new StringBuilder();
            Shopping oShopping = new Shopping(); //Entidad de compra
            MyShopCart myShopCart;

            myShopCart = new MyShopCart(new SqlDatabase(), new CreditCard());
            sb.AppendLine(myShopCart.Buy(oShopping));

            myShopCart = new MyShopCart(new OracleDatabase(), new DebitCard());
            sb.AppendLine(myShopCart.Buy(oShopping));

            myShopCart = new MyShopCart(new XmlFile(), new DebitCard());
            sb.AppendLine(myShopCart.Buy(oShopping));

            txtVisor.Text = sb.ToString();
        }

        private void Observer1()
        {
            TextBoxWriter t = new TextBoxWriter(txtVisor);
            Console.SetOut(t);

            WeatherStation weatherStation = new WeatherStation();
            weatherStation.Attach(new NewsAgency("CNN"));
            weatherStation.Attach(new NewsAgency("InfoBae"));
            weatherStation.Attach(new NewsAgency("BBC"));

            weatherStation.Temperature = 30;
            weatherStation.Temperature = 32;
            weatherStation.Temperature = 35;
            weatherStation.Temperature = 37;
            weatherStation.Temperature = 40;
        }

        private void Polimorfismo1()
        {
            StringBuilder sb = new StringBuilder();
            IPersona oPersona;

            oPersona = new Profesor();
            sb.Append(oPersona.MostrarDatos());

            oPersona = new Alumno();
            sb.Append(oPersona.MostrarDatos());

            txtVisor.Text = sb.ToString();
        }

        private void Polimorfismo2()
        {
            StringBuilder sb = new StringBuilder();
            IRuidoAnimal oAnimal;

            oAnimal = new Perro();
            sb.AppendLine(oAnimal.NombreAnimal);
            sb.AppendLine(oAnimal.HacerRuido());

            oAnimal = new Pajaro();
            sb.AppendLine(oAnimal.NombreAnimal);
            sb.AppendLine(oAnimal.HacerRuido());

            oAnimal = new Vaca();
            sb.AppendLine(oAnimal.NombreAnimal);
            sb.AppendLine(oAnimal.HacerRuido());

            //Se puede apreciar como cambiando la instancia, sin cambiar el codigo podemos hacer cambios.
            txtVisor.Text = sb.ToString();
        }


        private void ThreadMachine1()
        {
            ThreadPool threadPool;
            List<double> lResult = new List<double>();
            threadPool = new ThreadPool(Environment.ProcessorCount, "testWorker");

            var wir1 = threadPool.EnqueueWorkItem(TestHelper.CalcAverage, new[] { 2, 3, 2, 5 });
            var wir2 = threadPool.EnqueueWorkItem(TestHelper.CalcAverage, new[] { 1, 1, 1, 1 });
            var wir3 = threadPool.EnqueueWorkItem(TestHelper.CalcAverage, new[] { 2, 3, 2, 5 });
            var wir4 = threadPool.EnqueueWorkItem(TestHelper.CalcAverage, new[] { 2, 3, 2, 5 });
            var wir5 = threadPool.EnqueueWorkItem(TestHelper.CalcAverage, new[] { 2, 3, 2, 5 });
            var wir6 = threadPool.EnqueueWorkItem(TestHelper.CalcAverage, new[] { 2, 3, 2, 5 });
            var wir7 = threadPool.EnqueueWorkItem(TestHelper.CalcAverage, new[] { 2, 3, 2, 5 });
            var wir8 = threadPool.EnqueueWorkItem(TestHelper.CalcAverage, new[] { 2, 3, 2, 5 });
            var wir9 = threadPool.EnqueueWorkItem(TestHelper.CalcAverage, new[] { 2, 3, 2, 5 });

            lResult.Add(wir1.Result);
            lResult.Add(wir2.Result);
            lResult.Add(wir3.Result);
            lResult.Add(wir4.Result);
            lResult.Add(wir5.Result);
            lResult.Add(wir6.Result);
            lResult.Add(wir7.Result);
            lResult.Add(wir8.Result);
            lResult.Add(wir9.Result);

            wir1.Dispose();
            wir2.Dispose();
            wir3.Dispose();
            wir4.Dispose();
            wir5.Dispose();
            wir6.Dispose();
            wir7.Dispose();
            wir8.Dispose();
            wir9.Dispose();
            threadPool.ShutDown();
        }


        private void ThreadMachine3()
        {
            ThreadPool threadPool;
            threadPool = new ThreadPool(Environment.ProcessorCount, "testWorker");

            var wirs = new List<IWorkItemState>();

            for (var i = 0; i < 50; i++)
            {
                var wir = threadPool.EnqueueWorkItem(TestHelper.WriteToConsole, "test");
                wirs.Add(wir);
            }

            foreach (var workItemState in wirs)
            {
                workItemState.Result();
                workItemState.Dispose();
            }

            threadPool.ShutDown();
        }

        private void ThreadMachine4()
        {
            ThreadPool threadPool;
            StringBuilder sb = new StringBuilder();
            threadPool = new ThreadPool(Environment.ProcessorCount, "testWorker");

            var wirs = new List<IWorkItemState>();
            var objects = new List<ThreadingThreadpoolTestObject>();

            for (var j = 0; j < 5000; j++)
            {
                wirs.Clear();
                objects.Clear();
                for (var i = 0; i < 100; i++)
                {
                    var o = new ThreadingThreadpoolTestObject();
                    objects.Add(o);
                    var wir = threadPool.EnqueueWorkItem(o.Call);
                    wirs.Add(wir);
                }

                foreach (var workItemState in wirs)
                {
                    workItemState.Result();
                    workItemState.Dispose();
                }

                foreach (var threadingThreadpoolTestObject in objects)
                {
                    sb.Append(threadingThreadpoolTestObject.NumberOfCalls);
                    //Assert.AreEqual(1, threadingThreadpoolTestObject.NumberOfCalls,
                    //    "One of the objects has been called " + threadingThreadpoolTestObject.NumberOfCalls +
                    //    " times. It was expected to be called once only and exactly once.");
                }
            }

            threadPool.ShutDown();
        }

        private void ThreadConceptWithOutThreading()
        {
            txtVisor.Text = string.Empty;
            TextBoxWriter t = new TextBoxWriter(txtVisor);
            Console.SetOut(t);
            BreakFastThread.getInstance.VoilWater();
            BreakFastThread.getInstance.HeatMilk();
            BreakFastThread.getInstance.PutCoffeIntoTheCup();
            BreakFastThread.getInstance.PutSugarIntoTheCup();
            BreakFastThread.getInstance.DrinkCoffeWithMilk();
        }

        private async Task ThreadConceptWithThreading()
        {
            txtVisor.Text = string.Empty;
            TextBoxWriter t = new TextBoxWriter(txtVisor);
            Console.SetOut(t);

            var HotWater = BreakFastThread.getInstance.VoilWater_Async();
            var HotMilk = await BreakFastThread.getInstance.HeatMilk_Async();
            var Coffe = BreakFastThread.getInstance.PutCoffeIntoTheCup();
            var Azucar = BreakFastThread.getInstance.PutSugarIntoTheCup();
            var BreakFast = await BreakFastThread.getInstance.DrinkCoffeWithMilk_Async();
        }


        private async void SincronizacionDeThreading()
        {
            txtVisor.Text = string.Empty;
            TextBoxWriter t = new TextBoxWriter(txtVisor);
            Console.SetOut(t);
            List<string> lNombre = new List<string>() { "Mazana", "Banana", "Pera", "Melon" };
            var vTest = lNombre.Select(x => BreakFastThread.getInstance.AsyncronicMetodo(x));
            await Task.WhenAll(vTest);
        }

        private void OpenClose1()
        {
            txtVisor.Text = string.Empty;
            //Aqui podemos extender la funcionalidad de vehiculo agregando vehiculos sin modificar el vehiculo naturalmente.
            IVehiculo vehiculo;
            vehiculo = new Moto();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(vehiculo.Draw());
            vehiculo = new Car();
            sb.AppendLine(vehiculo.Draw());
            txtVisor.Text = sb.ToString();
        }

        private void OpenClose3()
        {
            txtVisor.Text = string.Empty;
            //La idea es sobreescribir clases y extenderlas como la clase base, sin modificarlas.
            StringBuilder sb = new StringBuilder();
            Descuento oDescuento;
            double d = 0;

            oDescuento = new DescuentoCliente();
            d = oDescuento.GetDiscount(1000);
            sb.AppendLine(d.ToString());

            oDescuento = new DescuentoExtrangero();
            d = oDescuento.GetDiscount(1000);
            sb.AppendLine(d.ToString());

            oDescuento = new DescuentoNoCliente();
            d = oDescuento.GetDiscount(1000);
            sb.AppendLine(d.ToString());

            txtVisor.Text = sb.ToString();
        }


        private void Liskov()
        {
            txtVisor.Text = string.Empty;
            //Una clase hija tiene que ser sustituible por una clase hija.
            StringBuilder sb = new StringBuilder();
            Pinguino p = new Pinguino();
            Aguila a = new Aguila();

            sb.Append(p.Comer());
            sb.Append(a.Comer());
            sb.Append(a.Volar());

            txtVisor.Text = sb.ToString();
        }

        private void SegregacionDeInterfaces()
        {
            txtVisor.Text = string.Empty;
            // Simplemente es NO IMPLEMENTAR LO QUE NO TENEMOS QUE USAR. 
            StringBuilder sb = new StringBuilder();
            Leon oLeon = new Leon();
            Salmon oSalmon = new Salmon();
            Conejo oConejo = new Conejo();

            sb.AppendLine(oLeon.Atacar());
            sb.AppendLine(oLeon.Cazar());
            sb.AppendLine(oLeon.Correr());
            sb.AppendLine(oLeon.Roer());

            sb.AppendLine(oSalmon.Nadar());

            sb.AppendLine(oConejo.Correr());
            sb.AppendLine(oConejo.Trepar());

            txtVisor.Text = sb.ToString();
        }

        private void ChainOfResponsibility()
        {
            txtVisor.Text = string.Empty;
            TextBoxWriter t = new TextBoxWriter(txtVisor);
            Console.SetOut(t);
            Handler handler1 = new ConcreteHandler1();
            Handler handler2 = new ConcreteHandler2();
            Handler handler3 = new ConcreteHandler3();
            handler1.SetSuccessor(handler2);
            handler2.SetSuccessor(handler3);

            // Cliente realiza una solicitud
            Client client = new Client();
            client.MakeRequest(5, handler1);
            client.MakeRequest(15, handler1);
            client.MakeRequest(25, handler1);
        }

        private void Prototype()
        {
            txtVisor.Text = string.Empty;
            StringBuilder sb = new StringBuilder();

            // Create an instance of the Warrior prototype
            var loki = new Warrior("Loki", 100, 20);

            // Clone the Loki warrior to create
            // a new warrior named Thor
            var thor = loki.Clone();
            thor.Name = "Thor";
            thor.Health = 120;

            // Now we have two different warrior objects with
            // similar properties but with some differences
            sb.AppendLine(loki.ToString());
            sb.AppendLine(thor.ToString());

            txtVisor.Text = sb.ToString();
        }

        private void Repository()
        {
            Cliente oCliente = new Cliente();
            IRepository<Cliente> oRepository;

            oRepository = new ClienteRepository(new ContextJson<Cliente>());

            oCliente.Nombre = "Cliente test";
            oCliente.Telefono = DateTime.Now.Ticks.ToString();

            oRepository.Insert(oCliente.ToDictionary());
            List<Cliente> lCliente = oRepository.List();
        }

        private void Command1()
        {
            txtVisor.Text = string.Empty;
            TextBoxWriter t = new TextBoxWriter(txtVisor);
            Console.SetOut(t);




            // Crear el invocador y agregar comandos
            Invoker oInvocador = new Invoker();
            Calculadora oCalculadora = new Calculadora();

            oInvocador.AddCommand(new SumarCommand(oCalculadora, 22));
            oInvocador.AddCommand(new RestarCommand(oCalculadora, 10));

            // Ejecutar los comandos
            oInvocador.EjecutarComandos();

            Console.ReadLine();
        }


        private void Command2()
        {
            txtVisor.Text = string.Empty;
            TextBoxWriter t = new TextBoxWriter(txtVisor);
            Console.SetOut(t);

            EditorTexto oEditorText = new EditorTexto();

            // Crear el invocador y agregar comandos
            var invocador = new Invoker();
            invocador.AddCommand(new AgregarTextoCommand(oEditorText, "Alejandro se va a la plaza"));
            invocador.AddCommand(new EliminarTextoCommand(oEditorText, 4));

            // Ejecutar los comandos
            invocador.EjecutarComandos();

            Console.ReadLine();
        }

        private void Iterator1() 
        {
            txtVisor.Text = string.Empty;
            TextBoxWriter t = new TextBoxWriter(txtVisor);
            Console.SetOut(t);

            WordsCollection collection = new WordsCollection();
            collection.AddItem("First");
            collection.AddItem("Second");
            collection.AddItem("Third");

            Console.WriteLine("Straight traversal:");

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("\nReverse traversal:");

            collection.ReverseDirection();

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }
        }

        public void ObjectPooling() 
        {
            GenericPool<StringBuilder> genericPool = new GenericPool<StringBuilder>(10);
            StringBuilder sb = genericPool.GetNext();
        
        }


        #endregion

        private void btnFactoryPattern_Click(object sender, EventArgs e)
        {
            FactoryPattern1();
            FactoryPattern2();
        }

        private void btnBuilder_Click(object sender, EventArgs e)
        {
            Builder();
        }

        private void btnAbstractFactory_Click(object sender, EventArgs e)
        {
            AbstractFactory();
        }

        private void btnDecorator_Click(object sender, EventArgs e)
        {
            Decorator();
        }

        private void btnStrategy_Click(object sender, EventArgs e)
        {
            StrategyPattern();
        }

        private void btnFlyWeight_Click(object sender, EventArgs e)
        {
            FlyWeight();
        }

        private void btnStatePatterm_Click(object sender, EventArgs e)
        {
            StatePattern();
        }

        private void btnSingleton_Click(object sender, EventArgs e)
        {
            Singleton();
        }

        private void btnLoadBalancer_Click(object sender, EventArgs e)
        {
            LoadBalancer();
        }

        private void btnInversionDeDependencias1_Click(object sender, EventArgs e)
        {
            InyeccionDeDependencias1();
        }

        private void btnInversionDeDepencias2_Click(object sender, EventArgs e)
        {
            InyeccionDeDependencias2();
        }

        private void btnObserver1_Click(object sender, EventArgs e)
        {
            Observer1();
        }

        private void btnThread1_Click(object sender, EventArgs e)
        {
            ThreadMachine1();
            ThreadMachine3();
            ThreadMachine4();
        }

        private void btnThreadConcept_Click(object sender, EventArgs e)
        {
            ThreadConceptWithOutThreading();
        }

        private async void btnThreadingConceptConThreading_Click(object sender, EventArgs e)
        {
            await ThreadConceptWithThreading();
        }

        private void btnSincronizacionThread_Click(object sender, EventArgs e)
        {
            SincronizacionDeThreading();
        }

        private void btnOpenClose_Click(object sender, EventArgs e)
        {
            OpenClose1();
        }

        private void btnOpenClose3_Click(object sender, EventArgs e)
        {
            OpenClose3();
        }

        private void btnLiskov_Click(object sender, EventArgs e)
        {
            Liskov();
        }

        private void btnSegregacionDeInterfaces_Click(object sender, EventArgs e)
        {
            SegregacionDeInterfaces();
        }

        private void btnChainOfResponsibility_Click(object sender, EventArgs e)
        {
            ChainOfResponsibility();
        }

        private void btnPrototype_Click(object sender, EventArgs e)
        {
            Prototype();
        }

        private void btnPolimorfismo1_Click(object sender, EventArgs e)
        {
            Polimorfismo1();
        }

        private void btnPolimorfismo2_Click(object sender, EventArgs e)
        {
            Polimorfismo2();
        }

        private void btnRepository_Click(object sender, EventArgs e)
        {
            Repository();
        }

        private void btnCommand1_Click(object sender, EventArgs e)
        {
            Command1();
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            Command2();
        }

        private void btnIterator1_Click(object sender, EventArgs e)
        {
            Iterator1();
        }
    }
}
