using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hello2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string action;
            int item1_quantity = 0, item2_quantity = 0, item3_quantity = 0, item1_money = 0, item2_money = 0, item3_money = 0;
            for (bool use = true; use == true;)
            {
                Console.WriteLine("(1)商品列表 (2)新增至購物車 (3)自購物車刪除 (4)查看購物車 (5)計算總金額 (6)退出網頁");
                Console.Write("輸入數字選擇功能:");
                action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        Console.WriteLine("列表:\n商品名稱 商品單價\n1.潛水相機房丟繩(TWD)199\n2.潛水配重帶(TWD)460\n3.潛水作業指北針(TWD)1100\n");
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
                                item1_money = item1_quantity * 199;
                                break;
                            case "2":
                                item2_quantity += add_value;
                                item2_money = item2_quantity * 460;
                                break;
                            case "3":
                                item3_quantity += add_value;
                                item3_money = item3_quantity * 1100;
                                break;
                        }
                        Console.Write("\n");
                        break;

                    case "3":
                        Console.Write("購物車內容:\n商品 數量 單價 小計\n");
                        Console.WriteLine("1.潛水相機房丟繩(TWD)199 " + item1_quantity + " " + item1_money + "\n2.潛水配重帶(TWD)460 " + item2_quantity + " " + item2_money + "\n3.潛水作業指北針(TWD)1100 " + item3_quantity + " " + item3_money);
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
                                    item1_money = item1_quantity * 199;
                                    break;
                                case "2":
                                    item2_quantity -= delete_value;
                                    item2_money = item2_quantity * 460;
                                    break;
                                case "3":
                                    item3_quantity -= delete_value;
                                    item3_money = item3_quantity * 1100;
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
                        item1_money = item1_quantity * 199;
                        item2_money = item2_quantity * 460;
                        item3_money = item3_quantity * 1100;
                        Console.WriteLine("1.潛水相機房丟繩(TWD)199 "+item1_quantity+" "+item1_money+"\n2.潛水配重帶(TWD)460 "+item2_quantity+" "+item2_money+"\n3.潛水作業指北針(TWD)1100 "+item3_quantity+" "+item3_money+"\n");
                        break;

                    case "5":
                        Console.WriteLine("訂單商品:\n商品 單價 數量 小計");
                        if (item1_quantity != 0)
                        {
                            Console.WriteLine("潛水相機房丟繩(TWD)199 " + item1_quantity + " " + item1_money);
                        }
                        if (item2_quantity != 0)
                        {
                            Console.WriteLine("潛水配重帶(TWD)460 " + item2_quantity + " " + item2_money);
                        }
                        if (item3_quantity != 0)
                        {
                            Console.WriteLine("潛水作業指北針(TWD)1100 " + item3_quantity + " " + item3_money);
                        }
                        Console.WriteLine("總價 = " + (item1_money + item2_money + item3_money)+"\n");
                        break;

                    case "6":
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
