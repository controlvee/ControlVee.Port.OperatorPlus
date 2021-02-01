using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTransactionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SalesTransaction t1 = new SalesTransaction("Adam");
            SalesTransaction t2 = new SalesTransaction("Susan", 400d, .15d);
            SalesTransaction t3 = new SalesTransaction("Luara", 100d, .2d);

            Console.WriteLine($"{t1.Name} made:" + t1);
            Console.WriteLine($"{t1.Name} and {t2.Name} made:" + t1 + t2);
            Console.Read();
        }
    }

    public class SalesTransaction
    {
        private string name;
        private double salesAmount;
        private double commission;
        private readonly double commissionRate;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public double SalesAmount
        {
            get
            {
                return salesAmount;
            }
            set
            {
                salesAmount = value;
            }
        }
        public double Commission
        {
            get => commission; set => commission = value;

        }

        public SalesTransaction()
        {

        }

        public SalesTransaction(string name)
        {
            this.name = name;
            this.salesAmount = .0d;
            this.commission = .0d;
        }

        public SalesTransaction(string name, double salesAmount)
        {
            this.name = name;
            this.salesAmount = salesAmount;
            this.commissionRate = .0d;

            commission = salesAmount * commissionRate;
        }

        public SalesTransaction(string name, double salesAmount, double commissionRate)
        {
            this.name = name;
            this.salesAmount = salesAmount;
            this.commissionRate = commissionRate;

            Commission = salesAmount * commissionRate;
        }

        public override string ToString()
        {
            return $"{commission}USD.\r\n";
        }

        public static SalesTransaction operator+(SalesTransaction t1, SalesTransaction t2)
        {
            SalesTransaction newT = new SalesTransaction();
            newT.Commission = t1.Commission + t2.Commission;

            return newT;
        }
           
            
    }
}
