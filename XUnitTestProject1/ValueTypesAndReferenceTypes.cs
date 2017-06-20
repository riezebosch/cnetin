using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class ValueTypesAndReferenceTypes
    {
        [Fact]
        public void HoeWerktEenValueType()
        {
            int a = 3;
            int b = a;

            a = 5;
            Assert.Equal(3, b);
        }

        [Fact]
        public void WatIsDanEenReferenceType()
        {
            var a = new MyClass();
            a.Leeftijd = 5;

            var b = a;
            a.Leeftijd = 3;

            Assert.Equal(3, b.Leeftijd);
        }

        class MyClass
        {
            public int Leeftijd { get; set; }
        }

        [Fact]
        public void KanIkOokZelfEenValueTypeMaken()
        {
            var a = new MyStruct { Hoogte = 5 };
            var b = a;

            a.Hoogte = 3;
            Assert.Equal(5, b.Hoogte);
        }

        struct MyStruct
        {
            public int Hoogte;// { get; set; }
        }

        [Fact]
        public void WatKanIkNullMaken()
        {
            //int a = null;
            MyClass b = null;
        }

        [Fact]
        public void EenArrayIsZelfEenReferenceType()
        {
            int[] a = { 1, 2, 3, 4 };
            int[] b = a;

            b[0] = 100;

            Assert.Equal(100, a[0]);
        }

        [Fact]
        public void DefiniteAssignmentDemo()
        {
            int a = 0;
            Assert.Equal(0, a);

            int b;
            IntialiseerMijnVariableVoorMij(out b);
            Assert.Equal(10, b);
        }

        private void IntialiseerMijnVariableVoorMij(out int c)
        {
            c = 10;
        }

        [Fact]
        public void DefiniteAssignmentAutomatischDoorInitialisatie()
        {
            var a = new MyClass();
            Assert.Equal(0, a.Leeftijd);
        }

        [Fact]
        public void SignedBitje()
        {
            Console.WriteLine(sbyte.MaxValue);
            Console.WriteLine(sbyte.MinValue);
        }

        [Fact]
        public void CharDemo()
        {
            string input = "asdf";
            char c = 'c';

            char c2 = input[0];
            char c3 = (char)26;
        }

        [Fact]
        public void StringDemo()
        {
            string a = "asdf";
            string b = "asdf\t\r\n";
            string c = "asdf\\t"; // <-- escape van '\'
            string d = @"asdf\t";
            string e = ((char)26) + "sdfsdf";
            string f = $"{(char)26}sdfsdf";
            string g = "\u0026asdf";

            Assert.Equal("&asdf", g);
        }

        [Fact]
        public void KunnenStructsDanEchtNietNullZijn()
        {
            int? a = null;
            Assert.Null(a);

            var b = new Nullable<int>();
            Assert.False(b.HasValue);

            // Andere notatie van hetzelfde:
            Nullable<int> b2;
            Nullable<int> b3 = default(Nullable<int>);

            // Werkt ook op eigen structs
            MyStruct? m = null;

            var c = new Nullable<MyStruct>();
            Assert.False(b.HasValue);
        }

        [Fact]
        public void BitFlagDemo()
        {
            var p1 = Permissions.Read;
            var p2 = Permissions.Write;

            var p3 = Permissions.Read | Permissions.Write;

            bool b = (p3 & Permissions.Write) == Permissions.Write;
            Assert.True(b);
        }

        [Flags]
        enum Permissions
        {
            None = 1,
            Read = 2,
            Write = 4,
            Delete = 8,
            Execute = 16,
            All = 31
        }

        [Fact]
        public void InitialisatieVanEenStruct()
        {
            var s1 = new MyStruct();
            Assert.Equal(0, s1.Hoogte);

            MyStruct s2;
            s2.Hoogte = 0;
            Assert.Equal(0, s2.Hoogte);
        }
    }
}
