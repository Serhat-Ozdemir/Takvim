using System;

namespace Takvim
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0, day1 = 0, day2 = 0, day_compare = 0; // for days and day compare
            double year1 = 0, year2 = 0, year_compare = 0; // for years and year compare
            double Y = 0, y = 0, c = 0, m1 = 0, m2 = 0, w = 0; // variables for gauss algorithm
            int MARCH = 1, APRIL = 2, MAY = 3, JUNE = 4, JULY = 5, AUGUST = 6, SEPTEMBER = 7, OCTOBER = 8, NOVEMBER = 9, DECEMBER = 10, JANUARY = 11, FEBRUARY = 12; // shifted months
            string w_day = "", month1 = "", month2 = "", temp_day = "", temp_year = "", temp_n = "", month_compare = ""; //for months, convet check and compare dates
            bool int_control, double_control;// for checking if the n, years and days can be converted

            Console.WriteLine("Please Enter The First Day:");

            //for checking if the day can be converted
            temp_day = Console.ReadLine();
            int_control = Int32.TryParse(temp_day, out day1);
            while (int_control == false)
            {
                Console.WriteLine("Please enter a number!:");
                temp_day = Console.ReadLine();
                int_control = Int32.TryParse(temp_day, out day1);
            }
            day1 = Convert.ToInt32(temp_day);

            Console.WriteLine("Please Enter The First Month:");
            month1 = Console.ReadLine();

            //for checking if the year can be converted
            Console.WriteLine("Please Enter The First Year:");
            temp_year = Console.ReadLine();
            double_control = double.TryParse(temp_year, out year1);
            while (double_control == false)
            {
                Console.WriteLine("Please enter a number!:");
                temp_year = Console.ReadLine();
                double_control = double.TryParse(temp_year, out year1);
            }
            year1 = Convert.ToDouble(year1);

            month1 = month1.ToUpper(new System.Globalization.CultureInfo("en-US", false));// Capitalizes all letters 

            //Date control
            while (year1 < 2015)
            {
                Console.WriteLine("Please enter a year greater than 2015");
                Console.WriteLine("Please enter the First Year:");
                temp_year = Console.ReadLine();
                double_control = double.TryParse(temp_year, out year1);
                while (double_control == false)
                {
                    Console.WriteLine("Please enter a number!");
                    temp_year = Console.ReadLine();
                    double_control = double.TryParse(temp_year, out year1);
                }
                year1 = Convert.ToDouble(year1);

            }
            while (month1 != "MARCH" && month1 != "APRIL" && month1 != "MAY" && month1 != "JUNE" && month1 != "JULY" && month1 != "AUGUST"
               && month1 != "SEPTEMBER" && month1 != "OCTOBER" && month1 != "NOVEMBER" && month1 != "DECEMBER" && month1 != "JANUARY"
               && month1 != "FEBRUARY")
            {

                Console.WriteLine("First month is wrong! Please enter a valid month");
                Console.WriteLine("Please Enter The First Month:");
                month1 = Console.ReadLine();
                month1 = month1.ToUpper(new System.Globalization.CultureInfo("en-US", false));
            }

            while (month1 == "MARCH" || month1 == "APRIL" || month1 == "MAY" || month1 == "JUNE" || month1 == "JULY" || month1 == "AUGUST"
                || month1 == "SEPTEMBER" || month1 == "OCTOBER" || month1 == "NOVEMBER" || month1 == "DECEMBER" || month1 == "JANUARY"
                || month1 == "FEBRUARY")
            {
                if ((month1 == "JANUARY" || month1 == "MARCH" || month1 == "MAY" || month1 == "JULY" || month1 == "AUGUST" || month1 == "OCTOBER" || month1 == "DECEMBER") && (day1 <= 0 || day1 > 31))
                {
                    Console.WriteLine("First day is wrong!");
                    Console.WriteLine("Please Enter The First Day:");
                    temp_day = Console.ReadLine();
                    int_control = Int32.TryParse(temp_day, out day1);
                    while (int_control == false)
                    {
                        Console.WriteLine("Please enter a number!");
                        temp_day = Console.ReadLine();
                        int_control = Int32.TryParse(temp_day, out day1);
                    }
                    day1 = Convert.ToInt32(temp_day);

                }
                else if ((month1 == "FEBRUARY" || month1 == "APRIL" || month1 == "JUNE" || month1 == "SEPTEMBER" || month1 == "NOVEMBER") && (day1 <= 0 || day1 > 28))
                {
                    if (month1 == "FEBRUARY" && (year1 % 4) == 0 && (day1 <= 0 || day1 > 29))
                    {
                        Console.WriteLine("First day is wrong!");
                        Console.WriteLine("Please Enter The First Day:");
                        day1 = Convert.ToInt32(Console.ReadLine());
                    }
                    else if (month1 == "FEBRUARY" && (year1 % 4) != 0 && (day1 <= 0 || day1 > 28))
                    {
                        Console.WriteLine("First day is wrong!");
                        Console.WriteLine("Please Enter The First Day:");
                        day1 = Convert.ToInt32(Console.ReadLine());
                    }
                    else if (month1 == "FEBRUARY" && day1 == 29)
                        break;
                    else if (month1 != "FEBRUARY" && day1 > 30)
                    {
                        Console.WriteLine("First day is wrong!");
                        Console.WriteLine("Please Enter The First Day:");
                        day1 = Convert.ToInt32(Console.ReadLine());

                    }
                    else if (month1 != "FEBRUARY" && day1 == 30)
                        break;
                }
                else
                    break;
            }
            Console.WriteLine("First Date: " + day1 + " " + month1 + " " + year1);


            Console.WriteLine("\nPlease Enter The Second Day:");

            //for checking if day can be converted
            temp_day = Console.ReadLine();
            int_control = Int32.TryParse(temp_day, out day2);
            while (int_control == false)
            {
                Console.WriteLine("Please enter a number!");
                temp_day = Console.ReadLine();
                int_control = Int32.TryParse(temp_day, out day2);
            }
            day2 = Convert.ToInt32(temp_day);

            Console.WriteLine("Please Enter The Second Month:");
            month2 = Console.ReadLine();

            //for checking if year can be converted
            Console.WriteLine("Please Enter The Second Year:");
            temp_year = Console.ReadLine();
            double_control = double.TryParse(temp_year, out year2);
            while (double_control == false)
            {
                Console.WriteLine("Please enter a number!");
                temp_year = Console.ReadLine();
                double_control = double.TryParse(temp_year, out year2);
            }
            year2 = Convert.ToDouble(year2);
            month2 = month2.ToUpper(new System.Globalization.CultureInfo("en-US", false));// capitalizes all letters

            //date control
            while (year2 < 2015)
            {
                Console.WriteLine("Please enter a year greater than 2015");
                Console.WriteLine("Please Enter The Second Year:");
                temp_year = Console.ReadLine();
                double_control = double.TryParse(temp_year, out year2);
                while (double_control == false)
                {
                    Console.WriteLine("Please enter a number!");
                    temp_year = Console.ReadLine();
                    double_control = double.TryParse(temp_year, out year2);
                }
                year2 = Convert.ToDouble(year2);

            }
            while (month2 != "MARCH" && month2 != "APRIL" && month2 != "MAY" && month2 != "JUNE" && month2 != "JULY" && month2 != "AUGUST"
                && month2 != "SEPTEMBER" && month2 != "OCTOBER" && month2 != "NOVEMBER" && month2 != "DECEMBER" && month2 != "JANUARY"
               && month2 != "FEBRUARY")
            {
                Console.WriteLine("Month2 is wrong! Please enter a valid month");
                Console.WriteLine("Please Enter The Second Month:");
                month2 = Console.ReadLine();
                month2 = month2.ToUpper(new System.Globalization.CultureInfo("en-US", false));
            }
            while (month2 == "MARCH" || month2 == "APRIL" || month2 == "MAY" || month2 == "JUNE" || month2 == "JULY" || month2 == "AUGUST"
                || month2 == "SEPTEMBER" || month2 == "OCTOBER" || month2 == "NOVEMBER" || month2 == "DECEMBER" || month2 == "JANUARY"
                || month2 == "FEBRUARY")
            {
                if ((month2 == "JANUARY" || month2 == "MARCH" || month2 == "MAY" || month2 == "JULY" || month2 == "AUGUST" || month2 == "OCTOBER" || month2 == "DECEMBER") && (day2 <= 0 || day2 > 31))
                {
                    Console.WriteLine("Second day is wrong!");
                    Console.WriteLine("Please Enter The Second Day:");
                    temp_day = Console.ReadLine();
                    int_control = Int32.TryParse(temp_day, out day2);
                    while (int_control == false)
                    {
                        Console.WriteLine("Please enter a number!");
                        temp_day = Console.ReadLine();
                        int_control = Int32.TryParse(temp_day, out day2);
                    }

                    day2 = Convert.ToInt32(temp_day);

                }
                else if ((month2 == "FEBRUARY" || month2 == "APRIL" || month2 == "JUNE" || month2 == "SEPTEMBER" || month2 == "NOVEMBER") && (day2 <= 0 || day2 > 28))
                {
                    if (month2 == "FEBRUARY" && (year2 % 4) == 0 && (day2 <= 0 || day2 > 29))
                    {
                        Console.WriteLine("Second day is wrong!");
                        Console.WriteLine("Please Enter The Second Day:");
                        day2 = Convert.ToInt32(Console.ReadLine());
                    }
                    else if (month2 == "FEBRUARY" && (year2 % 4) != 0 && (day2 <= 0 || day2 > 28))
                    {
                        Console.WriteLine("Second day is wrong");
                        Console.WriteLine("Please Enter The Second Day:");
                        day2 = Convert.ToInt32(Console.ReadLine());

                    }
                    else if (month2 == "FEBRUARY" && day2 == 29)
                        break;
                    else if (month2 != "FEBRUARY" && day2 > 30)
                    {
                        Console.WriteLine("Second day is wrong!");
                        Console.WriteLine("Please Enter The Second Day:");
                        day2 = Convert.ToInt32(Console.ReadLine());
                    }
                    else if (month2 != "FEBRUARY" && day2 == 30)
                        break;
                }
                else
                    break;
            }
            Console.WriteLine("Second Date:" + day2 + " " + month2 + " " + year2);

            Console.WriteLine("Please enter the step");
            // Checks if the n is an integer
            temp_n = Console.ReadLine();
            int_control = Int32.TryParse(temp_n, out n);
            while (int_control == false)
            {
                Console.WriteLine("Please enter a number!");
                temp_n = Console.ReadLine();
                int_control = Int32.TryParse(temp_n, out n);
            }
            n = Convert.ToInt32(temp_n);
            while (n <= 0)
            {
                Console.WriteLine("Please enter a number greater than zero!");
                temp_n = Console.ReadLine();
                int_control = Int32.TryParse(temp_n, out n);
                while (int_control == false)
                {
                    Console.WriteLine("Please enter a number!");
                    temp_n = Console.ReadLine();
                    int_control = Int32.TryParse(temp_n, out n);
                }
                n = Convert.ToInt32(temp_n);
            }

            // to determine months 
            switch (month1)
            {
                case "MARCH": m1 = MARCH; break;
                case "APRIL": m1 = APRIL; break;
                case "MAY": m1 = MAY; break;
                case "JUNE": m1 = JUNE; break;
                case "JULY": m1 = JULY; break;
                case "AUGUST": m1 = AUGUST; break;
                case "SEPTEMBER": m1 = SEPTEMBER; break;
                case "OCTOBER": m1 = OCTOBER; break;
                case "NOVEMBER": m1 = NOVEMBER; break;
                case "DECEMBER": m1 = DECEMBER; break;
                case "JANUARY": m1 = JANUARY; break;
                case "FEBRUARY": m1 = FEBRUARY; break;
            }
            switch (month2)
            {
                case "MARCH": m2 = MARCH; break;
                case "APRIL": m2 = APRIL; break;
                case "MAY": m2 = MAY; break;
                case "JUNE": m2 = JUNE; break;
                case "JULY": m2 = JULY; break;
                case "AUGUST": m2 = AUGUST; break;
                case "SEPTEMBER": m2 = SEPTEMBER; break;
                case "OCTOBER": m2 = OCTOBER; break;
                case "NOVEMBER": m2 = NOVEMBER; break;
                case "DECEMBER": m2 = DECEMBER; break;
                case "JANUARY": m2 = JANUARY; break;
                case "FEBRUARY": m2 = FEBRUARY; break;
            }

            // to compare dates
            if (year1 > year2)
            {
                year_compare = year1;
                year1 = year2;
                year2 = year_compare;
                month_compare = month1;
                month1 = month2;
                month2 = month_compare;
                day_compare = day1;
                day1 = day2;
                day2 = day_compare;
            }
            else if (year1 == year2 && m1 > m2 && (m1 != JANUARY && m1 != FEBRUARY) && (m2 != JANUARY && m2 != FEBRUARY))
            {
                month_compare = month1;
                month1 = month2;
                month2 = month_compare;
                day_compare = day1;
                day1 = day2;
                day2 = day_compare;
            }
            else if (year1 == year2 && m1 != JANUARY && m1 != FEBRUARY && m2 == FEBRUARY)
            {
                month_compare = month1;
                month1 = month2;
                month2 = month_compare;
                day_compare = day1;
                day1 = day2;
                day2 = day_compare;
            }
            else if (year1 == year2 && m1 == FEBRUARY && m2 == JANUARY)
            {
                month_compare = month1;
                month1 = month2;
                month2 = month_compare;
                day_compare = day1;
                day1 = day2;
                day2 = day_compare;
            }
            else if (year1 == year2 && m1 == m2 && day1 > day2)
            {
                month_compare = month1;
                month1 = month2;
                month2 = month_compare;
                day_compare = day1;
                day1 = day2;
                day2 = day_compare;
            }

            // to change m1's value and determine Gauss algorithm's variables
            y = year1 % 100;
            c = Math.Floor(year1 / 100);
            switch (month1)
            {
                case "MARCH": m1 = MARCH; break;
                case "APRIL": Console.WriteLine("\nSPRING"); m1 = APRIL; break;
                case "MAY": Console.WriteLine("\nSPRING"); m1 = MAY; break;
                case "JUNE": m1 = JUNE; break;
                case "JULY": Console.WriteLine("\nSUMMER"); m1 = JULY; break;
                case "AUGUST": Console.WriteLine("\nSUMMER"); m1 = AUGUST; break;
                case "SEPTEMBER": m1 = SEPTEMBER; break;
                case "OCTOBER": Console.WriteLine("\nAUTUMN"); m1 = OCTOBER; break;
                case "NOVEMBER": Console.WriteLine("\nAUTUMN"); m1 = NOVEMBER; break;
                case "DECEMBER": m1 = DECEMBER; break;
                case "JANUARY":
                    Console.WriteLine("\nWINTER");
                    m1 = JANUARY;
                    y = (year1 - 1) % 100;
                    c = Math.Floor((year1 - 1) / 100);
                    break;
                case "FEBRUARY":
                    Console.WriteLine("\nWINTER");
                    m1 = FEBRUARY;
                    y = (year1 - 1) % 100;
                    c = Math.Floor((year1 - 1) / 100);
                    break;
            }

            w = (day1 + Math.Floor((2.6 * m1 - 0.2)) + y + Math.Floor((y / 4)) + Math.Floor((c / 4)) - (2 * c)) % 7;
            if (w < 0)
                w = w + 7;
            // to print the dates
            do
            {
                switch (m1)
                {
                    case 1:

                        Console.WriteLine("\nSPRING");
                        while (31 - day1 >= 0)
                        {
                            // Gauss algorithm
                            w = (day1 + Math.Floor((2.6 * m1 - 0.2)) + y + Math.Floor((y / 4)) + Math.Floor((c / 4)) - (2 * c)) % 7;// for determine day of the year
                            if (w < 0)
                                w = w + 7;
                            switch (w)
                            {
                                case 0:
                                    w_day = "Sunday";
                                    break;
                                case 1:
                                    w_day = "Monday";
                                    break;
                                case 2:
                                    w_day = "Tuesday";
                                    break;
                                case 3:
                                    w_day = "Wedenesday";
                                    break;
                                case 4:
                                    w_day = "Thursday";
                                    break;
                                case 5:
                                    w_day = "Friday";
                                    break;
                                case 6:
                                    w_day = "Saturday";
                                    break;
                            }
                            Console.WriteLine(day1 + " " + month1 + " " + year1 + " " + w_day);
                            if (month1 == month2 && year1 == year2 && (day1 + n) >= day2)// to prevevent printing if reached the given date 
                            {
                                day1 += n;
                                if ((day1) == day2)
                                {
                                    Console.WriteLine((day1) + " " + month1 + " " + year1 + " " + w_day);// to print if the last date same with given date
                                    day1 += n;
                                    break;
                                }
                                day1 += n;
                                break;
                            }
                            day1 += n;
                        }
                        if (month1 != month2 || year1 != year2)// for changing months and determine new day of the new month
                        {
                            day1 = Math.Abs(31 - day1);
                            m1 = APRIL;
                            month1 = "APRIL";
                        }
                        break;
                    case 2:
                        while (30 - day1 >= 0)
                        {

                            w = (day1 + Math.Floor((2.6 * m1 - 0.2)) + y + Math.Floor((y / 4)) + Math.Floor((c / 4)) - (2 * c)) % 7;
                            if (w < 0)
                                w = w + 7;
                            switch (w)
                            {
                                case 0:
                                    w_day = "Sunday";
                                    break;
                                case 1:
                                    w_day = "Monday";
                                    break;
                                case 2:
                                    w_day = "Tuesday";
                                    break;
                                case 3:
                                    w_day = "Wedenesday";
                                    break;
                                case 4:
                                    w_day = "Thursday";
                                    break;
                                case 5:
                                    w_day = "Friday";
                                    break;
                                case 6:
                                    w_day = "Saturday";
                                    break;
                            }
                            Console.WriteLine(day1 + " " + month1 + " " + year1 + " " + w_day);
                            if (month1 == month2 && year1 == year2 && (day1 + n) >= day2)
                            {
                                day1 += n;
                                if ((day1) == day2)
                                {
                                    Console.WriteLine((day1) + " " + month1 + " " + year1 + " " + w_day);
                                    day1 += n;
                                    break;
                                }
                                day1 += n;
                                break;
                            }
                            day1 += n;

                        }
                        if (month1 != month2 || year1 != year2)
                        {
                            day1 = Math.Abs(30 - day1);
                            m1 = MAY;
                            month1 = "MAY";
                        }
                        break;
                    case 3:
                        while (31 - day1 >= 0)
                        {

                            w = (day1 + Math.Floor((2.6 * m1 - 0.2)) + y + Math.Floor((y / 4)) + Math.Floor((c / 4)) - (2 * c)) % 7;
                            if (w < 0)
                                w = w + 7;
                            switch (w)
                            {
                                case 0:
                                    w_day = "Sunday";
                                    break;
                                case 1:
                                    w_day = "Monday";
                                    break;
                                case 2:
                                    w_day = "Tuesday";
                                    break;
                                case 3:
                                    w_day = "Wedenesday";
                                    break;
                                case 4:
                                    w_day = "Thursday";
                                    break;
                                case 5:
                                    w_day = "Friday";
                                    break;
                                case 6:
                                    w_day = "Saturday";
                                    break;
                            }
                            Console.WriteLine(day1 + " " + month1 + " " + year1 + " " + w_day);
                            if (month1 == month2 && year1 == year2 && (day1 + n) >= day2)
                            {
                                day1 += n;
                                if ((day1) == day2)
                                {
                                    Console.WriteLine((day1) + " " + month1 + " " + year1 + " " + w_day);
                                    day1 += n;
                                    break;
                                }
                                day1 += n;
                                break;
                            }

                            day1 += n;
                        }
                        if (month1 != month2 || year1 != year2)
                        {
                            day1 = Math.Abs(31 - day1);
                            m1 = JUNE;
                            month1 = "JUNE";
                        }
                        break;
                    case 4:
                        Console.WriteLine("\nSUMMER");
                        while (30 - day1 >= 0)
                        {

                            w = (day1 + Math.Floor((2.6 * m1 - 0.2)) + y + Math.Floor((y / 4)) + Math.Floor((c / 4)) - (2 * c)) % 7;
                            if (w < 0)
                                w = w + 7;
                            switch (w)
                            {
                                case 0:
                                    w_day = "Sunday";
                                    break;
                                case 1:
                                    w_day = "Monday";
                                    break;
                                case 2:
                                    w_day = "Tuesday";
                                    break;
                                case 3:
                                    w_day = "Wedenesday";
                                    break;
                                case 4:
                                    w_day = "Thursday";
                                    break;
                                case 5:
                                    w_day = "Friday";
                                    break;
                                case 6:
                                    w_day = "Saturday";
                                    break;
                            }
                            Console.WriteLine(day1 + " " + month1 + " " + year1 + " " + w_day);
                            if (month1 == month2 && year1 == year2 && (day1 + n) >= day2)
                            {
                                day1 += n;
                                if ((day1) == day2)
                                {
                                    Console.WriteLine((day1) + " " + month1 + " " + year1 + " " + w_day);
                                    day1 += n;
                                    break;
                                }
                                day1 += n;
                                break;
                            }
                            day1 += n;

                        }
                        if (month1 != month2 || year1 != year2)
                        {
                            day1 = Math.Abs(30 - day1);
                            m1 = JULY;
                            month1 = "JULY";
                        }
                        break;
                    case 5:
                        while (31 - day1 >= 0)
                        {


                            w = (day1 + Math.Floor((2.6 * m1 - 0.2)) + y + Math.Floor((y / 4)) + Math.Floor((c / 4)) - (2 * c)) % 7;
                            if (w < 0)
                                w = w + 7;
                            switch (w)
                            {
                                case 0:
                                    w_day = "Sunday";
                                    break;
                                case 1:
                                    w_day = "Monday";
                                    break;
                                case 2:
                                    w_day = "Tuesday";
                                    break;
                                case 3:
                                    w_day = "Wedenesday";
                                    break;
                                case 4:
                                    w_day = "Thursday";
                                    break;
                                case 5:
                                    w_day = "Friday";
                                    break;
                                case 6:
                                    w_day = "Saturday";
                                    break;
                            }
                            Console.WriteLine(day1 + " " + month1 + " " + year1 + " " + w_day);
                            if (month1 == month2 && year1 == year2 && (day1 + n) >= day2)
                            {
                                day1 += n;
                                if ((day1) == day2)
                                {
                                    Console.WriteLine((day1) + " " + month1 + " " + year1 + " " + w_day);
                                    day1 += n;
                                    break;
                                }
                                day1 += n;
                                break;
                            }
                            day1 += n;


                        }
                        if (month1 != month2 || year1 != year2)
                        {
                            day1 = Math.Abs(31 - day1);
                            m1 = AUGUST;
                            month1 = "AUGUST";
                        }
                        break;
                    case 6:
                        while (31 - day1 >= 0)
                        {

                            w = (day1 + Math.Floor((2.6 * m1 - 0.2)) + y + Math.Floor((y / 4)) + Math.Floor((c / 4)) - (2 * c)) % 7;
                            if (w < 0)
                                w = w + 7;
                            switch (w)
                            {
                                case 0:
                                    w_day = "Sunday";
                                    break;
                                case 1:
                                    w_day = "Monday";
                                    break;
                                case 2:
                                    w_day = "Tuesday";
                                    break;
                                case 3:
                                    w_day = "Wedenesday";
                                    break;
                                case 4:
                                    w_day = "Thursday";
                                    break;
                                case 5:
                                    w_day = "Friday";
                                    break;
                                case 6:
                                    w_day = "Saturday";
                                    break;
                            }
                            Console.WriteLine(day1 + " " + month1 + " " + year1 + " " + w_day);
                            if (month1 == month2 && year1 == year2 && (day1 + n) >= day2)
                            {
                                day1 += n;
                                if ((day1) == day2)
                                {
                                    Console.WriteLine((day1) + " " + month1 + " " + year1 + " " + w_day);
                                    day1 += n;
                                    break;
                                }
                                day1 += n;
                                break;
                            }
                            day1 += n;

                        }
                        if (month1 != month2 || year1 != year2)
                        {
                            day1 = Math.Abs(31 - day1);
                            m1 = SEPTEMBER;
                            month1 = "SEPTEMBER";
                        }
                        break;
                    case 7:
                        Console.WriteLine("\nAUTUMN");
                        while (30 - day1 >= 0)
                        {

                            w = (day1 + Math.Floor((2.6 * m1 - 0.2)) + y + Math.Floor((y / 4)) + Math.Floor((c / 4)) - (2 * c)) % 7;
                            if (w < 0)
                                w = w + 7;
                            switch (w)
                            {
                                case 0:
                                    w_day = "Sunday";
                                    break;
                                case 1:
                                    w_day = "Monday";
                                    break;
                                case 2:
                                    w_day = "Tuesday";
                                    break;
                                case 3:
                                    w_day = "Wedenesday";
                                    break;
                                case 4:
                                    w_day = "Thursday";
                                    break;
                                case 5:
                                    w_day = "Friday";
                                    break;
                                case 6:
                                    w_day = "Saturday";
                                    break;
                            }
                            Console.WriteLine(day1 + " " + month1 + " " + year1 + " " + w_day);
                            if (month1 == month2 && year1 == year2 && (day1 + n) >= day2)
                            {
                                day1 += n;
                                if ((day1) == day2)
                                {
                                    Console.WriteLine((day1) + " " + month1 + " " + year1 + " " + w_day);
                                    day1 += n;
                                    break;
                                }
                                day1 += n;
                                break;
                            }
                            day1 += n;

                        }
                        if (month1 != month2 || year1 != year2)
                        {
                            day1 = Math.Abs(30 - day1);
                            m1 = OCTOBER;
                            month1 = "OCTOBER";
                        }
                        break;
                    case 8:
                        while (31 - day1 >= 0)
                        {

                            w = (day1 + Math.Floor((2.6 * m1 - 0.2)) + y + Math.Floor((y / 4)) + Math.Floor((c / 4)) - (2 * c)) % 7;
                            if (w < 0)
                                w = w + 7;
                            switch (w)
                            {
                                case 0:
                                    w_day = "Sunday";
                                    break;
                                case 1:
                                    w_day = "Monday";
                                    break;
                                case 2:
                                    w_day = "Tuesday";
                                    break;
                                case 3:
                                    w_day = "Wedenesday";
                                    break;
                                case 4:
                                    w_day = "Thursday";
                                    break;
                                case 5:
                                    w_day = "Friday";
                                    break;
                                case 6:
                                    w_day = "Saturday";
                                    break;
                            }
                            Console.WriteLine(day1 + " " + month1 + " " + year1 + " " + w_day);
                            if (month1 == month2 && year1 == year2 && (day1 + n) >= day2)
                            {
                                day1 += n;
                                if ((day1) == day2)
                                {
                                    Console.WriteLine((day1) + " " + month1 + " " + year1 + " " + w_day);
                                    day1 += n;
                                    break;
                                }
                                day1 += n;
                                break;
                            }

                            day1 += n;
                        }
                        if (month1 != month2 || year1 != year2)
                        {
                            day1 = Math.Abs(31 - day1);
                            m1 = NOVEMBER;
                            month1 = "NOVEMBER";
                        }
                        break;
                    case 9:
                        while (30 - day1 >= 0)
                        {

                            w = (day1 + Math.Floor((2.6 * m1 - 0.2)) + y + Math.Floor((y / 4)) + Math.Floor((c / 4)) - (2 * c)) % 7;
                            if (w < 0)
                                w = w + 7;
                            switch (w)
                            {
                                case 0:
                                    w_day = "Sunday";
                                    break;
                                case 1:
                                    w_day = "Monday";
                                    break;
                                case 2:
                                    w_day = "Tuesday";
                                    break;
                                case 3:
                                    w_day = "Wedenesday";
                                    break;
                                case 4:
                                    w_day = "Thursday";
                                    break;
                                case 5:
                                    w_day = "Friday";
                                    break;
                                case 6:
                                    w_day = "Saturday";
                                    break;
                            }
                            Console.WriteLine(day1 + " " + month1 + " " + year1 + " " + w_day);
                            if (month1 == month2 && year1 == year2 && (day1 + n) >= day2)
                            {
                                day1 += n;
                                if ((day1) == day2)
                                {
                                    Console.WriteLine((day1) + " " + month1 + " " + year1 + " " + w_day);
                                    day1 += n;
                                    break;
                                }
                                day1 += n;
                                break;
                            }
                            day1 += n;

                        }
                        if (month1 != month2 || year1 != year2)
                        {
                            day1 = Math.Abs(30 - day1);
                            m1 = DECEMBER;
                            month1 = "DECEMBER";
                        }
                        break;
                    case 10:
                        Console.WriteLine("\nWINTER");
                        while (31 - day1 >= 0)
                        {

                            w = (day1 + Math.Floor((2.6 * m1 - 0.2)) + y + Math.Floor((y / 4)) + Math.Floor((c / 4)) - (2 * c)) % 7;
                            if (w < 0)
                                w = w + 7;
                            switch (w)
                            {
                                case 0:
                                    w_day = "Sunday";
                                    break;
                                case 1:
                                    w_day = "Monday";
                                    break;
                                case 2:
                                    w_day = "Tuesday";
                                    break;
                                case 3:
                                    w_day = "Wedenesday";
                                    break;
                                case 4:
                                    w_day = "Thursday";
                                    break;
                                case 5:
                                    w_day = "Friday";
                                    break;
                                case 6:
                                    w_day = "Saturday";
                                    break;
                            }
                            Console.WriteLine(day1 + " " + month1 + " " + year1 + " " + w_day);
                            if (month1 == month2 && year1 == year2 && (day1 + n) >= day2)
                            {
                                day1 += n;
                                if ((day1) == day2)
                                {
                                    Console.WriteLine((day1) + " " + month1 + " " + year1 + " " + w_day);
                                    day1 += n;
                                    break;
                                }
                                day1 += n;
                                break;
                            }
                            day1 += n;

                        }
                        if (month1 != month2 || year1 != year2)
                        {
                            day1 = Math.Abs(31 - day1);
                            m1 = JANUARY;
                            month1 = "JANUARY";
                            year1 += 1;
                        }
                        break;
                    case 11:
                        // Changes the values of y and c according to Gauss algorithm
                        y = (year1 - 1) % 100;
                        c = Math.Floor((year1 - 1) / 100);
                        while (31 - day1 >= 0)
                        {

                            w = (day1 + Math.Floor((2.6 * m1 - 0.2)) + y + Math.Floor((y / 4)) + Math.Floor((c / 4)) - (2 * c)) % 7;
                            if (w < 0)
                                w = w + 7;
                            switch (w)
                            {
                                case 0:
                                    w_day = "Sunday";
                                    break;
                                case 1:
                                    w_day = "Monday";
                                    break;
                                case 2:
                                    w_day = "Tuesday";
                                    break;
                                case 3:
                                    w_day = "Wedenesday";
                                    break;
                                case 4:
                                    w_day = "Thursday";
                                    break;
                                case 5:
                                    w_day = "Friday";
                                    break;
                                case 6:
                                    w_day = "Saturday";
                                    break;
                            }
                            Console.WriteLine(day1 + " " + month1 + " " + year1 + " " + w_day);
                            if (month1 == month2 && year1 == year2 && (day1 + n) >= day2)
                            {
                                day1 += n;
                                if ((day1) == day2)
                                {
                                    Console.WriteLine((day1) + " " + month1 + " " + year1 + " " + w_day);
                                    day1 += n;
                                    break;
                                }
                                day1 += n;
                                break;
                            }
                            day1 += n;

                        }
                        if (month1 != month2 || year1 != year2)
                        {
                            day1 = Math.Abs(31 - day1);
                            m1 = FEBRUARY;
                            month1 = "FEBRUARY";
                        }
                        break;
                    case 12:
                        // Changes the values of y and c according to Gauss algorithm
                        y = (year1 - 1) % 100;
                        c = Math.Floor((year1 - 1) / 100);
                        if (year1 % 4 != 0)// to determine if february has 29 days 
                        {
                            while (28 - day1 >= 0)
                            {

                                w = (day1 + Math.Floor((2.6 * m1 - 0.2)) + y + Math.Floor((y / 4)) + Math.Floor((c / 4)) - (2 * c)) % 7;
                                if (w < 0)
                                    w = w + 7;
                                switch (w)
                                {
                                    case 0:
                                        w_day = "Sunday";
                                        break;
                                    case 1:
                                        w_day = "Monday";
                                        break;
                                    case 2:
                                        w_day = "Tuesday";
                                        break;
                                    case 3:
                                        w_day = "Wedenesday";
                                        break;
                                    case 4:
                                        w_day = "Thursday";
                                        break;
                                    case 5:
                                        w_day = "Friday";
                                        break;
                                    case 6:
                                        w_day = "Saturday";
                                        break;
                                }
                                Console.WriteLine(day1 + " " + month1 + " " + year1 + " " + w_day);
                                if (month1 == month2 && year1 == year2 && (day1 + n) >= day2)
                                {
                                    day1 += n;
                                    if ((day1) == day2)
                                    {
                                        Console.WriteLine((day1) + " " + month1 + " " + year1 + " " + w_day);
                                        day1 += n;
                                        break;
                                    }
                                    day1 += n;
                                    break;
                                }
                                day1 += n;

                            }

                            if (month1 != month2 || year1 != year2)
                            {
                                day1 = Math.Abs(28 - day1);
                                m1 = MARCH;
                                month1 = "MARCH";
                                y = (year1) % 100;
                                c = Math.Floor((year1) / 100);
                            }
                        }
                        else if (year1 % 4 == 0)// to determine if february has 29 days 
                        {
                            while (29 - day1 >= 0)
                            {

                                w = (day1 + Math.Floor((2.6 * m1 - 0.2)) + y + Math.Floor((y / 4)) + Math.Floor((c / 4)) - (2 * c)) % 7;
                                if (w < 0)
                                    w = w + 7;
                                switch (w)
                                {
                                    case 0:
                                        w_day = "Sunday";
                                        break;
                                    case 1:
                                        w_day = "Monday";
                                        break;
                                    case 2:
                                        w_day = "Tuesday";
                                        break;
                                    case 3:
                                        w_day = "Wedenesday";
                                        break;
                                    case 4:
                                        w_day = "Thursday";
                                        break;
                                    case 5:
                                        w_day = "Friday";
                                        break;
                                    case 6:
                                        w_day = "Saturday";
                                        break;
                                }
                                Console.WriteLine(day1 + " " + month1 + " " + year1 + " " + w_day);
                                if (month1 == month2 && year1 == year2 && (day1 + n) >= day2)
                                {
                                    day1 += n;
                                    if ((day1) == day2)
                                    {
                                        Console.WriteLine((day1) + " " + month1 + " " + year1 + " " + w_day);
                                        day1 += n;
                                        break;
                                    }
                                    day1 += n;
                                    break;
                                }
                                day1 += n;

                            }

                            if (month1 != month2 || year1 != year2)
                            {
                                day1 = Math.Abs(29 - day1);
                                m1 = MARCH;
                                month1 = "MARCH";
                                //to change values of y and c according to Gauss algorithm
                                y = (year1) % 100;
                                c = Math.Floor((year1) / 100);
                            }
                        }


                        break;

                }
                if (month1 == month2 && year1 == year2 && day1 >= day2)// for break the loop if reached the given date
                {
                    if (day1 == day2)
                    {
                        // to print the last season and day if the dae are identical
                        if (month1 == "MARCH")
                            Console.WriteLine("\nSPRING\n" + day1 + " " + month1 + " " + year1 + " " + w_day);// iki kere yazıyor
                        else if (month1 == "JUNE")
                            Console.WriteLine("\nSUMMER\n" + day1 + " " + month1 + " " + year1 + " " + w_day);
                        else if (month1 == "SEPTEMBER")
                            Console.WriteLine("\nAUTUMN\n" + day1 + " " + month1 + " " + year1 + " " + w_day);
                        else if (month1 == "DECEMBER")
                            Console.WriteLine("\nWINTER\n" + day1 + " " + month1 + " " + year1 + " " + w_day);
                        else
                            Console.WriteLine(day1 + " " + month1 + " " + year1 + " " + w_day);

                    }
                    break;
                }
            }

            while (day1 != day2 || month1 != month2 || year1 != year2);
            Console.ReadKey();
        }
    }
}
