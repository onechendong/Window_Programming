using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_2hw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string action;
            int item1_quantity = 0, item2_quantity = 0, item3_quantity = 0;
            string currency_type = "TWD";
            double item1_price = 199, item2_price = 460, item3_price = 1100, item1_money = 0, item2_money = 0, item3_money = 0;
            for (bool use = true; use == true;)
            {
                Console.WriteLine("(1)商品列表 (2)新增至購物車 (3)自購物車刪除 (4)查看購物車 (5)結帳 (6)轉換幣值 (7)退出網頁");
                Console.Write("輸入數字選擇功能:");
                action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        Console.WriteLine("列表:\n商品名稱 商品單價\n1.潛水相機房丟繩("+ currency_type+")"+ item1_price+"\n2.潛水配重帶("+ currency_type+")"+item2_price+"\n3.潛水作業指北針("+ currency_type+")"+item3_price+"\n");
                        break;

                    case "2":
                        Console.Write("(1)潛水相機房丟繩 (2)潛水配重帶 (3)潛水作業指北針\n輸入數字選擇商品:");
                        string item_add = Console.ReadLine();
                        Console.Write("輸入數量: ");
                        string add = Console.ReadLine();
                        int add_value = int.Parse(add);
                        switch (item_add)
                        {
                            case "1":
                                item1_quantity += add_value;
                                break;
                            case "2":
                                item2_quantity += add_value;
                                break;
                            case "3":
                                item3_quantity += add_value;
                                break;
                        }
                        Console.Write("\n");
                        break;

                    case "3":
                        Console.Write("購物車內容:\n商品 數量 單價 小計\n");
                        Console.WriteLine("1.潛水相機房丟繩("+ currency_type+")"+ item1_price+" " + item1_quantity + " " + item1_money + "\n2.潛水配重帶("+ currency_type+")"+item2_price+" " + item2_quantity + " " + item2_money + "\n3.潛水作業指北針("+ currency_type+")"+item3_price+" " + item3_quantity + " " + item3_money);
                        Console.Write("輸入數字選擇商品:");
                        string item_delete = Console.ReadLine();
                        if (item_delete == "1" || item_delete == "2" || item_delete == "3")
                        {
                            Console.Write("輸入數量: ");
                            string delete = Console.ReadLine();
                            int delete_value = int.Parse(delete);
                            switch (item_delete)
                            {
                                case "1":
                                    item1_quantity -= delete_value;
                                    break;
                                case "2":
                                    item2_quantity -= delete_value;
                                    break;
                                case "3":
                                    item3_quantity -= delete_value;
                                    break;
                            }
                            Console.WriteLine("成功刪除商品!\n");
                        }
                        else
                        {
                            Console.WriteLine("輸入錯誤!請重新輸入!\n");
                        }
                        break;

                    case "4":
                        Console.Write("購物車內容:\n商品 數量 單價 小計\n");
                        Console.WriteLine("1.潛水相機房丟繩("+ currency_type+")"+item1_price+" " + item1_quantity + " " + (item1_price*item1_quantity) + "\n2.潛水配重帶("+ currency_type+")"+item2_price+" " + item2_quantity + " " + (item2_price*item2_quantity) + "\n3.潛水作業指北針("+ currency_type+")"+item3_price+" " + item3_quantity + " " + (item3_price*item3_quantity) + "\n");
                        break;

                    case "5":
                        Console.WriteLine("訂單商品:\n商品 單價 數量 小計");
                        if (item1_quantity != 0)
                        {
                            Console.WriteLine("潛水相機房丟繩("+ currency_type+ ")" + item1_price + " " + item1_quantity + " " + (item1_price * item1_quantity));
                        }
                        if (item2_quantity != 0)
                        {
                            Console.WriteLine("潛水配重帶("+ currency_type+ ")" + item2_price + " " + item2_quantity + " " + (item2_price * item2_quantity));
                        }
                        if (item3_quantity != 0)
                        {
                            Console.WriteLine("潛水作業指北針("+ currency_type+ ")" + item3_price + " " + item3_quantity + " " + (item3_price * item3_quantity));
                        }
                        Console.WriteLine("總價 = " + ((item1_price * item1_quantity) + (item2_price * item2_quantity) + (item3_price * item3_quantity)));
                        Console.Write("*是否要結帳(Y/N):");
                        string checkout = Console.ReadLine();
                        switch (checkout)
                        {
                            case "Y":
                                if (item1_quantity > 1)
                                {
                                    Console.WriteLine("潛水相機房丟繩庫存不足!剩餘數量1!\n");
                                }
                                else if (item2_quantity > 2)
                                {
                                    Console.WriteLine("潛水配重帶庫存不足!剩餘數量2!\n");
                                }
                                else if (item3_quantity > 1)
                                {
                                    Console.WriteLine("潛水作業指北針庫存不足!剩餘數量1!\n");
                                }
                                else
                                {
                                    Console.Write("*選擇結帳方式(1.線上支付 2.貨到付款):");
                                    string checkout_method = Console.ReadLine();
                                    if (checkout_method != "1" && checkout_method != "2")
                                    {
                                        Console.WriteLine("輸入錯誤! 請重新輸入!\n");
                                        break;
                                    }
                                    else
                                    {
                                        Console.Write("*折扣碼(若無折扣碼則輸入N):");
                                        string discount = Console.ReadLine();
                                        switch (discount)
                                        {
                                            case "N":
                                                Console.Write("\n");
                                                Console.WriteLine("訂單狀態:\n商品 單價 數量 小計");
                                                if (item1_quantity != 0)
                                                {
                                                    Console.WriteLine("潛水相機房丟繩(" + currency_type + ")" + item1_price + " " + item1_quantity + " " + (item1_price * item1_quantity));
                                                }
                                                if (item2_quantity != 0)
                                                {
                                                    Console.WriteLine("潛水配重帶(" + currency_type + ")" + item2_price + " " + item2_quantity + " " + (item2_price * item2_quantity));
                                                }
                                                if (item3_quantity != 0)
                                                {
                                                    Console.WriteLine("潛水作業指北針(" + currency_type + ")" + item3_price + " " + item3_quantity + " " + (item3_price * item3_quantity));
                                                }
                                                Console.WriteLine("總價 = " + ((item1_price * item1_quantity) + (item2_price * item2_quantity) + (item3_price * item3_quantity)));
                                                if (checkout_method == "1")
                                                {
                                                    Console.WriteLine("狀態:已付款\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("狀態:尚未付款\n");
                                                }
                                                break;
                                            case "1111":
                                                Console.Write("\n");
                                                Console.WriteLine("訂單狀態:\n商品 單價 數量 小計");
                                                if (item1_quantity != 0)
                                                {
                                                    Console.WriteLine("潛水相機房丟繩(" + currency_type + ")" + item1_price + " " + item1_quantity + " " + (item1_price * item1_quantity));
                                                }
                                                if (item2_quantity != 0)
                                                {
                                                    Console.WriteLine("潛水配重帶(" + currency_type + ")" + item2_price + " " + item2_quantity + " " + (item2_price * item2_quantity));
                                                }
                                                if (item3_quantity != 0)
                                                {
                                                    Console.WriteLine("潛水作業指北針(" + currency_type + ")" + item3_price + " " + item3_quantity + " " + (item3_price * item3_quantity));
                                                }
                                                Console.WriteLine("總價 = " + ((item1_price * item1_quantity) + (item2_price * item2_quantity) + (item3_price * item3_quantity)));
                                                Console.WriteLine("總價(折扣後) = " + (((item1_price * item1_quantity) + (item2_price * item2_quantity) + (item3_price * item3_quantity)) * 0.95));
                                                if (checkout_method == "1")
                                                {
                                                    Console.WriteLine("狀態:已付款\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("狀態:尚未付款\n");
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("輸入錯誤! 請重新輸入!\n");
                                                break;
                                        }
                                    }
                                    
                                }
                                break;

                            case "N":
                                Console.Write("\n");
                                break;

                            default:
                                Console.WriteLine("輸入錯誤! 請重新輸入!\n");
                                break;
                        }
                        break;

                    case "6":
                        Console.Write("選擇貨幣 1.TWD 2.USD 3.CNY 4.JPY :");
                        string currency = Console.ReadLine();
                        Console.Write("\n");
                        switch (currency)
                        {
                            case "1":
                                currency_type = "TWD";
                                item1_price = 199;
                                item2_price = 460;
                                item3_price = 1100;
                                break;
                            case "2":
                                currency_type = "USD";
                                item1_price = 199*0.031;
                                item2_price = 460*0.031;
                                item3_price = 1100*0.031;
                                break;
                            case "3":
                                currency_type = "CNY";
                                item1_price = 199*0.23;
                                item2_price = 460*0.23;
                                item3_price = 1100*0.23;
                                break;
                            case "4":
                                currency_type = "JPY";
                                item1_price = 199*4.59;
                                item2_price = 460*4.59;
                                item3_price = 1100*4.59;
                                break;
                        }
                        break;

                    case "7":
                        use = false;
                        break;

                    default:
                        Console.WriteLine("輸入錯誤! 請重新輸入!\n");
                        break;
                }
            }
        }
    }
}
