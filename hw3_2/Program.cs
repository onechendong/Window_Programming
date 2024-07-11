using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _3_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool use = true;
            string action;
            string[] action_array=new string[5];
            ArrayList member= new ArrayList();
            
            Console.WriteLine("--------------------------###\t社員資料登記\t###--------------------------\n新增社員資訊:\tregister\tname\tdepartment\tid\n以特定屬性查詢:\tsearch\t\tname\ttag\tWant_search_string\n授予社員職位:\tentitle\t\tname\tdepartment\tid\tThat_title\n所有社員列表:\tcheck\n指令格式列表:\thelp\n離開此程式:\texit");
            while (use == true)
            {
                action = Console.ReadLine();
                Array.Clear(action_array, 0, action_array.Length);
                action_array = action.Split(' ');
                bool already_register=false;
                Student temp_student = new Student();

                switch (action_array[0])
                {
                    case "register":
                        foreach (Student element in member)
                        {
                            if(action_array[1]==element.name&& action_array[2] == element.department && action_array[3] == element.id)//已存在
                            {
                                already_register=true;
                                if (element.level == "盟新社員")//第二次
                                {
                                    element.level = "資深社員";
                                    Console.WriteLine("已晉升為資深社員!!");
                                }
                                else if(element.level== "資深社員")//第三次
                                {
                                    element.level = "永久社員";
                                    Console.WriteLine("已晉升為永久社員!!");
                                }
                                else//已是永久社員
                                {
                                    Console.WriteLine("已經是永久社員了ㄛ");
                                }
                            }
                        }
                        if (already_register == false)//尚未存在
                        {
                            temp_student.name = action_array[1];
                            temp_student.department = action_array[2];
                            temp_student.id = action_array[3];
                            temp_student.level = "盟新社員";
                            member.Add(temp_student);
                            Console.WriteLine("歡迎新社員!!");
                        }
                        break;

                    case "search":
                        bool find = false;
                        switch (action_array[1])
                        {
                            case "name":
                                foreach (Student element in member)
                                {
                                    if (element.name == action_array[2])
                                    {   
                                        find = true;
                                        Console.WriteLine(element.name + "\t" + element.department + "\t" + element.id + "\t" + element.level + "\t" + element.title);
                                    }
                                }
                                if (find==false)
                                {
                                    Console.WriteLine("\t找不到這個人ㄟ");
                                }
                                break;

                            case "department":
                                foreach (Student element in member)
                                {
                                    if (element.department == action_array[2])
                                    {
                                        find = true;
                                        Console.WriteLine(element.name + "\t" + element.department + "\t" + element.id + "\t" + element.level + "\t" + element.title);
                                    }
                                }
                                if (find == false)
                                {
                                    Console.WriteLine("\t找不到這個系的人ㄟ");
                                }
                                break;

                            case "ID":
                                foreach (Student element in member)
                                {
                                    if (element.id == action_array[2])
                                    {
                                        find = true;
                                        Console.WriteLine(element.name + "\t" + element.department + "\t" + element.id + "\t" + element.level + "\t" + element.title);
                                    }
                                }
                                if (find == false)
                                {
                                    Console.WriteLine("\t找不到這個學號的人ㄟ");
                                }
                                break;

                            case "level":
                                foreach (Student element in member)
                                {
                                    if (element.level == action_array[2])
                                    {
                                        find = true;
                                        Console.WriteLine(element.name + "\t" + element.department + "\t" + element.id + "\t" + element.level + "\t" + element.title);
                                    }
                                }
                                if (find == false)
                                {
                                    Console.WriteLine("\t找不到這個等級的人ㄟ");
                                }
                                break;

                            case "title":
                                foreach (Student element in member)
                                {
                                    if (element.title == action_array[2])
                                    {
                                        find = true;
                                        Console.WriteLine(element.name + "\t" + element.department + "\t" + element.id + "\t" + element.level + "\t" + element.title);
                                    }
                                }
                                if (find == false)
                                {
                                    Console.WriteLine("\t找不到這個職務的人ㄟ");
                                }
                                break;
                        }
                        break;

                    case "entitle":
                        bool find_entitle = false;
                        foreach (Student element in member)
                        {
                            if (element.name == action_array[1] && element.department == action_array[2] && element.id == action_array[3])
                            {
                                find_entitle = true;
                            }
                        }
                        if(find_entitle == true)//有這個人
                        {
                            if (action_array[4].Contains("社長"))//職稱包含社長
                            {
                                Console.WriteLine("我們的社長只有阿明一個人，你不要想篡位ㄛ!");
                            }
                            else//順利找到人且職稱不包含社長
                            {
                                foreach (Student element in member)
                                {
                                    if (element.name == action_array[1])
                                    {
                                        element.title = action_array[4];
                                        Console.WriteLine(element.name + "已晉升為" + action_array[4]);
                                    }
                                }
                            }
                        }
                        else//沒找到人
                        {
                            Console.WriteLine("\t找不到這個人ㄟ");
                        }
                        break;

                    case "check":
                        Console.WriteLine("---------------------------------------------------------------------------------------------");
                        foreach(Student element in member)
                        {
                            Console.WriteLine(element.name+"\t"+element.department+"\t"+element.id+"\t"+element.level+"\t"+element.title);
                        }
                        Console.WriteLine("---------------------------------------------------------------------------------------------");
                        break;

                    case "help":
                        Console.WriteLine("---------------------------------------------------------------------------------------------\n新增社員資訊:\tregister\tname\tdepartment\tid\n以特定屬性查詢:\tsearch\t\tname\ttag\tWant_search_string\n授予社員職位:\tentitle\t\tname\tdepartment\tid\tThat_title\n所有社員列表:\tcheck\n指令格式列表:\thelp\n離開此程式:\texit\n---------------------------------------------------------------------------------------------");
                        break;

                    case "exit":
                        use = false;
                        break;

                    default:
                        Console.WriteLine("不存在這個功能!有疑慮請打help!");
                        break;
                }
            }
           
        }
    }
}
