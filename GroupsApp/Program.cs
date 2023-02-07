using System;

namespace GroupsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Group[] groups = new Group[0];

            string option;
            do
            {
                Console.WriteLine("1. Qrup elave et");
                Console.WriteLine("2. Qruplara bax");
                Console.WriteLine("3. Type deyerine gore qruplara bax");
                Console.WriteLine("4. Bugunedek baslamis qruplara bax");
                Console.WriteLine("5. Son 2 ayda baslamis qruplara bax");
                Console.WriteLine("6. Bu ayin sonunadek yeni baslayacaq olan qruplara bax");
                Console.WriteLine("7. Verilmis 2 tarix araliginda baslamis olan qruplara bax");
                Console.WriteLine("0. Cixis");

                Console.Write("\nSeciminizi daxil edin: ");
                option = Console.ReadLine();


                switch (option)
                {
                    case "1":
                        Console.Write("No: ");
                        string no = Console.ReadLine();
                        Console.WriteLine("Type:");
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                            Console.WriteLine($"{(byte)item} - {item}");

                        byte typeByte;
                        string typeStr;
                        do
                        {
                            typeStr = Console.ReadLine();
                            typeByte = Convert.ToByte(typeStr);
                        } while (!Enum.IsDefined(typeof(GroupType), typeByte));

                        GroupType type = (GroupType)typeByte;

                        Console.WriteLine("StartDate:");
                        string startDatestr = Console.ReadLine();
                        DateTime startDate = Convert.ToDateTime(startDatestr);

                        Group group = new Group
                        {
                            No = no,
                            Type = type,
                            StartDate = startDate
                        };

                        Array.Resize(ref groups, groups.Length + 1);
                        groups[groups.Length - 1] = group;

                        break;
                    case "2":
                        foreach (var gr in groups)
                        {
                            Console.WriteLine($"No: {gr.No} - Type: {gr.Type} - StartDate: {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                        }
                        break;
                    case "3":
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                            Console.WriteLine($"{(byte)item} - {item}");

                        Console.Write("Type: ");
                        typeStr = Console.ReadLine();
                        typeByte = Convert.ToByte(typeStr);
                        type = (GroupType)typeByte;

                        foreach (var gr in groups)
                        {
                            if (gr.Type == type)
                                Console.WriteLine($"No: {gr.No} - Type: {gr.Type} - StartDate: {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                        }
                        break;
                        case "4":
                        foreach (var gr in groups)
                        {
                            if (gr.StartDate < DateTime.Now)
                                Console.WriteLine($"No: {gr.No} - Type: {gr.Type} - StartDate: {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                        }
                        break;
                        case "5":
                        string dateStr = "12-2022";
                        DateTime newDate = Convert.ToDateTime(dateStr);
                        foreach (var gr in groups)
                        {
                            if (gr.StartDate > newDate && gr.StartDate < DateTime.Now)
                                Console.WriteLine($"No: {gr.No} - Type: {gr.Type} - StartDate: {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                        }
                        break;
                        case "6":
                        dateStr = "02-28-2023";
                        newDate = Convert.ToDateTime(dateStr);
                        foreach (var gr in groups)
                        {
                            if (gr.StartDate <= newDate && gr.StartDate >= DateTime.Now)
                                Console.WriteLine($"No: {gr.No} - Type: {gr.Type} - StartDate: {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                        }
                        break;
                    case "7":
                        Console.Write("First Date: ");
                        string firstDateStr = Console.ReadLine();
                        DateTime firstDate = Convert.ToDateTime(firstDateStr);

                        Console.Write("Second Date: ");
                        string secondDateStr = Console.ReadLine();
                        DateTime secondDate = Convert.ToDateTime(secondDateStr);

                        foreach (var gr in groups)
                        {
                            if (gr.StartDate >= firstDate && gr.StartDate <= secondDate)
                                Console.WriteLine($"No: {gr.No} - Type: {gr.Type} - StartDate: {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                        }
                        break;
                    case "0":
                        Console.WriteLine("Proqram bitdi");
                        break;
                    default:
                        Console.WriteLine("Seciminiz yanlisdir");
                        break;
                }
            } while (option != "0");
        }
    }
}
