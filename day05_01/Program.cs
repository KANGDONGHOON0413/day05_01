using System;
using System.Collections.Generic;

//c# ref, out study

namespace day05_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new calculator();

            int a = 3, b = 10;
            
            calc.Double(a,  ref b);

            Console.WriteLine("a= " + a + "\tb=" + b);
            //출력결과 a=3 b=20 -> a는 값을 복제해서 넘겨주기에 Double함수에서 변한값은 복사값이고 원값은 변하지 않았다
            // b는 레퍼런스(유사 포인터) 즉 주소를 보냄으로써 원값을 넘겨준것이다.



            //out
            //int sum;
            //double avg;
            if(calc.GetSumAndAvg(ref a, ref b, out int sum, out double avg) == true)        // out을 사용할때 '_'를 인자로 주면 사용 안할 수 있다. ex) out _
                //= if(calc.GetSumAndAvg(ref a, ref b, out var sum, out var avg) == true ) ->var를 사용하여 리턴타입을 추정하게 만들어줄 수 있다.
                Console.WriteLine("sum= " + sum + "\tavg= " + avg);


            //C# params: 가변 파라미터
            int s = calc.Sum();
            s = calc.Sum(1);
            s = calc.Sum(1,2);
            s = calc.Sum(1,2,3);
            s = calc.Sum(1,2,3,4);
            //결론 가변 파라미터는 파라미터의 개수를 능동적으로 조절할 수 있다.



            //Named parameter, optional parameter
            studentList st = new studentList();
            //var st = new studentList();
            st.Addstudent("kang", "010-0000-0000", 24); //(우리가 흔히 사용하는 파라미터로) 순서를 반드시 지켜야한다는 단점이 있다.
            st.Addstudent( phone:"010-0000-0000", age: 24, name:"kang"); //named parameter로 순서를 지키지 않아도 된다.
            st.Addstudent("kang", "010-0000-0000"); // optional parameter를 사용한 모습
        }
    }

    class calculator
    {
        public void Double(int a, ref int b) // <-ref를 써줘야한다.
        {
            a *= 2;
            b *= 2;           
        }

        public bool GetSumAndAvg(ref int a, ref int  b, out int sum, out double avg)
        {
            sum = a + b;
            avg = a + b / 2.0;
            return true;
        }

        public int Sum(params int[] values)
        {
            int sum = 0;
            foreach(var v in values)
            {
                sum += v;
            }
            return sum;
        }
    }

    class student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
    }

    class studentList
    {
        private List<student> students = new List<student>();

        public void Addstudent(string name, string phone, int age = 0)
            // optional parameter를 사용할땐 default값을 설정해두어서 입력값이 없으면 해당값으로 사용한다. 여기선 age가 default값 0을 지녔다
        {
            var s = new student();
            s.Name = name;
            s.Phone = phone;
            s.Age = age;
            students.Add(s);
        }
    }
}
