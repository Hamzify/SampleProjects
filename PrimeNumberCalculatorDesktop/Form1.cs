namespace PrimeNumberCalculatorDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number1 = int.Parse(textBox1.Text);
            Thread primeThread = new Thread(() => FindPrimesList1(number1));
            primeThread.Start();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void FindPrimesList1(int maxNumber)
        {
            List<int> primes = new List<int>();
            for (int i = 2; i <= maxNumber; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            // Update UI safely
            this.Invoke(new MethodInvoker(delegate
            {
                listBox1.Items.Clear();
                foreach (int prime in primes)
                {
                    listBox1.Items.Add(prime);
                }
            }));
        }
        private void FindPrimesList2(int maxNumber)
        {
            List<int> primes = new List<int>();
            for (int i = 2; i <= maxNumber; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            // Update UI safely
            this.Invoke(new MethodInvoker(delegate
            {
                listBox2.Items.Clear();
                foreach (int prime in primes)
                {
                    listBox2.Items.Add(prime);
                }
            }));
        }
        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int number2 = int.Parse(textBox2.Text);
            Thread primeThread = new Thread(() => FindPrimesList2(number2));
            primeThread.Start();
        }
    }
}
