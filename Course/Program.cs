using System;
using System.Collections.Generic;
using System.Globalization;
using Course.Entities;
using Course.Entities.Enums;
using Course.Entities.TaxPayers;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Selecionar Programa: ");
            Console.WriteLine();
            Console.WriteLine("1 - Worker Contracts");
            Console.WriteLine("2 - Post Comments");
            Console.WriteLine("3 - Order Items");
            Console.WriteLine("4 - Up/Down Casting");
            Console.WriteLine("5 - Override");
            Console.WriteLine("6 - OutsorcedEmployee");
            Console.WriteLine("7 - Polimorfismo");
            Console.WriteLine("8 - Abstração");
            Console.WriteLine();
            int program = int.Parse(Console.ReadLine());

            switch (program) {
                case 1:
                    ProgramaUm();
                    break;
                case 2:
                    ProgramaDois();
                    break;
                case 3:
                    ProgramaTres();
                    break;
                case 4:
                    ProgramaQuatro();
                    break;
                case 5:
                    ProgramaCinco();
                    break;
                case 6:
                    ProgramaSeis();
                    break;
                case 7:
                    ProgramaSete();
                    break;
                case 8:
                    ProgramaOito();
                    break;
                default:
                    Console.WriteLine("Programa padrão ProgramaUm");
                    ProgramaUm();
                    break;
            }

        }

        static void ProgramaUm()
        {
            string deptName, name, monthYear;
            WorkerLevel level;
            double baseSalary, valuePerHour;
            Department dept;
            Worker worker;
            int contracts, duration, month, year;
            DateTime contractDate;
            HourContract contract;

            Console.WriteLine("Programa Funcionário/Contratos");
            Console.WriteLine("----------\n");

            Console.WriteLine();
            Console.Write("Enter name of department: ");
            deptName = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("WORKER DATA\n------\n");

            Console.Write("Name: ");
            name = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior): ");
            level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base Salary: ");
            baseSalary = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //Department
            dept = new Department(deptName);

            //Worker
            worker = new Worker(name, level, baseSalary, dept);

            Console.WriteLine();
            Console.WriteLine("CONTRACTS DATA\n------\n");

            Console.WriteLine();
            Console.Write("How many contracts?");
            contracts = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 1; i <= contracts; i++)
            {
                Console.Write($"Enter #{i} contract date (DD/MM/YYYY): ");
                contractDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Value per hour: ");
                valuePerHour = double.Parse(Console.ReadLine());

                Console.Write("Duration (hours): ");
                duration = int.Parse(Console.ReadLine());
                Console.WriteLine();

                //Add Contract
                contract = new HourContract(contractDate, valuePerHour, duration);
                worker.AddContract(contract);

            }
            Console.WriteLine();
            Console.Write("Calculate Income - provide Month and Year (MM/YYYY): ");
            monthYear = Console.ReadLine();
            month = int.Parse(monthYear.Substring(0, 2));
            year = int.Parse(monthYear.Substring(3));

            Console.WriteLine();
            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine($"Income for {monthYear}: {worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)}");
        }

        static void ProgramaDois()
        {
            int numberOfPosts, numberOfComments;
            string title, content, text;
            char checkLikes;
            Comment comment;
            List<Post> posts = new List<Post>() { };

            //ENTRADA DE DADOS
            Console.WriteLine("PROGRAMA DOIS \n----------\n\n");
            Console.Write("Quantidade de Posts: ");
            numberOfPosts = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPosts; i++)
            {
                Console.WriteLine($"POST #{i+1}");

                Console.Write("Título: ");
                title = Console.ReadLine();

                Console.Write("Conteúdo: ");
                content = Console.ReadLine();

                Post post = new Post(title,DateTime.Now, content);

                Console.Write("Você gostou do post? ");
                checkLikes = Char.Parse(Console.ReadLine());
                if(checkLikes=='s' ||
                    checkLikes == 'S')
                    post.AddLike();

                for (int k = 0; k < 6; k++)
                {
                    post.AddLike();
                }

                Console.Write("Quantidade de Comentários: ");
                numberOfComments = int.Parse(Console.ReadLine());

                for (int j = 0; j < numberOfComments; j++)
                {
                    Console.WriteLine($"POST {i+1} COMENTÁRIO #{j + 1}");

                    Console.WriteLine("Comentário: ");
                    text = Console.ReadLine();

                    comment = new Comment(text)
                    {
                        Text = text
                    };
                    post.AddComment(comment);
                }

                posts.Add(post);
            }

            Console.WriteLine("Imprimindo Posts e Comentários: \n\n");

            foreach (Post p in posts)
            {
                Console.WriteLine(p);
            }
            
        }

        static void ProgramaTres()
        {
            string customerName, productName, status, email;
            DateTime birthDate;
            int items, quantity;
            double productPrice;
            Client customer;
            Order order = new Order();
            Product product;
            
            Console.WriteLine("PROGRAMA TRÊS - ORDER ITEMS");
            Console.WriteLine("----------------");
            Console.WriteLine();

            Console.WriteLine("CUSTOMER DATA");

            Console.Write("Customer Name: ");
            customerName = Console.ReadLine();

            Console.Write("Customer Email: ");
            email = Console.ReadLine();

            Console.Write("Customer BirthDate: ");
            birthDate = DateTime.Parse(Console.ReadLine());

            customer = new Client
            {
                Name = customerName, 
                BirthDate = birthDate, 
                Email = email
            };

            order.Client = customer;

            Console.WriteLine("ORDERING DATA");

            Console.Write("Status (PendingPayment/Processing/Shipped/Delivered): ");
            status = Console.ReadLine();

            Console.Write("How many items to this order? ");
            items = int.Parse(Console.ReadLine());

            for (int i = 0; i < items; i++)
            {
                Console.WriteLine($"#{i+1} ITEM INFO");

                Console.Write("Product Name: ");
                productName = Console.ReadLine();

                Console.Write("Product Price: ");
                productPrice = double.Parse(Console.ReadLine());

                Console.Write("Quantity: ");
                quantity = int.Parse(Console.ReadLine());

                product = new Product
                {
                    Name = productName,
                    Price = productPrice
                };

                OrderItem orderItem = new OrderItem(quantity, productPrice, product);

                order.AddItem(orderItem);

                Console.WriteLine("Success");
                Console.WriteLine();

            }

            Console.WriteLine(order);
            
        }

        static void ProgramaQuatro()
        {
            Account acc = new BusinessAccount(1001, "Alex", 0.0, 200.0);
            BusinessAccount bacc = new BusinessAccount(1002, "Bia", 0.0, 500.0);

            //UPCASTING 
            Account acc1 = bacc;
            Account acc2 = new BusinessAccount(1003, "Bob", 0.0, 200.0);
            Account acc3 = new SavingsAccount(1004, "Ana", 0.0, 0.01);

            //DOWNCASTING -- OPERAÇÃO INSEGURA -- TESTAR 
            BusinessAccount acc4 = (BusinessAccount) acc2;
            acc4.Loan(200.0);
            //BusinessAccount acc5 = (BusinessAccount) acc3;  //<< ISSO NÃO É POSSÍVEL O COMPILADOR ENTENDER
            //Usando operador " is " para testar 
            if (acc3 is BusinessAccount)
            {
                //BusinessAccount acc5 = (BusinessAccount)acc3;
                BusinessAccount acc5 = acc3 as BusinessAccount;
                acc5.Loan(200.0);
                Console.WriteLine("Loan!");
            }

            if (acc3 is SavingsAccount)
            {
                //SavingsAccount acc5 = (SavingsAccount)acc3;
                SavingsAccount acc5 = acc3 as SavingsAccount;
                acc5.UpdateBalance();
                Console.WriteLine("Update");
            }

        }

        static void ProgramaCinco()
        {
            Console.WriteLine();

            Account acc1 = new BusinessAccount(1001, "Alex", 500.0, 100);
            Account acc2 = new SavingsAccount(1002, "Ana", 500.0, 0.01);

            acc1.Withdraw(10);
            acc2.Withdraw(10);

            Console.WriteLine(acc1.Balance);
            Console.WriteLine(acc2.Balance);

        }

        static void ProgramaSeis()
        {
            List<Employee> employees = new List<Employee>();
            Console.WriteLine();
            Employee emp;

            Console.WriteLine("Número de Funcionários: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"#{i+1} Funcionário ");

                Console.Write("Nome: ");
                string name = Console.ReadLine();

                Console.Write("É terceirizado (s/n)? ");
                char isOutsourced = char.Parse(Console.ReadLine());

                Console.Write("Horas: ");
                int hours = int.Parse(Console.ReadLine());

                Console.Write("Valor/Hora: ");
                double valuePerHour = double.Parse(Console.ReadLine());

                if (isOutsourced == 's' || isOutsourced == 'S')
                {
                    Console.Write("Custo adicional: ");
                    double additional = double.Parse(Console.ReadLine());
                    emp = new OutsourcedEmployee(name, hours, valuePerHour, additional);
                }
                else
                {
                    emp = new Employee(name, hours, valuePerHour);
                }

                employees.Add(emp);

                Console.WriteLine();
            }

            Console.WriteLine("PAGAMENTOS:");
            Console.WriteLine();

            foreach(Employee e in employees)
            {
                Console.WriteLine($"{e.Name} - R$ {e.Payment().ToString("F2")}");
            }
            
        }

        static void ProgramaSete()
        {
            List<Product> products = new List<Product>();
            Product product;

            Console.WriteLine();

            Console.WriteLine("Number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Product #{i+1} data: ");
                Console.Write("Common, used or imported (c/u/i)? ");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());

                if (type == 'i' || type == 'I')
                {
                    Console.Write("Enter customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine());
                    product = new ImportedProduct(name, price, customsFee);
                }else if(type=='u' || type == 'U')
                {
                    Console.Write("Enter manufature date: ");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                    product = new UsedProduct(name, price, manufactureDate);
                }
                else
                {
                    product = new Product(name, price);
                }

                products.Add(product);
                Console.WriteLine("Success");
                Console.WriteLine();
            }

            Console.WriteLine("PRICE TAGS");
            foreach(Product p in products)
            {
                Console.WriteLine(p.PriceTag());
            }

        }

        static void ProgramaOito()
        {
            Console.WriteLine();

            List<TaxPayer> taxPayers = new List<TaxPayer>();
            TaxPayer taxPayer;

            int n = 1;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Contribuinte #{0}", i+1);

                Console.WriteLine($"Física ou Jurídica {i + 1} (f/j): ");
                char type = char.Parse(Console.ReadLine());

                Console.WriteLine($"Nome {i+1}: ");
                string name = Console.ReadLine();

                Console.WriteLine($"Receita anual {i + 1}: ");
                double anualIncome = double.Parse(Console.ReadLine());

                if(type == 'f' || type == 'F')
                {
                    Console.WriteLine($"Gastos anuais com saúde  {i + 1}: ");
                    double healthExpenditures = double.Parse(Console.ReadLine());

                    taxPayer = new Individual(name, anualIncome, healthExpenditures);
                }else
                {
                    Console.WriteLine($"Número de empregados  {i + 1}: ");
                    int numberOfEmployees= int.Parse(Console.ReadLine());

                    taxPayer = new Company(name, anualIncome, numberOfEmployees);
                }
                taxPayers.Add(taxPayer);
                Console.WriteLine("success");
                Console.WriteLine();

            }

            Console.WriteLine("TAXES PAID");
            double sum = 0; 
            foreach (TaxPayer tp in taxPayers)
            {
                Console.WriteLine($"{tp.Name}: R$ {tp.TaxPaid().ToString("F2")}");
                sum += tp.TaxPaid();
            }

            Console.WriteLine($"Total taxes: {sum}");
        }
    }
}
