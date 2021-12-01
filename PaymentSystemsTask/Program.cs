using System;

public class Program
{
    static void Main(string[] args)
    {
        //Выведите платёжные ссылки для трёх разных систем платежа: 
        //pay.system1.ru/order?amount=12000RUB&hash={MD5 хеш ID заказа}
        //order.system2.ru/pay?hash={MD5 хеш ID заказа + сумма заказа}
        //system3.com/pay?amount=12000&curency=RUB&hash={SHA-1 хеш сумма заказа + ID заказа + секретный ключ от системы}

        string link1 = "pay.system1.ru/order?amount=12000RUB&hash=";
        string link2 = "order.system2.ru/pay?hash=";
        string link3 = "system3.com/pay?amount=12000&curency=RUB&hash=";

        int secretKey = 249687096;

        var md5 = new MD5Calculator(order => order.Id.ToString());
        var sha1 = new SHA1Calculator(order => order.Amount.ToString());

        var newOrder = new Order(1, 9999);

        var paymentSystem1 = new CustomizablePaymentSystem(link1, md5);
        var paymentSystem2 = new CustomizablePaymentSystem(link2, md5, new StandardPaymentSystem(newOrder.Amount));
        var paymentSystem3 = new CustomizablePaymentSystem(link3, sha1, new StandardPaymentSystem(newOrder.Id), new SecurePaymentSystem(secretKey));

        Console.WriteLine(paymentSystem1.GetPaylink(newOrder));
        Console.WriteLine(paymentSystem2.GetPaylink(newOrder));
        Console.WriteLine(paymentSystem3.GetPaylink(newOrder));
    }
}
