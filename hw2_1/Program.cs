using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string action;
            string[] action_array = new string[4];
            bool use = true;
            course[] transcrip = new course[0];
            while (use == true)
            {
                NEWTURN:
                Console.Write("\n## 成績計算器 ##\n1. 新增科目(creat)\n2. 刪除科目(delete)\n3. 更新科目(update)\n4. 列印成績單(print)\n5. 退出選單(exit)\n輸入要執行的指令操作:");
                action = Console.ReadLine();
                Array.Clear(action_array, 0, action_array.Length);
                action_array = action.Split(' ');
              
                switch (action_array[0])
                {
                    case "creat":
                        if (action_array.Length<4)//格式錯誤
                        {
                            Console.WriteLine("指令格式不符!請重新輸入!");
                            break;
                        }
                        if (int.Parse(action_array[2]) > 100 || int.Parse(action_array[2]) < 0)//成績錯誤
                        {
                            Console.WriteLine("成績分數異常!請重新輸入!");
                            break;
                        }
                        if (int.Parse(action_array[3]) > 10 || int.Parse(action_array[3]) < 0)//學分錯誤
                        {
                            Console.WriteLine("學分數異常!請重新輸入!");
                            break;
                        }
                        for (int i = 0; i < transcrip.Length; i++)//科目存在
                        {
                            if (action_array[1] == transcrip[i].num)
                            {
                                Console.WriteLine("科目已存在");
                                goto NEWTURN;
                            }
                        }
                            
                        Array.Resize(ref transcrip, transcrip.Length + 1);
                        transcrip[transcrip.Length - 1] = new course();
                        transcrip[transcrip.Length - 1].score = int.Parse(action_array[2]);
                        transcrip[transcrip.Length - 1].credit = int.Parse(action_array[3]);
                        transcrip[transcrip.Length - 1].num = action_array[1];
                        Console.WriteLine("科目已新增");
                        break;

                    case "delete":
                        if (transcrip.Length == 0)//防止67行執行不到
                        {
                            Console.WriteLine("科目不存在");
                            goto NEWTURN;
                        }
                        for (int i = 0; i < transcrip.Length; i++)
                        {
                            if (action_array[1] == transcrip[i].num)
                            {
                                goto HAVE;
                            }
                            else
                            {
                                Console.WriteLine("科目不存在");
                                goto NEWTURN;
                            }
                        }
                        HAVE:
                        transcrip = transcrip.Where(val => val.num != action_array[1]).ToArray();
                        Console.WriteLine("科目已刪除");
                        break;

                    case "update":
                        if (transcrip.Length == 0)//防止90行執行不到
                        {
                            Console.WriteLine("科目不存在");
                            goto NEWTURN;
                        }
                        for (int i = 0; i < transcrip.Length; i++)
                        {
                            if (action_array[1] == transcrip[i].num)
                            {
                                goto UPDATE_HAVE;
                            }
                            else
                            {
                                Console.WriteLine("科目不存在");
                                goto NEWTURN;
                            }
                        }
                        if (int.Parse(action_array[2]) > 100 || int.Parse(action_array[2]) < 0)//成績錯誤
                        {
                            Console.WriteLine("成績分數異常!請重新輸入!");
                            break;
                        }
                        if (int.Parse(action_array[3]) > 10 || int.Parse(action_array[3]) < 0)//學分錯誤
                        {
                            Console.WriteLine("學分數異常!請重新輸入!");
                            break;
                        }
                        UPDATE_HAVE:
                        for (int i=0; i<transcrip.Length; i++)
                        {
                            if (transcrip[i].num == action_array[1])
                            {
                                transcrip[i].score = int.Parse(action_array[2]);
                                transcrip[i].credit = int.Parse(action_array[3]);
                            }
                        }
                        Console.WriteLine("科目已更新");
                        break;

                    case "print":
                        if (action_array.Length > 1)
                        {
                            Console.WriteLine("指令格式不符!請重新輸入!");
                            break;
                        }
                        Console.WriteLine("我的成績單:\n編號\t科目代碼\t分數\t等第\t學分數 ");
                        for (int i=1; i<= transcrip.Length; i++)//回數
                            for (int j=1; j<=transcrip.Length - i; j++)//次數
                            {
                                if (transcrip[j].score > transcrip[j - 1].score)
                                {
                                    //兩數交換
                                    course temp = transcrip[j];
                                    transcrip[j] = transcrip[j - 1];
                                    transcrip[j - 1] = temp;
                                }
                            }
                        int sum_score = 0, sum_credit = 0, get_credit = 0;
                        double gpa_old_sum = 0, gpa_new_sum = 0;
                        for (int i=0; i<transcrip.Length; i++)
                        {
                            if (transcrip[i].score >= 90)
                            {
                                transcrip[i].rank = "A+";
                                gpa_new_sum += 4.3 * transcrip[i].credit;
                            }
                            else if(transcrip[i].score <= 89 && transcrip[i].score >= 85)
                            {
                                transcrip[i].rank = "A";
                                gpa_new_sum += 4 * transcrip[i].credit;
                            }
                            else if (transcrip[i].score <= 84 && transcrip[i].score >= 80)
                            {
                                transcrip[i].rank = "A-";
                                gpa_new_sum += 3.7 * transcrip[i].credit;
                            }
                            else if (transcrip[i].score <= 79 && transcrip[i].score >= 77)
                            {
                                transcrip[i].rank = "B+";
                                gpa_new_sum += 3.3 * transcrip[i].credit;
                            }
                            else if (transcrip[i].score <= 76 && transcrip[i].score >= 73)
                            {
                                transcrip[i].rank = "B";
                                gpa_new_sum += 3 * transcrip[i].credit;
                            }
                            else if (transcrip[i].score <= 72 && transcrip[i].score >= 70)
                            {
                                transcrip[i].rank = "B-";
                                gpa_new_sum += 2.7 * transcrip[i].credit;
                            }
                            else if (transcrip[i].score <= 69 && transcrip[i].score >= 67)
                            {
                                transcrip[i].rank = "C+";
                                gpa_new_sum += 2.3 * transcrip[i].credit;
                            }
                            else if (transcrip[i].score <= 66 && transcrip[i].score >= 63)
                            {
                                transcrip[i].rank = "C";
                                gpa_new_sum += 2 * transcrip[i].credit;
                            }
                            else if (transcrip[i].score <= 62 && transcrip[i].score >= 60)
                            {
                                transcrip[i].rank = "C-";
                                gpa_new_sum += 1.7 * transcrip[i].credit;
                            }
                            else
                            {
                                transcrip[i].rank = "F";
                            }

                            Console.WriteLine(i + "\t" + transcrip[i].num + "\t\t" + transcrip[i].score + "\t" + transcrip[i].rank + "\t" + transcrip[i].credit);
                            sum_score += transcrip[i].score * transcrip[i].credit;
                            sum_credit += transcrip[i].credit;

                            if (transcrip[i].score >= 80)
                            {
                                gpa_old_sum += 4 * transcrip[i].credit;
                            }
                            else if (transcrip[i].score <= 79 && transcrip[i].score >= 70)
                            {
                                gpa_old_sum += 3 * transcrip[i].credit;
                            }
                            else if (transcrip[i].score <= 69 && transcrip[i].score >= 60)
                            {
                                gpa_old_sum += 2 * transcrip[i].credit;
                            }
                            else if (transcrip[i].score <= 59 && transcrip[i].score >= 50)
                            {
                                gpa_old_sum += 1 * transcrip[i].credit;
                            }

                            if (transcrip[i].score >= 60)
                            {
                                get_credit += transcrip[i].credit;
                            }
                        }
                        float avg = (float)sum_score / (float)sum_credit;
                        float gpa_new = (float)gpa_new_sum / (float)sum_credit;
                        float gpa_old = (float)gpa_old_sum / (float)sum_credit;
                        if (sum_credit == 0)//防止出現"非數值"
                        {
                            avg = 0;
                            gpa_new = 0;
                            gpa_old = 0;
                        }
                        Console.WriteLine("總平均:" + avg);
                        Console.WriteLine("GPA: " + gpa_old + "/4.0(舊制), " + gpa_new + "/4.3(新制)");
                        Console.WriteLine("實拿學分數/總學分數: " + get_credit +"/"+ sum_credit);
                        break;

                    case "exit":
                        use = false;
                        break;

                    default:
                        Console.WriteLine("指令格式不符!請重新輸入!");
                        break;
                }
            }
        }
    }
}
